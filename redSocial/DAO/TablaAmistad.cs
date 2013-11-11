using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;


namespace DAO
{
    public class TablaAmistad: IDAO<Amistad>
    {
        private static TablaAmistad _instance;

        public static TablaAmistad Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new TablaAmistad();
            }
            return _instance;
        }

        public void Agregar(Amistad miAmistad) { 
        
        
        }
        public bool Existe(int yo, int miAmigo) {
           // try
            //{
                SqlCommand cmd = new SqlCommand("SELECT * FROM AMISTADES WHERE (IdUsuario1=@uno and IdUsuario2=@dos) or (IdUsuario2=@uno and IdUsuario1=@dos) ", Conexion.cn);
                int reader;
                cmd.Parameters.Add("@uno", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@dos", System.Data.SqlDbType.Int);
                cmd.Parameters["@uno"].Value = yo;
                cmd.Parameters["@dos"].Value = miAmigo;
                
                Conexion.open();
                reader = Convert.ToInt32(cmd.ExecuteScalar());
                Conexion.close();   
                if (reader > 0)
                    return true;
                else
                    return false;
        
        }
        public void Modificar(Amistad miAmistad) { 
        
        }
        public void Eliminar(Amistad miAmistad) { 
        
        
        }

    }
}
