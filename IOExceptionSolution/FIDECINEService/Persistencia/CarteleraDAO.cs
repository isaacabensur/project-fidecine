using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIDECINEService.Dominio;
using System.Text;
using System.Data.Objects;

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

    }
}