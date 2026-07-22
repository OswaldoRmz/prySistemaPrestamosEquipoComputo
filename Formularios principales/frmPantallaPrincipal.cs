using prySistemaPrestamosEquipoComputo.Clases;
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
        clsLectorSemantico lec = new clsLectorSemantico();
        public frmPantallaPrincipal()
        {
            InitializeComponent();
            ConfigurarAccesibilidad();
            AsignarEventosDeLectura(this);
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
        //configuracion de accesibilidad
        private void ConfigurarAccesibilidad()
        {
            this.AccessibleName = "Pantalla inicio";
            this.AccessibleDescription = "Bienvenido a la pantalla de inicio";

            pcbInicio.AccessibleName = "Inicio";
            pcbInicio.AccessibleDescription = "Click para entrar a la pantalla de inicio";

            pcbPrestamos.AccessibleName = "Préstamos";
            pcbPrestamos.AccessibleDescription = "Click para entrar a la pantalla de préstamos";

            pcbDevoluciones.AccessibleName = "Devolciones";
            pcbDevoluciones.AccessibleDescription = "Click para entrar a la pantalla de devoluciones";

            pcbInventario.AccessibleName = "Inventario";
            pcbInventario.AccessibleDescription = "Click para entrar a la pantallla de inventario";

            pcbSesion.AccessibleName = "Cerrar sesión";
            pcbSesion.AccessibleDescription = "Click para cerrar sesión";
        }
        //Asignar evento de lectura
        private void AsignarEventosDeLectura(Control contenedor)
        {
            foreach (Control c in contenedor.Controls)
            {
                c.MouseEnter += (sender, e) => { lec.Leer(c); };

                if (c.HasChildren)
                    AsignarEventosDeLectura(c);
            }
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
        //Evento click para cerrar la sesion y regresar al login
        private void pcbSesion_Click(object sender, EventArgs e)
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
        // Abrir el formulario prestamo
        private void pcbPrestamos_Click(object sender, EventArgs e)
        {
            frmVentanaPrestamos prestamo = new frmVentanaPrestamos();
            prestamo.Show();
            prestamo.WindowState = FormWindowState.Maximized;
            this.Hide();
        }
        // Abrir el formulario Inventario
        private void pcbInventario_Click(object sender, EventArgs e)
        {
            frmVentanaInventario inventario = new frmVentanaInventario();
            inventario.Show();
            inventario.WindowState = FormWindowState.Maximized;
            this.Hide();
        }
        //avrir el formulario devoluciones
        private void pcbDevoluciones_Click(object sender, EventArgs e)
        {
            frmVentanaDevoluciones devolucion = new frmVentanaDevoluciones();
            devolucion.Show();
            devolucion.WindowState = FormWindowState.Maximized;
            this.Hide();
        }        
    }
}
