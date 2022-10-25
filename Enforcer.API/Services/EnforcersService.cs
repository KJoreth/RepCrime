using RepCrime.Common.Exeptions;

namespace EnforcerAPI.Services
{
    public class EnforcersService : IEnforcersService
    {
        private readonly ICrimeRepository _crimeRepository;
        private readonly IEnforcerRepository _enforcerRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public EnforcersService(ICrimeRepository crimeRepository, IEnforcerRepository enforcerRepository, 
            IMapper mapper, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _crimeRepository = crimeRepository;
            _enforcerRepository = enforcerRepository;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _config = config;
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

        public async Task AssingEnforcerAsync(string crimeId, string enforcerId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var enforcer = await _enforcerRepository.GetSingleAsync(enforcerId);

            AssignRequest request = new AssignRequest { EnforcerId = enforcerId };
            var response = await httpClient.PutAsJsonAsync($"{_config["CrimeApiURL"]}/{crimeId}/assign", request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new ResourceNotFoundException($"Crime with id {crimeId} does not exist");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new BadRequestException($"Id {crimeId} is not a valid");

            if (await _crimeRepository.AnyById(crimeId))
            {
                var crime = await _crimeRepository.GetSingleAsync(crimeId);
                crime.Enforcer = enforcer;
                await _crimeRepository.SaveAsync();
            }
            else
            {
                var crime = new Crime { CrimeId = crimeId, Enforcer = enforcer };
                await _crimeRepository.CreateAsync(crime);
                await _crimeRepository.SaveAsync();
            }
            
        }
    }
}
