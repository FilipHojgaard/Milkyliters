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

    public async Task<int> GetLast24HourMlAsync()
    {
        var midnight = DateTime.UtcNow.AddHours(-24);
        var feedings = await _dbService.Connection
            .Table<Feeding>()
            .Where(x => x.Timestamp >= midnight)
            .ToListAsync();
        var totalMl = feedings.Sum(x => x.Ml);
        return totalMl;
    }

    public async Task<int> GetTotalMlSinceMidnightAsync()
    {
        var midnight = DateTime.UtcNow.Date;
        var todaysFeedings = await _dbService.Connection
            .Table<Feeding>()
            .Where(x => x.Timestamp >= midnight)
            .ToListAsync();
        var totalMl = todaysFeedings.Sum(x => x.Ml);
        return totalMl;
    }

    public async Task AddFeedingAsync(int ml, DateTime? timestamp = null)
    {
        var feeding = new Feeding
        {
            Ml = ml,
            Timestamp = timestamp ?? DateTime.UtcNow
        };
        await _dbService.Connection.InsertAsync(feeding);
    }
}
