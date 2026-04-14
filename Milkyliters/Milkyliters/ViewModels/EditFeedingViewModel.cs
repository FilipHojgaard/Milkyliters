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
    public partial string? AddMlErrorMessage { get; set; }

    public EditFeedingViewModel(IFeedingService feedingService)
    {
        _feedingService = feedingService;
    }

    [RelayCommand]
    public async Task UpdateFeedingAsync()
    {
        if (UpdateMl <= 0)
        {
            AddMlErrorMessage = "Ml skal være over 0";
            return;
        }
        await _feedingService.UpdateFeedingAsync(FeedingId, UpdateMl, UpdateTimestamp, UpdateMilkType);
    }

}
