using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IVendedor
    {
        Task<RespuestaModel> GetVendedor(double? id, string? estado);
        Task<RespuestaModel> PostVendedor(Vendedor vendedor);
        Task<RespuestaModel> PutVendedor(Vendedor vendedor);
        Task<RespuestaModel> DeleteVendedor(double id);

    }
}

