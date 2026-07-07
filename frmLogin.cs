using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySistemaPrestamosEquipoComputo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string clave = txtClaveAcceso.Text;
            string password = txtPassword.Text;

            if (usuario == "admin" && clave == "20250994" && password == "admin") 
            {
                MessageBox.Show("Acceso correcto");
                frmPantallaPrincipal principal = new frmPantallaPrincipal();
                principal.Show();
                this.Hide();   
            }
            else
            {
                MessageBox.Show("Acceso incorrecto. Intente nuevamente");
            }
        }
    }
}
