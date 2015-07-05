using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProveedorServicio.Modelos
{
    [DataContract]
    public class ClienteDTO
    {
        public ClienteDTO(Cliente aCliente)
        {
            Id = aCliente.Id;
            Nombre = aCliente.Nombre;
            Email = aCliente.Email;
            CI = aCliente.CI;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CI { get; set; }
    }
}