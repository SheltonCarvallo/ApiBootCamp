using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitarios
{
    public class PokeApi
    {
		private ControlError log = new();
        public async Task<RespuestaModel> GetPokeApi(string url)
        {
            var respuesta =  new RespuestaModel();
			try
			{
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<PokeApiDTO>(json); //await response.Content.ReadAsStringAsync();
                respuesta.Mensaje = "Se consumio correctamente";
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
			catch (Exception ex)
			{

				log.LogErrorMetodos("PokeApi", "GetPokeApi", ex.Message);

            }

            return respuesta;
        }
    }
}
