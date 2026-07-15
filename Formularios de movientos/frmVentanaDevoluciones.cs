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
    public partial class frmVentanaDevoluciones : Form
    {
        public frmVentanaDevoluciones()
        {
            InitializeComponent();
            //Llamar el procedimiento de fondos transparentes
            prcfondoPadre();
            //HACER REFERENCIA A NUESTROS PICTUREBOX A USAR EL EVENTO
            //pcbPrstamo
            this.pcbPrestamos.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pcbPrestamos.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            //pcbInicio
            this.pcbInicio.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pcbInicio.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            //pcbDevoliciones
            this.pcbDevoluciones.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pcbDevoluciones.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            //pcbInventario
            this.pcbInventario.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pcbInventario.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            //pcbReportes
            this.pcbReportes.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pcbReportes.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            //pcbCerrarSesion
            this.pcbSesion.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pcbSesion.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
        }
        //Poner fondo del contenedor padre
        public void prcfondoPadre()
        {
            pcbTituloPC.Parent = pcbFondoIncio;
            pcbInicio.Parent = pcbFondoIncio;
            pcbPrestamos.Parent = pcbFondoIncio;
            pcbDevoluciones.Parent = pcbFondoIncio;
            pcbInventario.Parent = pcbFondoIncio;
            pcbReportes.Parent = pcbFondoIncio;
            pcbSesion.Parent = pcbFondoIncio;
            pcbUsuario.Parent = pcbFondoIncio;
            lblRaya.Parent = pcbFondoIncio;
        }
        //Evento para el cuando pase el mouse por encima del objeto PictureBox
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.FromArgb(214, 234, 223);
        }
        //Evento para cuando salga el mouse del objeto PictureBox
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Transparent;
        }
        //pantalla principal
        private void pcbInicio_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal inicio = new frmPantallaPrincipal();
            inicio.WindowState = FormWindowState.Maximized;
            inicio.Show();
            this.Hide();
        }
        //pantalla prestamos
        private void pcbPrestamos_Click(object sender, EventArgs e)
        {
            frmVentanaPrestamos prestamo = new frmVentanaPrestamos();
            prestamo.WindowState = FormWindowState.Maximized;
            prestamo.Show();
            this.Hide();
        }
        // Pantalla devoluciones
        private void pcbDevoluciones_Click(object sender, EventArgs e)
        {
            frmVentanaDevoluciones devolucion = new frmVentanaDevoluciones();
            devolucion.WindowState = FormWindowState.Maximized;
            devolucion.Show();
            this.Hide();
        }
        // Pantalla inventario
        private void pcbInventario_Click(object sender, EventArgs e)
        {
            frmVentanaInventario inventario = new frmVentanaInventario();
            inventario.WindowState = FormWindowState.Maximized;
            inventario.Show();
            this.Hide();
        }
    }
}
