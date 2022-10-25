namespace CrimeAPI.Data.MongoDb.Interfaces
{
    public interface IMongoService
    {
        Task CreateAsync(Crime crime);
        Task<List<Crime>> GetAllAsync();
        double GetCount();
        Task<List<Crime>> GetPageAsync(int page, int max);
        Task<Crime> GetSingleAsync(string id);
        Task UpdateAsync(string id, Crime crime);
    }
}