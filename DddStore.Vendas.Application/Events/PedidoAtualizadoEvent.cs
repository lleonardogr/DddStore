using DddStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddStore.Vendas.Application.Events
{
    public class PedidoAtualizadoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public decimal ValorToal { get; private set; }

        public PedidoAtualizadoEvent(Guid clienteId, Guid pedidoId, decimal valorTotal)
        {
            AggregateId = clienteId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ValorToal = valorTotal;
        }
    }
}
