
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
    public partial class Cursos : System.Web.UI.Page
    {
        private Curso Entity
        {
            get;
            set;
        }

        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
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
            this.IdComisionTextBox.Text = (this.Entity.Id_comision).ToString();
            this.IdMateriaTextBox.Text = this.Entity.Id_materia.ToString();
            this.AnioCalendarioTextBox.Text = this.Entity.Año_calendario.ToString();
            this.CupoTextBox.Text = this.Entity.Cupo.ToString();
        }

        private void LoadEntity(Curso curso)
        {
            curso.Id_comision =int.Parse( this.IdComisionTextBox.Text);
            curso.Id_materia = int.Parse(this.IdMateriaTextBox.Text);
            curso.Año_calendario = int.Parse(this.AnioCalendarioTextBox.Text);
            curso.Cupo = int.Parse(this.CupoTextBox.Text);         
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void SaveEntity(Curso curso)
        {
            try
            {
                this.Logic.Save(curso);
            }
            catch
            {
                Response.Write("<script>alert('Error: El curso no se ha guardado, por favor verifique los valores ingresados.')</script>");
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.IdMateriaTextBox.Enabled = enable;
            this.IdComisionTextBox.Enabled = enable;
            this.AnioCalendarioTextBox.Enabled = enable;
            this.CupoTextBox.Enabled = enable;
            
        }

        // Vacia formulario luego de edicion
        private void ClearForm()
        {
            this.IdMateriaTextBox.Text = string.Empty;
            this.IdComisionTextBox.Text = string.Empty;
            this.AnioCalendarioTextBox.Text = string.Empty;
            this.CupoTextBox.Text = string.Empty;
           
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
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity); 
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Curso();
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