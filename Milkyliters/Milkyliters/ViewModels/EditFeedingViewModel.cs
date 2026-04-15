using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Milkyliters.Models;
using Milkyliters.Services;

namespace Milkyliters.ViewModels;

[QueryProperty(nameof(FeedingId), "feedingId")]
public partial class EditFeedingViewModel : ObservableObject
{
    private readonly IFeedingService _feedingService;

    [ObservableProperty]
    public partial int FeedingId { get; set; }

    [ObservableProperty]
    public partial int UpdateMl { get; set; }

    [ObservableProperty]
    public partial DateTime UpdateTimestamp { get; set; }

    [ObservableProperty]
    public partial MilktypeEnum UpdateMilkType{ get; set; }

    [ObservableProperty]
    public partial string? EditMlErrorMessage { get; set; }

    public EditFeedingViewModel(IFeedingService feedingService)
    {
        _feedingService = feedingService;
    }

    [RelayCommand]
    public async Task UpdateFeedingAsync()
    {
        if (UpdateMl <= 0)
        {
            EditMlErrorMessage = "Ml skal være over 0";
            return;
        }
        await _feedingService.UpdateFeedingAsync(FeedingId, UpdateMl, UpdateTimestamp, UpdateMilkType);

        await Shell.Current.GoToAsync("..");
    }

    async partial void OnFeedingIdChanged(int value)
    {
        var feeding = await _feedingService.GetFeedingByIdAsync(value);
        if (feeding != null)
        {
            UpdateMl = feeding.Ml;
            UpdateTimestamp = feeding.Timestamp;
            UpdateMilkType = feeding.Milktype;
        }
    }

}
