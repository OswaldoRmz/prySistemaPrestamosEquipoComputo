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
    public partial class frmRegistroUsuarios : Form
    {
        //variables para editar
        bool esEdicion = false;
        string matriculaSeleccionada = "";

        public frmRegistroUsuarios()
        {
            InitializeComponent();

            //poner fondo transparente
            prcfondoPadre();

            //configurar los botones cuando pasas el mouse
            pcbPrestamos.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pcbPrestamos.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            pcbInicio.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pcbInicio.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            pcbDevoluciones.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pcbDevoluciones.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            pcbInventario.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pcbInventario.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            pcbReportes.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pcbReportes.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            pcbSesion.MouseEnter += new EventHandler(PictureBox_MouseEnter);
            pcbSesion.MouseLeave += new EventHandler(PictureBox_MouseLeave);

            //cuando cambia el texto de los campos
            txtMatricula.TextChanged += new EventHandler(Campos_TextChanged);
            txtNombre.TextChanged += new EventHandler(Campos_TextChanged);
            txtAPaterno.TextChanged += new EventHandler(Campos_TextChanged);
            txtAMaterno.TextChanged += new EventHandler(Campos_TextChanged);
            txtTelefono.TextChanged += new EventHandler(Campos_TextChanged);
            txtCorreo.TextChanged += new EventHandler(Campos_TextChanged);
            txtGrado.TextChanged += new EventHandler(Campos_TextChanged);
            txtGrupo.TextChanged += new EventHandler(Campos_TextChanged);
            txtCalle.TextChanged += new EventHandler(Campos_TextChanged);
            txtColonia.TextChanged += new EventHandler(Campos_TextChanged);
            txtCP.TextChanged += new EventHandler(Campos_TextChanged);
            txtNumcasa.TextChanged += new EventHandler(Campos_TextChanged);

            //cuando cambia el tipo de usuario (Alumno, Docente, Trabajador)
            cmbTipo.SelectedIndexChanged += new EventHandler(cmbTipo_SelectedIndexChanged);

            //deshabilita botones al inicio
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtGrado.Enabled = false;
            txtGrupo.Enabled = false;

            //cambia el color de botones
            ActualizarColorBoton();
        }

        private bool ValidarCampos()
        {
            errorProvider1.Clear();

            //validamos el campo de matricula
            if (txtMatricula.Text == "")
            {
                errorProvider1.SetError(txtMatricula, "Matrícula requerida");
                txtMatricula.Focus();
                return false;
            }
            //validamos el campo nombre
            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Nombre requerido");
                txtNombre.Focus();
                return false;
            }
            //validamos el campo apellido paterno
            if (txtAPaterno.Text == "")
            {
                errorProvider1.SetError(txtAPaterno, "Apellido Paterno requerido");
                txtAPaterno.Focus();
                return false;
            }
            //validar el cmpo de telefono
            if (txtTelefono.Text == "")
            {
                errorProvider1.SetError(txtTelefono, "Teléfono requerido");
                txtTelefono.Focus();
                return false;
            }
            //validar el campo de correo
            if (txtCorreo.Text == "")
            {
                errorProvider1.SetError(txtCorreo, "Correo requerido");
                txtCorreo.Focus();
                return false;
            }
            //validar la colonia
            if (txtColonia.Text == "")
            {
                errorProvider1.SetError(txtColonia, "Colonia requerida");
                txtCorreo.Focus();
                return false;
            }
            //validar la calle
            if (txtCalle.Text == "")
            {
                errorProvider1.SetError(txtCalle, "Calle requerida");
                txtCorreo.Focus();
                return false;
            }
            //validar la codigo postal
            if (txtCP.Text == "")
            {
                errorProvider1.SetError(txtCP, "Codigo requerido");
                txtCorreo.Focus();
                return false;
            }
            //validar numero de casa
            if (txtNumcasa.Text == "")
            {
                errorProvider1.SetError(txtNumcasa, "Numero de casa requerido");
                txtCorreo.Focus();
                return false;
            }
            //validar la eleccion de un tipo
            if (cmbTipo.Text == "")
            {
                errorProvider1.SetError(cmbTipo, "Seleccione un tipo");
                cmbTipo.Focus();
                return false;
            }
            //validar la eleccion de un area
            if (cmbArea.Text == "")
            {
                errorProvider1.SetError(cmbArea, "Seleccione un área");
                cmbArea.Focus();
                return false;
            }


            //hacemos validacion por el tipo de usuario
            //Si es alumno
            if (cmbTipo.Text == "Alumno")
            {
                //valida grado
                if (txtGrado.Text == "")
                {
                    errorProvider1.SetError(txtGrado, "Grado requerido para alumnos");
                    txtGrado.Focus();
                    return false;
                }
                //valida grupo
                if (txtGrupo.Text == "")
                {
                    errorProvider1.SetError(txtGrupo, "Grupo requerido para alumnos");
                    txtGrupo.Focus();
                    return false;
                }
            }

            //si es docente o trabajador
            if (cmbTipo.Text == "Docente" || cmbTipo.Text == "Trabajador")
            {
                //limpiar grado y grupo
                txtGrado.Text = "";
                txtGrupo.Text = "";
            }

            //si tiene todo bien
            return true;
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //si selecciono alumno
            if (cmbTipo.Text == "Alumno")
            {
                //habilitar grado y grupo
                txtGrado.Enabled = true;
                txtGrupo.Enabled = true;
                txtGrado.BackColor = Color.White;
                txtGrupo.BackColor = Color.White;
            }
            else if(cmbTipo.Text =="Administrador")
            {
                //si es administrador
                txtGrado.Enabled = false;
                txtGrupo.Enabled = false;
                txtGrado.Text = "";
                txtGrupo.Text = "";
                txtGrado.BackColor = SystemColors.Control;
                txtGrupo.BackColor = SystemColors.Control;
                cmbArea.Enabled = false;
                cmbArea.BackColor = SystemColors.Control;
            }
            else
            {
                //si es docente o trabajador
                txtGrado.Enabled = false;
                txtGrupo.Enabled = false;
                txtGrado.Text = "";
                txtGrupo.Text = "";
                txtGrado.BackColor = SystemColors.Control;
                txtGrupo.BackColor = SystemColors.Control;
            }

                //cambia el color a los botones
                ActualizarColorBoton();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //validar campos
            if (ValidarCampos() == false)
            {
                return;
            }
            MessageBox.Show("Usuario agregado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCajas();
            CargarUsuarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //verifica el usuario que se selecciono
            if (matriculaSeleccionada == "")
            {
                MessageBox.Show("Seleccione un usuario para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCampos() == false)
            {
                return;
            }
            MessageBox.Show("Usuario editado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCajas();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtMatricula.Enabled = true;

            CargarUsuarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //verificar que haya seleccionado un usuario
            if (matriculaSeleccionada == "")
            {
                MessageBox.Show("Seleccione un usuario para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirmacion
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar al usuario con matrícula " + matriculaSeleccionada + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            //si
            if (respuesta == DialogResult.Yes)
            {
                MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCajas();
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                txtMatricula.Enabled = true;
                matriculaSeleccionada = "";
                CargarUsuarios();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            LimpiarCajas();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtMatricula.Enabled = true;
            matriculaSeleccionada = "";
            errorProvider1.Clear();

            ActualizarColorBoton();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            //verificar el filtro
            if (txtFiltroMatricula.Text == "")
            {
                errorProvider1.SetError(txtFiltroMatricula, "Escriba una matrícula para buscar");
                txtFiltroMatricula.Focus();
                return;
            }
            MessageBox.Show("Buscando matrícula: " + txtFiltroMatricula.Text, "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //se usa cuando se selecciona algo en la tabla
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //verificamos que haya seleccionado algo
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                //rellenamos con lo de la fila
                matriculaSeleccionada = fila.Cells["Matricula"].Value.ToString();
                txtMatricula.Text = matriculaSeleccionada;
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtAPaterno.Text = fila.Cells["ApellidoPaterno"].Value.ToString();
                txtAMaterno.Text = fila.Cells["ApellidoMaterno"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                cmbTipo.Text = fila.Cells["Tipo"].Value.ToString();
                cmbArea.Text = fila.Cells["Area"].Value.ToString();
                txtGrado.Text = fila.Cells["Grado"].Value.ToString();
                txtGrupo.Text = fila.Cells["Grupo"].Value.ToString();
                txtNumcasa.Text = fila.Cells["NumCasa"].Value.ToString();
                txtColonia.Text = fila.Cells["Colonia"].Value.ToString();
                txtCalle.Text = fila.Cells["Calle"].Value.ToString();
                txtCP.Text = fila.Cells["CP"].Value.ToString();

                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                txtMatricula.Enabled = false;
                esEdicion = true;

                cmbTipo_SelectedIndexChanged(sender, e);
            }
        }

        private void CargarUsuarios()
        {
            //aquí iría el código para cargar desde la base de datos
        }

        public void LimpiarCajas()
        {
            txtMatricula.Clear();
            txtNombre.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtGrado.Clear();
            txtGrupo.Clear();
            txtCalle.Clear();
            txtColonia.Clear();
            txtCP.Clear();
            txtNumcasa.Clear();
            cmbTipo.Text = "";
            cmbArea.Text = "";

            txtGrado.Enabled = false;
            txtGrupo.Enabled = false;
        }

        private void ActualizarColorBoton()
        {
            bool camposLlenos =
                txtMatricula.Text != "" &&
                txtNombre.Text != "" &&
                txtAPaterno.Text != "" &&
                txtAMaterno.Text != "" &&
                txtTelefono.Text != "" &&
                txtCorreo.Text != "" &&
                txtCalle.Text != "" &&
                txtColonia.Text != "" &&
                txtCP.Text != "" &&
                txtNumcasa.Text != "" &&
                cmbTipo.Text != "" &&
                cmbArea.Text != "";

            //para alumno verificamos grado y grupo
            if (cmbTipo.Text == "Alumno")
            {
                camposLlenos = camposLlenos &&
                               txtGrado.Text != "" &&
                               txtGrupo.Text != "";
            }

            if (camposLlenos == true)
            {
                btnAgregar.BackColor = Color.Green;
                btnAgregar.ForeColor = Color.White;

                btnEditar.BackColor = Color.Blue;
                btnEditar.ForeColor = Color.White;

                btnCancel.BackColor = Color.Orange;
                btnCancel.ForeColor = Color.White;

                btnEliminar.BackColor = Color.Red;
                btnEliminar.ForeColor = Color.White;
            }
            else
            {
                btnAgregar.BackColor = SystemColors.Control;
                btnAgregar.ForeColor = Color.Black;

                btnEditar.BackColor = SystemColors.Control;
                btnEditar.ForeColor = Color.Black;

                btnCancel.BackColor = SystemColors.Control;
                btnCancel.ForeColor = Color.Black;

                btnEliminar.BackColor = SystemColors.Control;
                btnEliminar.ForeColor = Color.Black;
            }
        }

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            ActualizarColorBoton();
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.FromArgb(214, 234, 223);
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.BackColor = Color.Transparent;
        }

        //cerrar sesion
        private void pcbSesion_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Desea cerrar la sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void pcbPrestamos_Click(object sender, EventArgs e)
        {
            frmVentanaPrestamos prestamo = new frmVentanaPrestamos();
            prestamo.Show();
            prestamo.WindowState = FormWindowState.Maximized;
            this.Hide();
        }

        private void pcbInventario_Click(object sender, EventArgs e)
        {
            frmVentanaInventario inventario = new frmVentanaInventario();
            inventario.Show();
            inventario.WindowState = FormWindowState.Maximized;
            this.Hide();
        }

        private void pcbDevoluciones_Click(object sender, EventArgs e)
        {
            frmVentanaDevoluciones devolucion = new frmVentanaDevoluciones();
            devolucion.Show();
            devolucion.WindowState = FormWindowState.Maximized;
            this.Hide();
        }

        private void pcbInicio_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal inicio = new frmPantallaPrincipal();
            inicio.WindowState = FormWindowState.Maximized;
            inicio.Show();
            this.Hide();
        }

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
    }
}
