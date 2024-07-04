using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;

        public VentaController(IVenta venta)
        {
            this._venta = venta;
        }

        [HttpGet]
        [Route("GetClientes")]
        public async Task<RespuestaModel> GetClientes(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.GetClientes(numFactura, date, vendedor, precio, estado, sucursal);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetClientesByDate")]

        public async Task<RespuestaModel> GetClientesByDate(DateTime date)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.GetClientesByDate(date);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }


        /*[HttpPost]
        [Route("PostVenta")]

        public async Task<RespuestaModel> PostVenta([FromBody] venta)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.GetClientesByDate(date);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }*/
    }
    
}
