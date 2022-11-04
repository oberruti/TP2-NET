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
    public partial class Planes : ApplicationForm
    {

        public Planes()
        {
            InitializeComponent();
            this.dgvPlans.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            EspecialidadLogic el = new EspecialidadLogic();
            List<Plan> planes = pl.GetAll();
            List<PlanConEspecialidad> planesconesp = new List<PlanConEspecialidad>();
            foreach (Plan item in planes)
            {
                Especialidad esp = el.GetOne(item.IDEspecialidad);
                PlanConEspecialidad pce = new PlanConEspecialidad();
                pce.ID = item.ID;
                pce.Descripcion = item.Descripcion;
                pce.IDEspecialidad = item.IDEspecialidad;
                pce.NombreEspecialidad = esp.Descripcion;
                planesconesp.Add(pce);
            }
            this.dgvPlans.DataSource = planesconesp;
        }

        private void Planes_Load(object sender, EventArgs e)
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
            PlanDesktop pd = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlans.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlans.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop pd = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlans.SelectedRows.Count > 0)
            {
                try
                {
                    int ID = ((Business.Entities.Plan)this.dgvPlans.SelectedRows[0].DataBoundItem).ID;
                    PlanDesktop pd = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                    pd.ShowDialog();
                    Listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede eliminar este plan ya que esta asociada a otra entidad");
                }
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class PlanConEspecialidad : Plan
    {
        private string _NombreEspecialidad;
        public string NombreEspecialidad { get => _NombreEspecialidad; set => _NombreEspecialidad = value; }
    }
}
