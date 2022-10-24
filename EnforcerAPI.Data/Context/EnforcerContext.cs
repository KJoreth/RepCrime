namespace EnforcerAPI.Data.Context
{
    public class EnforcerContext : DbContext
    {
        public EnforcerContext(DbContextOptions options) : base(options) { }
        public DbSet<Crime> Crimes { get; set; }
        public DbSet<Enforcer> Enforcers { get; set; }
    }
}
