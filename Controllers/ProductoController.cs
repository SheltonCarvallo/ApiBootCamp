using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]  //Estas dos lineas permiten decir de manera mas clara a nuestro controlador que es un controlador API, que solamente va a tener los end-points visibile para que un sistema o cliente lo pueda consumir 
    public class ProductoController : Controller //La clase controller es la clase que queda expuesta a la red
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }

        [HttpGet]
        [Route("GetListaProductos")]
        public async Task<RespuestaModel> GetListaProductos(int productoID, float precio)
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _producto.GetListaProductos(productoID, precio); // Metodo interno que se encuentra en el servicio
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        /*[HttpGet]
        [Route("GetProductoID")]
        public async Task<List<Producto>> GetProductoID(int productoID)
        {
            List<Producto> respuesta = [];
            try
            {
                respuesta = await _producto.GetProductoID(productoID); // Metodo interno que se encuentra en el servicio
            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }*/

        [HttpGet]
        [Route("GetProductoPrice")]
        public async Task<List<Producto>> GetProductoPrice(float price)
        {
            List<Producto> answer = [];

            try
            {
                answer = await _producto.GetProductoPrice(price);
            }
            catch (Exception)
            {

                throw;
            }

            return answer;
        }

        [HttpPost]
        [Route("PostProducto")] //Insertar 

        public async Task<RespuestaModel> PostProducto([FromBody] Producto producto)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _producto.PostProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutProducto")]

        public async Task<RespuestaModel> PutProducto([FromBody] Producto producto)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta = await _producto.PutProducto(producto);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}



