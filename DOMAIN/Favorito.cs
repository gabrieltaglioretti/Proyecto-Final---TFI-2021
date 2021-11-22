using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{
    public class Favorito
    {
        public Guid IdFavorito { get; set; }

        List<Producto> productos = new List<Producto>();

    }
}
