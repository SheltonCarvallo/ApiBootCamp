using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICatalogo
    {
        Task<RespuestaModel> GetCategoria();
        Task<RespuestaModel> GetMarca();
        Task<RespuestaModel> GetSucursal();

        Task<RespuestaModel> PostCategoria(Categorium categoria);
        Task<RespuestaModel> PostMarca(Marca marca);
        Task<RespuestaModel> PostSucursal(Sucursal sucursal);

        Task<RespuestaModel> PutCategoria(Categorium categoria);

        Task<RespuestaModel> PutMarca(Marca marca);

        Task<RespuestaModel> PutSucursal(Sucursal sucursal);

    }
}
