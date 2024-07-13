using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace EjemploEntity.Services
{
    public class VentaServices : IVenta
    {
        private readonly VentasContext _context;

        private ControlError Log = new ControlError();

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
                /*else if (estado != null)
                {
                    //query = query.Where(x => x.Estado.Equals(estado)); //method syntax, encadenando consultas

                    query = from v in query //query syntax, encadenando consultas
                            where v.Estado.Equals(1)
                            select v;

                    respuesta.Cod = "000";
                    respuesta.Data = await query.ToArrayAsync();
                    respuesta.Mensaje = "OK";
                }*/
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
                    respuesta.Mensaje = "Parametros ingresadoa de forma incorrecta";
                }
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "GetVenta", ex.Message);
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
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "GetClientesByDate", ex.Message);
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
                    double newFacturaId = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault() + 1;
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
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices","PostVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PutVenta(Venta venta)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                _context.Ventas.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "PutVenta", ex.Message);
            }
            return respuesta;

        }

        public async Task<RespuestaModel> GetVentaReport(double precio)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta.Cod = "000";

                IQueryable<ConsultaPrecioDTO> query = from ven in _context.Ventas  // Query Syntax
                                                      where ven.Precio >= precio
                                                      group ven by ven.Precio into newGroup
                                                      select new ConsultaPrecioDTO
                                                      {
                                                          Precio = newGroup.Key,
                                                          CantidadRegistros = newGroup.Count()

                                                      };

                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "Ok";

                /*var query = from ven in _context.Ventas   // Query Syntax Usando Artificio de programación
                            where ven.Precio >= precio
                            group ven by ven.Precio into newGroup
                            orderby newGroup.Key
                            select new
                            {
                                Precio = newGroup.Key,
                                CantidadRegistros = newGroup.Count()
                            };*/



                /*respuesta.Data = await _context.Ventas.Where(x => x.Precio >= precio). // Method Syntax
                    GroupBy(y => y.Precio).
                    Select(newG => new 
                    { 
                        precio = newG.Key, Freq = newG.Count() 
                    }).ToListAsync();*/
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "GetVentaReport", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetCleintesReport()
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                IQueryable<ClienteConsultasDTO> query = from v in _context.Ventas
                                                        join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                                        select new ClienteConsultasDTO
                                                        {
                                                            NombreCliente = cl.ClienteNombre,
                                                            TotalGasto = v.Precio
                                                        };

                respuesta.Cod = "000";

                respuesta.Data = await (from v in query
                                        group v by v.NombreCliente into newGroup
                                        orderby newGroup.Sum(x => x.TotalGasto)
                                        select new ClienteConsultasDTO
                                        {
                                            NombreCliente = newGroup.Key,
                                            TotalGasto = newGroup.Sum(x => x.TotalGasto)

                                        }).ToListAsync();

            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("VentaServices", "GetVentaReport", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> DeleteVenta(double idFactura)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                Venta? ventaToDelete = await _context.Ventas.FirstOrDefaultAsync(x => x.IdFactura == idFactura);

                if (ventaToDelete is not null)
                {
                    ventaToDelete.Estado = 2;

                    _context.Ventas.Update(ventaToDelete);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Data = ventaToDelete;
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No existe una venta registrada con el ID ingresado, no se puede realizar cambios";
                }
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("ClienteServices", "DeleteVenta", ex.Message);
            }

            return respuesta;
        }
    }
}

