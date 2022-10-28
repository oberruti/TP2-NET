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
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            MapearDeDatos();
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
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Desc_comision;
            this.txtAnioEspecialidad.Text = this.ComisionActual.Anio_especialidad.ToString();
            this.txtId_Plan.Text = this.ComisionActual.Id_Plan.ToString();

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

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Modo == ModoForm.Alta)
                {
                    Comision com = new Comision();
                    ComisionActual = com;
                    this.ComisionActual.State = BusinessEntity.States.New;
                }
                else this.ComisionActual.State = BusinessEntity.States.Modified;

                this.ComisionActual.Desc_comision = this.txtDescripcion.Text;
                this.ComisionActual.Anio_especialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                this.ComisionActual.Id_Plan = Int32.Parse(this.txtId_Plan.Text);
            }
            else if (this.Modo == ModoForm.Baja) this.ComisionActual.State = BusinessEntity.States.Deleted;
            else this.ComisionActual.State = BusinessEntity.States.Unmodified;
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
                (this.txtID.Text == "") ||
                (this.txtDescripcion.Text == "") ||
                (this.txtAnioEspecialidad.Text == "") ||
                (this.asd.Text == "")
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
    }
}
