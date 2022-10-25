namespace StatsAPI.Models
{
    public class Stats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime date { get; set; }
        public int CrimesReported { get; set; }
        public int EnforcesAssigned { get; set; }
    }
}
