using FluentValidation;

namespace VouViajar.Auth.Application.Features.RegistrarUuario
{
    public class RegistrarUsuarioValidator : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioValidator()
        {
        }
    }
}