using DddStore.Vendas.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddStore.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}
