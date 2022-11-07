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
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        private Business.Entities.Plan Entity { get; set; }

        PlanLogic _logic;

        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
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

        private void SaveEntity(Business.Entities.Plan plan)
        {
            this.Logic.Save(plan);
        }


        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private void EnableForm(bool enable)
        {

            this.descripcionEspecialidadLabel.Visible = enable;
            this.descripcionTextBox.Enabled = enable; // >>> ???? >> > > > > >> > > > > > > > > 
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.idEspecialidadTextBox.Text = Entity.IDEspecialidad.ToString();

        }
        private void LoadEntity(Business.Entities.Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IDEspecialidad = int.Parse(this.idEspecialidadTextBox.Text);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.idEspecialidadTextBox.Text = string.Empty;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

            if (this.IsEntitySelected)
            {

                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                tituloForm.Text = "Modificar especialidad";
                this.LoadForm(this.SelectedID);
            }
        }
 
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            TextBox[] textBoxes = { descripcionTextBox, idEspecialidadTextBox };

            if (methods.validarYPintarCamposVacios(textBoxes))
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        this.Entity = new Business.Entities.Plan();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    default:
                        break;
                    case FormModes.Alta:
                        this.Entity = new Business.Entities.Plan();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                }
                this.formPanel.Visible = false;
                validacionDescripcionEspecialidad.Visible = false;
            }
            else
            {
                validacionDescripcionEspecialidad.Visible = true;
            }
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.formPanel.Visible = false;

        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            tituloForm.Text = "Nueva plan";
        }


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
      
        protected void buscarButton_Click(object sender, EventArgs e)
        {

            if (idIngresoTextBox.Text.Length > 0)
            {
                try
                {
                    idIngresoTextBox.BorderColor = System.Drawing.Color.White;
                    ClearForm();
                    LoadForm(int.Parse(idIngresoTextBox.Text));
                    tituloForm.Text = "Modificar plan";
                    this.FormMode = FormModes.Modificacion;
                    this.formPanel.Visible = true;
                }
                catch (Exception er)
                {

                    idIngresoTextBox.BorderColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                idIngresoTextBox.BorderColor = System.Drawing.Color.Red;
            }

        }

        protected void seleccionarButton(object sender, EventArgs e)
        {
            LoadEspecialidadGrid();
            tablaEspecialidad.Visible = true;

        }

        private void LoadEspecialidadGrid()
        {
            this.especialidadGridView.DataSource = new EspecialidadLogic().GetAll();
            this.especialidadGridView.DataBind();
        }
 
        protected void especialidadGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idEspecialidadTextBox.Text = this.especialidadGridView.SelectedValue.ToString();
            this.tablaEspecialidad.Visible = false;
        }
    }
}