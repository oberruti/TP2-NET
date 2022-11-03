using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private Persona _PersonaActual;

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                if (pl.ValidarPersona(txtUsuario.Text, txtPass.Text))
                {
                    PersonaActual = pl.GetOneByNombreUsuario(txtUsuario.Text);
                    if (PersonaActual.Habilitado)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("El Usuario no está habilitado");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exception ExcepcionManejada = new Exception("Error al traer usuario", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
