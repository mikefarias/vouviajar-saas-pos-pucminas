using System.ComponentModel.DataAnnotations;

namespace VouViajar.Auth.Domain.Services.ViewModel
{
    public class RegistrarUsuarioAgenciaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public required string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public required string ConfirmPassword { get; set; }        
        public required string Nome { get; set; }
        public int Cadastur { get; set; }

    }

    public class UserTokenViewModel
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public required IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class LoginResponseViewModel
    {
        public required string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public required UserTokenViewModel UserToken { get; set; }
    }

    public class ClaimViewModel
    {
        public string? Value { get; set; }
        public required string Type { get; set; }
    }
}