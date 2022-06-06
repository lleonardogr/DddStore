using DddStore.Core.Messages;
using MediatR;

namespace DddStore.Core.Bus
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento)
        {
            await _mediator.Publish(evento);
        }
    }


}
