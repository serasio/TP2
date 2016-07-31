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
    public partial class Inscripciones : System.Web.UI.Page
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
                CursoLogic cl = new CursoLogic();
                listcursos = cl.GetAll();
                PersonaLogic pl = new PersonaLogic();
                listalumnos = pl.GetAll(Persona.TiposPersonas.Alumno);
                ddlCurso.DataSource = listcursos;
                ddlCurso.DataTextField = "MateriaComision";
                ddlCurso.DataBind();
                ddlAlumno.DataSource = listalumnos;
                ddlAlumno.DataTextField = "NombreYApellido";
                ddlAlumno.DataBind();
                listcondiciones.Add("Libre");
                listcondiciones.Add("Cursando");
                listcondiciones.Add("Regular");
                ddlCondicion.DataSource = listcondiciones;
                ddlCondicion.DataBind();
            }    
        }

        
        static List<Persona> listalumnos;
        static List<Curso> listcursos;
        static List<string> listcondiciones;

        private AluInscripcionLogic _logic;

        public AluInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AluInscripcionLogic();
                return _logic;
            }
        }

        private void LoadGrid()
        {
            AluInscripcionLogic ail = new AluInscripcionLogic();
            if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Alumno)
                this.ListarAlumno(ail);
            else if (UsuarioLogueado.TipoPersona == Persona.TiposPersonas.Docente)
                this.ListarProfesor(ail);
            else this.Listar(ail);
            this.gridView.DataBind();
            this.formActionsPanel.Visible = false;
        }

        private void Listar(AluInscripcionLogic ail)
        {
            this.gridView.DataSource = ail.GetAll();
        }

        private void ListarAlumno(AluInscripcionLogic ail)
        {
            this.gridView.DataSource = ail.GetAllAlumno(UsuarioLogueado.ID);
            this.eliminarLinkButton.Enabled = false;
            this.editarLinkButton.Enabled = false;
        }

        private void ListarProfesor(AluInscripcionLogic ail)
        {
            this.gridView.DataSource = ail.GetAllProfesor(UsuarioLogueado.ID);
            this.nuevoLinkButton.Enabled = false;
            this.eliminarLinkButton.Enabled = false;
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

        private AlumnoInscripcion Entity
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
            this.ddlCondicion.SelectedValue = this.Entity.Condicion.ToString();
            this.ddlCurso.Text = this.Entity.ComisionMateriaAnio;
            this.ddlAlumno.Text = this.Entity.AluNomYApe;
            this.txtbNota.Text = this.Entity.Nota.ToString();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.FormEditar();
                this.gridView.Visible = false;
                this.formActionsPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
            }
        }

        private void FormEditar()
        {
            this.ddlAlumno.Enabled = false;
            this.ddlCondicion.Enabled = true;
            this.ddlCurso.Enabled = false;
            this.txtbNota.Enabled = true;
        }

        private void FormNuevo()
        {
            this.ddlAlumno.Enabled = false;
            this.ddlCondicion.Enabled = false;
            this.ddlCurso.Enabled = true;
            this.txtbNota.Enabled = false;
        }
        
        private void LoadEntity(AlumnoInscripcion aluInsc)
        {
            aluInsc.Condicion = listcondiciones[ddlCondicion.SelectedIndex];
            aluInsc.IDCurso = listcursos[ddlCurso.SelectedIndex].ID;
            aluInsc.IDAlumno = listalumnos[ddlAlumno.SelectedIndex].ID;
            aluInsc.Nota = int.Parse(txtbNota.Text);
        }

        private void GuardarEditar(AlumnoInscripcion aluInsc)
        {
            aluInsc.Condicion = listcondiciones[ddlCondicion.SelectedIndex];
            aluInsc.IDCurso = Entity.IDCurso;
            aluInsc.IDAlumno = UsuarioLogueado.ID;
            aluInsc.Nota = int.Parse(txtbNota.Text);
        }

        private void GuardarNuevo(AlumnoInscripcion aluInsc)
        {
            aluInsc.Condicion = "Cursando";
            aluInsc.IDCurso = listcursos[ddlCurso.SelectedIndex].ID;
            aluInsc.IDAlumno = UsuarioLogueado.ID;
        }

        private void SaveEntity(AlumnoInscripcion aluInsc)
        {
            this.Logic.Save(aluInsc);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            this.Entity = new AlumnoInscripcion();
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
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = Entidad.States.Modificado;
                    this.GuardarEditar(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.GuardarNuevo(this.Entity);
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
            this.ddlAlumno.Enabled = enable;
            this.ddlCondicion.Enabled = enable;
            this.ddlCurso.Enabled = enable;
        }

        private void ClearForm()
        {
            this.ddlCurso.ClearSelection();
            this.ddlCondicion.ClearSelection();
            this.ddlAlumno.ClearSelection();
            txtbNota.Text = string.Empty;
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
            Response.Redirect("Inscripciones.aspx");
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}