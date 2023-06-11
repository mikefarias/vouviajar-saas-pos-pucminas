namespace VouViajar.Auth.Domain.Services.Interfaces
{
    public interface IUsuarioAgenciaService
    {
        Task<ResponseService> RegistrarAgencia(string usuarioID, string nome, int cadastur);
    }
}