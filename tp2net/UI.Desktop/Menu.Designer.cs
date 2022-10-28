
namespace UI.Desktop
{
    partial class Menu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnMenuUsuarios = new System.Windows.Forms.Button();
            this.btnMenuCursos = new System.Windows.Forms.Button();
            this.btnMenuMaterias = new System.Windows.Forms.Button();
            this.btnMenuComisiones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(75, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(319, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenidos, elija la opcion que desee!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMenuUsuarios
            // 
            this.btnMenuUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenuUsuarios.Location = new System.Drawing.Point(159, 236);
            this.btnMenuUsuarios.Name = "btnMenuUsuarios";
            this.btnMenuUsuarios.Size = new System.Drawing.Size(120, 60);
            this.btnMenuUsuarios.TabIndex = 1;
            this.btnMenuUsuarios.Text = "Usuarios";
            this.btnMenuUsuarios.UseVisualStyleBackColor = true;
            this.btnMenuUsuarios.Click += new System.EventHandler(this.btnMenuUsuarios_Click);
            // 
            // btnMenuCursos
            // 
            this.btnMenuCursos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenuCursos.Location = new System.Drawing.Point(159, 170);
            this.btnMenuCursos.Name = "btnMenuCursos";
            this.btnMenuCursos.Size = new System.Drawing.Size(120, 60);
            this.btnMenuCursos.TabIndex = 2;
            this.btnMenuCursos.Text = "Cursos";
            this.btnMenuCursos.UseVisualStyleBackColor = true;
            this.btnMenuCursos.Click += new System.EventHandler(this.btnMenuCursos_Click);
            // 
            // btnMenuMaterias
            // 
            this.btnMenuMaterias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenuMaterias.Location = new System.Drawing.Point(159, 104);
            this.btnMenuMaterias.Name = "btnMenuMaterias";
            this.btnMenuMaterias.Size = new System.Drawing.Size(120, 60);
            this.btnMenuMaterias.TabIndex = 3;
            this.btnMenuMaterias.Text = "Materias";
            this.btnMenuMaterias.UseVisualStyleBackColor = true;
            this.btnMenuMaterias.Click += new System.EventHandler(this.btnMenuMaterias_Click);
            // 
            // btnMenuComisiones
            // 
            this.btnMenuComisiones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenuComisiones.Location = new System.Drawing.Point(159, 302);
            this.btnMenuComisiones.Name = "btnMenuComisiones";
            this.btnMenuComisiones.Size = new System.Drawing.Size(120, 60);
            this.btnMenuComisiones.TabIndex = 4;
            this.btnMenuComisiones.Text = "Comisiones";
            this.btnMenuComisiones.UseVisualStyleBackColor = true;
            this.btnMenuComisiones.Click += new System.EventHandler(this.btnMenuComisiones_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 419);
            this.Controls.Add(this.btnMenuComisiones);
            this.Controls.Add(this.btnMenuMaterias);
            this.Controls.Add(this.btnMenuCursos);
            this.Controls.Add(this.btnMenuUsuarios);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMenuUsuarios;
        private System.Windows.Forms.Button btnMenuCursos;
        private System.Windows.Forms.Button btnMenuMaterias;
        private System.Windows.Forms.Button btnMenuComisiones;
    }
}