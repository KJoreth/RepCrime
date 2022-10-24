namespace EnforcerAPI.Data.Repositories.Interfaces
{
    public interface ICrimeRepository
    {
        Task<bool> AnyById(string crimeId);
        Task CreateAsync(string crimeId);
    }
}