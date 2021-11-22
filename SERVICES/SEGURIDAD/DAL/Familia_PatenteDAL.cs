using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SERVICIOS.SEGURIDAD.DAL
{
    internal sealed class Familia_PatenteDAL
    {
        #region Singleton
        private readonly static Familia_PatenteDAL _instance = new Familia_PatenteDAL();

        public static Familia_PatenteDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private Familia_PatenteDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAsignadas
        {
            get => "SELECT A.IdPatente, B.Patente " +
                "FROM [dbo].[Familia_Patente] A " +
                "INNER JOIN [dbo].[Patente] B on B.IdPatente = A.IdPatente " +
                "WHERE A.IdFamilia = @IdFamilia";
        }
        private static string SelectDisponibles
        {
            get => "SELECT A.IdPatente, A.Patente " +
                "FROM [dbo].[Patente] A " +
                "WHERE A.IdPatente not in (SELECT B.IdPatente FROM Familia_Patente B WHERE B.IdFamilia = @IdFamilia)";
        }
        private static string Insert
        {
            get => "INSERT INTO [dbo].[Familia_Patente] ([IdFamilia],[IdPatente]) VALUES (@IdFamilia, @IdPatente)";
        }
        private static string Delete
        {
            get => "DELETE [dbo].[Familia_Patente] WHERE IdFamilia = @IdFamilia AND IdPatente = @IdPatente";
        }
        #endregion

        public IEnumerable<Patente> GetPatentesAsignadas(string familiaId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdFamilia", familiaId));

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

        public IEnumerable<Patente> GetPatentesDisponibles(string familiaId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdFamilia", familiaId));

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

        public void AddFamiliaPatente(Familia familia, Patente patente)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", familia.idfamilia));
                p.Add(new SqlParameter("@IdPatente", patente.idfamilia));

                SqlHelper.ExecuteNonQuery(Insert, CommandType.Text, p.ToArray());

            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteFamiliaPatente(Familia familia, Patente patente)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", familia.idfamilia));
                p.Add(new SqlParameter("@IdPatente", patente.idfamilia));

                SqlHelper.ExecuteNonQuery(Delete, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
