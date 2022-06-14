using DddStore.Vendas.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DddStore.WebApp.Mvc.Extensions
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IPedidoQueries _pedidoQueries;

        protected Guid ClienteId = Guid.Parse("5914573c-5635-435a-a4a7-f2a626f31698");

        public CartViewComponent(IPedidoQueries pedidoQueries)
        { 
            _pedidoQueries = pedidoQueries;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carrinho = await _pedidoQueries.ObterCarrinhoCliente(ClienteId);
            var itens = carrinho?.Items.Count ?? 0;

            return View(itens);
        }

    }
}
