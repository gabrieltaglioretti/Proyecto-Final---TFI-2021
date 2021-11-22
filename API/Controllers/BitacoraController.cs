using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SERVICIOS.BITACORA.DOMINIO;
using SERVICIOS.BITACORA.BLL;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            List<Bitacora> listabitacora = new List<Bitacora>();
            listabitacora = (List<Bitacora>)BitacoraBLL.Leer();
            return Ok(listabitacora);

        }

        [HttpPost]
        public IActionResult Add(Bitacora bitacora)
        {
            BitacoraBLL.Grabar(bitacora);

            //BitacoraCritica bitacoraserializada = new BitacoraCritica();
            //bitacoraserializada.fecha = DateTime.Now;
            //BitacoraBLL.GrabarBitacoraCritica(bitacoraserializada);

            return Ok();
        }





    }
}
