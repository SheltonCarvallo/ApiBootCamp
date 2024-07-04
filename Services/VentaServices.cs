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
        public async Task<RespuestaModel> GetVenta(string? numFactura, DateTime? date, string? vendedor, double? precio, int? estado, string? sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                IQueryable<VentaDTO> query =
                from v in _context.Ventas
                join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                join ct in _context.Categoria on v.CategId equals ct.CategId
                join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                join ve in _context.Vendedors on v.VendedorId equals ve.VendedorId
                join ca in _context.Cajas on v.CajaId equals ca.CajaId
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
                    NombreVendedor = ve.VendedorDescripcion,
                    Precio = v.Precio,
                    Unidades = v.Unidades,
                    Estado = v.Estado
                };

                //List<VentaDTO> prueba = query.ToList();

                if (date != null && estado != null)
                {
                    //query = query.Where(x => x.FechaHora.Equals(date) && x.Estado.Equals(estado)); //method syntax, encadenando consultas
                    query = from v in query  //query syntax, encadenando consultas
                            where v.FechaHora.Equals(date) && v.Estado.Equals(estado)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToListAsync(); // Ejecutar la consulta y obtener los resultados
                    respuesta.Mensaje = "OK";
                }

                else if (numFactura != null && numFactura != "0" && estado != null)
                {
                    //query = query.Where(x => x.NumFact.Equals(numFactura) && x.Estado.Equals(estado)); //method syntax, encadenando consultas

                    query = from v in query //query syntax, encadenando consultas
                            where v.NumFact.Equals(numFactura) && v.Estado.Equals(estado)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToListAsync(); // Ejecutar la consulta y obtener los resultados
                    respuesta.Mensaje = "OK";
                }
                else if (vendedor != null && estado != null)
                {
                    //query = query.Where(x => x.NombreVendedor.Equals(vendedor)&& x.Estado.Equals(1)); //method syntax, encadenando consultas

                    query = from v in query //query syntax, encadenando consultas
                            where v.NombreVendedor.Equals(vendedor) && v.Estado.Equals(estado)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToListAsync(); // Ejecutar la consulta y obtener los resultados, encadenando consultas
                    respuesta.Mensaje = "OK";
                }

                else if (precio != null && estado != null)
                {
                    //query = query.Where(x => x.Precio.Equals(precio)&& x.Estado.Equals(1)); //method syntax, encadenando consultas

                    query = from v in query //query syntax, encadenando consultas
                            where v.Precio.Equals(precio) && v.Estado.Equals(estado)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToArrayAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (estado != null)
                {
                    //query = query.Where(x => x.Estado.Equals(estado)); //method syntax, encadenando consultas

                    query = from v in query //query syntax, encadenando consultas
                            where v.Estado.Equals(1)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToArrayAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (sucursal != null)
                {
                    //query = query.Where(x => x.SucursalDetalle.Equals(sucursal)); //method syntax, encadenando consultas

                    query = from v in query //query syntax, encadenando consultas
                            where v.SucursalDetalle.Equals(sucursal)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToArrayAsync();
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

        public async Task<RespuestaModel> PostVenta(Venta venta)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existeFacturaId;
                existeFacturaId = await _context.Ventas.Where(x => x.IdFactura == venta.IdFactura).AnyAsync(); //checking if the id is already stored

                if (!existeFacturaId)
                {
                    double newFacturaId = _context.Ventas.OrderBy(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault() + 1;
                    venta.IdFactura = newFacturaId;
                    venta.FechaHora = DateTime.Now;

                    _context.Ventas.Add(venta);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Ok";
                }

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
