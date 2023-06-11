using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VouViajar.Excursoes.Application.Features.Commands.AtualizarExcursao;
using VouViajar.Excursoes.Application.Features.Commands.CadastrarExcursao;
using VouViajar.Excursoes.Application.Features.Commands.ExcluirExcursao;
using VouViajar.Excursoes.Application.Features.Queries.ObterExcursao;
using VouViajar.Excursoes.Application.Features.Queries.ObterExcursoes;
using VouViajar.Excursoes.Application.Models;
using VouViajar.Excursoes.Domain.Enums;

namespace VouViajar.Excursoes.Application.Controllers
{
    [Authorize]
    [Route("api/excursao")]
    [ApiController]
    public class ExcursaoController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ExcursaoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CadastrarExcursao([FromBody] CadastrarExcursaoModel cadastrarExcursaoModel)
        {
            var cadastrarExcursaoCommand = new CadastrarExcursaoCommand()
            {
                Nome = cadastrarExcursaoModel.Nome,
                Resumo = cadastrarExcursaoModel.Resumo,
                DataInicio = cadastrarExcursaoModel.DataInicio,
                DataFim = cadastrarExcursaoModel.DataFim,
                Origem = cadastrarExcursaoModel.Origem,
                Destino = cadastrarExcursaoModel.Destino,
                NomeArquivo = cadastrarExcursaoModel.NomeArquivo,
                Arquivo = cadastrarExcursaoModel.Arquivo,
                TotalVagas = cadastrarExcursaoModel.TotalVagas,
                ValorVaga = cadastrarExcursaoModel.ValorVaga,
                Tipo = cadastrarExcursaoModel.Tipo,
                Situacao = EnumSituacaoExcursao.CADASTRADO

            };

            await _mediator.Send(cadastrarExcursaoCommand);
            return Created(Request.GetDisplayUrl(), cadastrarExcursaoModel);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpPut()]
        public async Task<ActionResult> AtualizarExcursao([FromBody] AtualizarExcursaoModel atualizarExcursaoModel, int id)
        {
            var atualizarExcursaoCommand = new AtualizarExcursaoCommand()
            {
                ID = id,
                Nome = atualizarExcursaoModel.Nome,
                Resumo = atualizarExcursaoModel.Resumo,
                DataInicio = atualizarExcursaoModel.DataInicio,
                DataFim = atualizarExcursaoModel.DataFim,
                Origem = atualizarExcursaoModel.Origem,
                Destino = atualizarExcursaoModel.Destino,
                NomeArquivo = atualizarExcursaoModel.NomeArquivo,
                Arquivo = atualizarExcursaoModel.Arquivo,
                TotalVagas = atualizarExcursaoModel.TotalVagas,
                ValorVaga = atualizarExcursaoModel.ValorVaga,
                Tipo = atualizarExcursaoModel.Tipo,
                Situacao = atualizarExcursaoModel.Situacao
            };

            await _mediator.Send(atualizarExcursaoCommand);

            return Ok(atualizarExcursaoModel);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpDelete]
        public async Task<ActionResult> ExcluirExcursao(int id)
        {
            var excluirExcursaoCommand = new ExcluirExcursaoCommand()
            {
                ID = id
            };

            await _mediator.Send(excluirExcursaoCommand);

            return Ok();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ObterExcursaoResult>> RecuperarExcursao(int id)
        {
            var ExcursaoResult = await _mediator.Send(new ObterExcursaoQuery
            {
                ID = id
            });

            return Ok(ExcursaoResult);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpGet]
        public async Task<ActionResult> ObterExcursoes()
        {
            var ExcursoesResult = await _mediator.Send(new ObterExcursoesQuery());
            return Ok(ExcursoesResult);
        }
    }
}