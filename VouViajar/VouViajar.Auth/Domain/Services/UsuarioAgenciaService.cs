using VouViajar.Auth.Application.Contracts.Infrastructure;
using VouViajar.Auth.Domain.Entities.Aggregates;
using VouViajar.Auth.Domain.Services.Interfaces;

namespace VouViajar.Auth.Domain.Services
{
    public class UsuarioAgenciaService : BaseService, IUsuarioAgenciaService
    {
        private readonly IAgenciaRepository _agenciaRepository;

        public UsuarioAgenciaService(INotificador notificador,
                                    IAgenciaRepository agenciaRepository) : base(notificador)
        {
            _agenciaRepository = agenciaRepository ?? throw new ArgumentNullException(nameof(agenciaRepository));
        }

        public async Task<ResponseService> RegistrarAgencia(string usuarioID, string nome, int cadastur)
        {
            var agencia = _agenciaRepository.Inserir(new Agencia(usuarioID, nome, cadastur, DateTime.Now));
            
            return await GenerateSuccessServiceResponse(agencia);
        }
    }
}