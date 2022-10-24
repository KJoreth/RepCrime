namespace EnforcerAPI.Data.Repositories
{
    public class EnforcerRepository : IEnforcerRepository
    {
        private readonly EnforcerContext _context;
        public EnforcerRepository(EnforcerContext context)
            => _context = context;
        public async Task<Enforcer> GetSingleAsync(string id)
        {
            var enforcer = await _context.Enforcers
                .Where(x => x.EnforcerId == id)
                .Include(x => x.Crimes)
                .FirstOrDefaultAsync();
            if (enforcer == null)
                throw new ResourceNotFoundException($"Enforcer with id {id} does not exist");
            return enforcer;
        }
        public async Task<List<Enforcer>> GetAllAsync()
            => await _context.Enforcers.ToListAsync();
        public async Task AssingAsync(string enforcerId, Crime crime)
        {
            var enforcer = await GetSingleAsync(enforcerId);
            enforcer.Crimes.Add(crime);
        }

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

    }
}
