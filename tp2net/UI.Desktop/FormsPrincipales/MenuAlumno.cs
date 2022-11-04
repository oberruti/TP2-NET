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
    public partial class MenuAlumno : Form
    {
        public MenuAlumno()
        {
            InitializeComponent();
        }

        public MenuAlumno(Persona persona) : this()
        {
            PersonaActual = persona;
            lblBienvenida.Text += " " + PersonaActual.Apellido + " " + PersonaActual.Nombre;
        }

        private Persona _PersonaActual;
        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
    }
}
