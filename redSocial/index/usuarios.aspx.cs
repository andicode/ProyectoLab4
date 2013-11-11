using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DAO;
using System.Data;
using Controladoras;

namespace index
{
    public partial class usuarios : System.Web.UI.Page
    {
        DataSet setDeDatos
        {

            get
            {
                if (Session["nuevoDataSet"] == null)
                    Session.Add("nuevoDataSet", GetDataSet());
                return (DataSet)Session["nuevoDataSet"];
            }


        }


        DataTable dtUsuarios
        {

            get
            {
                return setDeDatos.Tables[0];
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               SqlCommand cmd = new SqlCommand("select IdUsuario, Nombre, Email from Usuarios " , Conexion.cn);
                SqlDataReader reader;
                Conexion.open();
                reader = cmd.ExecuteReader();
                dtUsuarios.Load(reader);
                Conexion.close();
            }

            // andi
            btnBuscarAmigos.Click += new EventHandler(btnBuscarAmigos_Click);
            // fin andi
            gusuarios.DataSource = setDeDatos;
            gusuarios.DataBind();


        }
        private DataSet GetDataSet()
        {
            DataSet setDeDatos = new DataSet();
            DataTable dtUsuarios = new DataTable();
            dtUsuarios.Columns.Add("idUsuario");
            dtUsuarios.Columns.Add("Nombre");
            dtUsuarios.Columns.Add("Apellido");
            dtUsuarios.Columns.Add("Email");
            setDeDatos.Tables.Add(dtUsuarios);
            return setDeDatos;

        }
        private void btnBuscarAmigos_Click(object sender, EventArgs e)
        {
            // chequeo si existe en la  base de datos
            // si es mi amigo
            // si ya envie solicitud  
            // abro otro webForm
            CUsuario controlDeUsuarios=new CUsuario();
            int idMiamigo = controlDeUsuarios.Existe(tbBuscarAmigos.Text.ToString());
             // aviso que no existe 
            if (idMiamigo==-1)
                Response.Write("<p>no existe en la base de datos de usuarios</p>");
            else
                {
                // pruebo entre dos amigos cualquiera
                Controladoras.CAmistad amistad = new CAmistad();
                // dado el nombre del usuario que buscamos devuelve el id
                bool existe =amistad.existe(1,idMiamigo);
                if (existe)
                    Response.Redirect("miAmigo.aspx", existe);
                else
                {
                    Response.Redirect("datospublicos.aspx", existe);
                }
            }
          
        }
        
        
        
    }
}