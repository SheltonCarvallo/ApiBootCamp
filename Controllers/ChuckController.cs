using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChuckController : Controller
    {
        private ControlError log = new ControlError();
        private ChuckModel chuckApi = new ChuckModel();
        private readonly IConfiguration _configuration;

        public ChuckController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetChuckCategories")]
        public async Task<RespuestaModel> GetChuckCategories()
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckCategories").Value!;
                respuesta = await chuckApi.GetChuckCategories(url);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos("ChuckController", "GetChuckCategories", ex.Message);
            }
            return respuesta;
        }

        
        [HttpGet]
        [Route("GetChuckText")]
        public async Task<RespuestaModel> GetChuckText(string query)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckTextApi").Value!;
                respuesta = await chuckApi.GetChuckText(url, query);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos("ChuckController", "GetChuckText", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetChuckCategory")]
        public async Task<RespuestaModel> GetChuckCategory(string category)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                var url = _configuration.GetSection("Keys:UrlChuckGetCategory").Value!;
                respuesta = await chuckApi.GetChuckCategory(url, category);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos("ChuckController", "GetChuckCategory", ex.Message);
            }
            return respuesta;
        }

    }
}
