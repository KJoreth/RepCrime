namespace EnforcerAPI.Services.Interfaces
{
    public interface IEnforcersService
    {
        Task<List<EnforcerSimpleDTO>> GetAllAsync();
        Task<EnforcerDetailedDTO> GetSingleAsync(string id);
    }
}