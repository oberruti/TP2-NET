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
    public partial class Materias : System.Web.UI.Page
    {
        private Materia Entity
        {
            get;
            set;
        }

        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
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

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.desc_materiaTextBox.Text = this.Entity.Desc_materia;
            this.hs_semanalesTextBox.Text = this.Entity.Hs_semanales.ToString();
            this.hs_totalesTextBox.Text = this.Entity.Hs_totales.ToString();
            this.id_planTextBox.Text = this.Entity.Id_Plan.ToString();
        }

        private void LoadEntity(Materia materia)
        {
            materia.Desc_materia = this.desc_materiaTextBox.Text;
            materia.Hs_semanales = int.Parse(this.hs_semanalesTextBox.Text);
            materia.Hs_totales = int.Parse(this.hs_totalesTextBox.Text);
            materia.Id_Plan = int.Parse(this.id_planTextBox.Text);
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

        private void SaveEntity(Materia materia)
        {
            try
            {
                this.Logic.Save(materia);
            }
            catch
            {
                Response.Write("<script>alert('Error: La materia no se ha guardado, por favor verifique los valores ingresados.')</script>");
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.desc_materiaTextBox.Enabled = enable;
            this.hs_semanalesTextBox.Enabled = enable;
            this.hs_totalesTextBox.Enabled = enable;
            this.id_planTextBox.Enabled = enable;
        }

        // Vacia formulario luego de edicion
        private void ClearForm()
        {
            this.desc_materiaTextBox.Text = string.Empty;
            this.hs_semanalesTextBox.Text = string.Empty;
            this.hs_totalesTextBox.Text = string.Empty;
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
                    this.Entity = new Materia();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Materia();
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