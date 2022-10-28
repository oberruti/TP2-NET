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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario user = new Usuario();

            try
            {
                user = ul.GetOne(this.txtUsuario.Text);
                if (this.txtPass.Text == user.Clave && user.Habilitado)
                {
                    this.DialogResult = DialogResult.OK;
                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exception ExcepcionManejada = new Exception("Error al traer usuario", ex);
                throw ExcepcionManejada;
            }

            /*if (this.txtUsuario.Text == "Admin" && this.txtPass.Text == "Admin")
            {
                this.DialogResult = DialogResult.OK;
                Menu menu = new Menu();
                menu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
    }
}
