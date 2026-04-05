namespace Milkyliters.Models;

public class PooGroup : List<Poo>
{
    public DateTime Date { get; set; }

    public int TotalPoo { get; set; }

    public string LocalDate => Date.ToString("dd-MM-yyyy");

    public PooGroup(DateTime date, List<Poo> poos)
    {
        Date = date;
        TotalPoo = poos.Count;
        AddRange(poos);
    }
}
