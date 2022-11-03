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
            Application.Run(new PersonaDesktop());
            
            /*Login login = new Login();
            UsuarioLogic ul = new UsuarioLogic();

            if (login.ShowDialog() == DialogResult.OK)
            {
                int tipoPersona = ul.BuscarTipoPersona(login.UsuarioActual.ID);
                switch (tipoPersona)
                {
                    case (int)TiposPersonas.Admin: Application.Run(new MenuAdmin(login.UsuarioActual)); break;
                    case (int)TiposPersonas.Docente: Application.Run(new MenuDocente(login.UsuarioActual)); break;
                    case (int)TiposPersonas.Alumno: Application.Run(new MenuAlumno(login.UsuarioActual)); break;
                    default: break;
                }
            }
            else
            {
                Application.Exit();
            }*/

        }
    }
}
