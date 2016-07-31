using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        public void Validar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            if (ul.Buscar(usuarioTextBox.Text, passTextBox.Text))
            {
                this.Visible = false;
                Persona usu = new Persona();
                usu = ul.GetOnePersona(usuarioTextBox.Text, passTextBox.Text);
                Session["Usuario"] = usu;               
                Response.Redirect("MenuPpal.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void passLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("RecuperaPass.aspx", true);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Validar();
        }
    }
}