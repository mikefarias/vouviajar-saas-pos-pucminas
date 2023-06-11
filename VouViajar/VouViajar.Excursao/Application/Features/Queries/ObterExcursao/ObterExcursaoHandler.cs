using MediatR;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;

namespace VouViajar.Excursoes.Application.Features.Queries.ObterExcursao
{
    public class ObterExcursaoHandler : IRequestHandler<ObterExcursaoQuery, ObterExcursaoResult>
    {
        private readonly IUnitOfWorkExcursao _unitOfWorkExcursao;

        public ObterExcursaoHandler(IUnitOfWorkExcursao unitOfWorkExcursao)
        {
            _unitOfWorkExcursao = unitOfWorkExcursao ?? throw new ArgumentException(null, nameof(unitOfWorkExcursao));

        }

        public async Task<ObterExcursaoResult> Handle(ObterExcursaoQuery request, CancellationToken cancellationToken)
        {
            var excursao = _unitOfWorkExcursao.ExcursaoRepository.ObterPorId(request.ID);

            if (excursao is null) throw new InvalidOperationException("Excursão não encontrada.");

            return new ObterExcursaoResult
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
            };
        }
    }
}