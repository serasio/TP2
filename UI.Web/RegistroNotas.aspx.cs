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
    public partial class RegistroNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            if (!IsPostBack)
            {
                PlanLogic pl = new PlanLogic();
                listplan = pl.GetAll();
                ddlPlan.DataSource = listplan;
                ddlPlan.DataTextField = "PlanEspecialidadDesc";
                ddlPlan.DataBind();               
            }
            ddlCurso.Enabled = false;
            txtAnio.Enabled = false;
            ddlComision.Enabled = false;
            btnAceptar.Enabled = false;
        }

        static List<Plan> listplan;
        static List<Comision> listcom;
        static List<Curso> listcurso;
        static List<AlumnoInscripcion> listInscrip;

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAnio.Enabled = true;
        }

        protected void txtAnio_TextChanged(object sender, EventArgs e)
        {
            ddlComision.Enabled = true;
            ComisionLogic cl = new ComisionLogic();
            listcom = cl.GetComisionesAnio(int.Parse(txtAnio.Text), listplan[ddlPlan.SelectedIndex].ID);
            ddlComision.DataSource = listcom;
            ddlComision.DataTextField = "Descripcion";
            ddlComision.DataBind();
        }

        protected void ddlComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCurso.Enabled = true;
            CursoLogic cl = new CursoLogic();
            listcurso = cl.GetCursosComision(listcom[ddlComision.SelectedIndex].ID);
            ddlCurso.DataSource = listcurso;
            ddlCurso.DataTextField = "DescMateria";
            ddlCurso.DataBind();
        }

        protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnAceptar.Enabled = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = true;
            AluInscripcionLogic ail = new AluInscripcionLogic();
            listInscrip = ail.GetInscCurso(listcurso[ddlCurso.SelectedIndex].ID);
            this.gvNotas.DataSource = listInscrip;
            this.gvNotas.DataBind();
        }

        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}