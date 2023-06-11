using VouViajar.Excursoes.Domain.Enums;

namespace VouViajar.Excursoes.Application.Models
{
    public class CadastrarExcursaoModel
    {
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
    }
}
