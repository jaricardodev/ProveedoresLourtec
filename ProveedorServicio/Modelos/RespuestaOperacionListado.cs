using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProveedorServicio.Modelos
{
    [DataContract]
    public class RespuestaOperacionListado<T> where T:class 
    {
        [DataMember]
        public List<T> DatosRespuesta { get; set; }

        [DataMember]
        public bool EsOperacionExitosa { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}