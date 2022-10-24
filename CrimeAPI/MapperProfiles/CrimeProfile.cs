namespace CrimeAPI.MapperProfiles
{
    public class CrimeProfile : Profile
    {
        public CrimeProfile()
        {
            CreateMap<CrimeCreateDTO, Crime>();
            CreateMap<Crime, CrimeDetailedDTO>();
            CreateMap<Crime, CrimeSimpleDTO>();
        }
    }
}
