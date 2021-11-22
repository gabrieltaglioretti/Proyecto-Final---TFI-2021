using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{

    public class Cuenta
    {
        public int idCuenta { get; set; }
        public string correo { get; set; }
        public string sesion { get; set; }


        public Cuenta()
        {
            this.sesion = Guid.NewGuid().ToString();

        }
        

    }


}



