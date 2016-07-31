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
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        List<Plan> listplan = new List<Plan>();

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        private Comision _comisionActual;

        public Comision ComisionActual
        {
            get { return _comisionActual; }
            set { _comisionActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.comboIDPlan.SelectedText = this.ComisionActual.IDPlan.ToString();
            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
                ComisionActual.State = Entidad.States.Modificado;
            }
            if (Modo == ModoForm.Consulta)
            {
                txtID.ReadOnly = true;
                txtAnioEspecialidad.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                comboIDPlan.Enabled = false;
                btnAceptar.Text = "Aceptar";
            }
            if (Modo == ModoForm.Baja)
            {
                Notificar("Atención! Si elimina la comisión también se eliminarán los cursos asociados a la misma!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAceptar.Text = "Eliminar";
                comboIDPlan.Enabled = false;
                txtAnioEspecialidad.Enabled = false;
                txtDescripcion.Enabled = false;
            }
        }

        public override void MapearADatos()
        {
            if(Modo==ModoForm.Alta)
            {
                Comision comision = new Comision();
                this.ComisionActual = comision;
                this.ComisionActual.AnioEspecialidad = int.Parse(txtAnioEspecialidad.Text);
                this.ComisionActual.Descripcion = txtDescripcion.Text;
                this.ComisionActual.IDPlan = listplan[comboIDPlan.SelectedIndex].ID;
                this.ComisionActual.State = Entidad.States.Nuevo;
            }

            if(Modo==ModoForm.Modificacion)
            {
                this.ComisionActual.ID = int.Parse(this.txtID.Text);
                this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.IDPlan = listplan[comboIDPlan.SelectedIndex].ID;
                this.ComisionActual.State = Entidad.States.Modificado;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic comision = new ComisionLogic();
            comision.Save(ComisionActual);
        }

        public override bool Validar()
        {
            if (this.txtAnioEspecialidad.Text.Length < 1)
            {
                Notificar("No puedes dejar el año sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.txtDescripcion.Text.Length < 1)
            {
                Notificar("No puedes dejar la descripción sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.comboIDPlan.SelectedIndex == -1)
            {
                Notificar("No puedes dejar el plan sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int result = 0;
            if (!int.TryParse(txtAnioEspecialidad.Text, out result) || result <= 0)
            {
                Notificar("Debes ingresar un entero positivo mayor a cero en el año de la especialidad!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public ComisionDesktop(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            ComisionLogic comision = new ComisionLogic();
            ComisionActual = comision.GetOne(ID);
            MapearDeDatos();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic plan = new PlanLogic();
            listplan = plan.GetAll();
            comboIDPlan.DataSource = listplan;
            if (listplan.Count >= 1)
                comboIDPlan.DisplayMember = "PlanEspecialidadDesc";
            else
            {
                comboIDPlan.Enabled = false;
                btnAceptar.Visible = false;
                comboIDPlan.Text = "No hay planes cargados";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    Plan planSeleccionado = listplan[comboIDPlan.SelectedIndex];
                    GuardarCambios();
                    ComisionActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }

            if (btnAceptar.Text == "Eliminar")
            {
                ComisionLogic com = new ComisionLogic();
                com.Delete(ComisionActual.ID);
                ComisionActual.State = Entidad.States.Eliminado;
                this.Close();
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
