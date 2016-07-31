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
    public partial class Materias : Form
    {
        public Materias(Persona usu)
        {
            InitializeComponent();
            UsuarioLogeado = usu;
            dgvMaterias.AutoGenerateColumns = false;
        }

        private Persona _usuarioLogeado;

        public Persona UsuarioLogeado
        {
            get { return _usuarioLogeado; }
            set { _usuarioLogeado = value; }
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
        }

        public void ListarAlumno()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAllAlumno(UsuarioLogeado.IDPlan);
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                toolStrip1.Visible = false;
                ListarAlumno();
            }
            else
                Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (UsuarioLogeado.TipoPersona == Persona.TiposPersonas.Alumno)
                ListarAlumno();
            else
                Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.btnAceptar.Text = "Guardar";
            formMateria.txtID.Visible = false;
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvMaterias.SelectedRows!=null && this.dgvMaterias.SelectedRows.Count==1)
            {
                ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvMaterias.SelectedRows != null && this.dgvMaterias.SelectedRows.Count == 1)
            {
                ID = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
