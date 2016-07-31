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
    public partial class Materias : System.Web.UI.Page
    {
        protected Persona UsuarioLogueado
        {
            get { return (Persona)Session["Usuario"]; }
            set { UsuarioLogueado = (Persona)Session["Usuario"]; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                PlanLogic pl = new PlanLogic();
                listplan = pl.GetAll();
                DropDownListPlan.DataSource = listplan;
                DropDownListPlan.DataTextField = "PlanEspecialidadDesc";
                DropDownListPlan.DataBind();
            }    
        }

        static List<Plan> listplan;

        private MateriaLogic _logic;

        public MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new MateriaLogic();
                return _logic;
            }
        }

        private void LoadGrid()
        {
            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                this.gridView.DataSource = this.Logic.GetAll(UsuarioLogueado.IDPlan);
                this.editarLinkButton.Visible=false;
                this.nuevoLinkButton.Visible = false;
                this.eliminarLinkButton.Visible = false;
            }
            else
            {
                this.gridView.DataSource = this.Logic.GetAll();
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

        private Materia Entity
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
            this.hsTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            this.hsSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.DropDownListPlan.Text = this.Entity.DescripcionPlanCarrera;
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

        private void LoadEntity(Materia mat)
        {
            mat.Descripcion = this.descTextBox.Text;
            mat.HSTotales = int.Parse(this.hsTotalesTextBox.Text);
            mat.HSSemanales = int.Parse(this.hsSemanalesTextBox.Text);
            mat.IDPlan = listplan[DropDownListPlan.SelectedIndex].ID;
        }

        private void SaveEntity(Materia mat)
        {
            this.Logic.Save(mat);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new Materia();
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = Entidad.States.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
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
            this.hsTotalesTextBox.Enabled = enable;
            this.hsSemanalesTextBox.Enabled = enable;
            this.DropDownListPlan.Enabled = enable;
        }

        private void ClearForm()
        {
            this.descTextBox.Text = string.Empty;
            this.hsTotalesTextBox.Text = string.Empty;
            this.hsSemanalesTextBox.Text=string.Empty;
            this.DropDownListPlan.ClearSelection();
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

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Materias.aspx");
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}