﻿namespace DddStore.Core.DomainObjects.DTO
{
    public class ListaProdutosPedido
    {
        public Guid PedidoId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
