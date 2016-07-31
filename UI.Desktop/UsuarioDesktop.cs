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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        List<Persona> listper = new List<Persona>();

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.Email;
            if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Consulta)
            {
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConfirmarClave.Visible = false;
                this.txtEmail.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.btnAceptar.Text = "Aceptar";
            }
            if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtEmail.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.txtConfirmarClave.Visible = false;
                this.label8.Visible = false;
                this.chkHabilitado.Visible = false;
                UsuarioActual.Habilitado = false;
            }
        }
        public override void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario usuario = new Usuario();
                UsuarioActual = usuario;
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Habilitado = true;
                UsuarioActual.IDPersona = PersonaActual.ID;
                UsuarioActual.State = Entidad.States.Nuevo;
            }

            if (Modo == ModoForm.Modificacion)
             {
                 this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                 this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                 this.UsuarioActual.Nombre = this.txtNombre.Text ;
                 this.UsuarioActual.Apellido = this.txtApellido.Text ;
                 this.UsuarioActual.Clave = this.txtClave.Text ;
                 this.UsuarioActual.Email = this.txtEmail.Text ;
                 UsuarioActual.State = Entidad.States.Modificado;
             }
            
        }
        
        public override void GuardarCambios() 
        {
            MapearADatos();
            UsuarioLogic usuario = new UsuarioLogic();
            usuario.Save(UsuarioActual);
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

            if (this.txtUsuario.Text.Length < 1)
            {
                Notificar("No puedes dejar tu usuario sin completar!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtClave.Text.Length < 8)
            {
                Notificar("Tu clave debe tener al menos 8 caracteres!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } 

            if (this.txtConfirmarClave == null)
            {
                Notificar("Debes confirmar tu clave!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtClave.Text != txtConfirmarClave.Text)
            {
                Notificar("Las claves no se corresponden!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Validaciones.IsValidEmail(this.txtEmail.Text))
            {
                Notificar("Email invalido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboPersona.SelectedIndex == -1)
            {
                Notificar("Seleccione una persona!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            UsuarioActual = usuario.GetOne(ID);
            MapearDeDatos();
        }

        public void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAceptar.Text == "Guardar")
            {
                if (Validar())
                {
                    GuardarCambios();
                    UsuarioActual.State = Entidad.States.Modificado;
                    this.Close();
                }
            }
            if (btnAceptar.Text == "Eliminar")
            {
                UsuarioLogic usu = new UsuarioLogic();
                usu.Delete(UsuarioActual.ID);
                UsuarioActual.State = Entidad.States.Eliminado;
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(listper[comboPersona.SelectedIndex].ID, listper[comboPersona.SelectedIndex].TipoPersona);
            this.txtNombre.Text = listper[comboPersona.SelectedIndex].Nombre;
            this.txtApellido.Text = listper[comboPersona.SelectedIndex].Apellido;
            this.PersonaActual.ID = listper[comboPersona.SelectedIndex].ID;
        }

        private void btnCrearPer_Click(object sender, EventArgs e)
        {
            AltaPersona altaPer = new AltaPersona();
            altaPer.ShowDialog();
            this.Close();
        }

        private Persona _PersonaActual;

        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            listper = pl.GetNom();
            AutoCompleteStringCollection acc = new AutoCompleteStringCollection();
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            if (listper.Count >= 1)
            {
                foreach (Persona per in listper)
                {
                    acc.Add(per.NombreYApellido);
                }
                //Cargo el combo
                this.comboPersona.DataSource = listper;
                this.comboPersona.DisplayMember = "NombreYApellido";
                //Cargo el autocomplete
                this.comboPersona.AutoCompleteCustomSource = acc;
                this.comboPersona.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.comboPersona.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                comboPersona.Text = "No hay personas cargadas";
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtClave.Enabled = false;
                txtConfirmarClave.Enabled = false;
                txtEmail.Enabled = false;
                txtUsuario.Enabled = false;
                chkHabilitado.Enabled = false;
                btnAceptar.Visible = false;
                comboPersona.Enabled = false;
            }
        }
    }
}
