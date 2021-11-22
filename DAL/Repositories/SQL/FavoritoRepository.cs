using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using DAL.Tools;
using SERVICIOS;
using System.Data;

namespace DAL.Repositories.SQL

{
    internal class FavoritoRepository : IRepositoryFavorito<Favorito>
    {

        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;

        #region Statements        
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Producto] "
                + "(IdProducto, codigo, nombre, MaxAnual, MaxMensual, MaxSolicitud, activo, stock) "
                + "VALUES (@IdProducto, @codigo, @nombre, @MaxAnual, @MaxMensual, @MaxSolicitud, @activo, @stock);";
        }

        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[CuentasFidusuarias]";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[CuentasFidusuarias] where IdCuenta = '";
        }
        #endregion

        public void Add(Favorito favorito)
        {
            throw new NotImplementedException();
        }

        public void Update(Favorito favorito)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorito> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Favorito> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }






    }
}
