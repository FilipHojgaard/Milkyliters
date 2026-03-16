using Milkyliters.Models;
using SQLite;

namespace Milkyliters.Data;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "milkyliters.db");
        _db = new SQLiteAsyncConnection(dbPath);
    }

    public async Task InitializeAsync()
    {
        await _db.CreateTableAsync<Feeding>();
        await _db.CreateTableAsync<Poo>();
    }

    public SQLiteAsyncConnection Connection => _db;
}
