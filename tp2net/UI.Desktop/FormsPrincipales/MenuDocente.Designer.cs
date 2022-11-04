
namespace UI.Desktop
{
    partial class MenuDocente
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCargarNotas = new System.Windows.Forms.Button();
            this.btnReporteCursos = new System.Windows.Forms.Button();
            this.btnReportePlanes = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.45874F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.54126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.Controls.Add(this.btnCargarNotas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBienvenida, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReporteCursos, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnReportePlanes, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.44444F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(307, 72);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(218, 25);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido Profesor, ";
            // 
            // btnCargarNotas
            // 
            this.btnCargarNotas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarNotas.Location = new System.Drawing.Point(52, 269);
            this.btnCargarNotas.Name = "btnCargarNotas";
            this.btnCargarNotas.Size = new System.Drawing.Size(123, 80);
            this.btnCargarNotas.TabIndex = 2;
            this.btnCargarNotas.Text = "Cargar Notas";
            this.btnCargarNotas.UseVisualStyleBackColor = true;
            this.btnCargarNotas.Click += new System.EventHandler(this.btnCargarNotas_Click);
            // 
            // btnReporteCursos
            // 
            this.btnReporteCursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReporteCursos.Location = new System.Drawing.Point(355, 269);
            this.btnReporteCursos.Name = "btnReporteCursos";
            this.btnReporteCursos.Size = new System.Drawing.Size(123, 80);
            this.btnReporteCursos.TabIndex = 3;
            this.btnReporteCursos.Text = "Reporte cursos";
            this.btnReporteCursos.UseVisualStyleBackColor = true;
            this.btnReporteCursos.Click += new System.EventHandler(this.btnReporteCursos_Click);
            // 
            // btnReportePlanes
            // 
            this.btnReportePlanes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReportePlanes.Location = new System.Drawing.Point(641, 269);
            this.btnReportePlanes.Name = "btnReportePlanes";
            this.btnReportePlanes.Size = new System.Drawing.Size(123, 80);
            this.btnReportePlanes.TabIndex = 4;
            this.btnReportePlanes.Text = "Reporte planes";
            this.btnReportePlanes.UseVisualStyleBackColor = true;
            this.btnReportePlanes.Click += new System.EventHandler(this.btnReportePlanes_Click);
            // 
            // MenuDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MenuDocente";
            this.Text = "MenuDocente";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCargarNotas;
        private System.Windows.Forms.Button btnReporteCursos;
        private System.Windows.Forms.Button btnReportePlanes;
    }
}