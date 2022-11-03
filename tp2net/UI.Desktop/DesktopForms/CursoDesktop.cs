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
            InicializarComboBox();
        }
        private void InicializarComboBox()
        {
            cmbIDComision.DisplayMember = "desc_comision";
            cmbIDComision.DataSource = new ComisionLogic().GetAll();
            cmbIDMateria.DisplayMember = "descripcion";
            cmbIDMateria.DataSource = new MateriaLogic().GetAll();
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
            Materia materiaActual = GetMateria();
            Comision comisionActual = GetComision();
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAño_calendario.Text = this.CursoActual.Año_calendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            if (this.CursoActual.Descripcion != null)
            {
                this.txtDescripcion.Text = this.CursoActual.Descripcion.ToString();
            }
            else {
                this.txtDescripcion.Text = "holi";
            }
            this.cmbIDMateria.SelectedIndex = new MateriaLogic().GetIndex(this.CursoActual.IDMateria);
            this.cmbIDComision.SelectedIndex = new ComisionLogic().GetIndex(this.CursoActual.IDComision);

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
            Materia materia = GetMateria();
            Comision comision = GetComision();
            switch (this.Modo)
            {
                case (ModoForm.Alta):
                    {
                        CursoActual = new Curso();
                        this.CursoActual.Descripcion = this.txtDescripcion.Text;
                        this.CursoActual.Año_calendario = Int32.Parse(this.txtAño_calendario.Text);
                        this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                        this.CursoActual.IDComision = comision.ID;
                        this.CursoActual.IDMateria = materia.ID;
                        this.CursoActual.State = BusinessEntity.States.New;
                        break;
                    }
                case (ModoForm.Modificacion):
                    {
                        this.CursoActual.Descripcion = this.txtDescripcion.Text;
                        this.CursoActual.Año_calendario = Int32.Parse(this.txtAño_calendario.Text);
                        this.CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                        this.CursoActual.IDComision = comision.ID;
                        this.CursoActual.IDMateria = materia.ID;
                        this.CursoActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case (ModoForm.Baja):
                    {
                        this.CursoActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case (ModoForm.Consulta):
                    {
                        this.CursoActual.State = BusinessEntity.States.Unmodified;
                        break;
                    }
            }
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
                (this.txtAño_calendario.Text == "") ||
                (this.txtCupo.Text == "") ||
                (this.txtDescripcion.Text == "") ||
                (this.cmbIDComision == null) ||
                (this.cmbIDMateria == null)
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

        private Materia GetMateria()
        {
            return new MateriaLogic().GetOne(((Materia)this.cmbIDMateria.SelectedValue).ID); ;
        }
        private Comision GetComision()
        {
            return new ComisionLogic().GetOne(((Comision)this.cmbIDComision.SelectedValue).ID); ;
        }
    }
}
