namespace EnforcerAPI.Data.Repositories
{
    public class CrimeRepository : ICrimeRepository
    {
        private readonly EnforcerContext _context;
        public CrimeRepository(EnforcerContext context)
            => _context = context;

        public async Task<bool> AnyById(string crimeId)
            => await _context.Crimes.AnyAsync(x => x.CrimeId == crimeId);

        public async Task CreateAsync(Crime crime)
            => await _context.Crimes.AddAsync(crime);

        public async Task<Crime> GetSingleAsync(string crimeId)
            => await _context.Crimes
                .Where(x => x.CrimeId == crimeId)
                .FirstOrDefaultAsync();
   

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
