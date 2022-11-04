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
    public partial class MateriaDesktop : ApplicationForm
    {
        protected Materia _MateriaActual;
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        public MateriaDesktop()
        {
            InitializeComponent();
            InicializarComboBox();
        }

        private void InicializarComboBox()
        {
            cmbIDPlan.DisplayMember = "descripcion";
            cmbIDPlan.DataSource = new PlanLogic().GetAll();
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            Plan planActual = GetPlan();
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cmbIDPlan.SelectedIndex = new PlanLogic().GetIndex(MateriaActual.IDPlan);

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
            Plan planActual = GetPlan();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        MateriaActual = new Materia();
                        this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                        this.MateriaActual.HSSemanales = Int32.Parse(this.txtHsSemanales.Text);
                        this.MateriaActual.HSTotales = Int32.Parse(this.txtHsTotales.Text);
                        this.MateriaActual.IDPlan = planActual.ID;
                        this.MateriaActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                        this.MateriaActual.HSSemanales = Int32.Parse(this.txtHsSemanales.Text);
                        this.MateriaActual.HSTotales = Int32.Parse(this.txtHsTotales.Text);
                        this.MateriaActual.IDPlan = planActual.ID;
                        this.MateriaActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.MateriaActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.MateriaActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(this.MateriaActual);
        }

        public override bool Validar()
        {
            if (
                (this.txtDescripcion.Text == "") ||
                (this.txtHsSemanales.Text == "") ||
                (this.txtHsTotales.Text == "")
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private Plan GetPlan()
        {
            return new PlanLogic().GetOne(((Plan)this.cmbIDPlan.SelectedValue).ID); ;
        }
    }
}
