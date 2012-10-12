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
    
    public class ProductoService : IProductoService
    {

        public List<ProductoBE> listar(string str_pNombre, string str_pEstado)
        {

            ProductoBE obj_pProductoBE = new ProductoBE();
            obj_pProductoBE.Nombre = str_pNombre;
            obj_pProductoBE.Estado = str_pEstado;

            List<ProductoBE> listaProducto = new List<ProductoBE>();
            ProductoBE objProductoBE = null;

            foreach (Producto objProducto in new ProductoDAO().listar(obj_pProductoBE))
            {
                objProductoBE = new ProductoBE();
                objProductoBE.IdProducto = objProducto.IdProducto;
                objProductoBE.Nombre = objProducto.Nombre;
                objProductoBE.Estado = objProducto.Estado;
                listaProducto.Add(objProductoBE);
            }

            return listaProducto;
        }
    }
}
