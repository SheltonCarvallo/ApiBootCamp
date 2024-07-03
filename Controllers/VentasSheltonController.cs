using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentasSheltonController : Controller
    {
        private readonly IVentasShelton _ventasShelton;

        public VentasSheltonController(IVentasShelton ventasShelton)
        {
            this._ventasShelton = ventasShelton;
        }

        [HttpGet]
        [Route("GetAnnualSales")]
        public async Task<RespuestaModel> GetAnnualSales(DateTime year)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                respuesta = await _ventasShelton.GetAnnualSales(year);
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }
    }
}
