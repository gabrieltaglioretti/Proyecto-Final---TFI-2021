using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryPedido<Pedido>
    {
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        IEnumerable<Pedido> GetAll();
        IEnumerable<Pedido> GetOne(Guid id);
    }
}
