
namespace CrimeAPI.Services
{
    public class CrimesService : ICrimesService
    {
        private readonly IMongoService _mongoDb;
        private readonly IMapper _mapper;
        public CrimesService(IMongoService mongoDb, IMapper mapper)
        {
            _mongoDb = mongoDb;
            _mapper = mapper;
        }
        public async Task<CrimeDetailedDTO> CreateAsync(CrimeCreateDTO model)
        {
            Crime crime = _mapper.Map<Crime>(model);
            crime.Status = Data.Enums.CrimeStatus.Waiting;
            await _mongoDb.CreateAsync(crime);
            return _mapper.Map<CrimeDetailedDTO>(crime);
        }
    }
}
