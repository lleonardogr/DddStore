using DddStore.Core.Messages;

namespace DddStore.Vendas.Application.Events
{
    public class VoucherAplicadoPedidoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid VoucherId { get; private set; }

        public VoucherAplicadoPedidoEvent(Guid clienteId, Guid voucherId)
        {
            ClienteId = clienteId;
            VoucherId = voucherId;
        }
    }
}
