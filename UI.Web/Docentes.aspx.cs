using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace UI.Web
{
    public partial class Docentes : System.Web.UI.Page
    {
        protected Persona UsuarioLogueado
        {
            get { return (Persona)Session["Usuario"]; }
            set { UsuarioLogueado = (Persona)Session["Usuario"]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadGrid();
        }

        private PersonaLogic _logic;

        public PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new PersonaLogic();
                return _logic;
            }
        }

        private void LoadGrid()
        {
            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Docente)
            {
                this.gridView.DataSource = this.Logic.GetOne(UsuarioLogueado.ID, UsuarioLogueado.TipoPersona);
                this.editarLinkButton.Visible = false;
                this.nuevoLinkButton.Visible = false;
                this.eliminarLinkButton.Visible = false;
            }
            else
            {
                this.gridView.DataSource = this.Logic.GetAll(Persona.TiposPersonas.Docente);
            } 
            this.gridView.DataBind();
            this.formActionsPanel.Visible = false;
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Persona Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }


        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id, Persona.TiposPersonas.Docente);
            this.txtbNombre.Text = this.Entity.Nombre;
            this.txtbApellido.Text = this.Entity.Apellido;
            this.txtbLegajo.Text = this.Entity.Legajo.ToString();
            this.txtbTelefono.Text = this.Entity.Telefono;
            this.txtbDireccion.Text = this.Entity.Direccion;
            this.txtbFechaNac.Text = this.Entity.FechaNacimiento.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
                this.gridView.Visible = false;
                this.formActionsPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
            }
        }

        private void LoadEntity(Persona docente)
        {
            docente.Nombre = this.txtbNombre.Text;
            docente.Apellido = this.txtbApellido.Text;
            docente.Telefono = this.txtbTelefono.Text;
            docente.Direccion = this.txtbDireccion.Text;
            docente.Legajo = int.Parse(this.txtbLegajo.Text);
            docente.FechaNacimiento = DateTime.Parse(this.txtbFechaNac.Text);
            docente.TipoPersona = Persona.TiposPersonas.Docente;
        }

        private void SaveEntity(Persona docente)
        {
            this.Logic.Save(docente);
        }


        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new Persona();
            this.Entity.ID = this.SelectedID;
            this.Entity.State = Entidad.States.Modificado;
            this.LoadEntity(this.Entity);
            this.SaveEntity(Entity);
            this.LoadGrid();
            this.formPanel.Visible = false;
            this.gridView.Visible = true;
            this.formActionsPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = Entidad.States.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.txtbNombre.Enabled = enable;
            this.txtbApellido.Enabled = enable;
            this.txtbDireccion.Enabled = enable;
            this.txtbLegajo.Enabled = enable;
            this.txtbTelefono.Enabled = enable;
            this.txtbFechaNac.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
                this.formActionsPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
                this.gridView.Visible = false;
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.formActionsPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.gridView.Visible = false;
        }

        private void ClearForm()
        {
            this.txtbTelefono.Text = string.Empty;
            this.txtbNombre.Text = string.Empty;
            this.txtbLegajo.Text = string.Empty;
            this.txtbDireccion.Text = string.Empty;
            this.txtbApellido.Text = string.Empty;
            this.txtbFechaNac.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Docentes.aspx");
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}