namespace EnforcerAPI.Data.DTOs
{
    public record EnforcerSimpleDTO
    {
        public string EnforcerId { get; set; }
        public EnforcerRanks Rank { get; set; }
    }
}
