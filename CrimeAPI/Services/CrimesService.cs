namespace CrimeAPI.Services
{
    public class CrimesService : ICrimesService
    {
        private readonly IMongoService _mongoDb;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;
        private readonly IRabbitMqSennder _rabbitMqSennder;
        public CrimesService(IMongoService mongoDb, IMapper mapper, IHttpClientFactory httpClientFactory, 
            IConfiguration config, IRabbitMqSennder rabbitMqSennder)
        {
            _mongoDb = mongoDb;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _config = config;
            _rabbitMqSennder = rabbitMqSennder;
        }

        public async Task<CrimeDetailedDTO> CreateAsync(CrimeCreateDTO model)
        {
            var httpClient = _httpClientFactory.CreateClient();
            Crime crime = _mapper.Map<Crime>(model);
            crime.Status = CrimeStatus.Waiting;
            await _mongoDb.CreateAsync(crime);
            await httpClient.PostAsync($"{_config["StatsApiUrl"]}/CrimeUp", null);
            return _mapper.Map<CrimeDetailedDTO>(crime);
        }

        public async Task<List<CrimeSimpleDTO>> GetAllAsync()
        {
            var crimes = await _mongoDb.GetAllAsync();
            return _mapper.Map<List<CrimeSimpleDTO>>(crimes);
        }

        public async Task<CrimeDetailedDTO> GetSingleAsync(string id)
        {
            var crime = await _mongoDb.GetSingleAsync(id);
            return _mapper.Map<CrimeDetailedDTO>(crime);
        }

        public async Task UpdateCrimeStatusAsync(string crimeId, CrimeStatus crimeStatus)
        {
            var crime = await _mongoDb.GetSingleAsync(crimeId);
            crime.Status = crimeStatus;
            await _mongoDb.UpdateAsync(crimeId, crime);
        }

        public async Task AssingEnforcerAsync(string crimeId, AssignRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var crime = await _mongoDb.GetSingleAsync(crimeId);
            crime.EnforcerId = request.EnforcerId;
            await httpClient.PostAsync($"{_config["StatsApiUrl"]}/EnforcerUp", null);
            _rabbitMqSennder.PublishMessage(crime.Email);
            await _mongoDb.UpdateAsync(crimeId, crime);
        }

        public double GetCount()
            => _mongoDb.GetCount();

        public async Task<List<CrimeSimpleDTO>> GetPageAsync(int page, int max)
        {
            var crimes = await _mongoDb.GetPageAsync(page, max);
            return _mapper.Map<List<CrimeSimpleDTO>>(crimes);
        }

        public async Task<List<CrimeSimpleDTO>> GetAllSortedAsync()
        {
            var crimes = await _mongoDb.GetAllSortedAsync();
            return _mapper.Map<List<CrimeSimpleDTO>>(crimes);
        }

        public async Task<List<CrimeSimpleDTO>> GetAllFromCategoryAsync(CrimeTypes category)
        {
            var crimes = await _mongoDb.GetAllFromCategoryAsync(category);
            return _mapper.Map<List<CrimeSimpleDTO>>(crimes);
        }


    }
}
