using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryCarrito<Carrito>
    {
        void Add(Carrito carrito);
        void Update(Carrito carrito);
        IEnumerable<Carrito> GetAll();
        IEnumerable<Carrito> GetOne(int id);
        void Delete(int id);
        IEnumerable<Carrito> GetUserCart(string id);

    }
}
