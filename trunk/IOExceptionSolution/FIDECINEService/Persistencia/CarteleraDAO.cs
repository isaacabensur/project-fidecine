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
    public class CarteleraDAO
    {

        public void insertar(Cartelera objCartelera)
        {

            using (var context = new FideCineEntities())
            {
                context.Cartelera.AddObject(objCartelera);
                context.SaveChanges();
            }            
        }

        public void eliminar(int int_pIdCartelera)
        {

            using (var context = new FideCineEntities())
            {
                context.Cartelera.DeleteObject(context.Cartelera.Where(" it.IdCartelera = @pi_IdCartelera", new ObjectParameter[] { new ObjectParameter("pi_IdCartelera", int_pIdCartelera) }).First<Cartelera>());
                context.SaveChanges();
            }
        }

        public List<Cartelera> listar(int int_pIdPelicula, int int_pIdSala, string str_pFechaInicio, string str_pFechaFin)
        {
            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();


            if (int_pIdPelicula != 0)
            {
                sbScript.Append(" ( it.IdPelicula = @pi_IdPelicula )");
                lstParameters.Add(new ObjectParameter("pi_IdPelicula", int_pIdPelicula));
            }

            if (int_pIdSala != 0)
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.IdSala = @pi_IdSala )");
                lstParameters.Add(new ObjectParameter("pi_IdSala", int_pIdSala));
            }
            
            if (!string.IsNullOrEmpty(str_pFechaInicio))
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.FechaHora >= @pi_FechaInicio )");
                lstParameters.Add(new ObjectParameter("pi_FechaInicio", DateTime.ParseExact(str_pFechaInicio, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrEmpty(str_pFechaFin))
            {

                if (lstParameters.Count > 0) sbScript.Append(" and ");

                sbScript.Append(" ( it.FechaHora <= @pi_FechaFin )");
                lstParameters.Add(new ObjectParameter("pi_FechaFin", DateTime.ParseExact(str_pFechaFin, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)));
            }

            if (lstParameters.Count > 0)
                return (new FideCineEntities().Cartelera.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Cartelera>());
            else
                return (new FideCineEntities().Cartelera.ToList<Cartelera>());
        
        }

    }
}