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
            Excursao excursao = 
                new(request.AgenciaID, request.Nome, request.Resumo, request.DataInicio, request.DataFim,
                request.TotalVagas, request.ValorVaga, request.NomeArquivo, request.Arquivo, DateTime.Now,
                request.Origem, request.Destino, request.Situacao.GetHashCode(), request.Tipo.GetHashCode());

   
            _unitOfWorkExcursao.Context.Excursao.Add(excursao);
            _unitOfWorkExcursao.Save();

            return Task.FromResult(Unit.Value);
        }
    }
}