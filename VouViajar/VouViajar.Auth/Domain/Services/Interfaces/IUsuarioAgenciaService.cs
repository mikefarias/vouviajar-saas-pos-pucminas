using VouViajar.Auth.Domain.Entities.Aggregates;

namespace VouViajar.Auth.Domain.Services.Interfaces
{
    public interface IUsuarioAgenciaService
    {
        Task<ResponseService> RegistrarAgencia(Usuario usuario);
    }
}