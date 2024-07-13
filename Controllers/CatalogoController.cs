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

        //GETS

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
        [Route("GetModelo")]
        public async Task<RespuestaModel> GetModelo()
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.GetModelo();
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "GetModelo", ex.Message);
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

        [HttpGet]
        [Route("GetCiudad")]
        public async Task<RespuestaModel> GetCiudad()
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.GetCiudad();
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "GetCiudad", ex.Message);
            }
            return respuesta;
        }

        //POSTS

        [HttpPost]
        [Route("PostCategoria")]
        public async Task<RespuestaModel> PostCategoria([FromBody] Categorium categoria)
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
        public async Task<RespuestaModel> PostMarca([FromBody] Marca marca)
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
        public async Task<RespuestaModel> PostSucursal([FromBody] Sucursal sucursal)
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


        [HttpPost]
        [Route("PostModelo")]
        public async Task<RespuestaModel> PostModelo([FromBody] Modelo modelo)
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.PostModelo(modelo);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostCiudad")]
        public async Task<RespuestaModel> PostCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new RespuestaModel();
            try
            {
                respuesta = await _catalogo.PostCiudad(ciudad);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PostCiudad", ex.Message);
            }
            return respuesta;
        }


        //PUTS

        [HttpPut]
        [Route("PutCategoria")]
        public async Task<RespuestaModel> PutCategoria([FromBody] Categorium categoria)
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
        public async Task<RespuestaModel> PutMarca([FromBody] Marca marca)
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
        public async Task<RespuestaModel> PutSucursal([FromBody] Sucursal sucursal)
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

        [HttpPut]
        [Route("PutModelo")]
        public async Task<RespuestaModel> PutModelo([FromBody] Modelo modelo)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                respuesta = await _catalogo.PutModelo(modelo);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PutModelo", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCiudad")]
        public async Task<RespuestaModel> PutCiudad([FromBody] Ciudad ciudad)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                respuesta = await _catalogo.PutCiudad(ciudad);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("CatalogoController", "PutCiudad", ex.Message);
            }
            return respuesta;
        }
    }
}
