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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           this.persona = (Persona)Session["current_user"];
           
            pantallaSegunTipoPersona();
        }

        private Persona persona;

        private void pantallaSegunTipoPersona()
        {

            switch(persona.TipoPersona)
            {
                case TiposPersonas.Docente: pantallaDocente();  break;
                case TiposPersonas.Alumno: pantallaAlumno(); break;
                case TiposPersonas.Admin: pantallaAdminsitrador(); break;
            }
        }


        private void pantallaAlumno()
        {
            nombreAlumno.Text = persona.Apellido + " " + persona.Nombre;
        }

        private void pantallaAdminsitrador()
        {
            nombreAlumno.Text = persona.Apellido + " " + persona.Nombre;
        }
        private void pantallaDocente()
        {
            nombreAlumno.Text = persona.Apellido + " " + persona.Nombre;
        }

    }
}