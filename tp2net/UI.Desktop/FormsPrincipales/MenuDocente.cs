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

        public MenuDocente(Usuario usuario) : this()
        {
            UsuarioActual = usuario;
            lblBienvenida.Text += " " + UsuarioActual.Apellido + " " + UsuarioActual.Nombre;
        }

        private Usuario _usuarioActual;

        public Usuario UsuarioActual { get => _usuarioActual; set => _usuarioActual = value; }
    }
}
