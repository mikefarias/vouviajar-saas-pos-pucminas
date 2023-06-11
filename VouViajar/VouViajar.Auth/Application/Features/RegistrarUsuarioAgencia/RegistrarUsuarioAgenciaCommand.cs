using MediatR;

namespace VouViajar.Auth.Application.Features.RegistrarUsuarioAgencia
{
    public class RegistrarUsuarioAgenciaCommand : IRequest<Unit>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required string Nome { get; set; }
        public int Cadastur { get; set; }
    }
}