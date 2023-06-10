using VouViajar.Auth.Application.Features.RegistrarUuario;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Domain.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<LoginResponseViewModel> RegistrarUsuarioAsync(RegistrarUsuarioCommand request);
        Task<LoginResponseViewModel> LogarUsuarioAsync(string email, string password, bool isPersistent, bool bockoutOnFailure);
    }
}