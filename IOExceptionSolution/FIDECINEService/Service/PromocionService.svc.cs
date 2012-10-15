using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using FIDECINEService.Dominio;
using System.Globalization;
using FIDECINEService.Persistencia;
using System.ServiceModel.Activation;

namespace FIDECINEService.Service
{

    public class PromocionService : IPromocionService
    {

        public ResultadoBE insertar(PromocionBE objPromocionBE)
        {
            Promocion objPromocion = new Promocion();
            objPromocion.IdProducto = objPromocionBE.IdProducto;
            objPromocion.Puntos = objPromocionBE.Puntos;
            objPromocion.vigenciaInicio = DateTime.ParseExact(objPromocionBE.VigenciaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objPromocion.vigenciaFin = DateTime.ParseExact(objPromocionBE.VigenciaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            new PromocionDAO().insertar(objPromocion);

            return new ResultadoBE() { Mensaje = "La Oferta ingresada fue registrada con éxito" };

        }

        public ResultadoBE eliminar(int IdPromocion)
        {
            new PromocionDAO().eliminar(IdPromocion);
            return new ResultadoBE() { Mensaje = "La Oferta seleccionada fue eliminada con éxito" };
        }

        public List<PromocionBE> listar(PromocionBE objPromocionBE)
        {
            List<PromocionBE> listaPromocion = new List<PromocionBE>();
            PromocionBE tempPromocionBE = null;

            foreach (Promocion objPromocion in new PromocionDAO().listar(objPromocionBE.VigenciaInicio, objPromocionBE.VigenciaFin))
            {
                tempPromocionBE = new PromocionBE();
                tempPromocionBE.IdPromocion = objPromocion.IdPromocion;
                tempPromocionBE.ProductoNombre = objPromocion.Producto.Nombre;
                tempPromocionBE.Puntos = objPromocion.Puntos;
                tempPromocionBE.VigenciaInicio = objPromocion.vigenciaInicio.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                tempPromocionBE.VigenciaFin = objPromocion.vigenciaFin.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                listaPromocion.Add(tempPromocionBE);
            }

            return listaPromocion;
        }
    }
}
