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
    internal class PedidoRepository : IRepositoryPedido<Pedido>
    {
        //private static string cnnApp = "Data Source=.\\SQLEXPRESS;Initial Catalog=ExchangeSystem;Integrated Security=True";

        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;

        #region Statements        
        private string InsertPedido
        {
            get => "INSERT INTO [dbo].[Pedido] "
                + "(fechaHora, idUsuario, idCarrito, estadoPedido) "
                + "VALUES (@fechaHora, @idUsuario, @idCarrito, @estadoPedido);";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[Pedido]";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Pedido] SET fechaHora = @fechaHora, estadoPedido = @estadoPedido WHERE idPedido = @idPedido";
        }

        #endregion

        public void Add(Pedido pedido)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertPedido, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("fechaHora", pedido.fechaHora);
                        cmd.Parameters.AddWithValue("idUsuario", pedido.idUsuario);
                        cmd.Parameters.AddWithValue("idCarrito", pedido.idCarrito);
                        cmd.Parameters.AddWithValue("estadoPedido", Enum.GetName(typeof(Pedido.EstadoPedido), pedido.estado));

                        int idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                        pedido.idPedido = idPedido;
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


        public IEnumerable<Pedido> GetAll()
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Pedido pedido = new Pedido();

                        pedido.idPedido = Convert.ToInt32(values[0].ToString());
                        pedido.fechaHora = Convert.ToDateTime(values[1].ToString());
                        pedido.idUsuario = values[2].ToString();
                        pedido.idCarrito = Convert.ToInt32(values[3].ToString());
                        pedido.estado = (Pedido.EstadoPedido)Enum.Parse(typeof(Pedido.EstadoPedido), values[4].ToString());

                        pedidos.Add(pedido);
                    }
                }
                return pedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Pedido pedido)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(UpdateStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("fechaHora", pedido.fechaHora);
                        cmd.Parameters.AddWithValue("estadoPedido", Enum.GetName(typeof(Pedido.EstadoPedido), pedido.estado));
                        cmd.Parameters.AddWithValue("idPedido", pedido.idPedido); 


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

        public IEnumerable<Pedido> GetOne(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
