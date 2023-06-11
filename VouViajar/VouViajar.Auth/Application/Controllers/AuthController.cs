using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VouViajar.Auth.Application.Features.LogarUsuario;
using VouViajar.Auth.Application.Features.RegistrarUsuarioAgencia;
using VouViajar.Auth.Domain.Services.Interfaces;
using VouViajar.Auth.Domain.Services.ViewModel;

namespace VouViajar.Auth.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/account/register")]
    [ApiController]
    public class AutenticacaoController : BaseController
    {

        private readonly IMediator _mediator;

        public AutenticacaoController(INotificador notificador, IMediator mediator) : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost("agencia")]
        public async Task<ActionResult> RegistrarAgencia(RegistrarUsuarioAgenciaViewModel registrarUsuarioAgencia)
        {
            if (!ModelState.IsValid) return Retorno(ModelState);

            var retorno = await _mediator.Send(new RegistrarUsuarioAgenciaCommand
            {
                UserName = registrarUsuarioAgencia.Email,
                Email = registrarUsuarioAgencia.Email,
                EmailConfirmed = true,
                Password = registrarUsuarioAgencia.Password,
                ConfirmPassword = registrarUsuarioAgencia.ConfirmPassword, 
                Nome = registrarUsuarioAgencia.Nome, 
                Cadastur = registrarUsuarioAgencia.Cadastrar
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
