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
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Comisiones_Load);
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            PlanLogic pl = new PlanLogic();
            List<Comision> comisiones = cl.GetAll();
            List<ComisionConPlan> comisionesconplan = new List<ComisionConPlan>();
            foreach (Comision item in comisiones)
            {
                Plan plan = pl.GetOne(item.IDPlan);
                ComisionConPlan ccp = new ComisionConPlan();
                ccp.ID = item.ID;
                ccp.Desc_comision = item.Desc_comision;
                ccp.Anio_especialidad = item.Anio_especialidad;
                ccp.IDPlan = item.IDPlan;
                ccp.NombrePlan = plan.Descripcion;
                comisionesconplan.Add(ccp);
            }
            this.dgvComisiones.DataSource = comisionesconplan;
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            cd.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop cd = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                cd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop cd = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                cd.ShowDialog();
                Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar esta especialidad ya que esta asociada a otra entidad");
            }
        }
    }
    public class ComisionConPlan : Comision
    {
        private string _NombrePlan;
        public string NombrePlan { get => _NombrePlan; set => _NombrePlan = value; }
    }
}
