namespace CrimeAPI.Data.MongoDb.Service
{
    public class MongoService : IMongoService
    {
        private readonly IMongoCollection<Crime> _crimesCollection;
        public MongoService(IOptions<DbSettings> options)
        {
            var mongoClient = new MongoClient(
            options.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                options.Value.DatabaseName);

            _crimesCollection = mongoDatabase.GetCollection<Crime>(
                options.Value.CollectionName);
        }

        public async Task<List<Crime>> GetAllAsync()
            => await _crimesCollection.Find(_ => true).ToListAsync();

        public async Task<Crime> GetSingleAsync(string id)
        {
            var result = await _crimesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new ResourceNotFoundException($"Crime with Id {id} does not exists");
            return result;
        }

        public async Task CreateAsync(Crime crime)
            => await _crimesCollection.InsertOneAsync(crime);

        public async Task UpdateAsync(string id, Crime crime)
        {
            var result = await _crimesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null)
                throw new ResourceNotFoundException($"Crime with Id {id} does not exists");
            await _crimesCollection.ReplaceOneAsync(x => x.Id == id, crime);
        }

        public async Task<List<Crime>> GetPageAsync(int page, int max)
        {
            var result = await _crimesCollection
                .Find(_ => true)
                .Skip(max * (page - 1))
                .Limit(max)
                .ToListAsync();
            return result;
        }

        public double GetCount()
            => (int)_crimesCollection.CountDocuments(_ => true);

        public async Task<List<Crime>> GetAllSortedAsync()
            => await _crimesCollection.Find(_ => true).SortByDescending(x => x.DateOfEvent).ToListAsync();

        public async Task<List<Crime>> GetAllFromCategoryAsync(CrimeTypes category)
            => await _crimesCollection.Find(x => x.CrimeType == category).ToListAsync();
    }
}
