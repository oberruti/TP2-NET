
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CursosDS = new UI.Desktop.CursosDS();
            this.CursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CursosTableAdapter = new UI.Desktop.CursosDSTableAdapters.CursosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CursosDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CursosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CursosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReporteCursos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1161, 570);
            this.reportViewer1.TabIndex = 0;
            // 
            // CursosDS
            // 
            this.CursosDS.DataSetName = "CursosDS";
            this.CursosDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CursosBindingSource
            // 
            this.CursosBindingSource.DataMember = "Cursos";
            this.CursosBindingSource.DataSource = this.CursosDS;
            // 
            // CursosTableAdapter
            // 
            this.CursosTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 570);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteCursos";
            this.Text = "ReporteCursos";
            this.Load += new System.EventHandler(this.ReporteCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CursosDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CursosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CursosBindingSource;
        private CursosDS CursosDS;
        private CursosDSTableAdapters.CursosTableAdapter CursosTableAdapter;
    }
}