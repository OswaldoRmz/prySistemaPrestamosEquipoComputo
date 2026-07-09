using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        private void btnAcceso_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            string usuario = txtUsuario.Text;
            string clave = txtClaveAcceso.Text;
            string password = txtPassword.Text;

            //validamos el campo usuario
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario,"Campo vacio");
                txtUsuario.Focus();
                return;
            }
            //validamos el campo clave
            if (string.IsNullOrWhiteSpace(txtClaveAcceso.Text))
            {
                errorProvider1.SetError(txtClaveAcceso, "Campo vacio");
                txtClaveAcceso.Focus();
                return;
            }
            //vaidamos el campo contraseña            
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Campo vacio");
                txtPassword.Focus();
                return;
            }

            //Acceso basico
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
                limpiarCajas();
            }
        }
        //procedimiento para borrar las cajas de texto
        public void limpiarCajas()
        {
            txtUsuario.Clear();
            txtClaveAcceso.Clear();
            txtPassword.Clear();
        }
    }
}
