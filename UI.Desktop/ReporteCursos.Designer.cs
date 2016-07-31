namespace UI.Desktop
{
    partial class ReporteCursos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.alumnos_inscripcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docentes_cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AcademiaDataSet1 = new UI.Desktop.AcademiaDataSet1();
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvCurso = new Microsoft.Reporting.WinForms.ReportViewer();
            this.personasTableAdapter = new UI.Desktop.AcademiaDataSet1TableAdapters.personasTableAdapter();
            this.alumnos_inscripcionesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.alumnos_inscripcionesTableAdapter();
            this.comisionesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.comisionesTableAdapter();
            this.cursosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.cursosTableAdapter();
            this.docentes_cursosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.docentes_cursosTableAdapter();
            this.materiasTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.materiasTableAdapter();
            this.planesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.planesTableAdapter();
            this.especialidadesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.especialidadesTableAdapter();
            this.Datos_AlumnosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Datos_AlumnosTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.Datos_AlumnosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_inscripcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docentes_cursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_AlumnosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // alumnos_inscripcionesBindingSource
            // 
            this.alumnos_inscripcionesBindingSource.DataMember = "alumnos_inscripciones";
            this.alumnos_inscripcionesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // cursosBindingSource
            // 
            this.cursosBindingSource.DataMember = "cursos";
            this.cursosBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // docentes_cursosBindingSource
            // 
            this.docentes_cursosBindingSource.DataMember = "docentes_cursos";
            this.docentes_cursosBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // personasBindingSource
            // 
            this.personasBindingSource.DataMember = "personas";
            this.personasBindingSource.DataSource = this.AcademiaDataSet1;
            // 
            // AcademiaDataSet1
            // 
            this.AcademiaDataSet1.DataSetName = "AcademiaDataSet1";
            this.AcademiaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // especialidadesBindingSource
            // 
            this.especialidadesBindingSource.DataMember = "especialidades";
            this.especialidadesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // rpvCurso
            // 
            this.rpvCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DatosAlumnos";
            reportDataSource1.Value = this.Datos_AlumnosBindingSource;
            reportDataSource2.Name = "Comisiones";
            reportDataSource2.Value = this.comisionesBindingSource;
            reportDataSource3.Name = "Alumnos_Inscripciones";
            reportDataSource3.Value = this.alumnos_inscripcionesBindingSource;
            reportDataSource4.Name = "Cursos";
            reportDataSource4.Value = this.cursosBindingSource;
            reportDataSource5.Name = "Docentes_Cursos";
            reportDataSource5.Value = this.docentes_cursosBindingSource;
            reportDataSource6.Name = "Materias";
            reportDataSource6.Value = this.materiasBindingSource;
            reportDataSource7.Name = "Personas";
            reportDataSource7.Value = this.personasBindingSource;
            reportDataSource8.Name = "Planes";
            reportDataSource8.Value = this.planesBindingSource;
            reportDataSource9.Name = "Especialidades";
            reportDataSource9.Value = this.especialidadesBindingSource;
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource3);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource4);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource5);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource6);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource7);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource8);
            this.rpvCurso.LocalReport.DataSources.Add(reportDataSource9);
            this.rpvCurso.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReporteCurso.rdlc";
            this.rpvCurso.Location = new System.Drawing.Point(0, 0);
            this.rpvCurso.Name = "rpvCurso";
            this.rpvCurso.Size = new System.Drawing.Size(284, 262);
            this.rpvCurso.TabIndex = 0;
            // 
            // personasTableAdapter
            // 
            this.personasTableAdapter.ClearBeforeFill = true;
            // 
            // alumnos_inscripcionesTableAdapter
            // 
            this.alumnos_inscripcionesTableAdapter.ClearBeforeFill = true;
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // cursosTableAdapter
            // 
            this.cursosTableAdapter.ClearBeforeFill = true;
            // 
            // docentes_cursosTableAdapter
            // 
            this.docentes_cursosTableAdapter.ClearBeforeFill = true;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // especialidadesTableAdapter
            // 
            this.especialidadesTableAdapter.ClearBeforeFill = true;
            // 
            // Datos_AlumnosBindingSource
            // 
            this.Datos_AlumnosBindingSource.DataMember = "Datos_Alumnos";
            this.Datos_AlumnosBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // Datos_AlumnosTableAdapter
            // 
            this.Datos_AlumnosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.rpvCurso);
            this.Name = "ReporteCursos";
            this.Text = "Reporte Curso";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alumnos_inscripcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docentes_cursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Datos_AlumnosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCurso;
        private System.Windows.Forms.BindingSource personasBindingSource;
        private AcademiaDataSet1 AcademiaDataSet1;
        private AcademiaDataSet1TableAdapters.personasTableAdapter personasTableAdapter;
        private System.Windows.Forms.BindingSource alumnos_inscripcionesBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private System.Windows.Forms.BindingSource cursosBindingSource;
        private System.Windows.Forms.BindingSource docentes_cursosBindingSource;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private System.Windows.Forms.BindingSource especialidadesBindingSource;
        private AcademiaDataSetTableAdapters.alumnos_inscripcionesTableAdapter alumnos_inscripcionesTableAdapter;
        private AcademiaDataSetTableAdapters.comisionesTableAdapter comisionesTableAdapter;
        private AcademiaDataSetTableAdapters.cursosTableAdapter cursosTableAdapter;
        private AcademiaDataSetTableAdapters.docentes_cursosTableAdapter docentes_cursosTableAdapter;
        private AcademiaDataSetTableAdapters.materiasTableAdapter materiasTableAdapter;
        private AcademiaDataSetTableAdapters.planesTableAdapter planesTableAdapter;
        private AcademiaDataSetTableAdapters.especialidadesTableAdapter especialidadesTableAdapter;
        private System.Windows.Forms.BindingSource Datos_AlumnosBindingSource;
        private AcademiaDataSetTableAdapters.Datos_AlumnosTableAdapter Datos_AlumnosTableAdapter;
    }
}