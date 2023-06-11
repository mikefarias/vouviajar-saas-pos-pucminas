using MediatR;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Features.RegistrarUuario
{
    public class RegistrarUsuarioCommand : IRequest<LoginResponseViewModel>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required TipoUsuario TipoUsuario { get; set; }
    }
}
