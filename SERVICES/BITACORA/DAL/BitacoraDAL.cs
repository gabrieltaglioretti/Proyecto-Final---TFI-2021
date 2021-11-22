using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using SERVICIOS.Tools;
using SERVICIOS.BITACORA.DOMINIO;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SERVICIOS.BITACORA.DAL
{
    internal class BitacoraDAL    {

        private static string cnnSeguridad = ApplicationSettings.Current.connSeguridadDB;



        #region Statements        
        private static string InsertStatement
        //ajustar insert en base a la tabla de bitacora
        {
            get => "INSERT INTO [dbo].[Bitacora] "
                + "(Fecha, Mensaje, Usuario, Id_Severidad, Id_Tipo) "
                + "VALUES (@Fecha, @Mensaje, @Usuario, @Id_Severidad, @Id_Tipo)";

        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[Bitacora]";
        }


        public static string SelectFiltro
  
        {
            get => "SELECT * FROM [dbo].[Bitacora] where Id_Severidad = '";
        }

        #endregion

                
        public static void Grabar(Bitacora bitacora)
        {
            using (SqlConnection sqlConn = new SqlConnection(cnnSeguridad))
            {
                try
                {
                    sqlConn.Open();

                    using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("Fecha", bitacora.fecha);
                        cmd.Parameters.AddWithValue("Mensaje", bitacora.mensaje);                        
                        cmd.Parameters.AddWithValue("Usuario", bitacora.usuario);
                        cmd.Parameters.AddWithValue("Id_Severidad", bitacora.severidad);
                        cmd.Parameters.AddWithValue("Id_Tipo", bitacora.tipo);

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

        
        public static IEnumerable<Bitacora> Leer()
        {
            try
            {
                List<Bitacora> bitacoras = new List<Bitacora>();
               
                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Bitacora bitacora = new Bitacora();

                        bitacora.Id_Log= Convert.ToInt32(values[0]);
                        bitacora.fecha = Convert.ToDateTime(values[1]);
                        bitacora.mensaje = values[2].ToString();
                        bitacora.usuario = values[3].ToString();
                        bitacora.severidad = (Bitacora.Severidad)values[4];                
                        bitacora.tipo = (Bitacora.TipoLog)values[5];                       

                        bitacoras.Add(bitacora);                        
                    }
                }
                return bitacoras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Bitacora> LeerFiltro(string filtro1, string filtro2)
        {           
            {
                try
                {
                   List<Bitacora> bitacorasfiltro = new List<Bitacora>();

                   using (var dr = SqlHelper.ExecuteReader(SelectFiltro + filtro1 + "' and Id_Tipo = '"+ filtro2 + "'", CommandType.Text))

                    {
                        Object[] values = new Object[dr.FieldCount];

                        while (dr.Read())
                        {
                            dr.GetValues(values);

                            Bitacora bitacora = new Bitacora();

                            bitacora.Id_Log = Convert.ToInt32(values[0]);
                            bitacora.fecha = Convert.ToDateTime(values[1]);
                            bitacora.mensaje = values[2].ToString();
                            bitacora.usuario = values[3].ToString();
                            bitacora.severidad = (Bitacora.Severidad)values[4];
                            bitacora.tipo = (Bitacora.TipoLog)values[5];

                            bitacorasfiltro.Add(bitacora);
                        }
                    }

                    return bitacorasfiltro;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            

        }

        public static void GrabarSerializado(BitacoraCritica bitacoracritica)
            {
            {
                try
                {
                    using (FileStream stream = new FileStream(@"BITACORA_CRITICA\serialized.bin", FileMode.Append))
                    {
                        BinaryFormatter Formatter = new BinaryFormatter();
                        Formatter.Serialize(stream, bitacoracritica);
                        stream.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            } 
        }

        public static IEnumerable<BitacoraCritica> LeerSerializado()

        {

            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            List<BitacoraCritica> criticos = new List<BitacoraCritica>();
            Stream stream = new FileStream(@"BITACORA_CRITICA\BitacoraCritica.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            while (stream.Position < stream.Length)
            {
                BitacoraCritica obj = (BitacoraCritica)formatter.Deserialize(stream);
                criticos.Add(obj);
            }

            return criticos;
        }

    }
}

