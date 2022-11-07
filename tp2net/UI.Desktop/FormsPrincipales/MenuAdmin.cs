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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        public MenuAdmin(Persona persona) : this()
        {
            PersonaActual = persona;
            lblBienvenida.Text += " " + PersonaActual.Apellido + " " + PersonaActual.Nombre;
        }

        private Persona _PersonaActual;
        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Especialidades es = new Especialidades();
            es.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cu = new Cursos();
            cu.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones co = new Comisiones();
            co.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas pe = new Personas();
            pe.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes pl = new Planes();
            pl.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias();
            mat.ShowDialog();
        }
    }
}
