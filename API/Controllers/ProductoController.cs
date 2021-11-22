using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Producto> listaproductos = new List<Producto>();
            listaproductos = (List<Producto>)ProductoBLL.GetAll();
            return Ok(listaproductos);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            List<Producto> listaproductos = new List<Producto>();
            listaproductos = (List<Producto>)ProductoBLL.GetOne(id);
            return Ok(listaproductos);
        }


        [HttpPost]
        public IActionResult Add(Producto producto)
        {
            ProductoBLL.Current.Add(producto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Producto producto)
        {
            ProductoBLL.Current.Update(producto);
            return Ok();
        }

    }
}
