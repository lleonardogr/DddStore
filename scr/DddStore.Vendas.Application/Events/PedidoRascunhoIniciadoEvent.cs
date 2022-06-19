
using DddStore.Core.Messages;

namespace DddStore.Vendas.Application.Events
{
    public class PedidoRascunhoIniciadoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }

        public PedidoRascunhoIniciadoEvent(Guid clienteId, Guid pedidoId)
        {
            AggregateId = clienteId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
        }
    }
}
