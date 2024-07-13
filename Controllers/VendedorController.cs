using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VendedorController : Controller
    {
        private readonly IVendedor _vendedor;
        private ControlError Log = new ControlError();

        public VendedorController(IVendedor vendedor)
        {
            this._vendedor = vendedor;
        }

        [HttpGet]
        [Route("GetVendedor")]
        public async Task<RespuestaModel> GetVendedor(double? id, string? estado)
        {
            RespuestaModel respuesta = new();

            try
            {
                respuesta = await _vendedor.GetVendedor(id, estado);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VendedorController",ex.Message, "GetVendedor");
            }

            return respuesta;
        }

        [HttpPost]
        [Route("PostVendedor")]
        public async Task<RespuestaModel> PostVendedor([FromBody] Vendedor vendedor)
        {
            RespuestaModel respuesta = new();

            try
            {
                respuesta = await _vendedor.PostVendedor(vendedor);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VendedorController", ex.Message, "PutVendedor");
            }

            return respuesta;
        }

        [HttpPut]
        [Route("PutVendedor")]
        public async Task<RespuestaModel> PutVendedor([FromBody] Vendedor vendedor)
        {
            RespuestaModel respuesta = new();

            try
            {
                respuesta = await _vendedor.PutVendedor(vendedor);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VendedorController", ex.Message, "PutVendedor");
            }

            return respuesta;
        }

        [Route("DeleteVendedor")]
        public async Task<RespuestaModel> DeleteVendedor(double id)
        {
            RespuestaModel respuesta = new();

            try
            {
                respuesta = await _vendedor.DeleteVendedor(id);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("VendedorController", ex.Message, "PutVendedor");
            }

            return respuesta;
        }

    }
}
