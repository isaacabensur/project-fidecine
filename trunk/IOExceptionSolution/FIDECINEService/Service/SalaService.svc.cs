using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using FIDECINEService.Dominio;
using FIDECINEService.Persistencia;

namespace FIDECINEService.Service
{
    
    public class SalaService : ISalaService
    {

        public List<SalaBE> listar(string str_pNombre, string str_pEstado)
        {

            SalaBE obj_pSalaBE = new SalaBE();
            obj_pSalaBE.Nombre = str_pNombre;
            obj_pSalaBE.Estado = str_pEstado;

            List<SalaBE> listaSala = new List<SalaBE>();
            SalaBE objSalaBE = null;

            foreach (Sala objSala in new SalaDAO().listar(obj_pSalaBE))
            {
                objSalaBE = new SalaBE();
                objSalaBE.IdSala = objSala.IdSala;
                objSalaBE.Nombre = objSala.Nombre;
                objSalaBE.Estado = objSala.Estado;
                listaSala.Add(objSalaBE);
            }

            return listaSala;
        }
    }
}
