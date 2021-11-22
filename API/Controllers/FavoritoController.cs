using DOMAIN;
using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Favorito> listafavoritos = new List<Favorito>();
            listafavoritos = (List<Favorito>)FavoritoBLL.GetAll();
            return Ok(listafavoritos);

        }

        [HttpPost]
        public IActionResult Add(Favorito favorito)
        {
            FavoritoBLL.Current.Add(favorito);

            return Ok();
        }



        [HttpPut]
        public IActionResult Edit(Favorito favorito)
        {
            FavoritoBLL.Current.Update(favorito);
            return Ok();
        }

    }
}
