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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
            InicializarComboBox();
        }
        private void InicializarComboBox()
        {
            List<TiposPersonas> tipos = new List<TiposPersonas>();
            tipos.Add(TiposPersonas.Alumno);
            tipos.Add(TiposPersonas.Docente);
            cbmIDPlan.DisplayMember = "descripcion";
            cbmIDPlan.DataSource = new PlanLogic().GetAll();
            cbmIDTipoPersona.DataSource = tipos;
        }
        public Persona PersonaActual { get; set; }

        public PersonaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaLogic ul = new PersonaLogic();
            PersonaActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            Plan planActual = GetPlan();
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.chkHabilitado.Checked = this.PersonaActual.Habilitado;
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtClave.Text = this.PersonaActual.Clave;
            this.txtConfirmarClave.Text = this.PersonaActual.Clave;
            this.txtUsuario.Text = this.PersonaActual.NombreUsuario;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.cbmIDPlan.SelectedIndex = new PlanLogic().GetIndex(PersonaActual.IDPlan);
            this.cbmIDTipoPersona.SelectedIndex = (int)this.PersonaActual.TipoPersona;

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
            Plan planActual = GetPlan();
            if (Modo == ModoForm.Alta)
            {
                PersonaActual = new Persona();
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Habilitado = this.chkHabilitado.Checked;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Clave = this.txtClave.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.NombreUsuario = this.txtUsuario.Text;
                PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.IDPlan = planActual.ID;
                PersonaActual.TipoPersona = (TiposPersonas)this.cbmIDTipoPersona.SelectedIndex;
                PersonaActual.State = BusinessEntity.States.New;
                PersonaActual.FechaNacimiento = this.dtpFechaNacimiento.Value;
            }

            if (Modo == ModoForm.Modificacion)
            {
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Habilitado = this.chkHabilitado.Checked;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Clave = this.txtClave.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.NombreUsuario = this.txtUsuario.Text;
            }
        }

        public override bool Validar()
        {

            if (string.IsNullOrWhiteSpace(this.txtApellido.Text) || string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtUsuario.Text))
            {
                Notificar("Error", "Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.txtClave.Text.Length < 8)
            {
                Notificar("Error", "La clave debe tener 8 o más caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                Notificar("Error", "La clave no coincide con la confirmación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!this.txtEmail.Text.Contains("@") || !this.txtEmail.Text.Contains("."))
            {
                Notificar("Error", "El Email no es valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else { return true; }

        }

        public override void GuardarCambios()
        {
            PersonaLogic ul = new PersonaLogic();
            MapearADatos();
            ul.Save(PersonaActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Modificacion:
                    if (Validar())
                    {
                        GuardarCambios();
                        Close();
                    };
                    break;
                case ModoForm.Baja:
                    Eliminar();
                    Close();
                    break;
                case ModoForm.Consulta:
                    Close();
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public virtual void Eliminar()
        {
            PersonaLogic ul = new PersonaLogic();
            ul.Delete(PersonaActual.ID);
        }
        private Plan GetPlan()
        {
            return new PlanLogic().GetOne(((Plan)this.cbmIDPlan.SelectedValue).ID); ;
        }
    }
}
