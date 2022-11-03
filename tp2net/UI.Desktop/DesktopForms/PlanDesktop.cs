using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        private Plan planActual;
        protected Plan PlanActual { get => planActual; set => planActual = value; }
        public PlanDesktop()
        {
            InitializeComponent();
            InicializarComboBox();
        }
        private void InicializarComboBox()
        {
            cmbIDEspecialidad.DisplayMember = "descripcion";
            cmbIDEspecialidad.DataSource = new EspecialidadLogic().GetAll();
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cmbIDEspecialidad.SelectedIndex = new EspecialidadLogic().GetIndex(PlanActual.IDEspecialidad);

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public virtual void MapearADatos()
        {
            Especialidad especialidadActual = GetEspecialidad();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        PlanActual = new Plan();
                        this.PlanActual.Descripcion = this.txtDescripcion.Text;
                        this.PlanActual.IDEspecialidad = especialidadActual.ID;
                        this.PlanActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.PlanActual.Descripcion = this.txtDescripcion.Text;
                        this.PlanActual.IDEspecialidad = especialidadActual.ID;
                        this.PlanActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.PlanActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.PlanActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(this.PlanActual);
        }
        public override bool Validar()
        {
            if (
                (this.txtDescripcion.Text == "")
                )
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }
        private Especialidad GetEspecialidad()
        {
            return new EspecialidadLogic().GetOne(((Business.Entities.Especialidad)this.cmbIDEspecialidad.SelectedValue).ID); ;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
