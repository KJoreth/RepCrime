namespace CrimeAPI.Services.Interfaces
{
    public interface ICrimesService
    {
        Task<CrimeDetailedDTO> CreateAsync(CrimeCreateDTO model);
        Task<List<CrimeSimpleDTO>> GetAllAsync();
        Task<CrimeDetailedDTO> GetSingleAsync(string id);
    }
}