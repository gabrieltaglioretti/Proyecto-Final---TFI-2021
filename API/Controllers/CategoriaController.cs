using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Categoria> listacategorias = new List<Categoria>();
            listacategorias = (List<Categoria>)CategoriaBLL.GetAll();
            return Ok(listacategorias);
        }

        [HttpGet("{id}")]
        
        public IActionResult Get(Guid id)
        {
            List<Categoria> listacategorias = new List<Categoria>();
            listacategorias = (List<Categoria>)CategoriaBLL.GetOne(id);
            return Ok(listacategorias);
        }


        [HttpPost]
        public IActionResult Add(Categoria categoria)
        {
            CategoriaBLL.Current.Add(categoria);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Categoria categoria)
        {
            CategoriaBLL.Current.Update(categoria);
            return Ok();
        }

    }
}
