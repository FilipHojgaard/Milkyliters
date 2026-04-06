using Milkyliters.Models;

namespace Milkyliters.Services;

public interface IFeedingService
{
    Task<int> GetLast24HourMlAsync();

    Task<int> GetTotalMlSinceMidnightAsync();

    Task AddFeedingAsync(int ml, DateTime? timestamp = null);
    
    Task<List<Feeding>> GetRecentFeedingsAsync();

    Task DeleteFeedingAsync(int feedingId);
}
