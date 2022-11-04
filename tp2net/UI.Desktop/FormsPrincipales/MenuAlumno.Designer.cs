
namespace UI.Desktop
{
    partial class MenuAlumno
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
            this.btnInscribirseCurso = new System.Windows.Forms.Button();
            this.btnVerCursos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.34917F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.65083F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel1.Controls.Add(this.lblBienvenida, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInscribirseCurso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnVerCursos, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.54546F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.45454F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(319, 46);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(204, 25);
            this.lblBienvenida.TabIndex = 2;
            this.lblBienvenida.Text = "Bienvenido Alumno,";
            // 
            // btnInscribirseCurso
            // 
            this.btnInscribirseCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInscribirseCurso.Location = new System.Drawing.Point(357, 166);
            this.btnInscribirseCurso.Name = "btnInscribirseCurso";
            this.btnInscribirseCurso.Size = new System.Drawing.Size(129, 60);
            this.btnInscribirseCurso.TabIndex = 3;
            this.btnInscribirseCurso.Text = "Incribirse a un curso";
            this.btnInscribirseCurso.UseVisualStyleBackColor = true;
            this.btnInscribirseCurso.Click += new System.EventHandler(this.btnInscribirseCurso_Click);
            // 
            // btnVerCursos
            // 
            this.btnVerCursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerCursos.Location = new System.Drawing.Point(357, 332);
            this.btnVerCursos.Name = "btnVerCursos";
            this.btnVerCursos.Size = new System.Drawing.Size(129, 60);
            this.btnVerCursos.TabIndex = 4;
            this.btnVerCursos.Text = "Ver Cursos";
            this.btnVerCursos.UseVisualStyleBackColor = true;
            this.btnVerCursos.Click += new System.EventHandler(this.btnVerCursos_Click);
            // 
            // MenuAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MenuAlumno";
            this.Text = "MenuAlumno";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnInscribirseCurso;
        private System.Windows.Forms.Button btnVerCursos;
    }
}