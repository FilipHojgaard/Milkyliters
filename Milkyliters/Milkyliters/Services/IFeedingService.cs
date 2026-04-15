using Milkyliters.Models;

namespace Milkyliters.Services;

public interface IFeedingService
{
    Task<int> GetLast24HourMlAsync();

    Task<int> GetTotalMlSinceMidnightAsync();

    Task AddFeedingAsync(int ml, DateTime? timestamp = null);

    Task UpdateFeedingAsync(int feedingId, int ml, DateTime timestamp, MilktypeEnum milktype);

    Task<Feeding?> GetFeedingByIdAsync(int feedingId);

    Task<List<Feeding>> GetAllFeedingsAsync();

    Task DeleteFeedingAsync(int feedingId);
}
