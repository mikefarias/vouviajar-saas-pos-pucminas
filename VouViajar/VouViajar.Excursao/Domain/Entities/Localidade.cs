namespace VouViajar.Excursoes.Domain.Entities
{
    public class Localidade
    {
        public required int LocalidadeID { get; set; }
        public required string Nome { get; set; }
        public required bool Ativo { get; set; }
    }
}