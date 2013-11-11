using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Usuario
    {
        String nombre;
        String email;
        DateTime fecha_nac;
        String pais;
        Char sexo;
        String password;
        //Image*/ 
        String foto;
        Boolean estado;
        Int64 idusuario;


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime Fecha_nac
        {
            get { return fecha_nac; }
            set { fecha_nac = value; }
        }
        public String Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        public Char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public Int64 IdUsuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }

        public Usuario(String nom, String ema, DateTime fecha, String pai, Char sex, String pass, String fot, Boolean esta)
        {
            nombre = nom;
            email = ema;
            fecha_nac = fecha;
            pais = pai;
            sexo = sex;
            password = pass;
            foto = fot;
            estado = esta;
        }
    }
}
