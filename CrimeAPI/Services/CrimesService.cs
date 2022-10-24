﻿

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
            crime.Status = CrimeStatus.Waiting;
            await _mongoDb.CreateAsync(crime);
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
            var crime = await _mongoDb.GetSingleAsync(crimeId);
            crime.EnforcerId = request.EnforcerId;
            await _mongoDb.UpdateAsync(crimeId, crime);
        }

            
    }
}
