using SERVICIOS.SEGURIDAD.DAL;
using SERVICIOS.SEGURIDAD.DOMINIO;
using System;
using System.Collections.Generic;

namespace SERVICIOS.SEGURIDAD.BLL
{
    public sealed class PatenteBLL
    {

        #region Singleton
        private readonly static PatenteBLL _instance = new PatenteBLL();

        public static PatenteBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteBLL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion

        public IEnumerable<Patente> GetAll()
        {
            try
            {
                return PatenteDAL.Current.GetAll();
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
                PatenteDAL.Current.AddPatente(patente);

            }
            catch (Exception ex)
            {
            }
        }

        public void UpdatePatente(Patente patente)
        {
            try
            {
                PatenteDAL.Current.UpdatePatente(patente);

            }
            catch (Exception ex)
            {

            }
        }

        public void DeletePatente(Patente patente)
        {
            try
            {
                PatenteDAL.Current.DeletePatente(patente);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
