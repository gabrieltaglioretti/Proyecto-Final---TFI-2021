using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;

namespace SERVICIOS.SEGURIDAD.DAL
{
    public static class UsuarioDAL
    {
        //Conexión Servicios
        private static string cnnSeguridad = ApplicationSettings.Current.connSeguridadDB;


        //Statements
        private static string InsertStatement
        {
            get => "INSERT INTO [dbo].[Usuarios] ([IdUsuario],[Nombre],[Password],[Activo],[DVH],[Apellido],[Departamento],Foto, [Correo], CentroCostos) VALUES (@IdUsuario, @Nombre, @Password, @Activo, @DVH, @Apellido, @Departamento, @foto,  @Correo, @CentroCostos)";
        }

        private static string SelectCountStatement
        {
            get => "SELECT COUNT(IdUsuario) FROM [dbo].[Usuarios] where " +
                "Nombre = @Nombre AND Password = @Password";
        }

        private static string SelectAll
        {
            get => "SELECT IdUsuario, Nombre, Password, Activo, DVH, Apellido, Departamento, Foto, Correo, CentroCostos FROM Usuarios";
        }

        private static string SelectOne
        {
            get => "SELECT * FROM [dbo].[Usuarios] where Nombre = '";
        }


        

        public static bool BuscarUsuario(Usuario usuario)
        {

            using (SqlConnection sqlConn = new SqlConnection(cnnSeguridad))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(SelectCountStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("Nombre", usuario.nombreusuario);
                        cmd.Parameters.AddWithValue("Password", usuario.contraseña);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                            return false;

                        else
                            return true;
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

        public static IEnumerable<Usuario> GetAll()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Usuario usuario = new Usuario();

                        usuario.idUsuario = values[0].ToString();
                        usuario.nombreusuario = values[1].ToString();
                        usuario.contraseña = values[2].ToString();
                        usuario.estado = values[3].ToString();
                        usuario.DVH = Convert.ToDecimal(values[4]);
                        usuario.apellido = values[5].ToString();
                        usuario.departamento = values[6].ToString();
                        usuario.foto = (byte[])values[7];
                        usuario.correo = values[8].ToString();
                        usuario.centrocostos = values[9].ToString();

                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Usuario GetOne(string usuario)
        {
            try
            {
                Usuario user = new Usuario();

                using (var dr = SqlHelper.ExecuteReader(SelectOne + usuario + "'", CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        user.idUsuario = values[0].ToString();
                        user.nombreusuario = values[1].ToString();
                        user.contraseña = values[2].ToString();
                        user.estado = values[3].ToString();
                        user.DVH = Convert.ToInt32(values[4]);
                        user.apellido = values[5].ToString();
                        user.departamento = values[6].ToString();
                        user.foto = (byte[])values[7];
                        user.correo = values[8].ToString();
                        user.centrocostos = values[9].ToString();

                    }
                }

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}


   
