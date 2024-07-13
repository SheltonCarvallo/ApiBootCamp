using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitarios;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EjemploEntity.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly VentasContext _context;

        private ControlError Log = new ControlError();

        public CatalogoServices(VentasContext context)
        {
            this._context = context;
        }

        //GETS
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetCategoria", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetMarca", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetModelo()
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Modelos.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> GetCiudad()
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Ciudads.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "GetCiudad", ex.Message);
            }
            return respuesta;
        }

        //POSTS

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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostCategoria", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostMarca", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PostModelo(Modelo modelo)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                bool existModeloId = await _context.Modelos.Where(x => x.ModeloId == modelo.ModeloId).AnyAsync();

                if (!existModeloId)
                {
                    respuesta.Cod = "000";

                    double newCategId = _context.Categoria.OrderByDescending(x => x.CategId).Select(x => x.CategId).FirstOrDefault() + 1;
                    modelo.ModeloId = newCategId;
                    modelo.FechaHoraReg = DateTime.Now;
                    respuesta.Mensaje = "Ok";

                    _context.Modelos.Add(modelo);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "ID Modelo ya existe, no se puede registrar";
                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PostCiudad(Ciudad ciudad)
        {
            RespuestaModel respuesta = new RespuestaModel();

            try
            {
                bool existModeloId = await _context.Ciudads.Where(x => x.CiudadId == ciudad.CiudadId).AnyAsync();

                if (!existModeloId)
                {
                    respuesta.Cod = "000";

                    double newCategId = _context.Ciudads.OrderByDescending(x => x.CiudadId).Select(x => x.CiudadId).FirstOrDefault() + 1;
                    ciudad.CiudadId = newCategId;
                    ciudad.FechaHoraReg = DateTime.Now;
                    respuesta.Mensaje = "Ok";

                    _context.Ciudads.Add(ciudad);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "ID Ciudad ya existe, no se puede registrar";
                }

            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PostModelo", ex.Message);
            }
            return respuesta;
        }

        //PUTS

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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PutCategoria", ex.Message);
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
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PutMarca", ex.Message);
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
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar una Marca sin que este registrado primero";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PutSucursal", ex.Message);
            }

            return respuesta;
        }

        public async Task<RespuestaModel> PutModelo(Modelo modelo)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existId = await _context.Modelos.Where(x => x.ModeloId == modelo.ModeloId).AnyAsync();

                if (existId)
                {
                    _context.Modelos.Update(modelo);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    //respuesta.Data = 
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar un Modelo sin que este registrado primero";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PutModelo", ex.Message);
            }

            return respuesta;
        }

        public async Task<RespuestaModel> PutCiudad(Ciudad ciudad)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existId = await _context.Ciudads.Where(x => x.CiudadId == ciudad.CiudadId).AnyAsync();

                if (existId)
                {
                    _context.Ciudads.Update(ciudad);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    //respuesta.Data = 
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar una Ciudad sin que este registrado primero";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el departamento de sistemas";
                Log.LogErrorMetodos("CatalogoServices", "PutCiudad", ex.Message);
            }

            return respuesta;
        }

    }
}
