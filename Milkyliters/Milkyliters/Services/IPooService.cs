namespace Milkyliters.Services;

public interface IPooService
{
    Task AddPoo();

    Task<int?> GetDaysSinceLastPooAsync();
}
