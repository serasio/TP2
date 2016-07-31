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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
            dgvAlumnos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvAlumnos.DataSource = pl.GetAll(Persona.TiposPersonas.Alumno);
        }

        /*private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }*/

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        public void AltaPersona()
        {
            AlumnoDesktop formAlumno = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.btnAceptar.Text = "Guardar";
            formAlumno.txtID.Enabled = false;
            formAlumno.ShowDialog();
        }
    
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoDesktop formAlumno = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.btnAceptar.Text = "Guardar";
            formAlumno.txtID.Visible = false;
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvAlumnos.SelectedRows != null && this.dgvAlumnos.SelectedRows.Count == 1)
            {
                ID = ((Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formAlumno.ShowDialog();
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
            if (this.dgvAlumnos.SelectedRows != null && this.dgvAlumnos.SelectedRows.Count == 1)
            {
                ID = ((Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
                AlumnoDesktop formAlumno = new AlumnoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formAlumno.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            Listar();
        }

    }
}
