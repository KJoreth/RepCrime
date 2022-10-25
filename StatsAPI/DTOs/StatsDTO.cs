namespace StatsAPI.DTOs
{
    public record StatsDTO
    {
        public DateTime date { get; set; }
        public int CrimesReported { get; set; }
        public int EnforcesAssigned { get; set; }
    }
}
