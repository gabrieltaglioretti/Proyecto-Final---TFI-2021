using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{
    public class CarritoItem
    {
        public int idCarritoItem { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime changedOn { get; set; }
        public string changedBy { get; set; }

        //preguntar si esto deberia ir aca
        public decimal Total { get {return producto.precio * cantidad;}}

    }

}
