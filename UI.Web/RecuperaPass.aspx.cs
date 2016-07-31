using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace UI.Web
{
    public partial class RecuperaPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            string pass = ul.RecuperarPass(usuarioTextBox.Text, emailTextBox.Text);
            if (pass != null)
            {
                this.Visible = false;
                ul.EnviarCorreo(emailTextBox.Text, pass);
                Response.Write("El correo ha sido enviado, chequee su casilla");
            }
            else
            {
                Response.Write("El usuario y el mail no se corresponden");
            }
        }

        protected void LinkBtnInicio_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }
    }
}