using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Newtonsoft.Json;

namespace EjemploEntity.Utilitarios
{
    public class ChuckModel
    {
        private ControlError log = new();

        public async Task<RespuestaModel> GetChuckCategories(string url)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<List<string>>(json);
                respuesta.Mensaje = "Se consumio correctamente";
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos("PokeApi", "GetPokeApi", ex.Message);
            }

            return respuesta;
        }

        public async Task<RespuestaModel> GetChuckText(string url, string query)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url + query);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckTextDTO>(json);
                respuesta.Mensaje = "Se consumio correctamente";

            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetChuckCategory(string url, string category)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url + category);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                var json = await response.Content.ReadAsStringAsync();

                respuesta.Cod = "000";
                respuesta.Data = JsonConvert.DeserializeObject<ChuckByCategory>(json);
                respuesta.Mensaje = "Se consumio correctamente";

            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    } 
}
