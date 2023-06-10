using MediatR;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Features.LogarUsuario
{
    public class LogarUsuarioCommand : IRequest<LoginResponseViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
        public bool LockoutOnFailure { get; set; }

    }
}
