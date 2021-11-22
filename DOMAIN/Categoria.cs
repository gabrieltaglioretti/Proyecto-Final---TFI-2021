using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{
    public class Categoria
    {
        public Guid idCategoria { get; set; }
        public List<Producto> productos { get; set; }

    }
}
