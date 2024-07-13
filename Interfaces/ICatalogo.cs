using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface ICatalogo
    {
        Task<RespuestaModel> GetCategoria();
        Task<RespuestaModel> GetMarca();
        Task<RespuestaModel> GetSucursal();
        Task<RespuestaModel> GetModelo();
        Task<RespuestaModel> GetCiudad();

        Task<RespuestaModel> PostCategoria(Categorium categoria);
        Task<RespuestaModel> PostMarca(Marca marca);
        Task<RespuestaModel> PostSucursal(Sucursal sucursal);
        Task<RespuestaModel> PostModelo(Modelo modelo);
        Task<RespuestaModel> PostCiudad(Ciudad ciudad);


        Task<RespuestaModel> PutCategoria(Categorium categoria);
        Task<RespuestaModel> PutMarca(Marca marca);
        Task<RespuestaModel> PutSucursal(Sucursal sucursal);
        Task<RespuestaModel> PutModelo(Modelo modelo);
        Task<RespuestaModel> PutCiudad(Ciudad ciudad);





    }
}
