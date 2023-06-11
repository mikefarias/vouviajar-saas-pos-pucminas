using MediatR;

namespace VouViajar.Excursoes.Application.Features.Queries.ObterExcursoes
{
    public class ObterExcursoesQuery : IRequest<List<ObterExcursoesResult>>
    {
        public ObterExcursoesQuery()
        {
        }

        public int ID { get; set; }
    }
}