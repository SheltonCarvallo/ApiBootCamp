using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class VentaServices : IVenta
    {
        private readonly VentasContext _context;

        public VentaServices(VentasContext context)
        {
            _context = context;
        }
        public async Task<RespuestaModel> GetClientes(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string ?sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {

                if (date != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where v.FechaHora.Equals(date) && v.Estado.Equals(1)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

                /*else if (date != null && sucursal != null  )
                {
                    DateTime justDate = date.Date;
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where v.FechaHora.Date.Equals(justDate) && sc.SucursalNombre.Equals(sucursal) && v.Estado.Equals(1)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }*/

                else if (numFactura != null && numFactura != "0")
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where v.NumFact.Equals(numFactura) && v.Estado.Equals(2)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (vendedor != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where ve.VendedorDescripcion.Equals(vendedor) && v.Estado.Equals(1)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

                else if (precio != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where v.Precio.Equals(precio) && v.Estado.Equals(1)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (estado != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where v.Estado.Equals(estado)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (sucursal != null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                            join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                            where sc.SucursalNombre.Equals(sucursal) && v.Estado.Equals(1)
                                            select new VentaDTO
                                            {
                                                IdFactura = v.IdFactura,
                                                NumFact = v.NumFact,
                                                FechaHora = v.FechaHora,
                                                ClienteDetalle = cl.ClienteNombre,
                                                ProductoDetalle = pr.ProductoDescrip,
                                                ModeloDetalle = mo.ModeloDescripción,
                                                CategDetalle = ct.CategNombre,
                                                SucursalDetalle = sc.SucursalNombre,
                                                Caja = ca.CajaDescripcion,
                                                Vendedor = ve.VendedorDescripcion,
                                                Precio = v.Precio,
                                                Unidades = v.Unidades,
                                                Estado = v.Estado
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "Datos nos esxistentes";
                }
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetClientesByDate(DateTime date)
        {
            RespuestaModel respuesta = new RespuestaModel();

           try
            {
               /* DateTime justDate = date.Date;
                respuesta.Cod = "000";
                respuesta.Data = await(from v in _context.Ventas
                                       join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                       join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                       join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                       join ct in _context.Categoria on v.CategId equals ct.CategId
                                       join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                       join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                                       join ca in _context.Cajas on v.CajaId equals ca.CajaId
                                       where v.FechaHora.Date.Equals(justDate)  && v.Estado.Equals(1)
                                       select new VentaDTO
                                       {
                                           IdFactura = v.IdFactura,
                                           NumFact = v.NumFact,
                                           FechaHora = v.FechaHora,
                                           ClienteDetalle = cl.ClienteNombre,
                                           ProductoDetalle = pr.ProductoDescrip,
                                           ModeloDetalle = mo.ModeloDescripción,
                                           CategDetalle = ct.CategNombre,
                                           SucursalDetalle = sc.SucursalNombre,
                                           Caja = ca.CajaDescripcion,
                                           Vendedor = ve.VendedorDescripcion,
                                           Precio = v.Precio,
                                           Unidades = v.Unidades,
                                           Estado = v.Estado
                                       }).ToListAsync();
                respuesta.Mensaje = "OK";*/
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }

            return respuesta;
        }

    }
}
