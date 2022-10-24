namespace CrimeAPI.Services.Interfaces
{
    public interface ICrimesService
    {
        Task<CrimeDetailedDTO> CreateAsync(CrimeCreateDTO model);
    }
}