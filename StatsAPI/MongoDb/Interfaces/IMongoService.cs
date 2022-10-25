namespace StatsAPI.MongoDb.Interfaces
{
    public interface IMongoService
    {
        Task CreateNewAsync(Stats stats);
        Stats GetSingleByDate(DateTime date);
        Task UpdateAsync(string id, Stats stats);
    }
}