using MediatR;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;

namespace VouViajar.Excursoes.Application.Features.Queries.ObterExcursoes
{
    public class ObterExcursoesHandler : IRequestHandler<ObterExcursoesQuery, List<ObterExcursoesResult>>
    {
        private readonly IUnitOfWorkExcursao _unitOfWorkExcursao;

        public ObterExcursoesHandler(IUnitOfWorkExcursao unitOfWorkExcursao)
        {
            _unitOfWorkExcursao = unitOfWorkExcursao ?? throw new ArgumentException(null, nameof(unitOfWorkExcursao));

        }

        public async Task<List<ObterExcursoesResult>> Handle(ObterExcursoesQuery request, CancellationToken cancellationToken)
        {
            var excursoes = _unitOfWorkExcursao.ExcursaoRepository.ObterTodos();

            if (excursoes is null) throw new InvalidOperationException("Evento não encontrado");

            return (excursoes.Select(excursao => new ObterExcursoesResult
            {
                Nome = excursao.Nome,
                Resumo = excursao.Resumo,
                DataInicio = excursao.DataInicio,
                DataFim = excursao.DataFim,
                Origem = excursao.Origem?.ToString(),
                Destino = excursao.Destino?.ToString(),
                ValorVaga = excursao.ValorVaga,
                TotalVagas = excursao.TotalVagas,
                Situacao = excursao.Situacao?.ToString(),
                Tipo = excursao.Tipo?.ToString(),
                NomeArquivo = excursao.NomeArquivo,
                Arquivo = excursao.Arquivo,
                CadastradoEm = excursao.CadastradoEm

            })).ToList();
        }
    }
}