using EjemploEntity.DTOs;

namespace EjemploEntity.Models
{
    public class RespuestaModel
    {
        public string Cod { get; set; }
        public dynamic Data { get; set; }
        public string Mensaje { get; set; }

        public static implicit operator RespuestaModel(List<ProductoDTO> v)
        {
            throw new NotImplementedException();
        }
    }
}
