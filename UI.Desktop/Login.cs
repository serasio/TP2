using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Validar();
        }

        public void Validar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            if(ul.Buscar(txtUsuario.Text, txtPass.Text))
            {
                this.Visible = false;
                Persona usu = new Persona();
                usu = ul.GetOnePersona(txtUsuario.Text, txtPass.Text);
                MenuPpal menu = new MenuPpal(usu);
                menu.ShowDialog();              
            }
            else
            {
                MessageBox.Show("Datos ingresados incorrectos o usuario deshabilitado. Vuelva a intentar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Enter(object sender, EventArgs e)
        {
            Validar();
        }

        private void linkPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarPass rp = new RecuperarPass();
            rp.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
