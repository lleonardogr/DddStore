using DddStore.Catalogo.Application.Services;
using DddStore.Catalogo.Data;
using DddStore.Catalogo.Data.Repository;
using DddStore.Catalogo.Domain;
using DddStore.Catalogo.Domain.Events;
using DddStore.Core.Bus;
using MediatR;

namespace DddStore.WebApp.Mvc.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
        }
    }
}
