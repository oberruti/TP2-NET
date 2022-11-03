using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Personas());
            
            Login login = new Login();
            PersonaLogic pl = new PersonaLogic();

            if (login.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(login.PersonaActual.TipoPersona.ToString());
                switch (login.PersonaActual.TipoPersona)
                {
                    case TiposPersonas.Admin: Application.Run(new MenuAdmin(login.PersonaActual)); break;
                    case TiposPersonas.Docente: Application.Run(new MenuDocente(login.PersonaActual)); break;
                    case TiposPersonas.Alumno: Application.Run(new MenuAlumno(login.PersonaActual)); break;
                    default: break;
                }
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
