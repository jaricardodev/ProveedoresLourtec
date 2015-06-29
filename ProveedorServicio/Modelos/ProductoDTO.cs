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
            this.Id = aProducto.Id;
            this.UPC = aProducto.UPC;
            this.Nombre = aProducto.Nombre;
            this.UMId = aProducto.UMId;
            this.CategoriaId = aProducto.CategoriaId;
            this.Costo = aProducto.Costo;
            this.Precio = aProducto.Precio;
            this.FechaRegistro = aProducto.FechaRegistro;
            this.Exento = aProducto.Exento;
            this.Existencia = aProducto.Existencia;
            this.Activo = aProducto.Activo;
            this.TipoProducto = aProducto.TipoProducto;
            this.EsServicio = aProducto.EsServicio;

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
        public System.DateTime FechaRegistro { get; set; }
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
    }
}