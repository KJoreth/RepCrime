
namespace EnforcerAPI.MapperProfiles
{
    public class EnforcerProfile : Profile
    {
        public EnforcerProfile()
        {
            CreateMap<Enforcer, EnforcerSimpleDTO>();
        }
    }
}
