using MediatR;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;
using VouViajar.Excursoes.Domain.Entities.Aggregates;

namespace VouViajar.Excursoes.Application.Features.Commands.CadastrarExcursao
{
    public class CadastrarExcursaoHandler : IRequestHandler<CadastrarExcursaoCommand>
    {
        public readonly IUnitOfWorkExcursao _unitOfWorkExcursao;

        public CadastrarExcursaoHandler(IUnitOfWorkExcursao unitOfWorkExcursao)
        {
            _unitOfWorkExcursao = unitOfWorkExcursao ?? throw new ArgumentNullException(nameof(unitOfWorkExcursao));
        }
        public Task<Unit> Handle(CadastrarExcursaoCommand request, CancellationToken cancellationToken)
        {
            Excursao excursao = new Excursao
            {
                Nome = request.Nome,
                Resumo = request.Resumo,
                TotalVagas = request.TotalVagas,
                ValorVaga = request.ValorVaga,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                Arquivo = request.Arquivo,
                NomeArquivo = request.NomeArquivo,
                CadastradoEm = DateTime.Now,
                OrigemID = request.Origem,
                DestinoID = request.Destino,
                TipoID = request.Tipo.GetHashCode(),
                SituacaoID = request.Situacao.GetHashCode()
            };

            _unitOfWorkExcursao.Context.Excursao.Add(excursao);
            _unitOfWorkExcursao.Save();

            return Task.FromResult(Unit.Value);
        }
    }
}
