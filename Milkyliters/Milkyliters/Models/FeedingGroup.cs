namespace Milkyliters.Models;

public class FeedingGroup : List<Feeding>
{
    public DateTime Date { get; set; }

    public int TotalMl { get; set; }

    public int TotalBottles { get; set; } 

    public string LocalDay => StringHelpers.PresentDates(Date);

    public FeedingGroup(DateTime today, List<Feeding> feedings)
    {
        Date = today;
        TotalMl = feedings.Sum(x => x.Ml);
        TotalBottles = feedings.Count;
        AddRange(feedings);
    }
}
