using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN
{
    public class Pago
    {
        public string idPago{ get; set; }
        public string producto { get; set; }
        public string cantidad { get; set; }
        public string precio { get; set; }

        public string Observaciones { get; set; }
        public DateTime FechaHora { get; set; }
        public string MedioPago { get; set; }
        public string Titular { get; set; }

    }


}
