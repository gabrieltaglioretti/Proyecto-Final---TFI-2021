using SERVICIOS.SEGURIDAD.DOMINIO;
using System;
using System.Collections.Generic;

namespace SERVICIOS.SEGURIDAD.DOMINIO
{

    public class Usuario
    {
        public string idUsuario { get; set; }
        public string nombreusuario { get; set; }
        public string contraseña { get; set; }
        public string estado { get; set; }
        public decimal DVH { get; set; }
        public string apellido { get; set; }
        public string departamento { get; set; }
        public Byte[] foto { get; set; }
        public string correo { get; set; }
        public string idioma { get; set; }
        public string centrocostos { get; set; }




        public Usuario()
        {
            this.idUsuario = Guid.NewGuid().ToString();
          
        }

        public Usuario(string username, string password)
        {
            idUsuario = Guid.NewGuid().ToString();
            this.nombreusuario = username;
            this.contraseña = password;
        }





    }

}