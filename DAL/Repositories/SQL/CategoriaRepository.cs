using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using DAL.Tools;
using SERVICIOS;
using System.Data;

namespace DAL.Repositories.SQL

{
    internal class CategoriaRepository : IRepositoryCategoria<Categoria>
    {

        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;

        #region Statements        
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[CuentasCripto] "
                + "(1, 2, 2, 3) "
                + "VALUES (@1, @2, @3)";
        }

        private static string UpdateSaldo
        {
            get => "UPDATE [dbo].[CuentasCripto] SET Saldo = @Saldo WHERE IdCuenta = @IdCuenta";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[CuentasCripto]";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[CuentasCripto] where IdCuenta = '";
        }

        #endregion

        public void Add(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Update(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetAll()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Categoria> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
