﻿using DddStore.Core.Communication.Mediator;
using DddStore.Core.Messages.CommonMessages.Notifications;
using DddStore.Vendas.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DddStore.WebApp.Mvc.Controllers
{
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController(IPedidoQueries pedidoQueries,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediatorHandler) : base(notifications, mediatorHandler)
        {
            _pedidoQueries = pedidoQueries;
        }

        [Route("meus-pedidos")]
        public async Task<IActionResult> Index()
        {
            return View(await _pedidoQueries.ObterPedidosCliente(ClienteId));
        }
    }
}
