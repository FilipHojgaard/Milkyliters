using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Milkyliters.Models;
using Milkyliters.Services;

namespace Milkyliters.ViewModels;

public partial class FeedingHistoryViewModel : ObservableObject
{
    private readonly IFeedingService _feedingService;

    public ObservableCollection<FeedingGroup> FeedingGroups { get; set; }

    public FeedingHistoryViewModel(IFeedingService feedingService)
    {
        _feedingService = feedingService;

        FeedingGroups = new ObservableCollection<FeedingGroup>();
    }

    public async Task LoadRecentFeedingsAsync()
    {
        var feedings = await _feedingService.GetRecentFeedingsAsync();
        var feedingGroups = feedings
            .GroupBy(f => f.Timestamp.ToLocalTime().Date)
            .Select(g => new FeedingGroup(g.Key, g.ToList()))
            .OrderByDescending(g => g.Date);

        FeedingGroups.Clear();
        
        foreach (var feedingGroup in feedingGroups)
        {
            FeedingGroups.Add(feedingGroup);
        }
    }
}
