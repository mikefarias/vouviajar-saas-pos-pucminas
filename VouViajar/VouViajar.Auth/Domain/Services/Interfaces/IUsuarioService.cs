using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Domain.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> RegistrarUsuarioAsync(string userName, string email, string password, bool emailConfirmed, TipoUsuario tipoUsuario);
        Task<LoginResponseViewModel> LogarUsuarioAsync(string email, string password, bool isPersistent, bool bockoutOnFailure);
    }
}