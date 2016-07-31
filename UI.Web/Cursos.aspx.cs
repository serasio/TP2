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
    public partial class Cursos : System.Web.UI.Page
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
                ComisionLogic cl = new ComisionLogic();
                listcom = cl.GetAll();
                DropDownListComision.DataSource = listcom;
                DropDownListComision.DataTextField = "PlanEspDescripcion";
                DropDownListComision.DataBind();
            }
        }

        static List<Comision> listcom;
        static List<Materia> listmat;

        private CursoLogic _logic;

        public CursoLogic Logic
        {
            get 
            {
                if (_logic == null)
                    _logic = new CursoLogic();
                return _logic; 
            }
        }

        private void LoadGrid()
        {
            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Alumno)
            {
                this.gridView.DataSource = this.Logic.GetCursosAlumno(UsuarioLogueado.IDPlan);
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

        private Curso Entity
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

        private void CargarMaterias(int IDPlan)
        {
            MateriaLogic ml = new MateriaLogic();
            ml.GetAll(IDPlan);
            DropDownListMateria.DataSource=listmat;
            DropDownListMateria.DataTextField= "Descripcion";
            DropDownListMateria.DataBind();
        }


        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.anioCalTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
            this.DropDownListComision.Text = this.Entity.DescComision;
            this.DropDownListMateria.Text = this.Entity.DescMateria;
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

        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = int.Parse(this.anioCalTextBox.Text);
            curso.Cupo = int.Parse(this.cupoTextBox.Text);
            curso.IDComision = listcom[DropDownListComision.SelectedIndex].ID; 
            this.CargarMaterias(listcom[DropDownListComision.SelectedIndex].IDPlan);
            curso.IDMateria = listmat[DropDownListMateria.SelectedIndex].ID;
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new Curso();
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
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = Entidad.States.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
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
            this.anioCalTextBox.Enabled = enable;
            this.cupoTextBox.Enabled=enable;
            this.DropDownListComision.Enabled=enable;
            this.DropDownListMateria.Enabled=enable;
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
            this.anioCalTextBox.Text = string.Empty;
            this.cupoTextBox.Text=string.Empty;
            this.DropDownListComision.ClearSelection();
            this.DropDownListMateria.ClearSelection();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cursos.aspx");
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}