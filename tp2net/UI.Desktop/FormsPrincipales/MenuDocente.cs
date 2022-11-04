using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;

namespace UI.Desktop
{
    public partial class MenuDocente : Form
    {
        public MenuDocente()
        {
            InitializeComponent();
        }

        public MenuDocente(Persona persona) : this()
        {
            PersonaActual = persona;
            lblBienvenida.Text += " " + PersonaActual.Apellido + " " + PersonaActual.Nombre;
        }

        private Persona _PersonaActual;
        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

        private void btnCargarNotas_Click(object sender, EventArgs e)
        {
            AlumnosInscripcionesLista ail = new AlumnosInscripcionesLista(PersonaActual);
            ail.ShowDialog();
        }

        private void btnReporteCursos_Click(object sender, EventArgs e)
        {
            ReporteCursos rc = new ReporteCursos();
            rc.ShowDialog();
        }

        private void btnReportePlanes_Click(object sender, EventArgs e)
        {
            ReportePlanes rp = new ReportePlanes();
            rp.ShowDialog();
        }
    }
}
