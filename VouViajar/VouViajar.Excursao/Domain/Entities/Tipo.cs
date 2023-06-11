namespace VouViajar.Excursoes.Domain.Entities
{
    public class Tipo
    {
        public required int TipoID { get; set; }
        public required string Descricao { get; set; }
        public required bool Ativo { get; set; }
    }
}