using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface IVentasShelton
    {
        Task<RespuestaModel> GetAnnualSales(DateTime year);
    }
}
