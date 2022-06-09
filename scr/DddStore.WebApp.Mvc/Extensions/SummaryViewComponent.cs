﻿using DddStore.Core.Messages.CommonMessages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DddStore.WebApp.Mvc.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifications.ObterNotificacoes());
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(String.Empty, c.Value));

            return View();
        }
    }
}
