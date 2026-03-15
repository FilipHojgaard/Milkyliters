namespace Milkyliters.Services;

public interface IFeedingService
{
    Task<int> GetLast24HourMl();
    Task<int> GetTotalMlSinceMidnight();
    Task AddFeeding(int ml, DateTime? timestamp = null);
}
