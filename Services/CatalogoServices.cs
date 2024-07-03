using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EjemploEntity.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly VentasContext _context;

        public CatalogoServices(VentasContext context)
        {
            this._context = context;
        }
        public async Task<RespuestaModel> GetCategoria()
        {
            var respuesta = new RespuestaModel();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Categoria.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad {ex.Message}";

            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetMarca()
        {
            var respuesta = new RespuestaModel();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Marcas.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad {ex.Message}";

            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetSucursal()
        {
            var respuesta = new RespuestaModel();

            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Sucursals.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad {ex.Message}";

            }
            return respuesta;
        }

        public async Task<RespuestaModel> PostCategoria(Categorium categoria)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                bool existCategId = await _context.Categoria.Where(x => x.CategId == categoria.CategId).AnyAsync();

                if (!existCategId)
                {
                    respuesta.Cod = "000";

                    double newCategId = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefault() + 1;
                    categoria.CategId = newCategId;
                    categoria.FechaHoraReg = DateTime.Now;
                    respuesta.Mensaje = "Ok";

                    _context.Categoria.Add(categoria);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "ID categaria ya existe, no se puede registrar";
                }

            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad {ex.Message}";
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PostMarca(Marca marca)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                bool existCategId = await _context.Categoria.Where(x => x.CategId == marca.MarcaId).AnyAsync();

                if (!existCategId)
                {
                    respuesta.Cod = "000";

                    double newCategId = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefault() + 1;
                    marca.MarcaId = newCategId;
                    marca.FechaHoraReg = DateTime.Now;
                    respuesta.Mensaje = "Ok";

                    _context.Marcas.Add(marca);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "ID Marca ya existe, no se puede registrar";
                }

            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad {ex.Message}";
            }
            return respuesta;
        }
        public async Task<RespuestaModel> PostSucursal(Sucursal sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                bool existCategId = await _context.Categoria.Where(x => x.CategId == sucursal.SucursalId).AnyAsync();

                if (!existCategId)
                {
                    respuesta.Cod = "000";

                    double newCategId = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefault() + 1;
                    sucursal.SucursalId = newCategId;
                    sucursal.FechaHoraReg = DateTime.Now;
                    respuesta.Mensaje = "Ok";

                    _context.Sucursals.Add(sucursal);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "ID Marca ya existe, no se puede registrar";
                }

            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Me a presentado una novedad {ex.Message}";
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PutCategoria(Categorium categoria)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existId = await _context.Categoria.Where(x => x.CategId == categoria.CategId).AnyAsync();

                if (existId)
                {
                    _context.Categoria.Update(categoria);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    //respuesta.Data = 
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar una categoria sin que este registrado primero";
                }
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }

            return respuesta;
        }

        public async Task<RespuestaModel> PutMarca(Marca marca)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existId = await _context.Marcas.Where(x => x.MarcaId == marca.MarcaId).AnyAsync();

                if (existId)
                {
                    _context.Marcas.Update(marca);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    //respuesta.Data = 
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar una marca sin que este registrado primero";
                }
            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }

            return respuesta;
        }

        public async Task<RespuestaModel> PutSucursal(Sucursal sucursal)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existId = await _context.Sucursals.Where(x => x.SucursalId == sucursal.SucursalId).AnyAsync();

                if (existId)
                {
                    _context.Sucursals.Update(sucursal);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    //respuesta.Data = 
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar una marca sin que este registrado primero";
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
