using DAL.Contrats;
using DOMAIN;
using System;
using System.Collections.Generic;
using DAL.Tools;
using SERVICIOS;
using System.Data;
using System.Data.SqlClient;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;


namespace DAL.Repositories.SQL

{
    internal class ProductoRepository : IRepositoryProducto<Producto>
    {
        private static string cnnApp = ApplicationSettings.Current.connAplicacionDB;

        #region Statements        
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Producto] "
                + "(SKU, nombre, marca, modelo, genero, descripcion, activo, idPrecio, talle, color, createdOn, createdBy, changedOn, changedBy, idProveedor, idCategoria, idDescuento, stock, picturePath, pictureName, ranking, observaciones, precio) "
                + "VALUES (@SKU, @nombre, @marca, @modelo, @genero, @descripcion, @activo, @idPrecio, @talle, @color, @createdOn, @createdBy, @changedOn, @changedBy, @idProveedor, @idCategoria, @idDescuento, @stock, @picturePath, @pictureName, @ranking, @observaciones, @precio)";

        }    

        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[Producto]";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[Producto] where idProducto = '";
        }
        #endregion

        public void Add(Producto producto)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnApp))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("SKU", producto.SKU);

                        cmd.Parameters.AddWithValue("nombre", producto.nombre);
                        cmd.Parameters.AddWithValue("marca", producto.marca);
                        cmd.Parameters.AddWithValue("modelo", producto.modelo);
                        cmd.Parameters.AddWithValue("genero", producto.genero);
                        cmd.Parameters.AddWithValue("descripcion", producto.descripcion);
                        cmd.Parameters.AddWithValue("activo", producto.activo);
                        cmd.Parameters.AddWithValue("idPrecio", producto.idPrecio);
                        cmd.Parameters.AddWithValue("talle", producto.talle);


                        cmd.Parameters.AddWithValue("color", producto.color);
                        cmd.Parameters.AddWithValue("createdOn", producto.createdOn);
                        cmd.Parameters.AddWithValue("createdBy", producto.createdBy);
                        cmd.Parameters.AddWithValue("changedOn", producto.changedOn);


                        cmd.Parameters.AddWithValue("changedBy", producto.changedBy);
                        cmd.Parameters.AddWithValue("idProveedor", producto.idProveedor);
                        cmd.Parameters.AddWithValue("idCategoria", producto.idCategoria);
                        cmd.Parameters.AddWithValue("idDescuento", producto.idDescuento);


                        cmd.Parameters.AddWithValue("stock", producto.stock);
                        cmd.Parameters.AddWithValue("picturePath", producto.picturePath);
                        cmd.Parameters.AddWithValue("pictureName", producto.pictureName);
                        cmd.Parameters.AddWithValue("ranking", producto.ranking);
                        cmd.Parameters.AddWithValue("observaciones", producto.observaciones);
                        cmd.Parameters.AddWithValue("precio", producto.precio);

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

        public void Update(Producto producto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetAll()
        {
            try
            {
                List<Producto> productos = new List<Producto>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Producto producto = new Producto();

                        producto.idProducto = Convert.ToInt32(values[0]);
                        producto.SKU = Convert.ToInt32(values[1]);
                        producto.nombre = values[2].ToString();
                        producto.marca = values[3].ToString();
                        producto.modelo = values[4].ToString();
                        producto.genero = values[5].ToString();
                        producto.descripcion = values[6].ToString();
                        producto.activo = values[7].ToString();
                        producto.idPrecio = Convert.ToInt32(values[8]);
                        producto.talle = values[9].ToString();
                        producto.color = values[10].ToString();
                        producto.createdOn = Convert.ToDateTime(values[11]);
                        producto.createdBy = values[12].ToString();
                        producto.changedOn = Convert.ToDateTime(values[13]);
                        producto.changedBy = values[14].ToString();
                        producto.idProveedor = Convert.ToInt32(values[15]);
                        producto.idCategoria = Convert.ToInt32(values[16]);
                        producto.idDescuento = Convert.ToInt32(values[17]);
                        producto.stock = Convert.ToInt32(values[18]);
                        producto.picturePath = values[19].ToString();
                        producto.pictureName = values[20].ToString();
                        producto.ranking = values[21].ToString();
                        producto.observaciones = values[22].ToString();
                        producto.precio = Convert.ToDecimal(values[23]);
                        producto.picturePath1 = values[24].ToString();
                        producto.picturePath2 = values[25].ToString();
                        producto.picturePath3 = values[26].ToString();


                        productos.Add(producto);
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Producto> GetOne(int id)
        {
            try
            {
                List<Producto> productos = new List<Producto>();

                using (var dr = SqlHelper.ExecuteReader(SelectOne + id + "'", CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Producto producto = new Producto();

                        producto.idProducto = Convert.ToInt32(values[0]);
                        producto.SKU = Convert.ToInt32(values[1]);
                        producto.nombre = values[2].ToString();
                        producto.marca = values[3].ToString();
                        producto.modelo = values[4].ToString();
                        producto.genero = values[5].ToString();
                        producto.descripcion = values[6].ToString();
                        producto.activo = values[7].ToString();
                        producto.idPrecio = Convert.ToInt32(values[8]);
                        producto.talle = values[9].ToString();
                        producto.color = values[10].ToString();
                        producto.createdOn = Convert.ToDateTime(values[11]);
                        producto.createdBy = values[12].ToString();
                        producto.changedOn = Convert.ToDateTime(values[13]);
                        producto.changedBy = values[14].ToString();
                        producto.idProveedor = Convert.ToInt32(values[15]);
                        producto.idCategoria = Convert.ToInt32(values[16]);
                        producto.idDescuento = Convert.ToInt32(values[17]);
                        producto.stock = Convert.ToInt32(values[18]);
                        producto.picturePath = values[19].ToString();
                        producto.pictureName = values[20].ToString();
                        producto.ranking = values[21].ToString();
                        producto.observaciones = values[22].ToString();
                        producto.precio = Convert.ToDecimal(values[23]);
                        producto.picturePath1 = values[24].ToString();
                        producto.picturePath2 = values[25].ToString();
                        producto.picturePath3 = values[26].ToString();

                        productos.Add(producto);
                    }
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
