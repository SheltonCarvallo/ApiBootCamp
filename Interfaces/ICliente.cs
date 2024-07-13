using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICliente
    {
        Task<RespuestaModel> GetCliente(double clienteId, string? nombreCliente, double identificacion);
        Task<RespuestaModel> PostCliente(Cliente cliente);
        Task<RespuestaModel> PutCliente(Cliente cliente);
        Task<RespuestaModel> DeleteCliente(double id);


    }
}

