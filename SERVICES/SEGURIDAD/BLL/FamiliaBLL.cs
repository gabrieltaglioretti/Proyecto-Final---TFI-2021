
using SERVICIOS.SEGURIDAD.DAL;
using SERVICIOS.SEGURIDAD.DOMINIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVICIOS.SEGURIDAD.BLL
{
    public sealed class FamiliaBLL
    {

        #region Singleton
        private readonly static FamiliaBLL _instance = new FamiliaBLL();

        public static FamiliaBLL Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliaBLL()
        {
            //Implent here the initialization of your singleton
        }
        #endregion


        public IEnumerable<Familia> GetAll()
        {
            try
            {
                return FamiliaDAL.Current.GetAll();
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
                FamiliaDAL.Current.AddFamilia(familia);
            }
            catch (Exception ex)
            {
            }
        }

        public void UpdateFamilia(Familia familia)
        {
            try
            {
                FamiliaDAL.Current.UpdateFamilia(familia);
            }
            catch (Exception ex)
            {
            }
        }


        public IEnumerable<Patente> GetPatentesAsignadas(string familiaId)
        {
            try
            {
                return Familia_PatenteDAL.Current.GetPatentesAsignadas(familiaId);
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
                return Familia_PatenteDAL.Current.GetPatentesDisponibles(familiaId);
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
                Familia_PatenteDAL.Current.AddFamiliaPatente(familia, patente);

            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteFamiliaPatente(Familia familia, Patente patente)
        {
            try
            {
                Familia_PatenteDAL.Current.DeleteFamiliaPatente(familia, patente);

            }
            catch (Exception ex)
            {

            }
        }


        public IEnumerable<Familia> GetFamiliasAsignadas(string familiaId)
        {
            try
            {
                return Familia_FamiliaDAL.Current.GetFamiliasAsignadas(familiaId);
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
                return Familia_FamiliaDAL.Current.GetFamiliasDisponibles(familiaId);
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
                Familia_FamiliaDAL.Current.AddFamiliaFamilia(familia, familiaHijo);

            }
            catch (Exception ex)
            {

            }
        }


        public void DeleteFamiliaFamilia(Familia familia, Familia familiaHijo)
        {
            try
            {
                Familia_FamiliaDAL.Current.DeleteFamiliaFamilia(familia, familiaHijo);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
