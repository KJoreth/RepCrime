namespace EnforcerAPI.Data.Models
{
    public class Crime
    {
        public int Id { get; set; }
        public string CrimeId { get; set; }
        public Enforcer? Enforcer { get; set; }
    }
}
