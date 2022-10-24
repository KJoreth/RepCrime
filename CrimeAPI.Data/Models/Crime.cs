namespace CrimeAPI.Data.Models
{
    public record Crime
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime DateOfEvent { get; set; }
        public CrimeTypes CrimeType { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public CrimeStatus Status { get; set; }
        public string? EnforcerId { get; set; }
    }
}
