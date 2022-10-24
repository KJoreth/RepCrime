namespace EnforcerAPI.Data.DTOs
{
    public record EnforcerDetailedDTO
    {
        public string EnforcerId { get; set; }
        public EnforcerRanks Rank { get; set; }
        public List<CrimeDTO> Crimes { get; set; }
    }
}
