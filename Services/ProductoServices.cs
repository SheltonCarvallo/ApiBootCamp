using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EjemploEntity.Services
{
    public class ProductoServices : IProducto //Aqui heredamos la interfaz
    {
        /* Tenemos que hacer una inyeccion de dependencia dentro de nnuestro servicio 
         para poder inyectar la facultad de conexion de base de datos dentro de nuestro servicio para poder hacer uso de entity framework
        */
        private readonly VentasContext _context; //Siemple se llama de la clase context

        public ProductoServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<RespuestaModel> GetListaProductos(int productoID, float precio)
        {
            var respuesta = new RespuestaModel();
            try
            {
                if (productoID == 0 && precio == 0)
                {
                    respuesta.Cod = "000";
                    //respuesta = await _context.Productos.Where(x => x.Estado.Equals("A")).ToListAsync(); //El .Productos es accedido gracias al la iyencion de dependencias que se hizo con la clase VentasContext
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A")
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción

                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";

                }
                else if (productoID != 0 && precio == 0)
                {
                    //respuesta.Data = await _context.Productos.Where(x => x.ProductoId == productoID && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A") && p.ProductoId.Equals(productoID)
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción

                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                }
                else if (precio != 0 && productoID == 0)
                {
                    //respuesta.Data = await _context.Productos.Where(x => x.Precio == precio && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A") && p.Precio.Equals(precio)
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción

                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                }
                else if (precio != 0 && productoID != 0)
                {
                    //respuesta.Data = await _context.Productos.Where(x => x.ProductoId == productoID && x.Precio == precio && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Cod = "000";
                    respuesta.Data = await (from p in _context.Productos
                                            join m in _context.Marcas on p.MarcaId equals m.MarcaId
                                            join c in _context.Categoria on p.CategId equals c.CategId
                                            join mo in _context.Modelos on p.ModeloId equals mo.ModeloId
                                            where p.Estado.Equals("A") && p.Precio.Equals(precio) && p.Precio == precio
                                            select new ProductoDTO
                                            {
                                                ProductoId = p.ProductoId,
                                                ProductoDescrip = p.ProductoDescrip,
                                                Estado = p.Estado,
                                                FechaHoraReg = p.FechaHoraReg,
                                                Precio = p.Precio,
                                                CategNombre = c.CategNombre,
                                                MarcaNombre = m.MarcaNombre,
                                                ModeloNombre = mo.ModeloDescripción

                                            }).ToListAsync();
                    respuesta.Mensaje = "Ok";
                }

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;
        }


        /*public async Task<List<Producto>> GetProductoID(int productoID)
        {
            List<Producto> answer = [];

            try
            {
                answer = await _context.Productos.Where(x => x.ProductoId == productoID).ToListAsync();


            }
            catch (Exception)
            {

                throw;
            }

            return answer;
        }*/

        public async Task<List<Producto>> GetProductoPrice(float price)
        {
            List<Producto> answer = [];
            try
            {
                answer = await _context.Productos.Where(x => x.Precio == price).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return answer;
        }

        public async Task<RespuestaModel> PostProducto(Producto producto)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                double query = _context.Productos.OrderByDescending(x => x.ProductoId).Select(x => x.ProductoId).FirstOrDefault(); //this return a single value a double type, if this returns a list it would be INumberable<double>
                producto.ProductoId = Convert.ToInt32(query) + 1;
                producto.FechaHoraReg = DateTime.Now;

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se inserto correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PutProducto(Producto producto)
        {
            RespuestaModel respuesta = new RespuestaModel();
            bool existe = false;

            try
            {
                existe = await _context.Categoria.Where(x => x.CategId == producto.CategId).AnyAsync();
                if (existe)
                {
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se actualizo correctamente";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = $"No existe categoria";
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
