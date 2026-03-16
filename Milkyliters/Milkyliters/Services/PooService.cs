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
            Timestamp = DateTime.Now
        };
        await _dbService.Connection.InsertAsync(poo);
    }

    public async Task<TimeSpan> LastPooSince()
    {
        var lastPoo = await _dbService.Connection
            .Table<Poo>()
            .OrderByDescending(x => x.Timestamp)
            .FirstOrDefaultAsync();
        var now = DateTime.Now;
        var timeElapsed = now - lastPoo.Timestamp;
        return timeElapsed;
    }
}
