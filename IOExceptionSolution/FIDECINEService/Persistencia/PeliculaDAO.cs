﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEService.Dominio;
using System.Text;
using System.Data.Objects;

namespace FIDECINEService.Persistencia
{
    public class PeliculaDAO
    {

        public List<GeneroPelicula> listarGeneroPelicula()
        {
            return (new FideCineEntities().GeneroPelicula.ToList<GeneroPelicula>());
        }
        public List<TipoPelicula> listarTipoPelicula()
        {
            return (new FideCineEntities().TipoPelicula.ToList<TipoPelicula>());
        }
        public List<CategoriaPelicula> listarCategoriaPelicula()
        {
            return (new FideCineEntities().CategoriaPelicula.ToList<CategoriaPelicula>());
        }

        public List<Pelicula> listar(PeliculaBE objPeliculaBE)
        {
            StringBuilder sbScript = new StringBuilder("");
            List<ObjectParameter> lstParameters = new List<ObjectParameter>();
            if (!string.IsNullOrEmpty(objPeliculaBE.Estado))
            {
                sbScript.Append(" ( ToUpper(it.Estado) = @pi_Estado )");
                lstParameters.Add(new ObjectParameter("pi_Estado", objPeliculaBE.Estado.ToUpper()));
            }
            return (new FideCineEntities().Pelicula.Where(sbScript.ToString(), lstParameters.ToArray()).ToList<Pelicula>());
        }

        public void insertar(Pelicula entidad)
        {
            using (var context = new FideCineEntities())
            {
                context.Pelicula.AddObject(entidad);
                context.SaveChanges();
            }
        }

        public Pelicula obtener(Pelicula objCliente)
        {
            return new FideCineEntities().Pelicula.Where(" it.IdPelicula = @pi_IdPelicula", new ObjectParameter[] { new ObjectParameter("pi_IdPelicula", objCliente.IdPelicula) }).First<Pelicula>();
        }

        public void eliminar(int int_pIdCartelera)
        {

            using (var context = new FideCineEntities())
            {
                context.Pelicula.DeleteObject(context.Pelicula.Where(" it.IdPelicula = @pi_IdPelicula", new ObjectParameter[] { new ObjectParameter("pi_IdPelicula", int_pIdCartelera) }).First<Pelicula>());
                context.SaveChanges();
            }
        }
    }

}