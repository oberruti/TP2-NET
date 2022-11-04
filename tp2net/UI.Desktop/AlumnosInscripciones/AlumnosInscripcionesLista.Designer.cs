
namespace UI.Desktop
{
    partial class AlumnosInscripcionesLista
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
            this.tscAlumnosInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnosInscripciones = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Curso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            this.tscAlumnosInscripciones.ContentPanel.SuspendLayout();
            this.tscAlumnosInscripciones.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscripciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tscAlumnosInscripciones
            // 
            // 
            // tscAlumnosInscripciones.BottomToolStripPanel
            // 
            this.tscAlumnosInscripciones.BottomToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_BottomToolStripPanel_Click);
            this.tscAlumnosInscripciones.BottomToolStripPanelVisible = false;
            // 
            // tscAlumnosInscripciones.ContentPanel
            // 
            this.tscAlumnosInscripciones.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.tscAlumnosInscripciones.ContentPanel.Size = new System.Drawing.Size(800, 450);
            this.tscAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // tscAlumnosInscripciones.LeftToolStripPanel
            // 
            this.tscAlumnosInscripciones.LeftToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_LeftToolStripPanel_Click);
            this.tscAlumnosInscripciones.LeftToolStripPanelVisible = false;
            this.tscAlumnosInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tscAlumnosInscripciones.Name = "tscAlumnosInscripciones";
            // 
            // tscAlumnosInscripciones.RightToolStripPanel
            // 
            this.tscAlumnosInscripciones.RightToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_RightToolStripPanel_Click);
            this.tscAlumnosInscripciones.RightToolStripPanelVisible = false;
            this.tscAlumnosInscripciones.Size = new System.Drawing.Size(800, 450);
            this.tscAlumnosInscripciones.TabIndex = 0;
            this.tscAlumnosInscripciones.Text = "toolStripContainer1";
            // 
            // tscAlumnosInscripciones.TopToolStripPanel
            // 
            this.tscAlumnosInscripciones.TopToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_TopToolStripPanel_Click);
            this.tscAlumnosInscripciones.TopToolStripPanelVisible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvAlumnosInscripciones, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCargarDatos, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.33334F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvAlumnosInscripciones
            // 
            this.dgvAlumnosInscripciones.AllowUserToAddRows = false;
            this.dgvAlumnosInscripciones.AllowUserToDeleteRows = false;
            this.dgvAlumnosInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Curso,
            this.Condicion,
            this.Nota});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvAlumnosInscripciones, 2);
            this.dgvAlumnosInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnosInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvAlumnosInscripciones.Name = "dgvAlumnosInscripciones";
            this.dgvAlumnosInscripciones.ReadOnly = true;
            this.dgvAlumnosInscripciones.Size = new System.Drawing.Size(794, 395);
            this.dgvAlumnosInscripciones.TabIndex = 1;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "NombreAlumno";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "ApellidoAlumno";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 150;
            // 
            // Curso
            // 
            this.Curso.DataPropertyName = "DescCurso";
            this.Curso.HeaderText = "Curso";
            this.Curso.Name = "Curso";
            this.Curso.ReadOnly = true;
            this.Curso.Width = 150;
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.Name = "Condicion";
            this.Condicion.ReadOnly = true;
            this.Condicion.Width = 150;
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.Location = new System.Drawing.Point(700, 404);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 42);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.Location = new System.Drawing.Point(3, 404);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(97, 42);
            this.btnCargarDatos.TabIndex = 3;
            this.btnCargarDatos.Text = "Cargar Datos";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            this.btnCargarDatos.Visible = false;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // AlumnosInscripcionesLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tscAlumnosInscripciones);
            this.Name = "AlumnosInscripcionesLista";
            this.Text = "AlumnosInscripcionesLista";
            this.Load += new System.EventHandler(this.AlumnosInscripcionesLista_Load);
            this.tscAlumnosInscripciones.ContentPanel.ResumeLayout(false);
            this.tscAlumnosInscripciones.ResumeLayout(false);
            this.tscAlumnosInscripciones.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscripciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscAlumnosInscripciones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvAlumnosInscripciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.Button btnCargarDatos;
    }
}