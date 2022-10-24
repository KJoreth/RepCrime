namespace EnforcerAPI.Services.Interfaces
{
    public interface IEnforcersService
    {
        Task AssingEnforcerAsync(string crimeId, string enforcerId);
        Task<List<EnforcerSimpleDTO>> GetAllAsync();
        Task<EnforcerDetailedDTO> GetSingleAsync(string id);
    }
}