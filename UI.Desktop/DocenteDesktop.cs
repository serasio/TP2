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
    public partial class DocenteDesktop : ApplicationForm
    {
        public DocenteDesktop()
        {
            InitializeComponent();
        }


        public DocenteDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public DocenteDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PersonaLogic docente = new PersonaLogic();
            DocenteActual = docente.GetOne(ID, Persona.TiposPersonas.Docente);
            MapearDeDatos();
        }

        private Persona _docenteActual;

        public Persona DocenteActual
        {
            get { return _docenteActual; }
            set { _docenteActual = value; }
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocenteActual.ID.ToString();
            this.txtNombre.Text = this.DocenteActual.Nombre;
            this.txtApellido.Text = this.DocenteActual.Apellido;
            this.txtDireccion.Text = this.DocenteActual.Direccion;
            this.dtpFechaNac.Text = this.DocenteActual.FechaNacimiento.ToString();
            this.txtLegajo.Text = this.DocenteActual.Legajo.ToString();
            this.txtTelefono.Text = this.DocenteActual.Telefono.ToString();
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
                dtpFechaNac.Enabled = true;
                txtLegajo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
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
                Persona docente = new Persona();
                this.DocenteActual = docente;
                DocenteActual.TipoPersona = Persona.TiposPersonas.Docente;
                this.DocenteActual.Nombre = txtNombre.Text;
                this.DocenteActual.Apellido = txtApellido.Text;
                this.DocenteActual.Direccion = txtDireccion.Text;
                this.DocenteActual.Telefono = txtTelefono.Text;
                //this.DocenteActual.Legajo = int.Parse(txtLegajo.Text);
                this.DocenteActual.FechaNacimiento = DateTime.Parse(dtpFechaNac.Text);
                this.DocenteActual.State = Entidad.States.Nuevo;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.DocenteActual.ID = int.Parse(this.txtID.Text);
                this.DocenteActual.Nombre = txtNombre.Text;
                this.DocenteActual.Apellido = txtApellido.Text;
                this.DocenteActual.Direccion = txtDireccion.Text;
                this.DocenteActual.Telefono = txtTelefono.Text;
                //this.DocenteActual.Legajo = int.Parse(txtLegajo.Text);
                this.DocenteActual.FechaNacimiento = DateTime.Parse(dtpFechaNac.Text);
                this.DocenteActual.State = Entidad.States.Modificado;
            }
        }

        private void DocentesDesktop_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
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
            persona.Save(DocenteActual);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    GuardarCambios();
                    DocenteActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
            if (btnAceptar.Text == "Eliminar")
            {
                PersonaLogic doc = new PersonaLogic();
                doc.Delete(DocenteActual.ID);
                DocenteActual.State = Entidad.States.Eliminado;
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
