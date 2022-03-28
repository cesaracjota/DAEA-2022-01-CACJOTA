using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "usuario" && txtPassword.Text == "pass123")
            {
                PrincipalMDI principal = new PrincipalMDI();
                principal.Show();
                this.Hide();
            }
            else
            {
                Console.WriteLine("Error de inicio de Sesion");
                txtUsuario.ResetText();
                txtPassword.ResetText();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }
    }
}
