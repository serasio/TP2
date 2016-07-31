namespace UI.Desktop
{
    partial class ReportePlanes
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
            this.rpvPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AcademiaDataSet = new UI.Desktop.AcademiaDataSet();
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.planesTableAdapter();
            this.especialidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadesTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.especialidadesTableAdapter();
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasTableAdapter = new UI.Desktop.AcademiaDataSetTableAdapters.materiasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvPlanes
            // 
            this.rpvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Planes";
            reportDataSource1.Value = this.planesBindingSource;
            reportDataSource2.Name = "Especialidades";
            reportDataSource2.Value = this.especialidadesBindingSource;
            reportDataSource3.Name = "Materias";
            reportDataSource3.Value = this.materiasBindingSource;
            this.rpvPlanes.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvPlanes.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvPlanes.LocalReport.DataSources.Add(reportDataSource3);
            this.rpvPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportePlan.rdlc";
            this.rpvPlanes.Location = new System.Drawing.Point(0, 0);
            this.rpvPlanes.Name = "rpvPlanes";
            this.rpvPlanes.Size = new System.Drawing.Size(284, 262);
            this.rpvPlanes.TabIndex = 0;
            // 
            // AcademiaDataSet
            // 
            this.AcademiaDataSet.DataSetName = "AcademiaDataSet";
            this.AcademiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // especialidadesBindingSource
            // 
            this.especialidadesBindingSource.DataMember = "especialidades";
            this.especialidadesBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // especialidadesTableAdapter
            // 
            this.especialidadesTableAdapter.ClearBeforeFill = true;
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.AcademiaDataSet;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // ReportePlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.rpvPlanes);
            this.Name = "ReportePlanes";
            this.Text = "ReportePlanes";
            this.Load += new System.EventHandler(this.ReportePlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AcademiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvPlanes;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private AcademiaDataSet AcademiaDataSet;
        private System.Windows.Forms.BindingSource especialidadesBindingSource;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private AcademiaDataSetTableAdapters.planesTableAdapter planesTableAdapter;
        private AcademiaDataSetTableAdapters.especialidadesTableAdapter especialidadesTableAdapter;
        private AcademiaDataSetTableAdapters.materiasTableAdapter materiasTableAdapter;
    }
}