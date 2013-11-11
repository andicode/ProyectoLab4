using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Entidades;

namespace Controladoras
{
    public class CAmistad
    {

        TablaAmistad dataAmistad = TablaAmistad.Instance();


        public void AltaAmistad(int usuario1, int usuario2)
        {
            Amistad amiguitos = new Amistad(usuario1,usuario2);
            dataAmistad.Agregar(amiguitos);
            // elimino la solicitud.

        } 

        public bool existe(int yo, int miAmigo)
        {
            return dataAmistad.Existe(yo,miAmigo);
            //return true;

        }
    }
}
