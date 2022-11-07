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
    public partial class Inscripciones_Docentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
            modificarVistaSegunPermisosDelUsuario();
        }
        private Business.Entities.DocenteCurso Entity { get; set; }

        DocenteCursoLogic _logic;

        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }

        private void modificarVistaSegunPermisosDelUsuario()
        {
            Persona per = (Persona)Session["current_user"];
            switch (per.TipoPersona)
            {
                case TiposPersonas.Admin: break;
                case TiposPersonas.Docente: vistaParaDocente(); break;
                case TiposPersonas.Alumno: Response.Redirect("Home.aspx"); break;
            }
        }

        private void vistaParaDocente()
        {
            editarLinkButton.Visible = false;
            idPersonaLabel.Visible = false;
            seleccionarPersonaButton.Visible = false;
            buscadorPorID.Visible = false;
            idPersonaTextBox.Visible = false;

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
                return this.SelectedID != 0;
            }
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


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void SaveEntity(Business.Entities.DocenteCurso Docente_curso)
        {
            this.Logic.Save(Docente_curso);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {

            if (ingresoTextBox.Text.Length > 0)
            {
                try
                {
                    ingresoTextBox.BorderColor = System.Drawing.Color.White;
                    ClearForm();
                    LoadForm(int.Parse(ingresoTextBox.Text));
                    tituloForm.Text = "Modificar inscripcion";
                    this.FormMode = FormModes.Modificacion;
                    this.formPanel.Visible = true;
                }
                catch (Exception er)
                {

                    ingresoTextBox.BorderColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                ingresoTextBox.BorderColor = System.Drawing.Color.Red;
            }


        }

        private void LoadGrid()
        {
            Persona per = (Persona)Session["current_user"];
            switch (per.TipoPersona)
            {
                case TiposPersonas.Admin:
                    this.gridView.DataSource = this.Logic.GetAll();
                    this.gridView.Columns[1].Visible = true;
                    break;
                case TiposPersonas.Docente:
                    this.gridView.DataSource = this.Logic.GetAllYearDoc(per.ID, DateTime.Today.Year);
                    //this.gridView.Columns[0].Visible = false;
                    //this.gridView.Columns[1].Visible = false;
                    //this.gridView.Columns[5].Visible = false;
                    break;
                case TiposPersonas.Alumno:
                    Response.Redirect("Home.aspx");


                    break;
            }


            this.gridView.DataBind();

        }

        private void EnableForm(bool enable)
        {

            // this.descripcionEspecialidadLabel.Visible = enable;
            //  this.descripcionTextBox.Enabled = enable; // >>> ???? >> > > > > >> > > > > > > > > 
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);

            idCursoTextBox.Text = Entity.ID.ToString();
            idPersonaTextBox.Text = Entity.IDDocente.ToString();
            //cargoTextBox.Text = Entity.Cargo.ToString();

            switch (Entity.Cargo)
            {
                case TiposCargo.Jefe:
                    cargoDropDownList.SelectedValue = "0";
                    break;
                case TiposCargo.Docente:
                    cargoDropDownList.SelectedValue = "1";
                    break;
                case TiposCargo.Ayudante:
                    cargoDropDownList.SelectedValue = "2";
                    break;
                default:
                    break;
            }
        }
        private void LoadEntity(Business.Entities.DocenteCurso Docente_curso)
        {
            Persona per = (Persona)Session["current_user"];
            //switch (usr.DescTipoPersona)
            //{
            //    case "Administrativo":
            //        Docente_curso.id_docente = int.Parse(this.idPersonaTextBox.Text); ;

            //        Docente_curso.id_curso = int.Parse(this.idCursoTextBox.Text);

            //        break;
            //    case "Docente":
            //        Docente_curso.id_docente = usr.IdPersona;


            //        break;

            //}
            Docente_curso.IDDocente = int.Parse(this.idPersonaTextBox.Text);
            //Docente_curso.Cargo = int.Parse(this.cargoTextBox.Text);
            Docente_curso.IDCurso = int.Parse(this.idCursoTextBox.Text);
            if (Int32.Parse(this.cargoDropDownList.SelectedValue) == (int)TiposCargo.Jefe)
            {
                Docente_curso.Cargo = TiposCargo.Jefe;
            }
            else if (Int32.Parse(this.cargoDropDownList.SelectedValue) == (int)TiposCargo.Docente)
            {
                Docente_curso.Cargo = TiposCargo.Docente;
            }
            else Docente_curso.Cargo = TiposCargo.Ayudante;

            Docente_curso.ID = int.Parse(this.idCursoTextBox.Text);

        }

        private void ClearForm()
        {
            mensajeDeValidacionDeCampo.Visible = false;
            idCursoTextBox.Text = string.Empty;
            idPersonaTextBox.Text = string.Empty;
            //cargoTextBox.Text = string.Empty;
            //cargoDropDownList.SelectedValue ;

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                tituloForm.Text = "Modificar Docente_curso";
                this.LoadForm(this.SelectedID);

            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            tituloForm.Text = "Crear Docente_curso";
            this.ClearForm();
        }


        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            TextBox[] arreglo;

            if (((Persona)Session["current_user"]).TipoPersona == TiposPersonas.Alumno)
            {
                TextBox[] nuevoArreglo = { idCursoTextBox };
                arreglo = nuevoArreglo;

            }
            else
            {
                TextBox[] nuevoArreglo = { idPersonaTextBox, idCursoTextBox };
                arreglo = nuevoArreglo;

            }

            if (methods.validarYPintarCamposVacios(arreglo) && cargoDropDownList.SelectedValue != string.Empty)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        this.Entity = new Business.Entities.DocenteCurso();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    default:
                        break;
                    case FormModes.Alta:
                        this.Entity = new Business.Entities.DocenteCurso();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                }
                this.formPanel.Visible = false;

            }
            else
            {
                mensajeDeValidacionDeCampo.Visible = true;
            }

        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.formPanel.Visible = false;

        }




        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            ClearForm();
            this.formPanel.Visible = false;

        }

        protected void LoadPersonaGrid()
        {
            AlumnosGridView.DataSource = (idCursoTextBox.Text != string.Empty) ?
                   new PersonaLogic().GetDocentesByCourse(int.Parse(idCursoTextBox.Text))
                   :
                   new PersonaLogic().GetAllDocentes();
            AlumnosGridView.DataBind();
        }

        protected void seleccionarPersonaButton_Click(object sender, EventArgs e)
        {
            this.tablaCurso.Visible = false;
            LoadPersonaGrid();
            this.alumnosPanel.Visible = true;

        }



        protected void seleccionarCursoButton_Click(object sender, EventArgs e)
        {
            Persona per = (Persona)Session["current_user"];
            switch (per.TipoPersona)
            {
                case TiposPersonas.Admin: break;
                case TiposPersonas.Docente:
                    idPersonaTextBox.Text = per.ID.ToString();
                    break;
            }

            this.alumnosPanel.Visible = false;
            LoadCursoGrid();
            this.tablaCurso.Visible = true;

        }

        protected void cursoGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCursoTextBox.Text = this.cursoGridView.SelectedValue.ToString();
            this.tablaCurso.Visible = false;
        }

        protected void AlumnosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPersonaTextBox.Text = this.AlumnosGridView.SelectedValue.ToString();
            this.alumnosPanel.Visible = false;
        }

        protected void LoadCursoGrid()
        {
            cursoGridView.DataSource = (idPersonaTextBox.Text != string.Empty) ?
             new CursoLogic().GetAllForDoc(int.Parse(idPersonaTextBox.Text))
             :
             new CursoLogic().GetAll();
            cursoGridView.DataBind();
        }


        protected void cursoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cursoGridView.PageIndex = e.NewPageIndex;
            LoadCursoGrid();

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void AlumnosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AlumnosGridView.PageIndex = e.NewPageIndex;
            LoadPersonaGrid();
        }

        protected void cargoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
