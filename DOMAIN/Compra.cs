using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{
    public class Compra
    {
        public Guid IdCompra { get; set; }
        public List<Producto> productos { get; set; }
        public Guid IdUsuario { get; set; }


        public Compra()
        {
            List<Compra> compra = new List<Compra>();
            IdCompra = Guid.Empty;
            IdUsuario = Guid.Empty;
        }

    }




}
