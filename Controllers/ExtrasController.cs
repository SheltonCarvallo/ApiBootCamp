using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : Controller
    {
        private ControlError log = new ControlError();
        private PokeApi pokeApi = new PokeApi();
        private readonly IConfiguration _configuration;
        public ExtrasController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        
       public async Task<RespuestaModel> GetPokeApi()
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value!;
                respuesta = await pokeApi.GetPokeApi(url);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos("ExtrasController", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }
    }
}
