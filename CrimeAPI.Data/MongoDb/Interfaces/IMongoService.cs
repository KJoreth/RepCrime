namespace CrimeAPI.Data.MongoDb.Interfaces
{
    public interface IMongoService
    {
        Task CreateAsync(Crime crime);
        Task<List<Crime>> GetAllAsync();
        Task<Crime> GetSingleAsync(string id);
        Task UpdateAsync(string id, Crime crime);
    }
}