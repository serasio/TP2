using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Negocio;
using Entidades;

namespace UI.Web
{
    public partial class Especialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadGrid();
        }

        private EspecialidadLogic _logic;

        public EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
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

        private Especialidad Entity
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
            this.Entity = this.Logic.GetOne(id);
            this.descTextBox.Text = this.Entity.Descripcion;
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

        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = this.descTextBox.Text;
        }

        private void SaveEntity(Especialidad especialidad)
        {
            this.Logic.Save(especialidad);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new Especialidad();
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
                    this.Entity = new Especialidad();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = Entidad.States.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Especialidad();
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
            this.descTextBox.Enabled = enable;
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
            this.descTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Especialidades.aspx");
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}