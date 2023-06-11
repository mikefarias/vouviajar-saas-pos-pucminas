using MediatR;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;

namespace VouViajar.Excursoes.Application.Features.Commands.AtualizarExcursao
{
    public class AtualizarExcursaoHandler : IRequestHandler<AtualizarExcursaoCommand>
    {
        public readonly IUnitOfWorkExcursao _unitOfWorkExcursao;

        public AtualizarExcursaoHandler(IUnitOfWorkExcursao unitOfWorkExcursao)
        {
            _unitOfWorkExcursao = unitOfWorkExcursao ?? throw new ArgumentNullException(nameof(unitOfWorkExcursao));
        }
        public Task<Unit> Handle(AtualizarExcursaoCommand request, CancellationToken cancellationToken)
        {

            var excursao = _unitOfWorkExcursao.ExcursaoRepository.ObterPorId(request.ID);

            if (excursao is null) throw new InvalidOperationException("Excursão não encontrada.");

            excursao.Nome = request.Nome;
            excursao.Resumo = request.Resumo;
            excursao.TotalVagas = request.TotalVagas;
            excursao.ValorVaga = request.ValorVaga;
            excursao.DataInicio = request.DataInicio;
            excursao.DataFim = request.DataFim;
            excursao.Arquivo = request.Arquivo;
            excursao.NomeArquivo = request.NomeArquivo;
            excursao.CadastradoEm = DateTime.Now;
            excursao.OrigemID = request.Origem;
            excursao.DestinoID = request.Destino;
            excursao.TipoID = request.Tipo.GetHashCode();
            excursao.SituacaoID = request.Situacao.GetHashCode();

            _unitOfWorkExcursao.ExcursaoRepository.Salvar(excursao);
            _unitOfWorkExcursao.Save();

            return Task.FromResult(Unit.Value);
        }
    }
}