using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;


namespace EjemploEntity.Interfaces
{
    public interface IProducto
    {
        Task<RespuestaModel> GetListaProductos(int productoID, float precio);
        
        //Task<List<Producto>> GetProductoID(int productoID);

        Task<List<Producto>> GetProductoPrice (float  price);

        Task<RespuestaModel> PostProducto(Producto producto);

        Task<RespuestaModel> PutProducto(Producto producto);
    }
}
