using VouViajar.Auth.Application.Contracts.Infrastructure;
using VouViajar.Auth.Domain.Entities.Aggregates;
using VouViajar.Auth.Infrastructure.Persistence;

namespace VouViajar.Auth.Infrastructure.Repositories
{
    public class AgenciaRepository : BaseRepository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(UsuarioDbContext context) : base(context)
        {
        }
    }
}