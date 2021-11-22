using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryProductoNoSQL<ProductoNoSQL>
    {
        void Add(ProductoNoSQL productoNoSQL);
        IEnumerable<ProductoNoSQL> GetAll();
        void Update(ProductoNoSQL productoNoSQL);
        IEnumerable<ProductoNoSQL> GetOne(Guid id);
    }
}
