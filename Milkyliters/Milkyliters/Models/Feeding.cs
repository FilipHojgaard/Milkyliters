using SQLite;

namespace Milkyliters.Models;

[Table("Feedings")]
public class Feeding
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Ml { get; set; }

    public DateTime Timestamp { get; set; }

    public MilktypeEnum Milkype { get; set; } = MilktypeEnum.Semper;
}
