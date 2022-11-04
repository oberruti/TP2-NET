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
    public partial class Cursos : ApplicationForm
    /*{
        public Cursos()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            CursoLogic cu = new CursoLogic();
            this.dgvCursos.DataSource = cu.GetAll();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void dgvCursos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop md = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            md.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop md = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                md.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop md = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                md.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }*/
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic coml = new ComisionLogic();
            List<Curso> cursos = cl.GetAll();
            List<CursoConMateriaYComision> cursosmyc = new List<CursoConMateriaYComision>();
            foreach (Curso item in cursos)
            {
                Materia materia = ml.GetOne(item.IDMateria);
                Comision comision = coml.GetOne(item.IDComision);
                CursoConMateriaYComision cmyc = new CursoConMateriaYComision();
                cmyc.ID = item.ID;
                cmyc.IDComision = comision.ID;
                cmyc.IDMateria = materia.ID;
                cmyc.NombreComision = comision.Desc_comision;
                cmyc.NombreMateria = materia.Descripcion;
                cmyc.Año_calendario = item.Año_calendario;
                cmyc.Descripcion = item.Descripcion;
                cmyc.Cupo = item.Cupo;
                cursosmyc.Add(cmyc);
            }
            this.dgvCursos.DataSource = cursosmyc;
        }
        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbsNuevo_Click(object sender, EventArgs e)
        {
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tbsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCursos.SelectedRows.Count > 0)
                {
                    int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                    formCurso.ShowDialog();
                    this.Listar();
                }
            }
            catch (ArgumentOutOfRangeException ef)
            {
                MessageBox.Show("No existen registros a editar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCursos.SelectedRows.Count > 0)
                {
                    int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                    formCurso.ShowDialog();
                    this.Listar();
                }
            }
            catch (ArgumentOutOfRangeException ef)
            {
                MessageBox.Show("No existen registros a eliminar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCursos_Click(object sender, EventArgs e)
        {
            Listar();
        }

    }

    public class CursoConMateriaYComision : Curso
    {
        private string _NombreMateria;
        private string _NombreComision;

        public string NombreMateria { get => _NombreMateria; set => _NombreMateria = value; }
        public string NombreComision { get => _NombreComision; set => _NombreComision = value; }
    }

}
