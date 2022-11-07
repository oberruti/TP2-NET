using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.Web
{
    public partial class Docentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            div_mensaje_error.Visible = false;
            HiddeElements();
            this.LoadGrid();
        }

        protected Business.Entities.Persona Entity = new Persona();


        AlumnoInscripcion _logicInscripciones;
        PersonaLogic _logicDocentes;


        private PersonaLogic LogicDocentes
        {
            get
            {
                if (_logicDocentes == null)
                {
                    _logicDocentes = new PersonaLogic();
                }
                return _logicDocentes;
            }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }

        }


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.DocentesGridView.SelectedValue;
            showAdminButtons();
            validacionCamposLabel.Visible = false;
        }


        private void LoadGrid()
        {
            try
            {
                this.DocentesGridView.DataSource = this.LogicDocentes.GetAllDocentes();
                this.DocentesGridView.DataBind();
            }
            catch (Exception ex)
            {
                div_mensaje_error.Visible = true;
                mensaje_error.Text = ex.ToString();
            }

        }


        private void HiddeElements()
        {
            // BOTONES
            //   cursosAlumnoButton.Visible = false;
            // bajaAlumnoButton.Visible = false;
            // inscripcionesAlumnoButton.Visible = false;

            modificarAlumnoButton.Visible = false;

            // SECCIONES

            form_docente.Visible = false;

        }

        private void showAdminButtons()
        {
            //cursosAlumnoButton.Visible = true;
            //  bajaAlumnoButton.Visible = true;
            //inscripcionesAlumnoButton.Visible = true;
            modificarAlumnoButton.Visible = true;

        }


        private void LoadForm(int id)
        {
            this.Entity = this.LogicDocentes.GetOne(id);

            this.idDocenteIngresoTextBox.Text = this.Entity.ID.ToString();
            this.nombreAlumnoTextBox.Text = this.Entity.Nombre;
            this.apellidoAlumnoTextBox.Text = this.Entity.Apellido;
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.direccionAlumnoTextBox.Text = this.Entity.Direccion;
            this.telefonoTextBox.Text = this.Entity.Telefono;
            this.emailAlumnoTextBox.Text = this.Entity.Email;
            this.idPlanTextBox.Text = this.Entity.IDPlan.ToString();
            this.fechaNacimientoTextBox.Text = String.Format("{0:yyyy-MM-dd}", this.Entity.FechaNacimiento);

            form_docente.Visible = true;

        }
        private void LoadEntity(Business.Entities.Persona docente)
        {
            try
            {
                docente.TipoPersona = TiposPersonas.Docente;
                docente.Legajo = int.Parse(legajoTextBox.Text);
                docente.Nombre = nombreAlumnoTextBox.Text;
                docente.Apellido = apellidoAlumnoTextBox.Text;
                docente.Nombre = nombreAlumnoTextBox.Text;
                docente.Direccion = direccionAlumnoTextBox.Text;
                docente.Telefono = telefonoTextBox.Text;
                docente.Email = emailAlumnoTextBox.Text;
                docente.IDPlan = int.Parse(idPlanTextBox.Text);
                docente.NombreUsuario = nombreUsuarioAlumnoTextBox.Text;
                docente.Clave = passAlumnoTextBox.Text;
                docente.Habilitado = true;
            }
            catch (Exception error)
            {
                mostrarMensajeDeError("Completa todos los campos" + error.ToString());
            }


            try
            {
                docente.FechaNacimiento = DateTime.Parse(fechaNacimientoTextBox.Text);
            }
            catch (Exception error)
            {
                mostrarMensajeDeError("Ingrese la fecha con el siguiente formato: yyyy-mm-dd \n" + error.ToString());
            }

        }

        private void ClearForm()
        {
            this.idDocenteIngresoTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.nombreAlumnoTextBox.Text = string.Empty;
            this.apellidoAlumnoTextBox.Text = string.Empty;
            this.direccionAlumnoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.fechaNacimientoTextBox.Text = string.Empty;
            this.emailAlumnoTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
        }
        /// <summary>
        /// Al momento de crear un docente (Persona), este debe crear un usuario también
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void agregarAlumnoButton_Click(object sender, EventArgs e)
        {
            ClearForm();

            this.form_docente.Visible = true;
            this.FormMode = FormModes.Alta;
            tituloForm.Text = "Agregar nuevo docente";
            validacionCamposLabel.Visible = false;

        }

        protected void modificarAlumnoButton_Click1(object sender, EventArgs e)
        {
            validacionCamposLabel.Visible = false;
            try
            {
                if (IsEntitySelected)
                {
                    ClearForm();
                    LoadForm(this.SelectedID);
                    modificarAlumnoButton.Visible = false;
                    tituloForm.Text = "Modificar docente";
                    this.FormMode = FormModes.Modificacion;
                }
                else
                {
                    mostrarMensajeDeError("Selecciona a un docente");
                }

            }
            catch (Exception ex)
            {

                mostrarMensajeDeError(ex.ToString());
            }

        }


        protected void buscarButton_Click(object sender, EventArgs e)
        {
            if (idDocenteIngresoTextBox.Text.Length > 0)
            {
                try
                {
                    LoadForm(int.Parse(idDocenteIngresoTextBox.Text));
                    tituloForm.Text = "Modificar docente";
                    this.FormMode = FormModes.Modificacion;

                }
                catch (Exception er)
                {
                    mostrarMensajeDeError("No existe o fue mal ingresado");

                }

            }
            else
            {
                mostrarMensajeDeError("Ingresa la ID de un docente");
            }

        }


        private void mostrarMensajeDeError(string mensaje)
        {
            div_mensaje_error.Visible = true;
            mensaje_error.Text = mensaje;
        }



        protected void formAlumnoButton_Click(object sender, EventArgs e)
        {
           


            if (validarCampos())
            {

                Persona nuevoAlumno = new Persona();

                try
                {

                    switch (this.FormMode)
                    {
                        case FormModes.Baja:
                            // this.DeleteEntity(this.SelectedID);
                            this.LoadGrid();
                            break;
                        case FormModes.Modificacion:
                            this.Entity = new Business.Entities.Persona();
                            this.Entity.ID = this.SelectedID;
                            this.Entity.State = Business.Entities.BusinessEntity.States.Modified;
                            this.LoadEntity(this.Entity);
                            LogicDocentes.Save(Entity);
                            this.LoadGrid();
                            break;
                        default:
                            break;
                        case FormModes.Alta:
                            this.Entity = new Business.Entities.Persona();
                            this.LoadEntity(this.Entity);
                            LogicDocentes.Save(Entity);
                            this.LoadGrid();
                            break;
                    }
                    this.form_docente.Visible = false;
                }
                catch (Exception error)
                {
                    mostrarMensajeDeError(error.ToString());
                }
            }
            else
            {
                validacionCamposLabel.Visible = true;
                this.form_docente.Visible = true;
            }


        }

        private bool validarCampos()
        {
            TextBox[] textBoxes = { legajoTextBox,
                    nombreAlumnoTextBox,
                    apellidoAlumnoTextBox,
                    direccionAlumnoTextBox,
                    telefonoTextBox,
                    fechaNacimientoTextBox, emailAlumnoTextBox, idPlanTextBox };

            return methods.validarYPintarCamposVacios(textBoxes) && methods.validarEmail(emailAlumnoTextBox);
        }

        public enum FormModes
        {
            Alta, Baja, Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected void cancelarFormAlumnoButton_Click(object sender, EventArgs e)
        {

            this.form_docente.Visible = false;
            showAdminButtons();

        }

        protected void seleccionarButton_Click(object sender, EventArgs e)
        {
            LoadPlanGrid();
            tablaPlan.Visible = true;
            this.form_docente.Visible = true;

        }

        private void LoadPlanGrid()
        {
            this.planGridView.DataSource = new PlanLogic().GetAll();
            this.planGridView.DataBind();
        }

        protected void planGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idPlanTextBox.Text = this.planGridView.SelectedValue.ToString();
            this.tablaPlan.Visible = false;
            this.form_docente.Visible = true;
        }

        protected void DocentesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DocentesGridView.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }


}
