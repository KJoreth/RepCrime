
namespace StatsAPI.Services
{
    public class StatsService : IStatsService
    {
        private readonly IMongoService _mongoService;
        private readonly IMapper _mapper;
        public StatsService(IMongoService mongoService, IMapper mapper)
        {
            _mapper = mapper;
            _mongoService = mongoService;
        }

        public async Task RiseCrimeCounterAsync()
        {
            var stats = _mongoService.GetSingleByDate(DateTime.Now);
            if (stats != null)
            {
                stats.CrimesReported++;
                await _mongoService.UpdateAsync(stats.Id, stats);
            }
            else
                await _mongoService.CreateNewAsync(new Stats { date = DateTime.Now, CrimesReported = 1, EnforcesAssigned = 0 });
        }

        public async Task RiseEnforcerCounterAsync()
        {
            var stats = _mongoService.GetSingleByDate(DateTime.Now);
            if (stats != null)
            {
                stats.EnforcesAssigned++;
                await _mongoService.UpdateAsync(stats.Id, stats);
            }
            else
                await _mongoService.CreateNewAsync(new Stats { date = DateTime.Now, CrimesReported = 0, EnforcesAssigned = 1 });
        }

        public async Task<StatsDTO> GetTodayStatsAsync()
        {
            var stats = _mongoService.GetSingleByDate(DateTime.Now);
            if (stats == null)
            {
                stats = new Stats { date = DateTime.Now, CrimesReported = 0, EnforcesAssigned = 0 };
                await _mongoService.CreateNewAsync(stats);
            }
            return _mapper.Map<StatsDTO>(stats);
        }
    }
}
