using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using SERVICIOS;
using DAL.Tools;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repositories.SQL

{
    internal class CarritoRepository : IRepositoryCarrito<Carrito>
    {

        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;

        #region Statements        

        private static string SelectCarritoView
        {
            get => "SELECT * FROM [dbo].[Carrito_View_New]";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[Carrito_View_New] where idCarrito = '";
        }

        private static string Remove
        {
            get => "DELETE FROM[dbo].[CarritoItem] WHERE idCarritoItem = '";
        }


        private static string SelectUserCart
        {
            get => "SELECT * FROM [dbo].[Carrito] where idUsuario = '";
        }

        private static string InsertCarrito
        {
            get => "INSERT INTO [dbo].[Carrito] "
                + "(idUsuario, estado) "
                + "VALUES (@idUsuario, @estado)" + "SELECT MAX(idCarrito) from Carrito";
        }
        //
        private static string InsertCarritoDetalle
        {
            get => "INSERT INTO [dbo].[CarritoItem] "
                + "(idProducto, cantidad, idCarrito) "
                + "VALUES (@idProducto, @cantidad, @idCarrito)";
        }
        #endregion
        public void Add(Carrito carrito)
        {
            AddCarrito(carrito);
            AddCarritoDetalle(carrito);    
            

        }

        public void Update(Carrito carrito)
        {
            AddCarritoDetalle(carrito); 
                
        }

        public IEnumerable<Carrito> GetAll()
        {
            try
            {
                Carrito cart = new Carrito();
                List<Carrito> cartList = new List<Carrito>();

                using (var dr = SqlHelper.ExecuteReader(SelectCarritoView, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        cart.idCarrito = Convert.ToInt32(values[0]);
                        cart.estado = (Carrito.Estado)Enum.Parse(typeof(Carrito.Estado), values[1].ToString());
                        cart.idSesion = values[2].ToString();

                        List<CarritoItem> linesItems = new List<CarritoItem>();
                        CarritoItem lineItem = new CarritoItem();
                        lineItem.cantidad = Convert.ToInt32(values[3]);

                        Producto producto = new Producto();
                        producto.picturePath = values[4].ToString();
                        producto.nombre = values[5].ToString();
                        producto.precio = Convert.ToDecimal(values[6]);

                        lineItem.idCarritoItem = Convert.ToInt32(values[7]);


                        lineItem.producto = producto;

                        linesItems.Add(lineItem);

                        cart.carritoItems = linesItems;

                        cartList.Add(cart);

                    }
                }
                return cartList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Carrito> GetOne(int id)
        {
            try
            {
                Carrito cart = new Carrito();
                List<Carrito> cartList = new List<Carrito>();
                List<CarritoItem> linesItems = new List<CarritoItem>();


                using (var dr = SqlHelper.ExecuteReader(SelectOne + id + "'", CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        cart.idCarrito = Convert.ToInt32(values[0]);
                        cart.estado = (Carrito.Estado)Enum.Parse(typeof(Carrito.Estado), values[1].ToString());
                        cart.idSesion = values[2].ToString();

                        CarritoItem lineItem = new CarritoItem();
                        lineItem.cantidad = Convert.ToInt32(values[3]);

                        Producto producto = new Producto();
                        producto.picturePath = values[4].ToString();
                        producto.nombre = values[5].ToString();
                        producto.precio = Convert.ToDecimal(values[6]);

                        lineItem.idCarritoItem = Convert.ToInt32(values[7]);

                        lineItem.producto = producto;

                        linesItems.Add(lineItem);

                        cart.carritoItems = linesItems;

                        cartList.Add(cart);

                    }
                }
                return cartList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public void AddCarrito(Carrito carrito) 
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertCarrito, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("idUsuario", carrito.idSesion);
                        cmd.Parameters.AddWithValue("estado", Enum.GetName(typeof(Carrito.Estado), carrito.estado));

                        int idCarrito = Convert.ToInt32(cmd.ExecuteScalar());
                        carrito.idCarrito = idCarrito;

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

        public void AddCarritoDetalle(Carrito carrito)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertCarritoDetalle, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("idProducto", carrito.carritoItems.First().producto.idProducto);
                        cmd.Parameters.AddWithValue("cantidad", carrito.carritoItems.First().cantidad);
                        cmd.Parameters.AddWithValue("idCarrito", carrito.idCarrito);

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

        public IEnumerable<Carrito> GetUserCart(string id)
        {
            try
            {
                Carrito UserCart = new Carrito();
                List<Carrito> UserCartList = new List<Carrito>();

                using (var dr = SqlHelper.ExecuteReader(SelectUserCart + id + "'", CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        UserCart.idCarrito = Convert.ToInt32(values[0]);
                        UserCart.idSesion = values[1].ToString();

                        UserCartList.Add(UserCart);

                    }
                }
                return UserCartList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Delete(int id)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(Remove + id + "'", sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;
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
    }


}
