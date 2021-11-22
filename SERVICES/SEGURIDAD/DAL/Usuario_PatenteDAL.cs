
using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SERVICIOS.SEGURIDAD.DAL
{
    internal sealed class Usuario_PatenteDAL
    {

        #region Singleton
        private readonly static Usuario_PatenteDAL _instance = new Usuario_PatenteDAL();

        public static Usuario_PatenteDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private Usuario_PatenteDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAsignadas
        {
            get => "SELECT A.IdPatente, B.Patente " +
                "FROM [dbo].[Usuario_Patente] A " +
                "INNER JOIN [dbo].[Patente] B on B.IdPatente = A.IdPatente " +
                "WHERE A.IdUsuario = @IdUsuario";
        }
        private static string SelectDisponibles
        {
            get => "SELECT A.IdPatente, A.Patente " +
                "FROM [dbo].[Patente] A " +
                "WHERE A.IdPatente not in (SELECT B.IdPatente FROM Usuario_Patente B WHERE B.IdUsuario = @IdUsuario)";
        }
        private static string Insert
        {
            get => "INSERT INTO [dbo].[Usuario_Patente] ([IdUsuario],[IdPatente]) VALUES (@IdUsuario, @IdPatente)";
        }
        private static string Delete
        {
            get => "DELETE [dbo].[Usuario_Patente] WHERE IdUsuario = @IdUsuario AND IdPatente = @IdPatente";
        }
        #endregion


        public IEnumerable<Patente> GetPatentesAsignadas(string userId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdUsuario", userId));

                List<Patente> patentes = new List<Patente>();

                using (var dr = SqlHelper.ExecuteReader(SelectAsignadas, CommandType.Text, p.ToArray()))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Patente patente = new Patente();
                        patente.idfamilia = values[0].ToString();
                        patente.nombre = values[1].ToString();

                        patentes.Add(patente);
                    }
                }
                return patentes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Patente> GetPatentesDisponibles(string userId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdUsuario", userId));

                List<Patente> patentes = new List<Patente>();

                using (var dr = SqlHelper.ExecuteReader(SelectDisponibles, CommandType.Text, p.ToArray()))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Patente patente = new Patente();
                        patente.idfamilia = values[0].ToString();
                        patente.nombre = values[1].ToString();

                        patentes.Add(patente);
                    }
                }
                return patentes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddUsuarioPatente(string userId, string patenteId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdUsuario", userId));
                p.Add(new SqlParameter("@IdPatente", patenteId));

                SqlHelper.ExecuteNonQuery(Insert, CommandType.Text, p.ToArray());

            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteUsuarioPatente(string userId, string patenteId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdUsuario", userId));
                p.Add(new SqlParameter("@IdPatente", patenteId));

                SqlHelper.ExecuteNonQuery(Delete, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
