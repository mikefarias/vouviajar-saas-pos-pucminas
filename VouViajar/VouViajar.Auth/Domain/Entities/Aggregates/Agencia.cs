namespace VouViajar.Auth.Domain.Entities.Aggregates
{
    public class Agencia
    {
        public Agencia(string usuarioID, string nome, int cadastur, DateTime cadastradoEm)
        {
            UsuarioID = usuarioID;
            Nome = nome;
            Cadastur = cadastur;
            CadastradoEm = cadastradoEm;
        }

        public int AgenciaID { get; set; }
        public string UsuarioID { get; set; }
        public string Nome { get; set; }
        public int Cadastur { get; set; }
        public DateTime CadastradoEm { get; set; }

    }
}