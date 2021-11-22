using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryPromocion<Promocion>
    {
        void Add(Promocion promocion);
        void Update(Promocion promocion);
        IEnumerable<Promocion> GetAll();
        IEnumerable<Promocion> GetOne(Guid id);
    }
}
