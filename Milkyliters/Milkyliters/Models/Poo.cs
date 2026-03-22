using SQLite;

namespace Milkyliters.Models;

public class Poo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }
}
