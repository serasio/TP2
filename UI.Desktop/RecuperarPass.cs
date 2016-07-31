using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace UI.Desktop
{
    public partial class RecuperarPass : Form
    {
        public RecuperarPass()
        {
            InitializeComponent();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            string pass = ul.RecuperarPass(txtUsuario.Text, txtEmail.Text);
            if (pass != null)
            {
                this.Visible = false;
                ul.EnviarCorreo(txtEmail.Text, pass);
                MessageBox.Show("El correo ha sido enviado, chequee su casilla");
            }
            else
            {
                MessageBox.Show("El usuario y el mail no se corresponden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
