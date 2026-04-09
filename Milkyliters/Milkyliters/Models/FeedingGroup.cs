namespace Milkyliters.Models;

public class FeedingGroup : List<Feeding>
{
    public DateTime Date { get; set; }

    public int TotalMl { get; set; }

    public int TotalBottles { get; set; } 

    public string LocalDay => StringHelpers.PresentDates(Date);

    public int AvgMl { get; set; }

    public FeedingGroup(DateTime today, List<Feeding> feedings)
    {
        Date = today;
        TotalMl = feedings.Sum(x => x.Ml);
        TotalBottles = feedings.Count;
        AvgMl = TotalBottles > 0 ? TotalMl / TotalBottles : 0;
        AddRange(feedings);
    }
}
