using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.INTEGRIDAD
{
    public static class IntegridadDAL
    {

        //Conexión Base de datos Servicios
        private static string cnnSeguridad = ApplicationSettings.Current.connSeguridadLocal;

        //Statements
        private static string UpdateDVV
        {
            get => "UPDATE [dbo].[Setting] SET valor = @valor where tipo = 'DVV'";
        }
        private static string GetDVV
        {
            get => "SELECT COUNT(idsettings) FROM[dbo].[Setting] WHERE valor = @valor AND tipo = @DVV";
        }

        private static string GetCurrentDVV
        {
            get => "SELECT valor FROM [dbo].[Setting]";
        }

        public static void ActualizarDVV(decimal dvv)
        {

            using (SqlConnection sqlConn = new SqlConnection(cnnSeguridad))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(UpdateDVV, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@valor", dvv);

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

        public static bool LeerDVV(decimal dvv)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnSeguridad))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(GetDVV, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("valor", dvv);
                        cmd.Parameters.AddWithValue("tipo", "DVV");

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

        public static decimal LeerDVV()
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnSeguridad))
            {
                try
                {
                    sqlConn.Open();

                    decimal dvv = 0;

                    using (var dr = SqlHelper.ExecuteReader(GetCurrentDVV, CommandType.Text))
                    {
                        Object[] values = new Object[dr.FieldCount];

                        while (dr.Read())
                        {
                            dr.GetValues(values);
                            
                            dvv = Convert.ToDecimal(values[0]);
                        }

                        return (dvv);
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
