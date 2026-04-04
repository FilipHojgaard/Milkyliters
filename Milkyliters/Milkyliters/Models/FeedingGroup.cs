namespace Milkyliters.Models;

public class FeedingGroup : List<Feeding>
{
    public DateTime Date { get; set; }

    public int TotalMl { get; set; }

    public string LocalDay => Date.ToString("dd-MM-yyyy");

    public FeedingGroup(DateTime today, List<Feeding> feedings)
    {
        Date = today;
        TotalMl = feedings.Sum(x => x.Ml);
        AddRange(feedings);
    }
}
