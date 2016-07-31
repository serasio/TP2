using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class ReporteCursos : Form
    {
        public ReporteCursos()
        {
            InitializeComponent();
        }
        private Reporte _Reporte;

        public Reporte Reporte
        {
            get { return _Reporte; }
            set { _Reporte = value; }
        }

        public ReporteCursos(Reporte rep)
        {
            Reporte = rep;
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.alumnos_inscripciones' Puede moverla o quitarla según sea necesario.
            this.alumnos_inscripcionesTableAdapter.Fill(this.AcademiaDataSet.alumnos_inscripciones);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.comisiones' Puede moverla o quitarla según sea necesario.
            this.comisionesTableAdapter.Fill(this.AcademiaDataSet.comisiones);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.cursos' Puede moverla o quitarla según sea necesario.
            this.cursosTableAdapter.Fill(this.AcademiaDataSet.cursos);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.docentes_cursos' Puede moverla o quitarla según sea necesario.
            this.docentes_cursosTableAdapter.Fill(this.AcademiaDataSet.docentes_cursos);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.materias' Puede moverla o quitarla según sea necesario.
            this.materiasTableAdapter.Fill(this.AcademiaDataSet.materias);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.AcademiaDataSet.planes);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.especialidades' Puede moverla o quitarla según sea necesario.
            this.especialidadesTableAdapter.Fill(this.AcademiaDataSet.especialidades);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet1.personas' Puede moverla o quitarla según sea necesario.
            this.personasTableAdapter.Fill(this.AcademiaDataSet1.personas);
            this.Datos_AlumnosTableAdapter.Fill(this.AcademiaDataSet.Datos_Alumnos);
            
            ReportParameter iddoc = new ReportParameter("IDDocente",Reporte.IDDocente.ToString());
            ReportParameter idplan = new ReportParameter("IDPlan", Reporte.IDPlan.ToString());
            ReportParameter idcurso = new ReportParameter("IDCurso", Reporte.IDCurso.ToString());
            ReportParameter idesp = new ReportParameter("IDEspecialidad", Reporte.IDEspecialidad.ToString());
            ReportParameter idmat = new ReportParameter("IDMateria", Reporte.IDMateria.ToString());
            ReportParameter idcom = new ReportParameter("IDComision", Reporte.IDComision.ToString());

                        
            this.rpvCurso.LocalReport.SetParameters(iddoc);
            this.rpvCurso.LocalReport.SetParameters(idplan);
            this.rpvCurso.LocalReport.SetParameters(idcurso);
            this.rpvCurso.LocalReport.SetParameters(idesp);
            this.rpvCurso.LocalReport.SetParameters(idmat);
            this.rpvCurso.LocalReport.SetParameters(idcom);


            this.rpvCurso.RefreshReport();
            
        }
    }
}
