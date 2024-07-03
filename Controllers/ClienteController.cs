using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        public readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<RespuestaModel> GetCliente(double clienteId, string? nombreCliente, double identificacion)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _cliente.GetCliente(clienteId, nombreCliente, identificacion);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }


        [HttpPost]
        [Route("PostCliente")]
        public async Task<RespuestaModel> PostCliente(Cliente cliente)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _cliente.PostCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCliente")]
        public async Task<RespuestaModel> PutCliente(Cliente cliente)
        {
            RespuestaModel respuesta = new RespuestaModel();
                
            try
            {
                respuesta = await _cliente.PutCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

    }
}
