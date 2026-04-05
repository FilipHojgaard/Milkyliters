using Milkyliters.Data;
using Milkyliters.Models;

namespace Milkyliters.Services;

public class PooService : IPooService
{

    private readonly DatabaseService _dbService;

    public PooService(DatabaseService dbService)
    {
        _dbService = dbService;
    }

    public async Task AddPoo()
    {
        var poo = new Poo
        {
            Timestamp = DateTime.UtcNow
        };
        await _dbService.Connection.InsertAsync(poo);
    }

    public async Task<int?> GetDaysSinceLastPooAsync()
    {
        var lastPoo = await _dbService.Connection
            .Table<Poo>()
            .OrderByDescending(x => x.Timestamp)
            .FirstOrDefaultAsync();
        if (lastPoo == null)
        {
            return null;
        }
        var now = DateTime.Now.ToUniversalTime();
        var storedTime = DateTime.SpecifyKind(lastPoo.Timestamp, DateTimeKind.Utc);
        var timeElapsed = now - storedTime;
        return (int)timeElapsed.TotalDays;
    }

    public async Task<List<Poo>> GetRecentPooGroupsAsync()
    {
        var cutoffDate = DateTime.Now.AddDays(-7).ToUniversalTime();
        var poos = await _dbService.Connection
            .Table<Poo>()
            .Where(x => x.Timestamp >= cutoffDate)
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync();
        return poos;
    }
}
