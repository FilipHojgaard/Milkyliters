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
        var midnight = DateTime.Now.Date.ToUniversalTime(); // Get local midnight and convert to utc. 
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

    public async Task UpdateFeedingAsync(int feedingId, int ml, DateTime timestamp, MilktypeEnum milktype)
    {
        var feeding = await _dbService.Connection.FindAsync<Feeding>(feedingId);
        if (feeding != null)
        {
            feeding.Ml = ml;
            feeding.Timestamp = timestamp;
            feeding.Milktype = milktype;
            await _dbService.Connection.UpdateAsync(feeding);
        }
    }

    public async Task<List<Feeding>> GetAllFeedingsAsync()
    {
        var feedings = await _dbService.Connection
            .Table<Feeding>()
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync();
        return feedings;
    }

    public async Task DeleteFeedingAsync(int feedingId)
    {
        await _dbService.Connection.DeleteAsync<Feeding>(feedingId);
    }

    public async Task<Feeding?> GetFeedingByIdAsync(int feedingId)
    {
        var feeding = await _dbService.Connection.FindAsync<Feeding>(feedingId);
        return feeding;
    }
}
