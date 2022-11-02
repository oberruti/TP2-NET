using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Profesores : ApplicationForm
    {
        public Profesores()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop ud = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
