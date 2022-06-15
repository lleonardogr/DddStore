using DddStore.Catalogo.Application.Services;
using DddStore.Catalogo.Data;
using DddStore.Catalogo.Data.Repository;
using DddStore.Catalogo.Domain;
using DddStore.Catalogo.Domain.Events;
using DddStore.Core.Communication.Mediator;
using DddStore.Core.Messages.CommonMessages.IntegrationEvents;
using DddStore.Core.Messages.CommonMessages.Notifications;
using DddStore.Pagamentos.AntiCorruption;
using DddStore.Pagamentos.Business;
using DddStore.Pagamentos.Business.Events;
using DddStore.Pagamentos.Data;
using DddStore.Pagamentos.Data.Repository;
using DddStore.Vendas.Application.Commands;
using DddStore.Vendas.Application.Events;
using DddStore.Vendas.Application.Queries;
using DddStore.Vendas.Data;
using DddStore.Vendas.Data.Repository;
using DddStore.Vendas.Domain;
using MediatR;
using ConfigurationManager = DddStore.Pagamentos.AntiCorruption.ConfigurationManager;

namespace DddStore.WebApp.Mvc.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatrHandler>();

            //Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Bounded Context - Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessamentoCanceladoEvent>, ProdutoEventHandler>();

            //Bounded Context - Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<FinalizarPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>, PedidoCommandHandler>();

            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoEstoqueRejeitadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoRealizadoEvent>, PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoRecusadoEvent>, PedidoEventHandler>();

            //Bounded context - pagamentos
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<PagamentoContext>();

            services.AddScoped<INotificationHandler<PedidoEstoqueConfirmadoEvent>, PagamentoEventHandler>();

        }
    }
}
