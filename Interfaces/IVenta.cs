﻿using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IVenta
    {
        Task<RespuestaModel> GetVenta(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal);
        Task<RespuestaModel> GetClientesByDate(DateTime date);

        Task<RespuestaModel> PostVenta(Venta venta);

        Task<RespuestaModel> PutVenta(Venta venta);

        Task<RespuestaModel> GetVentaReport(double precio);

        Task<RespuestaModel> GetCleintesReport();

        Task<RespuestaModel> DeleteVenta(double idFactura);
    }
}
