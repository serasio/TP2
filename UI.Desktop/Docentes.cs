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
    public partial class Docentes : Form
    {
        public Docentes()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvDocentes.DataSource = pl.GetAll(Persona.TiposPersonas.Docente);
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
            DocenteDesktop formDocente = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formDocente.btnAceptar.Text = "Guardar";
            formDocente.txtID.Enabled = false;
            formDocente.ShowDialog();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteDesktop formDocente = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formDocente.btnAceptar.Text = "Guardar";
            formDocente.txtID.Enabled = false;
            formDocente.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvDocentes.SelectedRows != null && this.dgvDocentes.SelectedRows.Count == 1)
            {
                ID = ((Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formDocente = new DocenteDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formDocente.ShowDialog();
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
            if (this.dgvDocentes.SelectedRows != null && this.dgvDocentes.SelectedRows.Count == 1)
            {
                ID = ((Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formDocente = new DocenteDesktop(ID, ApplicationForm.ModoForm.Baja);
                formDocente.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Docentes_Load(object sender, EventArgs e)
        {
            dgvDocentes.AutoGenerateColumns = false;
            Listar();
        }


    }
}
