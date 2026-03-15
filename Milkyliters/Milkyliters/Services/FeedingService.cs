using Milkyliters.Data;
using Milkyliters.Models;

namespace Milkyliters.Services;

public class FeedingService : IFeedingService
{
    private readonly DatabaseService _dbService;

    public FeedingService(DatabaseService dbService)
    {
        _dbService = dbService;
    }

    public async Task<int> GetLast24HourMl()
    {
        var midnight = DateTime.Now.AddHours(-24);
        var feedings = await _dbService.Connection
            .Table<Feeding>()
            .Where(x => x.Timestamp >= midnight)
            .ToListAsync();
        var totalMl = feedings.Sum(x => x.Ml);
        return totalMl;
    }

    public async Task<int> GetTotalMlSinceMidnight()
    {
        var midnight = DateTime.Today;
        var todaysFeedings = await _dbService.Connection
            .Table<Feeding>()
            .Where(x => x.Timestamp >= midnight)
            .ToListAsync();
        var totalMl = todaysFeedings.Sum(x => x.Ml);
        return totalMl;
    }

    public async Task AddFeeding(int ml, DateTime? timestamp = null)
    {
        var feeding = new Feeding
        {
            Ml = ml,
            Timestamp = timestamp ?? DateTime.Now
        };
        await _dbService.Connection.InsertAsync(feeding);
    }
}
