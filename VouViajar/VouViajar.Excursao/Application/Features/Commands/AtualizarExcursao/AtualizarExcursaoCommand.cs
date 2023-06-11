using MediatR;
using VouViajar.Excursoes.Domain.Enums;

namespace VouViajar.Excursoes.Application.Features.Commands.AtualizarExcursao
{
    public class AtualizarExcursaoCommand : IRequest
    {
        public int ID { get; set; }
        public required string Nome { get; set; }

        public required string Resumo { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Origem { get; set; }

        public int Destino { get; set; }

        public required string NomeArquivo { get; set; }
        public required string Arquivo { get; set; }
        public int TotalVagas { get; set; }

        public decimal ValorVaga { get; set; }

        public EnumTipoExcursao Tipo { get; set; }

        public EnumSituacaoExcursao Situacao { get; set; }
    }
}