using DddStore.Core.DomainObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddStore.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}
