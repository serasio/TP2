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
    public partial class DocentesCursos : System.Web.UI.Page
    {
        protected Persona UsuarioLogueado
        {
            get { return (Persona)Session["Usuario"]; }
            set { UsuarioLogueado = (Persona)Session["Usuario"]; }
        }

        static List<string> listcargo = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                CursoLogic cl = new CursoLogic();
                listcurso = cl.GetAll();
                PersonaLogic pl = new PersonaLogic();
                listdoc = pl.GetAll(Persona.TiposPersonas.Docente);
                ddlCurso.DataSource = listcurso;
                ddlCurso.DataTextField = "MateriaComision";
                ddlCurso.DataBind();
                ddlDocente.DataSource = listdoc;
                ddlDocente.DataTextField = "NombreYApellido";
                ddlDocente.DataBind();
                listcargo.Add("Titular");
                listcargo.Add("Auxiliar");
                listcargo.Add("Suplente");
            }    
        }

        static List<Curso> listcurso;
        static List<Persona> listdoc;

        private DocCursoLogic _logic;

        public DocCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new DocCursoLogic();
                return _logic;
            }
        }

        private void LoadGrid()
        {
            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Docente)
            {
                this.gridView.DataSource = this.Logic.GetAll(UsuarioLogueado.ID);
                this.editarLinkButton.Visible = false;
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

        private DocenteCurso Entity
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
            this.ddlCargo.SelectedValue = this.Entity.Cargo.ToString();
            this.ddlCurso.Text = this.Entity.MateriaComision;
            this.ddlDocente.Text = this.Entity.NombreYApellido;
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

        private void LoadEntity(DocenteCurso docCurso)
        {
            docCurso.IDCurso = listcurso[ddlCurso.SelectedIndex].ID;
            docCurso.IDDocente = listdoc[ddlDocente.SelectedIndex].ID;
            docCurso.Cargo = (DocenteCurso.TiposCargos)this.ddlCargo.SelectedIndex;
        }

        private void SaveEntity(DocenteCurso docCurso)
        {
            this.Logic.Save(docCurso);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new DocenteCurso();
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
                    this.Entity = new DocenteCurso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = Entidad.States.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
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
            this.ddlCargo.Enabled = enable;
            this.ddlCurso.Enabled = enable;
            this.ddlDocente.Enabled = enable;
        }

        private void ClearForm()
        {
            this.ddlDocente.ClearSelection();
            this.ddlCurso.ClearSelection();
            this.ddlCargo.ClearSelection();
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
            Response.Redirect("DocentesCursos.aspx");
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}