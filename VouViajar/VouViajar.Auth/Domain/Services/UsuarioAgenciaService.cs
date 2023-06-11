using VouViajar.Auth.Domain.Entities.Aggregates;
using VouViajar.Auth.Domain.Services.Interfaces;

namespace VouViajar.Auth.Domain.Services
{
    public class UsuarioAgenciaService : BaseService, IUsuarioAgenciaService
    {
        private readonly INotificador _notificador;
        public UsuarioAgenciaService(INotificador notificador) : base(notificador)
        {
            _notificador = notificador;
        }

        public async Task<ResponseService> RegistrarAgencia(Usuario usuario)
        {
            return await GenerateSuccessServiceResponse();
        }
    }
}
