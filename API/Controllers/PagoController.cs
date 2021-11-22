using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOMAIN;
using BLL;
using System;
using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System.Threading.Tasks;
using SERVICIOS;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pago> pagos = new List<Pago>();
            pagos = (List<Pago>)PagoBLL.Current.GetAll();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            List<Pago> listapagos = new List<Pago>();
            listapagos = (List<Pago>)PagoBLL.GetOne(id);
            return Ok(listapagos);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllAsync(Item item)
        {
            MercadoPagoConfig.AccessToken = ApplicationSettings.Current.AccessTokenMP;
            // Crea el objeto de request de la preference
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Title = item.title,
                        Quantity = item.quantity,
                        CurrencyId = "ARS",
                        UnitPrice = item.unit_price,
                    },
                },
                Shipments = new PreferenceShipmentsRequest
                {
                    Cost = 999,
                    Mode = "not_specified",
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://localhost:44362/Gracias/"+ item.id, 
                    Failure = "https://localhost:44362/Gracias/" + item.id,
                    Pending = "https://localhost:44362/Gracias/" + item.id,
                },
                AutoReturn = "approved",


            };            
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);

            Pago pago = new Pago();
            pago.idPago = preference.Id;
            pago.FechaHora = DateTime.Now;
                
            PagoBLL.Current.Add(pago);

            return Ok(pago.idPago);//preference
        }


        [HttpPut]
        public IActionResult Edit(Pago pago)
        {
            PagoBLL.Current.Update(pago);
            return Ok();
        }

    }
}
