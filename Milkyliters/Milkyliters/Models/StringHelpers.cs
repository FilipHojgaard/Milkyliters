namespace Milkyliters.Models;

public static class StringHelpers
{
    public static string PresentDates(DateTime date)
    {
            var today = DateTime.Today;
            var yesterday = today.AddDays(-1);
            if (date.Date == today)
            {
                return "I dag";
            }
            else if (date.Date == yesterday)
            {
                return "I går";
            }
            else
            {
                return date.ToString("dd-MM-yyyy");
        }
    }
}
