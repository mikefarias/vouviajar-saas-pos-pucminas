using VouViajar.Excursoes.Application.Contracts.Infrastructure;

namespace VouViajar.Excursoes.Infrastructure.Persistence
{
    public class UnitOfWorkExcursao : IUnitOfWorkExcursao, IDisposable
    {
        private readonly ExcursaoDbContext _excursaoDbContext;

        public ExcursaoDbContext Context { get { return _excursaoDbContext; } }

        private readonly IExcursaoRepository _excursaoRepository;
        public IExcursaoRepository ExcursaoRepository { get { return _excursaoRepository; } }

        public UnitOfWorkExcursao(ExcursaoDbContext excursaoDbContext,
                                IExcursaoRepository excursaoRepository)
        {
            _excursaoDbContext = excursaoDbContext;
            _excursaoRepository = excursaoRepository;
        }

        public void Save()
        {
            _excursaoDbContext.Instance.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                _excursaoDbContext.Instance.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _excursaoDbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _excursaoDbContext.Database.CommitTransaction();
        }
    }
}