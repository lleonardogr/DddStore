using DddStore.Core.Communication.Mediator;
using DddStore.Core.Messages.CommonMessages.Notifications;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace DddStore.WebApp.Mvc.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("5914573c-5635-435a-a4a7-f2a626f31698");

        public ControllerBase(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler) notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificaErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

    }
}
