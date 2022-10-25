namespace StatsAPI.Services.Interfaces
{
    public interface IStatsService
    {
        Task<StatsDTO> GetTodayStatsAsync();
        Task RiseCrimeCounterAsync();
        Task RiseEnforcerCounterAsync();
    }
}