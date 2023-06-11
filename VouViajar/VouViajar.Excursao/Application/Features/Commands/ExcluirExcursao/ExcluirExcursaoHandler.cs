using MediatR;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;

namespace VouViajar.Excursoes.Application.Features.Commands.ExcluirExcursao
{
    public class ExcluirExcursaoHandler : IRequestHandler<ExcluirExcursaoCommand>
    {
        public readonly IUnitOfWorkExcursao _unitOfWorkExcursao;

        public ExcluirExcursaoHandler(IUnitOfWorkExcursao unitOfWorkExcursao)
        {
            _unitOfWorkExcursao = unitOfWorkExcursao ?? throw new ArgumentNullException(nameof(unitOfWorkExcursao));
        }
        public Task<Unit> Handle(ExcluirExcursaoCommand request, CancellationToken cancellationToken)
        {

            var excursao = _unitOfWorkExcursao.ExcursaoRepository.ObterPorId(request.ID);

            if (excursao is null) throw new InvalidOperationException("Excursao não encontrada.");

            _unitOfWorkExcursao.ExcursaoRepository.Excluir(excursao);
            _unitOfWorkExcursao.Save();

            return Task.FromResult(Unit.Value);
        }
    }
}