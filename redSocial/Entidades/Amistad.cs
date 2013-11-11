using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Amistad
    {
        int idUsuario;
        int miAmigo;

        public int MiAmigo
        {
            get { return miAmigo; }
            set { miAmigo = value; }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public Amistad(int amigo1, int amigo2)
        {
            IdUsuario = amigo1;
            MiAmigo = amigo2;
        
        }
    }
}
