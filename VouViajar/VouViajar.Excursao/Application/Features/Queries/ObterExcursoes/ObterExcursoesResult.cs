namespace VouViajar.Excursoes.Application.Features.Queries.ObterExcursoes
{
    public class ObterExcursoesResult
    {
        public required string Nome { get; set; }
        public required string Resumo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TotalVagas { get; set; }
        public decimal ValorVaga { get; set; }
        public required string NomeArquivo { get; set; }
        public required string Arquivo { get; set; }
        public DateTime CadastradoEm { get; set; }
        public required string Origem { get; set; }
        public required string Destino { get; set; }
        public required string Situacao { get; set; }
        public required string Tipo { get; set; }
    }
}