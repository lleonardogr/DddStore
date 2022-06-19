﻿using DddStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddStore.Vendas.Application.Events
{
    public class PedidoFinalizadoEvent : Event
    {
        public Guid PedidoId { get; private set; }
        public PedidoFinalizadoEvent(Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            
        }
    }
}
