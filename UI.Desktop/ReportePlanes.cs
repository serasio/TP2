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
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }
        private Reporte _Reporte;

        public Reporte Reporte
        {
            get { return _Reporte; }
            set { _Reporte = value; }
        }

        public ReportePlanes(Reporte rep)
        {
            Reporte = rep;
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.AcademiaDataSet.planes);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.especialidades' Puede moverla o quitarla según sea necesario.
            this.especialidadesTableAdapter.Fill(this.AcademiaDataSet.especialidades);
            // TODO: esta línea de código carga datos en la tabla 'AcademiaDataSet.materias' Puede moverla o quitarla según sea necesario.
            this.materiasTableAdapter.Fill(this.AcademiaDataSet.materias);
            ReportParameter idesp = new ReportParameter("IDEspecialidad", Reporte.IDEspecialidad.ToString());
            ReportParameter idplan = new ReportParameter("IDPlan", Reporte.IDPlan.ToString());

            this.rpvPlanes.LocalReport.SetParameters(idesp);
            this.rpvPlanes.LocalReport.SetParameters(idplan);

            this.rpvPlanes.RefreshReport();
        }
    }
}
