using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEService.Dominio;
using System.Text;
using System.Data.Objects;
using System.Globalization;

namespace FIDECINEService.Persistencia
{
    public class PromocionDAO
    {
        public void insertar(Promocion objPromocion)
        {

            using (var context = new FideCineEntities())
            {
                context.Promocion.AddObject(objPromocion);
                context.SaveChanges();
            }
        }

        public void actualizar(Promocion objPromocion)
        {

            using (var context = new FideCineEntities())
            {
                context.Promocion.Attach(objPromocion);
                context.SaveChanges();
            }
        }

        public Promocion obtener(int int_pIdPromocion)
        {

            return new FideCineEntities().Promocion.Where(" it.IdPromocion = @pi_IdPromocion", new ObjectParameter[] { new ObjectParameter("pi_IdPromocion", int_pIdPromocion) }).First<Promocion>();
        }

        public List<Promocion> listar(string str_pFechaInicio, string str_pFechaFin, string str_pEstado)
        {
            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();


            if (!string.IsNullOrEmpty(str_pEstado))
            {
                sbScript.Append(" ( it.Estado = @pi_Estado)");
                lstParameters.Add(new ObjectParameter("pi_Estado", str_pEstado));
            }

            if (!string.IsNullOrEmpty(str_pFechaInicio))
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.vigenciaInicio >= @pi_FechaInicio )");
                lstParameters.Add(new ObjectParameter("pi_FechaInicio", DateTime.ParseExact(str_pFechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrEmpty(str_pFechaFin))
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.vigenciaFin <= @pi_FechaFin )");
                lstParameters.Add(new ObjectParameter("pi_FechaFin", DateTime.ParseExact(str_pFechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            }

            if (lstParameters.Count > 0)
                return (new FideCineEntities().Promocion.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Promocion>());
            else
                return (new FideCineEntities().Promocion.ToList<Promocion>());

        }
    }

}