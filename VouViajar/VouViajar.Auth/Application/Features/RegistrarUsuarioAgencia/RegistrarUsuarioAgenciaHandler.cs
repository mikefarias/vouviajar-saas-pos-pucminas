using MediatR;
using VouViajar.Auth.Domain.Services;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Features.RegistrarUsuarioAgencia
{
    public class RegistrarUsuarioAgenciaHandler : IRequestHandler<RegistrarUsuarioAgenciaCommand, Unit>
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioAgenciaService _usuarioAgenciaService;

        public RegistrarUsuarioAgenciaHandler(IUsuarioService usuarioService, IUsuarioAgenciaService usuarioAgenciaService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _usuarioAgenciaService = usuarioAgenciaService ?? throw new ArgumentNullException(nameof(usuarioAgenciaService));
        }

        public async Task<Unit> Handle(RegistrarUsuarioAgenciaCommand request, CancellationToken cancellationToken)
        {

            var usuarioID = await _usuarioService.RegistrarUsuarioAsync(request.UserName, request.Email, request.Password, request.EmailConfirmed, TipoUsuario.AGENCIA);

            await _usuarioAgenciaService.RegistrarAgencia(usuarioID, request.Nome, request.Cadastur);
            
            return await Task.FromResult(Unit.Value);
        }
    }
}
