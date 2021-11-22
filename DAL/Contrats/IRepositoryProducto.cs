using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryProducto<Producto>
    {
        void Add(Producto producto);
        void Update(Producto producto);
        IEnumerable<Producto> GetAll();
        IEnumerable<Producto> GetOne(int id);
    }
}
