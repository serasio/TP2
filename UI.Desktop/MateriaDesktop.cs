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
using Util;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        List<Especialidad> listEsp = new List<Especialidad>();
        List<Plan> listplan = new List<Plan>();

        public MateriaDesktop(ModoForm modo):this()
        {
            this.Modo = modo;
        }

        private Materia _materiaActual;

        public Materia MateriaActual
        {
            get { return _materiaActual; }
            set { _materiaActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDesc.Text = this.MateriaActual.Descripcion;
            this.cmbIDPlan.SelectedText = this.MateriaActual.IDPlan.ToString();
            this.txtHsTot.Text = this.MateriaActual.HSTotales.ToString();
            this.txtHsSem.Text = this.MateriaActual.HSSemanales.ToString();
            if(Modo==ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            if(Modo==ModoForm.Consulta)
            {
                txtID.ReadOnly = true;
                txtDesc.ReadOnly = true;
                cmbIDPlan.Enabled = false;
                cmbEspecialidades.Enabled = false;
                txtHsTot.ReadOnly = true;
                txtHsSem.ReadOnly = true;
                btnAceptar.Text = "Aceptar";
            }
            if(Modo==ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                cmbIDPlan.Enabled = false;
                cmbEspecialidades.Enabled = false;
                txtDesc.ReadOnly = true;
                txtHsSem.ReadOnly = true;
                txtHsTot.ReadOnly = true;
            }
        }

        public override void MapearADatos()
        {
            if(Modo==ModoForm.Alta)
            {
                Materia materia = new Materia();
                MateriaActual = materia;
                MateriaActual.Descripcion = txtDesc.Text;
                MateriaActual.IDPlan = listplan[cmbIDPlan.SelectedIndex].ID;
                MateriaActual.HSTotales = int.Parse(txtHsTot.Text);
                MateriaActual.HSSemanales = int.Parse(txtHsSem.Text);
                MateriaActual.State = Entidad.States.Nuevo;
            }
            if(Modo==ModoForm.Modificacion)
            {
                this.MateriaActual.ID = int.Parse(this.txtID.Text);
                this.MateriaActual.Descripcion = this.txtDesc.Text;
                this.MateriaActual.IDPlan = listplan[cmbIDPlan.SelectedIndex].ID;
                this. MateriaActual.HSTotales = int.Parse(this.txtHsTot.Text);
                this.MateriaActual.HSSemanales = int.Parse(this.txtHsSem.Text);
                MateriaActual.State = Entidad.States.Modificado;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic materia = new MateriaLogic();
            materia.Save(MateriaActual);
        }

        public override bool Validar()
        {
            if (this.txtDesc.Text.Length < 1)
            {
                Notificar("No puedes dejar la descripción sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.txtHsTot.Text.Length < 1)
            {
                Notificar("No puedes dejar las horas totales sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.txtHsSem.Text.Length < 1)
            {
                Notificar("No puedes dejar las horas semanales sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.cmbIDPlan.SelectedIndex == -1)
            {
                Notificar("No puedes dejar el plan sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            int result = 0;
            if (!int.TryParse(txtHsTot.Text, out result) || result <= 0)
            {
                Notificar("Debes ingresar un entero positivo mayor a cero en las horas totales!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtHsSem.Text, out result) || result <= 0)
            {
                Notificar("Debes ingresar un entero positivo mayor a cero en las horas semanales!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public new void Notificar(string mensaje, string titulo, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(mensaje, this.Text, botones, icono);
        }

        public MateriaDesktop(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            MateriaLogic materia = new MateriaLogic();
            MateriaActual = materia.GetOne(ID);
            MapearDeDatos();
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            EspecialidadLogic esp = new EspecialidadLogic();
            PlanLogic plan = new PlanLogic();
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                listEsp = esp.GetAll();
                listplan = plan.GetAll();
                if (listEsp.Count >= 1)
                {
                    cmbEspecialidades.DataSource = listEsp;
                    cmbEspecialidades.DisplayMember = "Descripcion";
                }
                
                else
                {
                    cmbEspecialidades.Text = "No hay especialidades cargadas";
                    cmbEspecialidades.Enabled = false;
                    cmbIDPlan.Enabled = false;
                    btnAceptar.Visible = false;
                }

                if (listplan.Count >= 1)
                {
                    cmbIDPlan.DataSource = listplan;
                    cmbIDPlan.DisplayMember = "Descripcion";
                }

                else
                {
                    cmbIDPlan.Text = "No hay planes cargados";
                    cmbEspecialidades.Enabled = false;
                    cmbIDPlan.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
            if (Modo == ModoForm.Baja)
            {
                listplan.Add(plan.GetOne(MateriaActual.IDPlan));
                cmbEspecialidades.DataSource = listplan;
                cmbIDPlan.DataSource = listplan;
                cmbIDPlan.DisplayMember = "Descripcion";
                cmbEspecialidades.DisplayMember = "DescripcionEspecialidad";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    GuardarCambios();
                    Plan planSeleccionado = listplan[cmbIDPlan.SelectedIndex];
                    MateriaActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
        
            if (btnAceptar.Text == "Eliminar")
            {
                MateriaLogic mat = new MateriaLogic();
                mat.Delete(MateriaActual.ID);
                MateriaActual.State = Entidad.States.Eliminado;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PlanLogic plan = new PlanLogic();
                listplan = plan.GetAll(listEsp[cmbEspecialidades.SelectedIndex].ID);
                if (listplan.Count >= 1)
                {
                    cmbIDPlan.DataSource = listplan;
                    cmbIDPlan.Enabled = true;
                    btnAceptar.Visible = true;
                    cmbIDPlan.DisplayMember = "Descripcion";
                }
                else
                {
                    btnAceptar.Visible = false;
                    cmbIDPlan.Enabled = false;
                    cmbIDPlan.Text = "No hay planes cargados";
                }
            }
        }
    }
}
