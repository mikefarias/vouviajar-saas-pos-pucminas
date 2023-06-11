using VouViajar.Excursoes.Application.Contracts.Infrastructure;
using VouViajar.Excursoes.Domain.Entities.Aggregates;
using VouViajar.Excursoes.Infrastructure.Persistence;

namespace VouViajar.Excursoes.Infrastructure.Repositories
{
    public class ExcursaoRepository : BaseRepository<Excursao>, IExcursaoRepository
    {
        public ExcursaoRepository(ExcursaoDbContext context) : base(context)
        {
        }
    }
}