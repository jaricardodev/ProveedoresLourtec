using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProveedorServicio.Modelos
{
    [DataContract]
    public class CategoriaDTO
    {
        public CategoriaDTO(Categoria aCategoria)
        {
            this.Id = aCategoria.Id;
            this.PadreId = aCategoria.PadreId;
            this.Nombre = aCategoria.Nombre;
            if (aCategoria.Categoria2 != null)
            {
                NombrePadre = aCategoria.Categoria2.Nombre;
            }
           
        }


        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? PadreId { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string NombrePadre { get; set; }
    }
}