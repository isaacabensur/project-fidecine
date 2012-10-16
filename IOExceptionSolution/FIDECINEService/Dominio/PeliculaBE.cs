using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FIDECINEService.Dominio
{
    [DataContract]
    public class PeliculaBE
    {
        [DataMember]
        public int IdPelicula { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public int IdCategoria { get; set; }

        [DataMember]
        public int IdTipo { get; set; }

        [DataMember]
        public string Trailer { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int IdGenero { get; set; }

        [DataMember]
        public int Duracion { get; set; }
    }
}