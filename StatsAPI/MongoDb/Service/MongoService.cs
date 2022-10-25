namespace StatsAPI.MongoDb.Service
{
    public class MongoService : IMongoService
    {
        private readonly IMongoCollection<Stats> _crimesCollection;
        public MongoService(IOptions<DbSettings> options)
        {
            var mongoClient = new MongoClient(
            options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _crimesCollection = mongoDatabase.GetCollection<Stats>(
                options.Value.CollectionName);
        }

        public async Task CreateNewAsync(Stats stats)
            => await _crimesCollection.InsertOneAsync(stats);

        public async Task UpdateAsync(string id, Stats stats)
        {
            var result = await _crimesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new ResourceNotFoundException($"Stats with Id {id} does not exists");
            await _crimesCollection.ReplaceOneAsync(x => x.Id == id, stats);
        }

        public Stats GetSingleByDate(DateTime date)
        {
            var stats = _crimesCollection
                .Find(_ => true)
                .ToList()
                .Where(x => x.date.Date == date.Date)
                .FirstOrDefault();
            return stats;
        }
    }
}
