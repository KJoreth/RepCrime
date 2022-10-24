namespace CrimeAPI.Data.DTOs
{
    public record CrimeCreateDTO
    {
        [Required]
        public DateTime DateOfEvent { get; set; }
        [Required]
        public CrimeTypes CrimeType { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Place { get; set; }
    }
}
