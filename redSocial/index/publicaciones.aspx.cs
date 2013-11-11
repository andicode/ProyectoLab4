using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladoras;

namespace index
{
    public partial class publicaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             btnBuscarAmigos.Click += new EventHandler(btnBuscarAmigos_Click);
        }

        private void btnBuscarAmigos_Click(object sender, EventArgs e)
        {
            // chequeo si existe en la  base de datos
            // si es mi amigo
            // si ya envie solicitud  
            // abro otro webForm
            CUsuario controlDeUsuarios = new CUsuario();
            int idMiamigo = controlDeUsuarios.Existe(tbBuscarAmigos.Text.ToString());
            // aviso que no existe 
            if (idMiamigo == -1)
                Response.Write("<p>no existe en la base de datos de usuarios</p>");
            else
            {
                // pruebo entre dos amigos cualquiera
                Controladoras.CAmistad amistad = new CAmistad();
                // dado el nombre del usuario que buscamos devuelve el id
                bool existe = amistad.existe(1, idMiamigo);
                if (existe)
                    Response.Redirect("miAmigo.aspx", existe);
                else
                {
                    Response.Redirect("datospublicos.aspx", existe);
                }
            }

        }
}   }