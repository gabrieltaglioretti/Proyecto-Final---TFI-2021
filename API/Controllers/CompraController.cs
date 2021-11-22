using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Compra> listacompras = new List<Compra>();
            listacompras = (List<Compra>)CompraBLL.GetAll();
            return Ok(listacompras);
        }

        [HttpGet("{id}")]
        
        public IActionResult Get(Guid id)
        {
            List<Compra> listacompras = new List<Compra>();
            listacompras = (List<Compra>)CompraBLL.GetOne(id);
            return Ok(listacompras);
        }

        [HttpPost]
        public IActionResult Add(Compra compra)
        {
            CompraBLL.Current.Add(compra);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Compra compra)
        {
            CompraBLL.Current.Update(compra);
            return Ok();
        }


    }
}
