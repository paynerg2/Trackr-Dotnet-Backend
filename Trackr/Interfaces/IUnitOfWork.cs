using Trackr.Data;

namespace Trackr.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Application> Applications { get; }
        IRepository<Interview> Interviews { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<Settings> Settings { get; }

        Task Save();
    }
}
