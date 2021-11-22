using DOMAIN;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pedido> listapedidos = new List<Pedido>();
            listapedidos = (List<Pedido>)PedidoBLL.GetAll();
            return Ok(listapedidos);
        }

        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            List<Pedido> listapedidos = new List<Pedido>();
            listapedidos = (List<Pedido>)PedidoBLL.GetOne(id);
            return Ok(listapedidos);
        }


        [HttpPost]
        public IActionResult Add(Pedido pedido)
        {
            PedidoBLL.Current.Add(pedido);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Pedido pedido)
        {
            PedidoBLL.Current.Update(pedido);
            return Ok();
        }

    }
}
