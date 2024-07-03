using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class VentasSheltonServices : IVentasShelton
    {
        private readonly VentasContext _context;

        public VentasSheltonServices(VentasContext context)
        {
            this._context = context;
        }

        public async Task<RespuestaModel> GetAnnualSales(DateTime year)
        {
            int justYear = year.Year; //Getting just the year
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
               /* respuesta.Cod = "000";
                respuesta.Data = await (from v in _context.Ventas
                                        join p in _context.Productos on v.ProductoId equals p.ProductoId
                                        join m in _context.Marcas on v.MarcaId equals m.MarcaId
                                        join s in _context.Sucursals on v.SucursalId equals s.SucursalId
                                        where v.FechaHora.Year == justYear
                                        select new VentasSheltonDTO
                                        {
                                            FechaHora = v.FechaHora,
                                            ProductoDescrip = p.ProductoDescrip,
                                            MarcaDescrip = m.MarcaNombre,
                                            Precio = v.Precio,
                                            SucursalNombre = s.SucursalNombre

                                        }).ToListAsync();

                respuesta.Mensaje = "Ok";
               */
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
