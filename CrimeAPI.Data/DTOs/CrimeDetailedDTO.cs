namespace CrimeAPI.Data.DTOs
{
    public record CrimeDetailedDTO
    {
        public string Id { get; set; }
        public DateTime DateOfEvent { get; set; }
        public CrimeTypes CrimeType { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Email { get; set; }
        public CrimeStatus Status { get; set; }
        public string? EnforcerId { get; set; }
    }
}
