using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SERVICIOS.SEGURIDAD.DAL
{
    internal sealed class Familia_FamiliaDAL
    {
        #region Singleton
        private readonly static Familia_FamiliaDAL _instance = new Familia_FamiliaDAL();

        public static Familia_FamiliaDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private Familia_FamiliaDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAsignadas
        {
            get => "SELECT A.IdFamiliaHijo, B.Familia " +
                "FROM [dbo].[Familia_Familia] A " +
                "INNER JOIN [dbo].[Familia] B on B.IdFamilia = A.IdFamiliaHijo " +
                "WHERE A.IdFamilia = @IdFamilia";
        }
        private static string SelectDisponibles
        {
            get => "SELECT A.IdFamilia, A.Familia " +
                "FROM [dbo].[Familia] A " +
                "WHERE A.IdFamilia not in (SELECT B.IdFamiliaHijo FROM Familia_Familia B WHERE B.IdFamilia = @IdFamilia)";
        }
        private static string Insert
        {
            get => "INSERT INTO [dbo].[Familia_Familia] ([IdFamilia],[IdFamiliaHijo]) VALUES (@IdFamilia, @IdFamiliaHijo)";
        }
        private static string Delete
        {
            get => "DELETE [dbo].[Familia_Familia] WHERE IdFamilia = @IdFamilia AND IdFamiliaHijo = @IdFamiliaHijo";
        }
        #endregion


        public IEnumerable<Familia> GetFamiliasAsignadas(string familiaId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdFamilia", familiaId));

                List<Familia> familias = new List<Familia>();

                using (var dr = SqlHelper.ExecuteReader(SelectAsignadas, CommandType.Text, p.ToArray()))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        //Adapta los valores "values" que vienen en el array a string y lo agrego a la lista
                        Familia familia = new Familia();
                        familia.idfamilia = values[0].ToString();
                        familia.nombre = values[1].ToString();

                        familias.Add(familia);
                    }
                }
                return familias;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Familia> GetFamiliasDisponibles(string familiaId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdFamilia", familiaId));

                List<Familia> familias = new List<Familia>();

                using (var dr = SqlHelper.ExecuteReader(SelectDisponibles, CommandType.Text, p.ToArray()))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Familia familia = new Familia();
                        familia.idfamilia = values[0].ToString();
                        familia.nombre = values[1].ToString();

                        familias.Add(familia);
                    }
                }
                return familias;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddFamiliaFamilia(Familia familia, Familia familiaHijo)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", familia.idfamilia));
                p.Add(new SqlParameter("@IdFamiliaHijo", familiaHijo.idfamilia));

                SqlHelper.ExecuteNonQuery(Insert, CommandType.Text, p.ToArray());

            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteFamiliaFamilia(Familia familia, Familia familiaHijo)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", familia.idfamilia));
                p.Add(new SqlParameter("@IdFamiliaHijo", familiaHijo.idfamilia));

                SqlHelper.ExecuteNonQuery(Delete, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
