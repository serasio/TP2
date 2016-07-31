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
    public partial class AlumnoDesktop : ApplicationForm
    {
        public AlumnoDesktop()
        {
            InitializeComponent();
        }

        List<Plan> listplan = new List<Plan>();

        public AlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PersonaLogic alumno = new PersonaLogic();
            AlumnoActual = alumno.GetOne(ID, Persona.TiposPersonas.Alumno);
            MapearDeDatos();
        }

        private Persona _alumnoActual;

        public Persona AlumnoActual
        {
            get { return _alumnoActual; }
            set { _alumnoActual = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.AlumnoActual.ID.ToString();
            this.txtNombre.Text = this.AlumnoActual.Nombre;
            this.txtApellido.Text = this.AlumnoActual.Apellido;
            this.txtDireccion.Text = this.AlumnoActual.Direccion;
            this.txtFechaNac.Text = this.AlumnoActual.FechaNacimiento.ToString();
            this.txtLegajo.Text = this.AlumnoActual.Legajo.ToString();
            this.txtTelefono.Text = this.AlumnoActual.Telefono.ToString();
            this.comboIDPlan.SelectedText = this.AlumnoActual.IDPlan.ToString();
            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Consulta)
            {
                txtID.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtFechaNac.Enabled = true;
                txtLegajo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                comboIDPlan.Enabled = false;
                btnAceptar.Text = "Aceptar";
            }
            if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Persona alumno = new Persona();
                this.AlumnoActual = alumno;
                AlumnoActual.TipoPersona = Persona.TiposPersonas.Alumno;
                this.AlumnoActual.Nombre = txtNombre.Text;
                this.AlumnoActual.Apellido = txtApellido.Text;
                this.AlumnoActual.Direccion = txtDireccion.Text;
                this.AlumnoActual.Telefono = txtTelefono.Text;
                //this.AlumnoActual.Legajo = int.Parse(txtLegajo.Text);
                this.AlumnoActual.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                this.AlumnoActual.IDPlan = listplan[comboIDPlan.SelectedIndex].ID;
                this.AlumnoActual.State = Entidad.States.Nuevo;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.AlumnoActual.ID = int.Parse(this.txtID.Text);
                this.AlumnoActual.Nombre = txtNombre.Text;
                this.AlumnoActual.Apellido = txtApellido.Text;
                this.AlumnoActual.Direccion = txtDireccion.Text;
                this.AlumnoActual.Telefono = txtTelefono.Text;
                //this.AlumnoActual.Legajo = int.Parse(txtLegajo.Text);
                this.AlumnoActual.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                this.AlumnoActual.IDPlan = listplan[comboIDPlan.SelectedIndex].ID;
                this.AlumnoActual.State = Entidad.States.Modificado;
            }
        }

        private void AlumnoDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic plan = new PlanLogic();
            listplan = plan.GetAll();
            if (listplan.Count >= 1)
            {
                comboIDPlan.DataSource = listplan;
                comboIDPlan.DisplayMember = "PlanEspecialidadDesc";
            }
            else
            {
                comboIDPlan.Text = "No hay planes cargados";
                btnAceptar.Visible = false;
                txtApellido.Enabled = false;
                txtDireccion.Enabled = false;
                txtFechaNac.Enabled = false;
                txtLegajo.Enabled = false;
                txtNombre.Enabled = false;
                txtTelefono.Enabled = false;
                comboIDPlan.Enabled = false;
            }
        }

        public override bool Validar()
        {

            if (this.txtNombre.Text.Length < 1)
            {
                Notificar("No puedes dejar tu nombre sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtApellido.Text.Length < 1)
            {
                Notificar("No puedes dejar tu apellido sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

             return true;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic persona = new PersonaLogic();
            persona.Save(AlumnoActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    GuardarCambios();
                    AlumnoActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
            if (btnAceptar.Text == "Eliminar")
            {
                PersonaLogic alu = new PersonaLogic();
                alu.Delete(AlumnoActual.ID);
                AlumnoActual.State = Entidad.States.Eliminado;
                GuardarCambios();
                this.Close();
            }
        }
    }
}
