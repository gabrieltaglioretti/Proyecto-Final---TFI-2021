using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BLL;
using System;
using SERVICIOS.BACKUP.DOMINIO;
using SERVICIOS.BACKUP.BLL;
using System.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespaldoController : ControllerBase
    {


        [HttpPost]
        public IActionResult Add(Backup backup)
        {

            BackupBLL.BackUp(backup);
            return Ok();
        }
        

    }
}
