namespace EnforcerAPI.Services.Interfaces
{
    public interface IEnforcersService
    {
        Task<List<EnforcerSimpleDTO>> GetAllAsync();
    }
}