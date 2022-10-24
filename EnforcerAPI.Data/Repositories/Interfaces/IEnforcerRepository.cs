namespace EnforcerAPI.Data.Repositories.Interfaces
{
    public interface IEnforcerRepository
    {
        Task AssingAsync(string enforcerId, Crime crime);
        Task<List<Enforcer>> GetAllAsync();
        Task<Enforcer> GetSingleAsync(string id);
        Task SaveAsync();
    }
}