using VouViajar.Auth.Domain.Services.Notificacoes;

namespace VouViajar.Auth.Domain.Services.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
