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
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            PlanLogic planl = new PlanLogic();
            List<Persona> personas = pl.GetAll();
            List<PersonaConPlan> personasconplanes = new List<PersonaConPlan>();
            foreach (Persona item in personas)
            {
                Plan plan = planl.GetOne(item.IDPlan);
                PersonaConPlan pcp = new PersonaConPlan();
                pcp.ID = item.ID;
                pcp.Habilitado = item.Habilitado;
                pcp.IDPlan = item.IDPlan;
                pcp.Legajo = item.Legajo;
                pcp.Nombre = item.Nombre;
                pcp.Apellido = item.Apellido;
                pcp.Clave = item.Clave;
                pcp.Direccion = item.Direccion;
                pcp.Email = item.Email;
                pcp.FechaNacimiento = item.FechaNacimiento;
                pcp.NombrePlan = plan.Descripcion;
                pcp.NombreUsuario = item.NombreUsuario;
                pcp.TipoPersona = item.TipoPersona;
                pcp.Telefono = item.Telefono;
                personasconplanes.Add(pcp);
            }
            this.dgvPersonas.DataSource = personasconplanes;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvPersonas.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop ud = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            ud.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                pd.ShowDialog();
                Listar();
            }
            else Notificar("Atención", "No se seleccionó ningún elemento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class PersonaConPlan : Persona
    {
        private string _NombrePlan;
        public string NombrePlan { get => _NombrePlan; set => _NombrePlan = value; }
    }
}
