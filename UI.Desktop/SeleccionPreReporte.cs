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

namespace UI.Desktop
{
    public partial class SeleccionPreReporte : ApplicationForm
    {
        public SeleccionPreReporte(string tipo)
        {
            InitializeComponent();
            Tipo = tipo;
            if (Tipo == "Plan")
            {
                cmbIDCurso.Visible = false;
                cmbIDProfesor.Visible = false;
                label1.Visible = false;
                label4.Visible = false;
            }
        }

        private string _tipo;

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        List<Persona> listprofesores;
        List<Plan> listplanes;
        List<Curso> listcursos;

        private void SeleccionPreReporte_Load(object sender, EventArgs e)
        {
            if (Tipo == "Curso")
            {
                PersonaLogic proflogic = new PersonaLogic();
                PlanLogic planlogic = new PlanLogic();
                CursoLogic cursologic = new CursoLogic();
                listprofesores = proflogic.GetNom(Persona.TiposPersonas.Docente);
                listplanes = planlogic.GetAll();
                cmbIDPlan.DataSource = listplanes;
                listcursos = cursologic.GetAll();
                cmbIDCurso.DataSource = listcursos;
                cmbIDProfesor.DataSource = listprofesores;
                cmbIDProfesor.DisplayMember = "NombreYApellido";
                cmbIDPlan.DisplayMember = "PlanEspecialidadDesc";
                cmbIDCurso.DisplayMember = "MateriaComision";
                AutoCompleteStringCollection accprof = new AutoCompleteStringCollection();
                AutoCompleteStringCollection acccur = new AutoCompleteStringCollection();
                if (listprofesores.Count >= 1)
                {
                    foreach (Persona prof in listprofesores)
                    {
                        accprof.Add(prof.NombreYApellido);
                    }
                    cmbIDProfesor.AutoCompleteCustomSource = accprof;
                    cmbIDProfesor.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbIDProfesor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                {
                    cmbIDProfesor.Text = "No hay profesores cargados";
                    cmbIDProfesor.Enabled = false;
                    cmbIDPlan.Enabled = false;
                    btnAceptar.Visible = false;
                }
                if (listcursos.Count >= 1)
                {
                    foreach (Curso cur in listcursos)
                    {
                        acccur.Add(cur.MateriaComision);
                    }
                    cmbIDCurso.AutoCompleteCustomSource = acccur;
                    cmbIDCurso.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbIDCurso.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                {
                    cmbIDCurso.Text = "No hay cursos cargados";
                    cmbIDProfesor.Enabled = false;
                    cmbIDCurso.Enabled = false;
                    cmbIDPlan.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
            else
            {
                PlanLogic planlogic = new PlanLogic();
                listplanes = planlogic.GetAll();
                cmbIDPlan.DataSource = listplanes;
                cmbIDPlan.DisplayMember = "PlanEspecialidadDesc";
            }
       
            if (listplanes.Count < 1)
            {
                cmbIDCurso.Text = "No hay planes cargados";
                cmbIDProfesor.Enabled = false;
                cmbIDCurso.Enabled = false;
                cmbIDPlan.Enabled = false;
                btnAceptar.Visible = false;
            }
        }

        public override bool Validar()
        {

            if (cmbIDPlan.SelectedIndex == -1)
            {
                Notificar("Seleccione un plan!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Tipo == "Curso")
            {
                if (cmbIDCurso.SelectedIndex == -1)
                {
                    Notificar("Seleccione un curso!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (cmbIDProfesor.SelectedIndex == -1)
                {
                    Notificar("Seleccione un profesor!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (Tipo == "Curso")
                {
                    Reporte reporte = new Reporte();
                    reporte.IDCurso = listcursos[cmbIDCurso.SelectedIndex].ID;
                    reporte.IDDocente = listprofesores[cmbIDProfesor.SelectedIndex].ID;
                    reporte.IDPlan = listplanes[cmbIDPlan.SelectedIndex].ID;
                    reporte.IDEspecialidad = listplanes[cmbIDPlan.SelectedIndex].IDEspecialidad;
                    reporte.IDComision = listcursos[cmbIDCurso.SelectedIndex].IDComision;
                    reporte.IDMateria = listcursos[cmbIDCurso.SelectedIndex].IDMateria;
                    ReporteCursos rep = new ReporteCursos(reporte);
                    rep.Show();
                }
                else
                {
                    Reporte reporte = new Reporte();
                    reporte.IDPlan = listplanes[cmbIDPlan.SelectedIndex].ID;
                    reporte.IDEspecialidad = listplanes[cmbIDPlan.SelectedIndex].IDEspecialidad;
                    ReportePlanes rep = new ReportePlanes(reporte);
                    rep.Show();
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbIDPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tipo == "Curso")
            {
                CursoLogic cl = new CursoLogic();
                listcursos = cl.GetCursosAlumno(listplanes[cmbIDPlan.SelectedIndex].ID);
                cmbIDCurso.DataSource = listcursos;
                cmbIDCurso.DisplayMember = "MateriaComision";
                AutoCompleteStringCollection acccur = new AutoCompleteStringCollection();
                cmbIDCurso.Enabled = true;
                btnAceptar.Visible = true;
                if (listcursos.Count >= 1)
                {
                    foreach (Curso cur in listcursos)
                    {
                        acccur.Add(cur.MateriaComision);
                    }
                    cmbIDCurso.AutoCompleteCustomSource = acccur;
                    cmbIDCurso.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbIDCurso.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                {
                    cmbIDCurso.Text = "No hay cursos cargados";
                    cmbIDCurso.Enabled = false;
                    btnAceptar.Visible = false;
                }
            }
        }

    }
}
