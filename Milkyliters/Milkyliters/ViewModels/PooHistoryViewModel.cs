using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Milkyliters.Models;
using Milkyliters.Services;

namespace Milkyliters.ViewModels;

public class PooHistoryViewModel : ObservableObject
{
    private readonly IPooService _pooService;

    public ObservableCollection<PooGroup> PooGroups { get; set; }

    public PooHistoryViewModel(IPooService pooService)
    {
        _pooService = pooService;

        PooGroups = new ObservableCollection<PooGroup>();
    }

    public async Task LoadRecentPoosAsync()
    {
        var poos = await _pooService.GetRecentPooGroupsAsync();
        var pooGroups = poos
            .GroupBy(f => f.Timestamp.ToLocalTime().Date)
            .Select(g => new PooGroup(g.Key, g.ToList()))
            .OrderByDescending(g => g.Date);

        PooGroups.Clear();

        foreach (var pooGroup in pooGroups)
        {
            PooGroups.Add(pooGroup);
        }
    }
}
