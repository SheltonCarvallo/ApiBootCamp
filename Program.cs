using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Services;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //Esta es la linea que permite arrancar el proyecto ya sea un microservicio o APIrest (van de la mano)

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IProducto, ProductoServices>();
            builder.Services.AddScoped<ICatalogo, CatalogoServices>();
            builder.Services.AddScoped<ICliente, ClienteServices>();
            builder.Services.AddScoped<IVentasShelton, VentasSheltonServices>();
            builder.Services.AddScoped<IVenta, VentaServices>();

            builder.Services.AddDbContext<VentasContext>(opciones =>
            opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
