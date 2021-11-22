using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {

        [HttpPost]
        public IActionResult Add(Carrito carrito)
        {
            CarritoBLL.Current.Add(carrito);
            return Ok();

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Carrito> listacarritos = new List<Carrito>();
            listacarritos = (List<Carrito>)CarritoBLL.GetAll();
            return Ok(listacarritos);
        }

        [HttpGet("{id}")]
        
        public IActionResult Get(int id)
        {
            List<Carrito> listacarritos = new List<Carrito>();
            listacarritos = (List<Carrito>)CarritoBLL.GetOne(id);
            return Ok(listacarritos);
        }


        [HttpPut]
        public IActionResult Edit(Carrito carrito)
        {
            CarritoBLL.Current.Update(carrito);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CarritoBLL.Current.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}
