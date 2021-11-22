using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SERVICIOS.SEGURIDAD.DAL
{
    internal sealed class PatenteDAL
    {

        #region Singleton
        private readonly static PatenteDAL _instance = new PatenteDAL();

        public static PatenteDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAll
        {
            get => "SELECT IdPatente, Patente FROM [dbo].[Patente]";
        }
        private static string Insert
        {
            get => "INSERT INTO [dbo].[Patente] ([IdPatente],[Patente]) VALUES (@IdPatente, @Patente)";
        }
        private static string Update
        {
            get => "UPDATE [dbo].[Patente] SET Patente = @Patente WHERE IdPatente = @IdPatente";
        }
        private static string Delete
        {
            get => "DELETE [dbo].[Patente] WHERE IdPatente = @IdPatente";
        }
        #endregion

        public IEnumerable<Patente> GetAll()
        {
            try
            {
                List<Patente> patentes = new List<Patente>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
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

        public void AddPatente(Patente patente)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdPatente", patente.idfamilia));
                p.Add(new SqlParameter("@Patente", patente.nombre));
                
                SqlHelper.ExecuteNonQuery(Insert, CommandType.Text, p.ToArray());

            }
            catch (Exception ex)
            {
            }
        }

        public void UpdatePatente(Patente patente)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdPatente", patente.idfamilia));
                p.Add(new SqlParameter("@Patente", patente.nombre));

                SqlHelper.ExecuteNonQuery(Update, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {
            }
        }


        public void DeletePatente(Patente patente)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdPatente", patente.idfamilia));

                SqlHelper.ExecuteNonQuery(Delete, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {
            }
        }

    }
}
