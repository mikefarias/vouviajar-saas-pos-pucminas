using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VouViajar.Auth.Application.Features.LogarUsuario;
using VouViajar.Auth.Application.Features.RegistrarUuario;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AutenticacaoController : BaseController
    {

        private readonly IMediator _mediator;

        public AutenticacaoController(INotificador notificador, IMediator mediator) : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(RegistrarUsuarioViewModel registrarUsuario)
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            var retorno = await _mediator.Send(new RegistrarUsuarioCommand
            {
                UserName = registrarUsuario.Email,
                Email = registrarUsuario.Email,
                EmailConfirmed = true,
                Password = registrarUsuario.Password,
                ConfirmPassword = registrarUsuario.ConfirmPassword,
                TipoUsuario = registrarUsuario.TipoUsuario
            });

            return Retorno(retorno);
        }

        [HttpPost("logar")]
        public async Task<ActionResult> Login(LoginUsuarioViewModel loginUsuario)
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            var retorno = await _mediator.Send(new LogarUsuarioCommand
            {
                Email = loginUsuario.Email,
                Password = loginUsuario.Password,
                IsPersistent = true,
                LockoutOnFailure = false
            });

            return Retorno(retorno);
        }
    }
}
