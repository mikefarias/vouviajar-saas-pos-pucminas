using VouViajar.Excursoes.Infrastructure.Persistence;

namespace VouViajar.Excursoes.Application.Contracts.Infrastructure
{
    public interface IUnitOfWorkExcursao
    {
        ExcursaoDbContext Context { get; }
        IExcursaoRepository ExcursaoRepository { get; }
        void BeginTransaction();
        void CommitTransaction();
        void Save();
    }
}