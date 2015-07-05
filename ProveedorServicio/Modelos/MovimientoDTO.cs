using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ProveedorServicio.Modelos;

namespace ProveedorServicio
{
    [DataContract]
    public class MovimientoDTO
    {
        public MovimientoDTO(Movimiento aMovimiento)
        {
            Id = aMovimiento.Id;
            TipoMovimiento = aMovimiento.TipoMovimiento;
            ProductoId = aMovimiento.ProductoId;
            Cantidad = aMovimiento.Cantidad;
        }
         [DataMember]
        public int Id { get; set; }
         [DataMember]
        public int TipoMovimiento { get; set; }
         [DataMember]
        public int ProductoId { get; set; }
         [DataMember]
        public int Cantidad { get; set; }
    
    }
}