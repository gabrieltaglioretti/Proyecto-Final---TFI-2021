using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SERVICIOS.SEGURIDAD.DAL
{
    internal sealed class FamiliaDAL
    {

        #region Singleton
        private readonly static FamiliaDAL _instance = new FamiliaDAL();

        public static FamiliaDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliaDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAll
        {
            get => "SELECT IdFamilia, Familia FROM [dbo].[Familia]";
        }
        private static string Insert
        {
            get => "INSERT INTO [dbo].[Familia] ([IdFamilia],[Familia]) VALUES (@IdFamilia, @Familia)";
        }
        private static string Update
        {
            get => "UPDATE [dbo].[Familia] SET Familia = @Familia WHERE IdFamilia = @IdFamilia";
        }
        private static string Delete
        {
            get => "DELETE [dbo].[Familia] WHERE IdFamilia = @IdFamilia";
        }
        #endregion

        public IEnumerable<Familia> GetAll()
        {
            try
            {
                List<Familia> familias = new List<Familia>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        //Adapta los valores "values" que vienen en el array a un objeto Usuario
                        Familia familia= new Familia();
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

        public void AddFamilia(Familia familia)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", familia.idfamilia));
                p.Add(new SqlParameter("@Familia", familia.nombre));
                
                SqlHelper.ExecuteNonQuery(Insert, CommandType.Text, p.ToArray());

            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateFamilia(Familia familia)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", familia.idfamilia));
                p.Add(new SqlParameter("@Familia", familia.nombre));

                SqlHelper.ExecuteNonQuery(Update, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteFamilia(string idFamilia)
        {
            try
            {
                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@IdFamilia", idFamilia));

                SqlHelper.ExecuteNonQuery(Delete, CommandType.Text, p.ToArray());
            }
            catch (Exception ex)
            {

            }
        }
    }
}
