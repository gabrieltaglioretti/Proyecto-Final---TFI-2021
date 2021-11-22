using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SERVICIOS.SEGURIDAD.DAL
{
    internal sealed class Usuario_FamiliaDAL
    {

        #region Singleton
        private readonly static Usuario_FamiliaDAL _instance = new Usuario_FamiliaDAL();

        public static Usuario_FamiliaDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private Usuario_FamiliaDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAsignadas
        {
            get => "SELECT A.IdFamilia, B.Familia " +
                "FROM [dbo].[Usuario_Familia] A " +
                "INNER JOIN [dbo].[Familia] B on B.IdFamilia = A.IdFamilia " +
                "WHERE A.IdUsuario = @IdUsuario";
        }
        private static string SelectDisponibles
        {
            get => "SELECT A.IdFamilia, A.Familia " +
                "FROM [dbo].[Familia] A " +
                "WHERE A.IdFamilia not in (SELECT B.IdFamilia FROM Usuario_Familia B WHERE B.IdUsuario = @IdUsuario)";
        }
        private static string Insert
        {
            get => "INSERT INTO [dbo].[Usuario_Familia] ([IdUsuario],[IdFamilia]) VALUES (@IdUsuario, @IdFamilia)";
        }
        private static string Delete
        {
            get => "DELETE [dbo].[Usuario_Familia] WHERE IdUsuario = @IdUsuario AND IdFamilia = @IdFamilia";
        }
        #endregion


        public IEnumerable<Familia> GetFamiliasAsignadas(string userId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdUsuario", userId));

                List<Familia> familias = new List<Familia>();

                using (var dr = SqlHelper.ExecuteReader(SelectAsignadas, CommandType.Text, p.ToArray()))
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

        public IEnumerable<Familia> GetFamiliasDisponibles(string userId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();
                p.Add(new SqlParameter("@IdUsuario", userId));

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

        public void AddUsuarioFamilia(string userId, string familiaId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdUsuario", userId));
                p.Add(new SqlParameter("@IdFamilia", familiaId));

                SqlHelper.ExecuteNonQuery(Insert, CommandType.Text, p.ToArray());

            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteUsuarioFamilia(string userId, string familiaId)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdUsuario", userId));
                p.Add(new SqlParameter("@IdFamilia", familiaId));

                SqlHelper.ExecuteNonQuery(Delete, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
