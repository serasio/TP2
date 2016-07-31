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
    public partial class ReporteCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PlanLogic pl = new PlanLogic();
                listplan = pl.GetAll();
                ddlPlan.DataSource = listplan;
                ddlPlan.DataTextField = "PlanEspecialidadDesc";
                ddlPlan.DataBind();
            }
            this.gridPanel.Visible = false;
        }

        static List<Plan> listplan;
        static List<Materia> listmateria;

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            MateriaLogic ml = new MateriaLogic();
            listmateria = ml.GetAll(listplan[ddlPlan.SelectedIndex].ID);
            this.gvPlan.DataSource = listmateria;
            this.gvPlan.DataBind();
            this.gridPanel.Visible = true;
        }


        protected void lbtnMenuPpal_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPpal.aspx");
        }
    }
}