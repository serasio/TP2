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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
                
            }
            if (Modo == ModoForm.Consulta)
            {
                this.txtID.ReadOnly = true;
                this.txtDescripcion.ReadOnly = true;
                btnAceptar.Text = "Aceptar";
            }
            if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                this.txtDescripcion.ReadOnly = true;
                
            }
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Especialidad especialidad = new Especialidad();
                EspecialidadActual = especialidad;
                EspecialidadActual.Descripcion = txtDescripcion.Text;
                EspecialidadActual.State = Entidad.States.Nuevo;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.ID = int.Parse(this.txtID.Text);
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                EspecialidadActual.State = Entidad.States.Modificado;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic especialidad = new EspecialidadLogic();
            especialidad.Save(EspecialidadActual);
        }

        public override bool Validar()
        {

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

        private Especialidad _especialidadActual;

        public Especialidad EspecialidadActual
        {
            get { return _especialidadActual; }
            set { _especialidadActual = value; }
        }

        public EspecialidadDesktop(int ID, ModoForm modo)
            : this()
        {
            this.Modo = modo;
            EspecialidadLogic especialidad = new EspecialidadLogic();
            EspecialidadActual = especialidad.GetOne(ID);
            MapearDeDatos();
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    GuardarCambios();
                    EspecialidadActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
            if (btnAceptar.Text == "Eliminar")
            {
                EspecialidadLogic esp = new EspecialidadLogic();
                esp.Delete(EspecialidadActual.ID);
                EspecialidadActual.State = Entidad.States.Eliminado;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
