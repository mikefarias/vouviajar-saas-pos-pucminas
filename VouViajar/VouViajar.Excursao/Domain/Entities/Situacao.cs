namespace VouViajar.Excursoes.Domain.Entities
{
    public class Situacao
    {
        public required int SituacaoID { get; set; }
        public required string Descricao { get; set; }
        public required bool Ativo { get; set; }
    }
}