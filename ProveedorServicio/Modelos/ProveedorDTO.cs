using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProveedorServicio.Modelos
{

   
    [DataContract]
    public  class ProveedorDTO
    {
        public ProveedorDTO(Proveedor aProveedor)
        {
            Id = aProveedor.Id;
            Nombre = aProveedor.Nombre;
            RIF =aProveedor.RIF;
            Direccion = aProveedor.Direccion;
            Correo = aProveedor.Correo;
            Responsable = aProveedor.Responsable;
            Telefono = aProveedor.Telefono;
            FechaRegistro = aProveedor.FechaRegistro;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string RIF { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Responsable { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public System.DateTime FechaRegistro { get; set; }
    }
}