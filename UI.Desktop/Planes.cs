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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.btnAceptar.Text = "Guardar";
            formPlan.txtID.Visible = false;
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID;
            if (this.dgvPlanes.SelectedRows != null && this.dgvPlanes.SelectedRows.Count == 1)
            {
                ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
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
            if (this.dgvPlanes.SelectedRows != null && this.dgvPlanes.SelectedRows.Count == 1)
            {
                ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }
    }
}
