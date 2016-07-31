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
    public partial class Inscripciones : ApplicationForm
    {
        public Inscripciones(Persona usu)
        {
            InitializeComponent();
            UsuarioLogeado = usu;
            dgvInscripciones.AutoGenerateColumns = false;
        }

        private Persona _usuarioLogeado;

        public Persona UsuarioLogeado
        {
            get { return _usuarioLogeado; }
            set { _usuarioLogeado = value; }
        }

        void Listar()
        {
            AluInscripcionLogic ail = new AluInscripcionLogic();

            this.dgvInscripciones.DataSource = ail.GetAll();
        }

        void ListarAlumno()
        {
            AluInscripcionLogic ail = new AluInscripcionLogic();

            this.dgvInscripciones.DataSource = ail.GetAllAlumno(UsuarioLogeado.ID);
        }

        void ListarProfesor()
        {
            AluInscripcionLogic ail = new AluInscripcionLogic();

            this.dgvInscripciones.DataSource = ail.GetAllProfesor(UsuarioLogeado.ID);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            InscripcionDesktop formInscripcion = new InscripcionDesktop(ApplicationForm.ModoForm.Alta, UsuarioLogeado);
            formInscripcion.btnAceptar.Text = "Guardar";
            formInscripcion.ShowDialog();
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
                this.ListarAlumno();
            else
                this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvInscripciones.SelectedRows != null && this.dgvInscripciones.SelectedRows.Count == 1)
            {
                ID = ((AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop formInscripcion = new InscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                formInscripcion.btnAceptar.Text = "Eliminar";
                formInscripcion.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
                ListarAlumno();
            else if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Docente)
                ListarProfesor();
            else
                Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                ListarAlumno();
                this.tsbEditar.Visible = false;
                this.tsbEliminar.Visible = false;
            }
            else if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Docente)
            {
                ListarProfesor();
                this.tsbNuevo.Visible = false;
                this.tsbEliminar.Visible = false;
            }
            else
                Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            int ID;
            if (this.dgvInscripciones.SelectedRows != null && this.dgvInscripciones.SelectedRows.Count == 1)
            {
                ID = ((AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                InscripcionDesktop formInscripcion;
                formInscripcion = new InscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion, UsuarioLogeado);
                formInscripcion.btnAceptar.Text = "Guardar";
                formInscripcion.ShowDialog();
                if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Docente)
                {
                    this.ListarProfesor();
                }
                else 
                    this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar!","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
