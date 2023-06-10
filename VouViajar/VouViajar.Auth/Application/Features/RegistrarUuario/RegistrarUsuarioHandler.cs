using MediatR;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Features.RegistrarUuario
{
    public class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuarioCommand, LoginResponseViewModel>
    {

        private readonly IUsuarioService _usuarioService;

        public RegistrarUsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        public async Task<LoginResponseViewModel> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {

            var loginResponse = await _usuarioService.RegistrarUsuarioAsync(request);

            return await Task.FromResult(loginResponse);
        }
    }
}
