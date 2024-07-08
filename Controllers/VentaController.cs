using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : Controller
       
    {
        private readonly IVenta _venta;
        private ControlError Log = new ControlError();


        public VentaController(IVenta venta)
        {
            this._venta = venta;
        }

        [HttpGet]
        [Route("GetVenta")]
        public async Task<RespuestaModel> GetVenta(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.GetVenta(numFactura, date, vendedor, precio, estado, sucursal);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "GetVenta", ex.Message);
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
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "GetClientesByDate", ex.Message);
            }
            return respuesta;
        }


        [HttpPost]
        [Route("PostVenta")]

        public async Task<RespuestaModel> PostVenta([FromBody] Venta venta)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.PostVenta(venta);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "PostVenta", ex.Message);
            }
            return respuesta;
        }


        [HttpPut]
        [Route("PutVenta")]

        public async Task<RespuestaModel> PutVenta([FromBody] Venta venta)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.PutVenta(venta);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "PutVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetVentaReport")]
        public async Task<RespuestaModel> GetVentaReport(double precio)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.GetVentaReport(precio);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "GetVentaReport", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetCleintesReport")]
        public async Task<RespuestaModel> GetCleintesReport()
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _venta.GetCleintesReport();
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VentaController", "GetCleintesReport", ex.Message);
            }
            return respuesta;

        }
    }
}
