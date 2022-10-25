namespace CrimeAPI.Services.Interfaces
{
    public interface ICrimesService
    {
        Task AssingEnforcerAsync(string crimeId, AssignRequest request);
        Task<CrimeDetailedDTO> CreateAsync(CrimeCreateDTO model);
        Task<List<CrimeSimpleDTO>> GetAllAsync();
        double GetCount();
        Task<List<CrimeSimpleDTO>> GetPageAsync(int page, int max);
        Task<CrimeDetailedDTO> GetSingleAsync(string id);
        Task UpdateCrimeStatusAsync(string crimeId, CrimeStatus crimeStatus);
    }
}