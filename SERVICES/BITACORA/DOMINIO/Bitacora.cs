using System;

namespace SERVICIOS.BITACORA.DOMINIO
{
    public class Bitacora
    
    {
        public enum Severidad {NONE, ERROR, INFO, WARNING}
        public enum TipoLog {USUARIO, SISTEMA, NEGOCIO}
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
        public Severidad severidad { get; set; }
        public TipoLog tipo { get; set; }
        public int Id_Log { get; set; }

    }
}
