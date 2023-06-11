using System.ComponentModel;

namespace VouViajar.Excursoes.Domain.Enums
{
    public enum EnumSituacaoExcursao
    {
        [Description("Cadastrado")]
        CADASTRADO = 1,
        [Description("Andamento")]
        ANDAMENTO = 2,
        [Description("Finalizado")]
        FINALIZADO = 3,
        [Description("Cancelamento")]
        CANCELAMENTO = 4,
        [Description("Excluido")]
        EXCLUIDO = 5
    }

    public enum EnumTipoExcursao
    {
        [Description("Bate e Volta")]
        BATE_VOLTA = 1,
        [Description("Excursão")]
        EXCURSAO = 2
    }
}