namespace CrimeAPI.Services.Interfaces
{
    public interface ICrimesService
    {
        Task AssingEnforcerAsync(string crimeId, AssignRequest request);
        Task<CrimeDetailedDTO> CreateAsync(CrimeCreateDTO model);
        Task<List<CrimeSimpleDTO>> GetAllAsync();
        Task<CrimeDetailedDTO> GetSingleAsync(string id);
        Task UpdateCrimeStatusAsync(string crimeId, CrimeStatus crimeStatus);
    }
}