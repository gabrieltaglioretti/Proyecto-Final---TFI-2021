using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// SERIALIZACION
/// </summary>
namespace SERVICIOS.BITACORA.DOMINIO
{
    [Serializable]
    public class BitacoraCritica
    {
        public enum Severidad { NONE, ERROR, INFO, WARNING }
        public enum TipoLog { USUARIO, SISTEMA, NEGOCIO }
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
        public Severidad severidad { get; set; }
        public TipoLog tipo { get; set; }
       
        public BitacoraCritica()
        {

        }
    }


}
