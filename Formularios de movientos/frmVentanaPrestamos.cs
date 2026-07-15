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
    public partial class frmVentanaPrestamos : Form
    {
        public frmVentanaPrestamos()
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

            //HACER REFERENCIA DE TODOS LOS CAMPOS SI ESTA LLENO O NO PARA EL CAMBIO DE COLOR
            txtMatricula.TextChanged += Campos_TextChanged;
            txtNombre.TextChanged += Campos_TextChanged;
            txtAPaterno.TextChanged += Campos_TextChanged;
            txtAMaterno.TextChanged += Campos_TextChanged;
            txtTelefono.TextChanged += Campos_TextChanged;
            txtCorreo.TextChanged += Campos_TextChanged;
            cmbDispositivo.TextChanged += Campos_TextChanged;
            txtGarantia.TextChanged += Campos_TextChanged;
            //LLAMAR EL METODO PARA CAMBIAR
            ActualizarColorBoton();
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

        private void pcbInicio_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal principal = new frmPantallaPrincipal();
            principal.Show();
            principal.WindowState = FormWindowState.Maximized;
            this.Hide();
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
        //EVENTO CLICK AL BUSCAR POR MATRICULA
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtMatricula.Text))
            {
                errorProvider1.SetError(txtMatricula, "Llene el campo\nAntes de buscar ");
                txtMatricula.Focus();
                return;
            }
        }
        //EVENTO CLICK AL ACEPTAR TODOS LOS CAMPOS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtMatricula.Text)) 
            {
                errorProvider1.SetError(txtMatricula, "Llene el campo\nAntes de aceptar ");
                txtMatricula.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) 
            {
                errorProvider1.SetError(txtNombre, "Llene el campo\nAntes de aceptar ");
                txtNombre.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtAPaterno.Text)) 
            {
                errorProvider1.SetError(txtAPaterno, "Llene el campo\nAntes de aceptar ");
                txtAPaterno.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtAMaterno.Text)) 
            {
                errorProvider1.SetError(txtAMaterno, "Llene el campo\nAntes de aceptar ");
                txtAMaterno.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) 
            {
                errorProvider1.SetError(txtTelefono, "Llene el campo\nAntes de aceptar ");
                txtTelefono.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtCorreo.Text)) 
            {
                errorProvider1.SetError(txtCorreo, "Llene el campo\nAntes de aceptar ");
                txtCorreo.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(cmbDispositivo.Text)) 
            {
                errorProvider1.SetError(cmbDispositivo, "Llene el campo\nAntes de aceptar ");
                cmbDispositivo.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(txtGarantia.Text)) 
            {
                errorProvider1.SetError(txtGarantia, "Llene el campo\nAntes de aceptar ");
                txtGarantia.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(dtmPrestamo.Text)) 
            {
                errorProvider1.SetError(dtmPrestamo, "Llene el campo\nAntes de aceptar ");
                dtmPrestamo.Focus();
                return;
            }
            //validamos el campo matricula
            if (string.IsNullOrWhiteSpace(dtmDevolucion.Text)) 
            {
                errorProvider1.SetError(dtmDevolucion, "Llene el campo\nAntes de aceptar ");
                dtmDevolucion.Focus();
                return;
            }
        }
        //metodo cambiar color del boton
        private void ActualizarColorBoton()
        {
            bool camposCompletos =
                !string.IsNullOrWhiteSpace(txtMatricula.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtAPaterno.Text) &&
                !string.IsNullOrWhiteSpace(txtAMaterno.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                !string.IsNullOrWhiteSpace(txtCorreo.Text) &&
                !string.IsNullOrWhiteSpace(cmbDispositivo.Text) &&
                !string.IsNullOrWhiteSpace(txtGarantia.Text);

            if (camposCompletos)
            {
                btnAceptar.BackColor = Color.Green;
                btnAceptar.ForeColor = Color.White;
            }
            else
            {
                btnAceptar.BackColor = SystemColors.Control;
                btnAceptar.ForeColor = Color.Black;
            }
        }
        //EVENTO PARA TODOS LOS CAMPOS
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            ActualizarColorBoton();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistroUsuarios newUsuario = new frmRegistroUsuarios();
            newUsuario.Show();
            newUsuario.WindowState = FormWindowState.Maximized;
            this.Hide();
        }

        private void pcbDevoluciones_Click(object sender, EventArgs e)
        {
            frmVentanaDevoluciones devolucion = new frmVentanaDevoluciones();
            devolucion.Show();
            devolucion.WindowState = FormWindowState.Maximized;
            this.Hide();
        }

        private void pcbInventario_Click(object sender, EventArgs e)
        {
            frmVentanaInventario inventario = new frmVentanaInventario();
            inventario.Show();
            inventario.WindowState = FormWindowState.Maximized;
            this.Hide();
        }
    }
}
