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
using Entidades;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios(Persona usu)
        {
            InitializeComponent();
            UsuarioLogeado = usu;
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private Persona _usuarioLogeado;

        public Persona UsuarioLogeado
        {
            get { return _usuarioLogeado; }
            set { _usuarioLogeado = value; }
        }

        void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        void ListarUsuarioLogeado()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetOneAlumno(UsuarioLogeado.IDUsuario);
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno || UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Docente)
            {
                this.ListarUsuarioLogeado();
                this.tsbNuevo.Visible = false;
                this.tsbEliminar.Visible = false;
                this.tsbEditar.Visible = false;
            }
            else 
                this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno || UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Docente)
                this.ListarUsuarioLogeado();
            else
                this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.btnAceptar.Text = "Guardar";
            formUsuario.chkHabilitado.Visible = false;
            formUsuario.txtID.Visible = false;
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            int ID;
            if (this.dgvUsuarios.SelectedRows != null && this.dgvUsuarios.SelectedRows.Count == 1)
            {
                ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar!","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvUsuarios.SelectedRows != null && this.dgvUsuarios.SelectedRows.Count == 1)
            {
                ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
