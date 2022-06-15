﻿using MediatR;
using DddStore.Core.Messages.CommonMessages.IntegrationEvents;
using DddStore.Core.Communication.Mediator;

namespace DddStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : 
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>,
        INotificationHandler<PedidoProcessamentoCanceladoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatorHandler _mediatorHandler;
        public ProdutoEventHandler(IProdutoRepository produtoRepository, IEstoqueService estoqueService, IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);
            //TODO: enviar email ou qualquer notificação para comprar mais produtos
        }

        public async Task Handle(PedidoIniciadoEvent mensagem, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(mensagem.ProdutosPedido);
            if (result)
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(mensagem.PedidoId, mensagem.ClienteId, mensagem.Total));
            else
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(mensagem.PedidoId, mensagem.ClienteId));
        }

        public async Task Handle(PedidoProcessamentoCanceladoEvent message, CancellationToken cancellationToken)
        {
            await _estoqueService.ReporListaProdutosPedido(message.ProdutosPedido);
        }
    }
}
