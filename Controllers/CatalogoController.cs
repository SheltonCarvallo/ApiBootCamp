using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;

        private ControlError Log = new ControlError();
        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("GetCategoria")]
        public async Task<RespuestaModel> GetCategoria()
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.GetCategoria();
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetMarca")]
        public async Task<RespuestaModel> GetMarca()
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.GetMarca();
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "GetMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetSucursal")]
        public async Task<RespuestaModel> GetSucursal()
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.GetSucursal();
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "GetSucursal", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<RespuestaModel> PostCategoria(Categorium categoria)
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.PostCategoria(categoria);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostMarca")]
        public async Task<RespuestaModel> PostMarca(Marca marca)
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.PostMarca(marca);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PostMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostSucursal")]
        public async Task<RespuestaModel> PostSucursal(Sucursal sucursal)
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.PostSucursal(sucursal);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PostSucursal", ex.Message);
            }
            return respuesta;
        }


        [HttpPut]
        [Route("PutCategoria")]
        public async Task<RespuestaModel> PutCategoria(Categorium categoria)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                respuesta = await _catalogo.PutCategoria(categoria);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PutCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutMarca")]
        public async Task<RespuestaModel> PutMarca(Marca marca)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                respuesta = await _catalogo.PutMarca(marca);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PutMarca", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutSucursal")]
        public async Task<RespuestaModel> PutSucursal(Sucursal sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                respuesta = await _catalogo.PutSucursal(sucursal);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PutSucursal", ex.Message);
            }
            return respuesta;
        }
    }
}
