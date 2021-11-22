using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryFavorito<Favorito>
    {
        void Add(Favorito favorito);
        void Update(Favorito favorito);
        IEnumerable<Favorito> GetAll();
        IEnumerable<Favorito> GetOne(Guid id);
    }
}
