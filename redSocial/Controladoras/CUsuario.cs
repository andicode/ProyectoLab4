using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using Entidades;
using System.Data;

namespace Controladoras
{
    public class CUsuario
    {
        TablaUsuario dataUsuarios = TablaUsuario.Instance();


        public void AltaUsuario(String nom, String email, DateTime fecha, String pai, Char sex, String pass, String fot, Boolean esta)
        {
            Usuario auxUsu = new Usuario(nom, email, fecha, pai, sex, pass, fot, esta);
            dataUsuarios.Agregar(auxUsu);
        }
        // dado el nombre del usuario devuelvo la clave primaria: IdUsuario
        public int Existe(string nombre) { 
          return dataUsuarios.Existe(nombre);
        }

        public Int64 Existe(String mail, String pass)
        {
            return 1;//dataUsuarios.Existe(mail, pass);
        }
    }
}
