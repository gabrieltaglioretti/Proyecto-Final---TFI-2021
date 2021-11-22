using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryCompra<Compra>
    {
        void Add(Compra compra);
        void Update(Compra compra);
        IEnumerable<Compra> GetAll();
        IEnumerable<Compra> GetOne(Guid id);
    }
}
