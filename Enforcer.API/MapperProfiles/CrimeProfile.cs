namespace EnforcerAPI.MapperProfiles
{
    public class CrimeProfile : Profile
    {
        public CrimeProfile()
        {
            CreateMap<Crime, CrimeDTO>();
        }
    }
}
