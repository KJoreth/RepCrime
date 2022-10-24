namespace EnforcerAPI.Data.Repositories
{
    public class CrimeRepository : ICrimeRepository
    {
        private readonly EnforcerContext _context;
        public CrimeRepository(EnforcerContext context)
            => _context = context;
        public async Task<bool> AnyById(string crimeId)
            => await _context.Crimes.AnyAsync(x => x.CrimeId == crimeId);
        public async Task CreateAsync(string crimeId)
        {
            Crime crime = new Crime { CrimeId = crimeId };
            _context.Crimes.Add(crime);
        }
        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
