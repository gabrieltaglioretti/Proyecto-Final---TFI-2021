using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using DAL.Tools;
using SERVICIOS;
using System.Data;

namespace DAL.Repositories.SQL

{
    internal class PromocionRepository : IRepositoryPromocion<Promocion>
    {

        //private static string cnnApp = "Data Source=.\\SQLEXPRESS;Initial Catalog=ExchangeSystem;Integrated Security=True";
        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;


        #region Statements        
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Transacciones] "
                + "(IdCuentaOrigen, IdCuentaDestino, Monto, TipoOperacion, FechaHora) "
                + "VALUES (@IdCuentaOrigen, @IdCuentaDestino, @Monto, @TipoOperacion, @FechaHora)";
        }

        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[Transacciones]";
        }

        #endregion


        public void Add(Promocion promocion)
        {
            throw new NotImplementedException();
        }

        public void Update(Promocion promocion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Promocion> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Promocion> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }







    }
}
