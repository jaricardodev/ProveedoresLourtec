using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProveedorServicio.Modelos
{
    [DataContract]
    public class RespuestaOparacionSimple<T> where T:class 
    {
        [DataMember]
        public T Dato { get; set; }

        [DataMember]
        public string TipoOperacion { get; set; }

        [DataMember]
        public bool EsOperacionExitosa { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}