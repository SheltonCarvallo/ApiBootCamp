using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVenta
    {
        Task<RespuestaModel> GetClientes(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal);
        Task<RespuestaModel> GetClientesByDate(DateTime date);
    }
}
