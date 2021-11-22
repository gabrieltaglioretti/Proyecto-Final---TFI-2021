using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using DAL.Tools;
using SERVICIOS;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.SQL

{
    internal class PagoRepository : IRepositoryPago<Pago>
    {
        //private static string cnnApp = "Data Source=.\\SQLEXPRESS;Initial Catalog=ExchangeSystem;Integrated Security=True";

        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;

        #region Statements        
        private string InsertStatement
        {
            get => "Delete [dbo].[Pago]; INSERT INTO [dbo].[Pago] "
                + "(idPago, FechaHora) "
                + "VALUES (@idPago, @FechaHora);";
        }

        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[Pago]";
        }

        #endregion

        public void Add(Pago pago)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("idPago", pago.idPago);
                        cmd.Parameters.AddWithValue("FechaHora", pago.FechaHora);


                        cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
        }

        public void Update(Pago pago)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pago> GetAll()
        {
            try
            {
                List<Pago> pagos = new List<Pago>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Pago pago = new Pago();

                        pago.idPago = values[0].ToString();
                        pago.FechaHora = Convert.ToDateTime(values[1]);

                        pagos.Add(pago);
                    }
                }
                return pagos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pago> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
