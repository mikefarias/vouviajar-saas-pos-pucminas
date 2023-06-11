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
    public class EventoController : ControllerBase
    {

        private readonly IMediator _mediator;
        public EventoController(IMediator mediator)
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
        public async Task<ActionResult> AtualizarEvento([FromBody] AtualizarExcursaoModel atualizarEventoModel, int id)
        {
            var atualizarEventoCommand = new AtualizarExcursaoCommand()
            {
                ID = id,
                Nome = atualizarEventoModel.Nome,
                Resumo = atualizarEventoModel.Resumo,
                DataInicio = atualizarEventoModel.DataInicio,
                DataFim = atualizarEventoModel.DataFim,
                Origem = atualizarEventoModel.Origem,
                Destino = atualizarEventoModel.Destino,
                NomeArquivo = atualizarEventoModel.NomeArquivo,
                Arquivo = atualizarEventoModel.Arquivo,
                TotalVagas = atualizarEventoModel.TotalVagas,
                ValorVaga = atualizarEventoModel.ValorVaga,
                Tipo = atualizarEventoModel.Tipo,
                Situacao = atualizarEventoModel.Situacao
            };

            await _mediator.Send(atualizarEventoCommand);

            return Ok(atualizarEventoModel);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpDelete]
        public async Task<ActionResult> ExcluirEvento(int id)
        {
            var excluirEventoCommand = new ExcluirExcursaoCommand()
            {
                ID = id
            };

            await _mediator.Send(excluirEventoCommand);

            return Ok();
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ObterExcursaoResult>> RecuperarEvento(int id)
        {
            var eventoResult = await _mediator.Send(new ObterExcursaoQuery
            {
                ID = id
            });

            return Ok(eventoResult);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpGet]
        public async Task<ActionResult> ObterExcursoes()
        {
            var eventosResult = await _mediator.Send(new ObterExcursoesQuery());
            return Ok(eventosResult);
        }
    }
}