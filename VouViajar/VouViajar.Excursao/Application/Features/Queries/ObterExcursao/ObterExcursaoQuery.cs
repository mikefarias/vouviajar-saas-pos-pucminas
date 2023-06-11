using MediatR;

namespace VouViajar.Excursoes.Application.Features.Queries.ObterExcursao
{
    public class ObterExcursaoQuery : IRequest<ObterExcursaoResult>
    {
        public ObterExcursaoQuery()
        {
        }
        public int ID { get; set; }
    }
}