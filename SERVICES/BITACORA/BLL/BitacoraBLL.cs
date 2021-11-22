using System;
using System.Collections.Generic;
using SERVICIOS.BITACORA.DOMINIO;
using SERVICIOS.BITACORA.DAL;


namespace SERVICIOS.BITACORA.BLL
{
    public static class BitacoraBLL
    {

        public static void Grabar(Bitacora bitacora)
        {
            try
            {

                BitacoraDAL.Grabar(bitacora);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public static IEnumerable<Bitacora> Leer()
        {
            try
            {
                return BitacoraDAL.Leer();                 
            }
            catch (Exception)
            {
                throw;
            }            
        }
       
        public static IEnumerable<Bitacora> LeerFiltro(string filtro1, string filtro2)
        {
            try
            {
                return BitacoraDAL.LeerFiltro(filtro1,filtro2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void GrabarBitacoraCritica(BitacoraCritica bitacoracritica)
        {
            try
            {
                BitacoraDAL.GrabarSerializado(bitacoracritica);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static IEnumerable<BitacoraCritica> LeerBitacoraCritica()
        {
            try
            {
                return BitacoraDAL.LeerSerializado();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
