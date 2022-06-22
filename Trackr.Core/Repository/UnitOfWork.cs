using Trackr.Data;
using Trackr.Interfaces;

namespace Trackr.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IRepository<Application> _applications;
        private IRepository<Interview> _interviews;
        private IRepository<Contact> _contacts;
        private IRepository<Settings> _settings;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepository<Application> Applications => _applications ??= new Repository<Application>(_context);

        public IRepository<Interview> Interviews => _interviews ??= new Repository<Interview>(_context);

        public IRepository<Contact> Contacts => _contacts ??= new Repository<Contact>(_context);

        public IRepository<Settings> Settings => _settings ??= new Repository<Settings>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
