using Milkyliters.Models;

namespace Milkyliters.Services;

public interface IPooService
{
    Task AddPoo();

    Task<int?> GetDaysSinceLastPooAsync();

    Task<List<Poo>> GetRecentPooGroupsAsync();
}
