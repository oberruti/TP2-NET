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
    public partial class CursoDesktop : ApplicationForm
    {
        protected Curso _CursoActual;
        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic ml = new CursoLogic();
            CursoActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAño_calendario.Text = this.CursoActual.Año_calendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtID_Materia.Text = this.CursoActual.IDMateria.ToString();
            this.txtID_Comision.Text = this.CursoActual.IDComision.ToString();

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
                    Curso cur = new Curso();
                    CursoActual = cur;
                    this.CursoActual.State = BusinessEntity.States.New;
                }
                else this.CursoActual.State = BusinessEntity.States.Modified;


                this.CursoActual.Año_calendario = Int32.Parse(this.txtAño_calendario.Text); //Int32.Parse(this.txtAño_calendario.Text);
                this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                this.CursoActual.IDMateria = Int32.Parse(this.txtID_Materia.Text);
                this.CursoActual.IDComision = Int32.Parse(this.txtID_Comision.Text);

            }
            else if (this.Modo == ModoForm.Baja) this.CursoActual.State = BusinessEntity.States.Deleted;
            else this.CursoActual.State = BusinessEntity.States.Unmodified;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic ml = new CursoLogic();
            ml.Save(this.CursoActual);
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }
        public override bool Validar()
        {
            if (
                (this.txtID.Text == "") ||
                (this.txtID_Comision.Text == "") ||
                (this.txtID_Materia.Text == "") ||
                (this.año.Text == "") ||
                (this.cupolabel.Text == "")
                )
            {
                this.Notificar("Atención", "Datos incorrectos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }

        private void txtID_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();

        }
    }
}
