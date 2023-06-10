using MediatR;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Features.LogarUsuario
{
    public class LogarUsuarioHandler : IRequestHandler<LogarUsuarioCommand, LoginResponseViewModel>
    {

        private readonly IUsuarioService _usuarioService;

        public LogarUsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        public async Task<LoginResponseViewModel> Handle(LogarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var retorno = await _usuarioService.LogarUsuarioAsync(request.Email, request.Password, request.IsPersistent, request.LockoutOnFailure);

            return await Task.FromResult<LoginResponseViewModel>(retorno);
        }

    }
}
