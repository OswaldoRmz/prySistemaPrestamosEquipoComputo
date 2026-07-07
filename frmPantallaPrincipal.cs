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
    public partial class frmPantallaPrincipal : Form
    {                
        public frmPantallaPrincipal()
        {
            InitializeComponent();
            lblTitulo.Parent = pcbFondoIncio;
            pcbTituloPC.Parent = pcbFondoIncio;
            pcbInicio.Parent = pcbFondoIncio;
            pcbPrestamos.Parent = pcbFondoIncio;
            pcbDevoluciones.Parent = pcbFondoIncio;
            pcbInventario.Parent = pcbFondoIncio;
            pcbReportes.Parent = pcbFondoIncio;
            pcbSesion.Parent = pcbFondoIncio;
            pcbUsuario.Parent = pcbFondoIncio;

            lblRaya.Parent = pcbFondoIncio;
            lblUsuario.Parent = pcbFondoIncio;
            lblSesion.Parent = pcbFondoIncio;
            lblPrestamos.Parent = pcbFondoIncio;
            lblReportes.Parent = pcbFondoIncio;
            lblDevoluciones.Parent = pcbFondoIncio;
            lblIncio.Parent = pcbFondoIncio;
            lblInventario.Parent = pcbFondoIncio;
        }

        private void lblSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
        "¿Desea cerrar la sesión?",
        "Cerrar sesión",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void lblPrestamos_Click(object sender, EventArgs e)
        {
            frmVentanaPrestamos prestamo = new frmVentanaPrestamos();
            prestamo.Show();
            prestamo.MaximizeBox = true;
            this.Hide();
        }

        private void lblDevoluciones_Click(object sender, EventArgs e)
        {
            frmVentanaDevoluciones devo = new frmVentanaDevoluciones();
            devo.Show();
            this.Hide();
        }
    }
}
