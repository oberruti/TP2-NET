using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;

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
            Application.Run(new Planes());
            /*
            Login login = new Login();
            UsuarioLogic ul = new UsuarioLogic();

            if (login.ShowDialog() == DialogResult.OK)
            {
                int tipoPersona = ul.BuscarTipoPersona(login.UsuarioActual.ID);
                switch (tipoPersona)
                {
                    case 1: Application.Run(new MenuAdmin(login.UsuarioActual)); break;
                    case 2: Application.Run(new MenuDocente(login.UsuarioActual)); break;
                    case 3: Application.Run(new MenuAlumno(login.UsuarioActual)); break;
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
