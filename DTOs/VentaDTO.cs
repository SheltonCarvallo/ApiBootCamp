using EjemploEntity.Models;

namespace EjemploEntity.DTOs
{
    public class VentaDTO
    {

        public double IdFactura { get; set; }

        public string? NumFact { get; set; }

        public DateTime? FechaHora { get; set; }

        public string? ClienteDetalle { get; set; }

        public string? ProductoDetalle { get; set; }

        public string? ModeloDetalle { get; set; }

        public string? CategDetalle { get; set; }

        public string? MarcaDetalle { get; set; }

        public string? SucursalDetalle { get; set; }

        public string? Caja { get; set; }

        public string? NombreVendedor { get; set; }

        public double? Precio { get; set; }

        public double? Unidades { get; set; }

        public int? Estado { get; set; }

    }
}
