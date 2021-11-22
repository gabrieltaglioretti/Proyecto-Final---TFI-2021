using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryPago<Pago>
    {
        void Add(Pago pago);
        void Update(Pago pago);
        IEnumerable<Pago> GetAll();
        IEnumerable<Pago> GetOne(Guid id);
    }
}
