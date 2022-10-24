namespace CrimeAPI.Data.DTOs
{
    public record CrimeSimpleDTO
    {
        public string Id { get; set; }
        public DateTime DateOfEvent { get; set; }
        public CrimeTypes CrimeType { get; set; }
        public CrimeStatus Status { get; set; }
    }
}
