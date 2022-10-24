namespace EnforcerAPI.Data.Repositories.Interfaces
{
    public interface ICrimeRepository
    {
        Task<bool> AnyById(string crimeId);
        Task CreateAsync(Crime crime);
        Task<Crime> GetSingleAsync(string crimeId);
        Task SaveAsync();
    }
}