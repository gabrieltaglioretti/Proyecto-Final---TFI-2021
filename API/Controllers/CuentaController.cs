using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Cuenta> listacuentas = new List<Cuenta>();
            listacuentas = (List<Cuenta>)CuentaBLL.GetAll();
            return Ok(listacuentas);
        }

        [HttpGet("{id}")]
        
        public IActionResult Get(Guid id)
        {
            List<Cuenta> listacuentas = new List<Cuenta>();
            listacuentas = (List<Cuenta>)CuentaBLL.GetOne(id);
            return Ok(listacuentas);
        }


        [HttpPost]
        public IActionResult Add(Cuenta cuenta)
        {
            CuentaBLL.Current.Add(cuenta);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Cuenta cuenta)
        {
            CuentaBLL.Current.Update(cuenta);
            return Ok();
        }

    }
}
