using VouViajar.Excursoes.Domain.Entities.Aggregates;

namespace VouViajar.Excursoes.Application.Contracts.Services
{
    public interface IExcursaoService
    {
        void CadastrarExcursao(Excursao excursao);
    }
}