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
    public partial class ComisionDesktop : ApplicationForm
    {

        protected Comision _ComisionActual;
        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }
        public ComisionDesktop()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            cmbIDPlan.DisplayMember = "descripcion";
            cmbIDPlan.DataSource = new PlanLogic().GetAll();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            Plan planActual = GetPlan();
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Desc_comision;
            this.txtAnioEspecialidad.Text = this.ComisionActual.Anio_especialidad.ToString();
            this.cmbIDPlan.SelectedIndex = new PlanLogic().GetIndex(ComisionActual.IDPlan);

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
            Business.Entities.Plan planActual = this.DevolverPlan();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        ComisionActual = new Comision();
                        this.ComisionActual.Desc_comision = this.txtDescripcion.Text;
                        this.ComisionActual.IDPlan = planActual.ID;
                        this.ComisionActual.Anio_especialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                        this.ComisionActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.ComisionActual.Desc_comision = this.txtDescripcion.Text;
                        this.ComisionActual.IDPlan = planActual.ID;
                        this.ComisionActual.Anio_especialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                        this.ComisionActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.ComisionActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.ComisionActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }
        private Plan DevolverPlan()
        {
            return new PlanLogic().GetOne(((Business.Entities.Plan)this.cmbIDPlan.SelectedValue).ID);
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic com = new ComisionLogic();
            com.Save(this.ComisionActual);
        }

        public override bool Validar()
        {
            if (
                (this.txtDescripcion.Text == "") ||
                (this.txtAnioEspecialidad.Text == "") ||
                (this.cmbIDPlan == null)
                )
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar()) GuardarCambios();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Plan GetPlan()
        {
            return new PlanLogic().GetOne(((Plan)this.cmbIDPlan.SelectedValue).ID); ;
        }
    }
}
