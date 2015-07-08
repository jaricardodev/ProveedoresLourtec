using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProveedorServicio.Modelos
{
    [DataContract]
    public class ProductoDTO
    {
        public ProductoDTO(Producto aProducto)
        {
            Id = aProducto.Id;
            UPC = aProducto.UPC;
            Nombre = aProducto.Nombre;
            UMId = aProducto.UMId;
            CategoriaId = aProducto.CategoriaId;
            Costo = aProducto.Costo;
            Precio = aProducto.Precio;
            FechaRegistro = aProducto.FechaRegistro;
            Exento = aProducto.Exento;
            Existencia = aProducto.Existencia;
            Activo = aProducto.Activo;
            TipoProducto = aProducto.TipoProducto;
            EsServicio = aProducto.EsServicio;
            NombreCategoria = aProducto.Categoria.Nombre;

        }

        [DataMember]
        public int Id { get; set; }
         [DataMember]
        public string UPC { get; set; }
         [DataMember]
        public string Nombre { get; set; }
         [DataMember]
        public string UMId { get; set; }
         [DataMember]
        public int CategoriaId { get; set; }
         [DataMember]
        public decimal Costo { get; set; }
         [DataMember]
        public decimal Precio { get; set; }
         [DataMember]
        public DateTime FechaRegistro { get; set; }
         [DataMember]
        public bool Exento { get; set; }
         [DataMember]
        public decimal Existencia { get; set; }
         [DataMember]
        public bool Activo { get; set; }
         [DataMember]
        public bool TipoProducto { get; set; }
         [DataMember]
        public bool EsServicio { get; set; }
        [DataMember]
         public string NombreCategoria { get; set; }

    }
}