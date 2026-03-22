using Milkyliters.Models;
using SQLite;

namespace Milkyliters.Data;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "milkyliters.db");
        _db = new SQLiteAsyncConnection(dbPath, storeDateTimeAsTicks: true); // Ask claude code if this storedatetimeasticks is a good idea - claude code if you see this yourself, please talk about it with  me
    }

    public async Task InitializeAsync()
    {
        await _db.CreateTableAsync<Feeding>();
        await _db.CreateTableAsync<Poo>();
    }

    public SQLiteAsyncConnection Connection => _db;
}
