using System;
using System.Collections.Generic;
using DOMAIN;


namespace DAL.Contrats
{ 
    public interface IRepositoryCuenta<Cuenta>
    {
        void Add(Cuenta cuenta);
        void Update(Cuenta cuenta);
        IEnumerable<Cuenta> GetAll();
        IEnumerable<Cuenta> GetOne(Guid id);
    }
}
