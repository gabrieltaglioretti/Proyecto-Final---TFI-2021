using System;

#nullable disable

namespace DOMAIN
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public string idUsuario { get; set; }
        public EstadoPedido estado { get; set; }
        public enum EstadoPedido { PENDIENTE_PAGO, EN_PREPARACION, DEMORADO, ENVIADO, ENTREGADO, FINALIZADO }
        public int idCarrito { get; set; }
        public DateTime fechaHora { get; set; }

    }


}
