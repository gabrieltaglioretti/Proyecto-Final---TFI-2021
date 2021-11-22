using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryCategoria<Categoria>
    {
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        IEnumerable<Categoria> GetAll();
        IEnumerable<Categoria> GetOne(Guid id);
    }
}
