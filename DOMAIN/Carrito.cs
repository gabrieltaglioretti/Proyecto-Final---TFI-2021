using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{
    public class Carrito
    {
        public int idCarrito { get; set; }
        public Estado estado { get; set; }
        public string idSesion { get; set; }
        public List<CarritoItem> carritoItems { get; set; }
        public enum Estado { ACTIVO, CANCELADO, PROCESADO };
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime changedOn { get; set; }
        public string changedBy { get; set; }

        //VALIDAR SI ESTO VA ACA
        public Decimal Total { get { decimal total = (decimal)0.0;
        foreach (var item in carritoItems) {total += item.Total;} return total;}}


        public DateTime LastAccessed { get; set; }
        public int TimeToLiveInSeconds { get; set; } = 30; // default


        public Carrito()
        {
            //this.idCarrito = Guid.NewGuid().ToString();
            List<CarritoItem> carritoItems = new List<CarritoItem>();

        }

    }


}

