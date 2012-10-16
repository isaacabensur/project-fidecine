using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FIDECINEService.Dominio;
using FIDECINEService.Persistencia;

using System.Globalization;

namespace FIDECINEService.Service
{
    
    public class VisitaService : IVisitaService
    {

        public List<VisitaBE> listar(int IdCliente, int IdCartelera)
        {
            List<VisitaBE> listaVisita = new List<VisitaBE>();
            return listaVisita;
        }
    }
}
