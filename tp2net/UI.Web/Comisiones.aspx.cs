using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Business.Entities.Tables;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Comisiones : System.Web.UI.Page
    {
        private Business.Entities.Comision Entity
        {
            get;
            set;
        }

        ComisionLogic _logic;

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
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
        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {

            if (idIngresoTextBox.Text.Length > 0)
            {
                try
                {
                    LoadForm(int.Parse(idIngresoTextBox.Text));
                    this.FormMode = FormModes.Modificacion;
                    formPanel.Visible = true;
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

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Desc_comision;
            this.anioEspecialidadTextBox.Text = this.Entity.Anio_especialidad.ToString();
            this.idPlanTextBox.Text = this.Entity.IDPlan.ToString();
        }



        private void EnableForm(bool enable)
        {

            this.descripcionTextBox.Enabled = enable;
            this.anioEspecialidadTextBox.Enabled = enable;


        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Persona persona = (Persona)Session["current_user"];
            LoadGrid();

            mostrarOpcionesABM(persona.TipoPersona);

        }
        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }



        private void mostrarOpcionesABM(TiposPersonas tipoPersona)
        {

            this.cancelarLinkButton.Visible = true;
            this.aceptarLinkButton.Visible = true;
            this.editarLinkButton.Visible = true;

            this.nuevoLinkButton.Visible = true;
            this.gridView.Visible = true;
            this.gridPanel.Visible = true;

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

            if (this.IsEntitySelected)
            {

                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Business.Entities.Comision comision)
        {
            comision.Desc_comision = this.descripcionTextBox.Text;
            comision.IDPlan = int.Parse(this.idPlanTextBox.Text);
            comision.Anio_especialidad = int.Parse(this.anioEspecialidadTextBox.Text);


        }
        private void SaveEntity(Business.Entities.Comision comision)
        {
            this.Logic.Save(comision);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            TextBox[] arreglo = { descripcionTextBox, anioEspecialidadTextBox, idPlanTextBox };


            if (methods.validarYPintarCamposVacios(arreglo))
            {

                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        this.Entity = new Business.Entities.Comision();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = Business.Entities.BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    default:
                        break;
                    case FormModes.Alta:
                        this.Entity = new Business.Entities.Comision();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                }
                this.formPanel.Visible = false;


            }
            else
            {
                validacionCartelLabel.Visible = true;
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.idPlanTextBox.Text = string.Empty;
            this.anioEspecialidadTextBox.Text = string.Empty;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            this.formPanel.Visible = false;

        }
        protected void seleccionarButton(object sender, EventArgs e)
        {
            LoadEspecialidadGrid();
            tablaPlan.Visible = true;

        }

        private void LoadEspecialidadGrid()
        {
            this.planGridView.DataSource = new PlanLogic().GetAll();
            this.planGridView.DataBind();
        }

        protected void planGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idPlanTextBox.Text = this.planGridView.SelectedValue.ToString();
            this.tablaPlan.Visible = false;
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

    }
}
