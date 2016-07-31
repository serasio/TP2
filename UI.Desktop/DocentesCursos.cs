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
    public partial class DocentesCursos : Form
    {
        public DocentesCursos()
        {
            InitializeComponent();
            dgvDocCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            DocCursoLogic dcl = new DocCursoLogic();
            this.dgvDocCursos.DataSource = dcl.GetAll();
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop formDocCurso = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocCurso.btnAceptar.Text = "Guardar";
            formDocCurso.txtID.Visible = false;
            formDocCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID;
            if(this.dgvDocCursos.SelectedRows!=null && this.dgvDocCursos.SelectedRows.Count==1)
            {
                ID = ((DocenteCurso)this.dgvDocCursos.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop formDocCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formDocCurso.ShowDialog();
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
            if (this.dgvDocCursos.SelectedRows != null && this.dgvDocCursos.SelectedRows.Count == 1)
            {
                ID = ((DocenteCurso)this.dgvDocCursos.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop formDocCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formDocCurso.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        } 

    }
}
