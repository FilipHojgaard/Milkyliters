using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Milkyliters.Services;

namespace Milkyliters.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial int AddMl { get; set; }

    [ObservableProperty]
    public partial int MlToday { get; set; }

    [ObservableProperty]
    public partial int MlLast24Hours { get; set; }

    [ObservableProperty]
    public partial int? DaysSinceLastPoo { get; set; }

    IFeedingService _feedingService;
    IPooService _pooService;

    public MainViewModel(IFeedingService feedingService, IPooService pooService)
    {
        _feedingService = feedingService;
        _pooService = pooService;
    }

    public async Task InitializeAsync()
    {
        MlToday = await _feedingService.GetTotalMlSinceMidnightAsync();
        MlLast24Hours = await _feedingService.GetLast24HourMlAsync();
        DaysSinceLastPoo = await _pooService.GetDaysSinceLastPooAsync();
    }

    [RelayCommand]
    private async Task AddFeeding()
    {
        await _feedingService.AddFeedingAsync(AddMl);
        HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        await InitializeAsync();
    }

    [RelayCommand]
    private async Task AddPoo()
    {
        await _pooService.AddPoo();
        HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
        await InitializeAsync();
    }
}
