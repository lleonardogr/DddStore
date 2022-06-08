using DddStore.Catalogo.Application.Services;
using DddStore.Catalogo.Data;
using DddStore.Catalogo.Data.Repository;
using DddStore.Catalogo.Domain;
using DddStore.Catalogo.Domain.Events;
using DddStore.Core.Bus;
using DddStore.Vendas.Application.Commands;
using DddStore.Vendas.Data;
using DddStore.Vendas.Data.Repository;
using DddStore.Vendas.Domain;
using MediatR;

namespace DddStore.WebApp.Mvc.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Bus
            services.AddScoped<IMediatorHandler, MediatrHandler>();

            //Bounded Context - Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            //Bounded Context - Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        }
    }
}
