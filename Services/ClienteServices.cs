using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class ClienteServices : ICliente
    {
        private readonly VentasContext _context;

        public ClienteServices(VentasContext context)
        {
            _context = context;
        }

        public async Task<RespuestaModel> GetCliente(double clienteId, string? nombreCliente, double identificacion)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {

                if (clienteId == 0 && nombreCliente == null && identificacion == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await _context.Clientes.Where(x => x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

                else if (clienteId != 0 && nombreCliente == null && identificacion == 0) //by ID
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await _context.Clientes.Where(x => x.ClienteId == clienteId && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

                else if (clienteId == 0 && nombreCliente != null && identificacion == 0) //by nombre cliente
                {

                    respuesta.Cod = "000";
                    respuesta.Data = await _context.Clientes.Where(x => x.ClienteNombre.ToUpper().Equals(nombreCliente.ToUpper()) && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (clienteId == 0 && nombreCliente == null && identificacion != 0) // by cedula
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await _context.Clientes.Where(x => x.Cedula == identificacion && x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

                else if (clienteId != 0 && nombreCliente != null && identificacion != 0) // by cedula
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await _context.Clientes.Where(x => x.ClienteId.Equals(clienteId) && x.ClienteNombre.Equals(nombreCliente) && x.Cedula == identificacion && x.Estado.Equals("A")).ToListAsync();
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

        public async Task<RespuestaModel> PostCliente(Cliente cliente)
        {

            bool existeId = false;
            RespuestaModel respuesta = new RespuestaModel();

            try
            {  
                existeId = await _context.Clientes.Where(x => x.Cedula == cliente.Cedula).AnyAsync();

                if (cliente.ClienteNombre != null && existeId == false && cliente.Cedula != 0 && cliente.Cedula > 999)
                {
                    respuesta.Cod = "000";

                    double newClienteId = _context.Clientes.OrderByDescending(x => x.ClienteId).Select(x => x.ClienteId).FirstOrDefault() + 1;
                    cliente.ClienteId = newClienteId;
                    
                    cliente.FechaHoraReg = DateTime.Now;
                   
                    respuesta.Mensaje = "OK";
                   
                    _context.Clientes.Add(cliente);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "Cedula existente o se ingresaron campos no validos";
                }


            }
            catch (Exception ex)
            {

                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento un error: {ex.Message}";
            }
            return respuesta;
        }

        public async Task<RespuestaModel> PutCliente(Cliente cliente)
        {
            RespuestaModel respuesta = new RespuestaModel();
            try
            {
                bool existId = await _context.Clientes.Where(x => x.ClienteId == cliente.ClienteId).AnyAsync();

                if (existId)
                {
                    _context.Clientes.Update(cliente);
                    await _context.SaveChangesAsync();
                    respuesta.Cod = "000";
                    //respuesta.Data = 
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "999";
                    respuesta.Mensaje = "No exite el ID ingresado, no se puede editar un cliente sin que este registrado primero";
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
