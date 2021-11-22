using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Promocion> listapromociones = new List<Promocion>();
            listapromociones = (List<Promocion>)PromocionBLL.GetAll();
            return Ok(listapromociones);
        }

        [HttpGet("{id}")]

        public IActionResult Get(Guid id)
        {
            List<Promocion> listapromociones = new List<Promocion>();
            listapromociones = (List<Promocion>)PromocionBLL.GetOne(id);
            return Ok(listapromociones);
        }


        [HttpPost]
        public IActionResult Add(Promocion promocion)
        {
            PromocionBLL.Current.Add(promocion);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Promocion promocion)
        {
            PromocionBLL.Current.Update(promocion);
            return Ok();
        }

    }
}
