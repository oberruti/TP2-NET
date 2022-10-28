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
    public partial class Comisiones : System.Web.UI.Page
    {
        private Comision Entity
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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.modo_vista(true);
            LoadGrid();
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.desc_comisionTextBox.Text = this.Entity.Desc_comision;
            this.anio_especialidadTextBox.Text = this.Entity.Anio_especialidad.ToString();
            this.id_planTextBox.Text = this.Entity.Id_Plan.ToString();
        }

        private void LoadEntity(Comision comision)
        {
            comision.Desc_comision = this.desc_comisionTextBox.Text;
            comision.Anio_especialidad = int.Parse(this.anio_especialidadTextBox.Text);
            comision.Id_Plan = int.Parse(this.id_planTextBox.Text);
        }

        private void SaveEntity(Comision comision)
        {
            try
            {
                this.Logic.Save(comision);
            }
            catch
            {
                Response.Write("<script>alert('Error: La comision no se ha guardado, por favor verifique los valores ingresados.')</script>");
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.desc_comisionTextBox.Enabled = enable;
            this.anio_especialidadTextBox.Enabled = enable;
            this.id_planTextBox.Enabled = enable;
        }

        // Vacia formulario luego de edicion
        private void ClearForm()
        {
            this.desc_comisionTextBox.Text = string.Empty;
            this.anio_especialidadTextBox.Text = string.Empty;
            this.id_planTextBox.Text = string.Empty;
        }

        // BOTONES GRID
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.modo_vista(false);
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.modo_vista(false);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.modo_vista(false);
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        // BOTONES FORM
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Comision();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    break;
                default:
                    break;
            }
            this.modo_vista(true);
            this.LoadGrid();
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.modo_vista(true);
        }

        // Otros metodos
        protected void modo_vista(bool modo)
        {
            // true: seleccion - false: edicion.
            this.gridPanel.Visible = modo;
            this.formPanel.Visible = !modo;
            this.gridActionsPanel.Visible = modo;
            this.formActionsPanel.Visible = !modo;
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}