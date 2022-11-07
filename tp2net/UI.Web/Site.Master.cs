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
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            nav_administrador.Visible = false;
            nav_alumno.Visible = false;

            if (Session["current_user"] != null)
            {
                Persona per = (Persona)Session["current_user"];

                ocultarOpcionesMenu((int)per.TipoPersona);
 
            }
            else
            {

                Response.Redirect("Login.aspx");
            }

        }

        private void ocultarOpcionesMenu(int tipoPersona)
        {
            switch (tipoPersona)
            {
                case 3: // alumno
                   nav_alumno.Visible = true;
                    break;
                case 2: // docente
                    nav_docente.Visible = true;
                    break;
                case 1: // administrador
                    nav_administrador.Visible = true;
                    break;
                default:
                    break;
            }
        }




    }
}