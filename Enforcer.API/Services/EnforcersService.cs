namespace EnforcerAPI.Services
{
    public class EnforcersService : IEnforcersService
    {
        private readonly ICrimeRepository _crimeRepository;
        private readonly IEnforcerRepository _enforcerRepository;
        private readonly IMapper _mapper;

        public EnforcersService(ICrimeRepository crimeRepository, IEnforcerRepository enforcerRepository, IMapper mapper)
        {
            _crimeRepository = crimeRepository;
            _enforcerRepository = enforcerRepository;
            _mapper = mapper;
        }

        public async Task<List<EnforcerSimpleDTO>> GetAllAsync()
        {
            var enforcers = await _enforcerRepository.GetAllAsync();
            return _mapper.Map<List<EnforcerSimpleDTO>>(enforcers);
        }

        public async Task<EnforcerDetailedDTO> GetSingleAsync(string id)
        {
            var enforcer = await _enforcerRepository.GetSingleAsync(id.ToUpper());
            return _mapper.Map<EnforcerDetailedDTO>(enforcer);
        }


    }
}
