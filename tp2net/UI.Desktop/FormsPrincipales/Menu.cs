﻿using System;
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
    public partial class Menu : ApplicationForm
    {

        public Menu(Usuario usuario) : this()
        {
            UsuarioActual = usuario;
        }

        private Usuario _usuarioActual;

        public Usuario UsuarioActual { get => _usuarioActual; set => _usuarioActual = value; }

        public Menu()
        {
            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnMenuUsuarios_Click(object sender, EventArgs e)
        {
            Personas pd = new Personas();
            pd.ShowDialog();
        }

        private void btnMenuCursos_Click(object sender, EventArgs e)
        {
            Cursos ud = new Cursos();
            ud.ShowDialog();
        }

        private void btnMenuMaterias_Click(object sender, EventArgs e)
        {
            Materias ud = new Materias();
            ud.ShowDialog();
        }

        private void btnMenuComisiones_Click(object sender, EventArgs e)
        {
            Comisiones ud = new Comisiones();
            ud.ShowDialog();
        }
    }
}
