
namespace EnforcerAPI.Services
{
    public class EnforcersService
    {
        private readonly ICrimeRepository _crimeRepository;
        private readonly IEnforcerRepository _enforcerRepository;

        public EnforcersService(ICrimeRepository crimeRepository, IEnforcerRepository enforcerRepository)
        {
            _crimeRepository = crimeRepository;
            _enforcerRepository = enforcerRepository;
        }



    }
}
