using MediatR;

namespace VouViajar.Excursoes.Application.Features.Commands.ExcluirExcursao
{
    public class ExcluirExcursaoCommand : IRequest
    {
        public int ID { get; set; }
    }
}
