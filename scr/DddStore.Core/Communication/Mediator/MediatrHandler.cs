using DddStore.Core.Messages;
using DddStore.Core.Messages.CommonMessages.Notifications;
using MediatR;

namespace DddStore.Core.Communication.Mediator
{
    public class MediatrHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicaNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }
    }


}
