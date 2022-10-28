using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }

        protected void btnMaterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Materias.aspx");
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");
        }

        protected void btnCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");
        }
    }
}