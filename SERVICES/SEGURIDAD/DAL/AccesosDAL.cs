using SERVICIOS.SEGURIDAD.DOMINIO;
using SERVICIOS.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.SEGURIDAD.DAL
{

    internal sealed class AccesosDAL
    {
        #region Singleton
        private readonly static AccesosDAL _instance = new AccesosDAL();

        public static AccesosDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private AccesosDAL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        //Statements
        #region Statements
        private static string SelectAccesos
        {
            get => "SELECT IdPatente, Patente FROM [dbo].[VW_PATENTES] WHERE UserName = @UserName";
        }
        #endregion


        public List<Patente> GetAccesos(string userName)
        {
            try
            {
                List<Patente> patentes = new List<Patente>();

                List<SqlParameter> p = new List<SqlParameter>();

                p.Add(new SqlParameter("@UserName", userName));

                using (var dr = SqlHelper.ExecuteReader(SelectAccesos, CommandType.Text, p.ToArray()))
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
    }
}
