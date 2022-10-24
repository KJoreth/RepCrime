namespace EnforcerAPI.Data.Models
{
    public class Enforcer
    {
        public int Id { get; set; }
        public string EnforcerId { get; set; }
        public EnforcerRanks Rank { get; set; }
        public List<Crime> Crimes { get; set; }
    }
}
