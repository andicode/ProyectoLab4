using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class TablaUsuario : IDAO<Usuario>
    {
        private static TablaUsuario _instance;
        List<Usuario> lUsuarios = new List<Usuario>();

        public static TablaUsuario Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new TablaUsuario();
            }
            return _instance;
        }
        /*
        public byte[] ImageToArray(System.Net.Mime.MediaTypeNames.Image Imagen)
        {
           /* MemoryStream ms = new MemoryStream();
            if (ImageFormat.Jpeg.Equals(Imagen.RawFormat))
            {
                Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else if (ImageFormat.Png.Equals(Imagen.RawFormat))
            {
                Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            }
            else if (ImageFormat.Bmp.Equals(Imagen.RawFormat))
            {
                Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else if (ImageFormat.Gif.Equals(Imagen.RawFormat))
            {
                Imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            }
            return ms.ToArray();
        }*/
        public int Existe(string unNombre) {
            try
            {
                int idUsuario=-1;
               SqlCommand cmd = new SqlCommand("SELECT IdUsuario FROM USUARIOS WHERE Nombre='"+ @unNombre +"'  ", Conexion.cn);
                Conexion.open();           
              cmd.Parameters.Add("@unNombre", System.Data.SqlDbType.VarChar);
              cmd.Parameters["@unNombre"].Value = unNombre;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    idUsuario = (int)reader.GetInt32(0);
                reader.Close();
                Conexion.close();
                return idUsuario;
            }
            catch (Exception ex)
            { 

            //mostrar error
                return -1;
            
            }
        }
        public void Agregar(Usuario usu)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=NICOLAS-PC\\SQL2005;Initial Catalog=ShareThis;User ID=sa;Password=bobesponja");
                SqlCommand cmdAgregar = new SqlCommand();
                cmdAgregar.Connection = conn; /// DAO.Conexion.Conectar();
                cmdAgregar.CommandText = "INSERT INTO Usuarios(Nombre,Apellido,Email,Fecha_Nac,Pais,Sexo,Password,Foto,Baja) VALUES (@Nombre,@Apellido,@Email,@Fecha_Nac,@Pais,@Sexo,@Password,@Foto,@Baja)";
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Fecha_Nac", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Pais", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Sexo", System.Data.SqlDbType.Char);
                cmdAgregar.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
                cmdAgregar.Parameters.Add("@Baja", System.Data.SqlDbType.Bit);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = usu.Nombre;
                cmdAgregar.Parameters["@Email"].Value = usu.Email;
                cmdAgregar.Parameters["@Fecha_Nac"].Value = usu.Fecha_nac;
                cmdAgregar.Parameters["@Pais"].Value = usu.Pais;
                cmdAgregar.Parameters["@Sexo"].Value = usu.Sexo;
                cmdAgregar.Parameters["@Password"].Value = usu.Password;
                cmdAgregar.Parameters["@Foto"].Value = usu.Foto;
                cmdAgregar.Parameters["@Baja"].Value = usu.Estado;
                conn.Open();
                cmdAgregar.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /*
        public Int64 Existe(String mail, String pass)
        {
            SqlConnection conn = new SqlConnection("Data Source=NICOLAS-PC\\SQL2005;Initial Catalog=ShareThis;User ID=sa;Password=bobesponja");
            SqlCommand cmdExiste = new SqlCommand("Select IdUsuario FROM Usuarios WHERE Email = '" + mail + "' AND Password = '" + pass + "'", conn);
            //cmdExiste.Connection = conn; /// DAO.Conexion.Conectar();

        }
        */
        public void Eliminar(Usuario usu)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=NICOLAS-PC\\SQL2005;Initial Catalog=ShareThis;User ID=sa;Password=bobesponja");
                SqlCommand cmdAgregar = new SqlCommand();
                cmdAgregar.Connection = conn;
                cmdAgregar.CommandText = "INSERT INTO Usuarios(Nombre,Apellido,Email,Fecha_Nac,Domicilio,Pais,Sexo,Password,Estado) VALUES (@Nombre,@Apellido,@Email,@Fecha_Nac,@Domicilio,@Pais,@Sexo,@Password,@Estado)";
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Fecha_Nac", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Domicilio", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Pais", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Sexo", System.Data.SqlDbType.Char);
                cmdAgregar.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                //cmdAgregar.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
                cmdAgregar.Parameters.Add("@Estado", System.Data.SqlDbType.Bit);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = usu.Nombre;
                cmdAgregar.Parameters["@Email"].Value = usu.Email;
                cmdAgregar.Parameters["@Fecha_Nac"].Value = usu.Fecha_nac;
                cmdAgregar.Parameters["@Pais"].Value = usu.Pais;
                cmdAgregar.Parameters["@Sexo"].Value = usu.Sexo;
                cmdAgregar.Parameters["@Password"].Value = usu.Password;
                //MemoryStream ms = new MemoryStream();
                //usu.Foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] arreglo = ms.ToArray();
                //cmdAgregar.Parameters["@Foto"].Value = usu.Foto;
                cmdAgregar.Parameters["@Estado"].Value = usu.Estado;
                conn.Open();
                cmdAgregar.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                //ex.Message
            }
        }

        public void Modificar(Usuario usu)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=NICOLAS-PC\\SQL2005;Initial Catalog=ShareThis;User ID=sa;Password=bobesponja");
                SqlCommand cmdAgregar = new SqlCommand();
                cmdAgregar.Connection = conn;
                cmdAgregar.CommandText = "INSERT INTO Usuarios(Nombre,Apellido,Email,Fecha_Nac,Domicilio,Pais,Sexo,Password,Estado) VALUES (@Nombre,@Apellido,@Email,@Fecha_Nac,@Domicilio,@Pais,@Sexo,@Password,@Estado)";
                //paso parametros
                cmdAgregar.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Apellido", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Fecha_Nac", System.Data.SqlDbType.DateTime);
                cmdAgregar.Parameters.Add("@Domicilio", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Pais", System.Data.SqlDbType.VarChar);
                cmdAgregar.Parameters.Add("@Sexo", System.Data.SqlDbType.Char);
                cmdAgregar.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                //cmdAgregar.Parameters.Add("@Foto", System.Data.SqlDbType.Image);
                cmdAgregar.Parameters.Add("@Estado", System.Data.SqlDbType.Bit);
                //ahora los completo
                cmdAgregar.Parameters["@Nombre"].Value = usu.Nombre;
                cmdAgregar.Parameters["@Email"].Value = usu.Email;
                cmdAgregar.Parameters["@Fecha_Nac"].Value = usu.Fecha_nac;
                cmdAgregar.Parameters["@Pais"].Value = usu.Pais;
                cmdAgregar.Parameters["@Sexo"].Value = usu.Sexo;
                cmdAgregar.Parameters["@Password"].Value = usu.Password;
                //MemoryStream ms = new MemoryStream();
                //usu.Foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //byte[] arreglo = ms.ToArray();
                //cmdAgregar.Parameters["@Foto"].Value = usu.Foto;
                cmdAgregar.Parameters["@Estado"].Value = usu.Estado;
                conn.Open();
                cmdAgregar.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                //ex.Message
            }
        }

    }

}
