namespace StatsAPI.MapperProfiles
{
    public class StatsProfile : Profile
    {
        public StatsProfile()
            => CreateMap<Stats, StatsDTO>();
    }
}
