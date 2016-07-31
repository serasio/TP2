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
    public partial class PlanDesktop : ApplicationForm
    {
        List<Especialidad> listEspecialidades = new List<Especialidad>();
        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.comboIDEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;
            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Consulta)
            {
                txtID.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                comboIDEspecialidad.Enabled = false;
                btnAceptar.Text = "Aceptar";
            }
            if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtID.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                comboIDEspecialidad.Enabled = false;
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Plan plan = new Plan();
                PlanActual = plan;
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = listEspecialidades[this.comboIDEspecialidad.SelectedIndex].ID;
                PlanActual.State = Entidad.States.Nuevo;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.PlanActual.ID = int.Parse(this.txtID.Text);
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = listEspecialidades[comboIDEspecialidad.SelectedIndex].ID;
                PlanActual.State = Entidad.States.Modificado;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic plan = new PlanLogic();
            plan.Save(PlanActual);
        }

        public override bool Validar()
        {
            if (this.comboIDEspecialidad.SelectedIndex == -1)
            {
                Notificar("No puedes dejar la especialidad sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtDescripcion.Text.Length < 1)
            {
                Notificar("No puedes dejar la descripción sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Plan _planActual;

        public Plan PlanActual
        {
            get { return _planActual; }
            set { _planActual = value; }
        }

        public PlanDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            PlanLogic plan = new PlanLogic();
            PlanActual = plan.GetOne(ID);
            MapearDeDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    Especialidad especialidadSeleccionada = listEspecialidades[comboIDEspecialidad.SelectedIndex];
                    GuardarCambios();
                    PlanActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }

            if (btnAceptar.Text == "Eliminar")
            {
                PlanLogic plan = new PlanLogic();
                plan.Delete(PlanActual.ID);
                PlanActual.State = Entidad.States.Eliminado;
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            EspecialidadLogic especialidad = new EspecialidadLogic();
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                listEspecialidades = especialidad.GetAll();
                if (listEspecialidades.Count >= 1)
                {
                    comboIDEspecialidad.DataSource = listEspecialidades;
                    comboIDEspecialidad.DisplayMember = "Descripcion";
                }
                else
                {
                    comboIDEspecialidad.Text = "No hay especialidades cargadas";
                    comboIDEspecialidad.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
            if (Modo == ModoForm.Baja)
            {
                listEspecialidades.Add(especialidad.GetOne(PlanActual.IDEspecialidad));
                comboIDEspecialidad.DataSource = listEspecialidades;
                comboIDEspecialidad.DisplayMember = "Descripcion";
            }
        }
    }
}
