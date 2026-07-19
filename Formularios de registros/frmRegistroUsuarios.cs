using MySql.Data.MySqlClient;
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
    public partial class frmRegistroUsuarios : Form
    {
        //variables para editar
        bool esEdicion = false;
        string matriculaSeleccionada = "";
        string tablaOrigenSeleccionada = "";
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

        //Metodo para cargar los datos en dtg
        private clsConexion coneccion;
        // Guarda el ID del producto seleccionado
        private int productoIdSeleccionado = 0;

        private void cargaDatos()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                string consulta = @"
            SELECT *
            FROM vw_usuarios_catalogo
            ORDER BY Matricula";

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(consulta, con);

                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvUsuarios.DataSource = tabla;

                // Configuración del DataGridView
                dgvUsuarios.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvUsuarios.MultiSelect = false;
                dgvUsuarios.ReadOnly = true;
                dgvUsuarios.AllowUserToAddRows = false;

                // Ocultamos datos que no necesitas mostrar,
                // pero que servirán para llenar los campos
                dgvUsuarios.Columns["Correo"].Visible = false;
                dgvUsuarios.Columns["Tipo"].Visible = false;
                dgvUsuarios.Columns["Area"].Visible = false;
                dgvUsuarios.Columns["Grado"].Visible = false;
                dgvUsuarios.Columns["Grupo"].Visible = false;
                dgvUsuarios.Columns["NumCasa"].Visible = false;
                dgvUsuarios.Columns["Colonia"].Visible = false;
                dgvUsuarios.Columns["Calle"].Visible = false;
                dgvUsuarios.Columns["CP"].Visible = false;
                dgvUsuarios.Columns["TablaOrigen"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los usuarios:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
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
            else if (cmbTipo.Text == "Administrador")
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
            // Validamos todos los campos del formulario
            if (ValidarCampos() == false)
            {
                return;
            }

            if (cmbTipo.Text == "Alumno")
            {
                AgregarAlumno();
            }
            else
            {
                AgregarTrabajador();
            }
            
            LimpiarCajas();
            cargaDatos();
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
            string tablaOrigen = tablaOrigenSeleccionada.Trim().ToLower();
            if (tablaOrigen == "alumno")
            {
                EditarAlumno();
            }
            else if (tablaOrigen == "trabajador")
            {
                EditarTrabajador();
            }            

            LimpiarCajas();
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtMatricula.Enabled = true;

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
                EliminarUsuario();
                LimpiarCajas();
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                txtMatricula.Enabled = true;
                matriculaSeleccionada = "";
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
        //Obtener id de carreras
        private int ObtenerIdCarrera(MySqlConnection con,string nombreCarrera)
        {
            string consulta = @"
        SELECT id_carrera
        FROM carrera
        WHERE nombre = @nombre
        LIMIT 1";

            MySqlCommand comando = new MySqlCommand(consulta, con);

            comando.Parameters.AddWithValue(
                "@nombre",
                nombreCarrera.Trim());

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
        //Obtener id de area
        private int ObtenerIdArea(MySqlConnection con, string nombreArea)
        {
            string consulta = @"
        SELECT id_area
        FROM area
        WHERE nombre = @nombre
        LIMIT 1";

            MySqlCommand comando =
                new MySqlCommand(consulta, con);

            comando.Parameters.AddWithValue(
                "@nombre",
                nombreArea.Trim());

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
        //obtener id de rol
        private int ObtenerIdRol(MySqlConnection con,string nombreRol)
        {
            string consulta = @"
        SELECT id_rol
        FROM rol
        WHERE tipo_rol = @tipoRol
        LIMIT 1";

            MySqlCommand comando =
                new MySqlCommand(consulta, con);

            comando.Parameters.AddWithValue(
                "@tipoRol",
                nombreRol.Trim());

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
        private void frmRegistroUsuarios_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }
        //Metodo para agregar un alumno
        private void AgregarAlumno()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();
            int idCarrera = ObtenerIdCarrera(con,cmbArea.Text);

            string consulta = @"INSERT INTO alumno(matricula,nombres,apellido_paterno, apellido_materno,telefono,correo,codigo_postal, calle, colonia, numero_casa, grado,grupo,id_carrera)
            VALUES (@matricula,@nombres,@apellidoPaterno,@apellidoMaterno,@telefono,@correo,@codigoPostal,@calle,@colonia,@numeroCasa,@grado,@grupo,@idCarrera)";

            MySqlCommand comando = new MySqlCommand(consulta, con);

            comando.Parameters.AddWithValue("@matricula", txtMatricula.Text.Trim());
            comando.Parameters.AddWithValue("@nombres", txtNombre.Text.Trim());
            comando.Parameters.AddWithValue("@apellidoPaterno", txtAPaterno.Text.Trim());
            comando.Parameters.AddWithValue("@apellidoMaterno", txtAMaterno.Text.Trim());
            comando.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
            comando.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
            comando.Parameters.AddWithValue("@codigoPostal", txtCP.Text.Trim());
            comando.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
            comando.Parameters.AddWithValue("@colonia", txtColonia.Text.Trim());
            comando.Parameters.AddWithValue("@numeroCasa", txtNumcasa.Text.Trim());
            comando.Parameters.AddWithValue("@grado", txtGrado.Text.Trim());
            comando.Parameters.AddWithValue("@grupo", txtGrupo.Text.Trim());
            comando.Parameters.AddWithValue("@idcarrera", idCarrera);

            int filasAfectads = comando.ExecuteNonQuery();
            con.Close();

            if (filasAfectads > 0)
            {
                MessageBox.Show("Alumno agregado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCajas();
                cargaDatos();
            }
            else
            {
                MessageBox.Show("Algo Fallo");
            }
        }
        //Metodo para agregar un trabajador
        private void AgregarTrabajador()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();
            int idarea = ObtenerIdArea(con, cmbArea.Text);
            int idrol = ObtenerIdRol(con, cmbTipo.Text);
            string consulta = @"INSERT INTO trabajador(num_trabajador,nombres,apellido_paterno,apellido_materno,telefono,correo,codigo_postal,calle,colonia,numero_casa,id_area,id_rol)
            VALUES (@numeroTrabajador,@nombres,@apellidoPaterno,@apellidoMaterno,@telefono,@correo,@codigoPostal,@calle,@colonia,@numeroCasa,@idarea,@idrol)";

            MySqlCommand command = new MySqlCommand(consulta, con);

            command.Parameters.AddWithValue("@numeroTrabajador", txtMatricula.Text.Trim());
            command.Parameters.AddWithValue("@nombres", txtNombre.Text.Trim());
            command.Parameters.AddWithValue("@apellidoPaterno", txtAPaterno.Text.Trim());
            command.Parameters.AddWithValue("@apellidoMaterno", txtAMaterno.Text.Trim());
            command.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
            command.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
            command.Parameters.AddWithValue("@codigoPostal", txtCP.Text.Trim());
            command.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
            command.Parameters.AddWithValue("@colonia", txtColonia.Text.Trim());
            command.Parameters.AddWithValue("@numeroCasa", txtNumcasa.Text.Trim());
            command.Parameters.AddWithValue("@idarea", idarea);
            command.Parameters.AddWithValue("@idrol", idrol);

            int filasAfectadas = command.ExecuteNonQuery();
            con.Close();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Usuario agregado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarCajas();
                cargaDatos();
            }
            else
            {
                MessageBox.Show("Algo fallo");
            }
        }

        //Evento al seleccionar una entidad desde el data griev view
        private void dgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Evita seleccionar los encabezados
            if (e.RowIndex < 0)
            {
                return;
            }

            // Obtenemos la fila seleccionada directamente
            // desde el DataTable
            DataRowView fila = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as DataRowView;

            if (fila == null)
            {
                return;
            }

            // Guardamos la llave primaria seleccionada
            matriculaSeleccionada = fila["Matricula"]?.ToString() ?? "";
            // Guardamos la tabla de origen
            tablaOrigenSeleccionada = fila["TablaOrigen"]?.ToString() ?? "";
            // Llenamos los campos personales
            txtMatricula.Text = fila["Matricula"]?.ToString() ?? "";
            txtNombre.Text = fila["Nombre"]?.ToString() ?? "";
            txtAPaterno.Text = fila["ApellidoPaterno"]?.ToString() ?? "";
            txtAMaterno.Text = fila["ApellidoMaterno"]?.ToString() ?? "";
            txtTelefono.Text = fila["Telefono"]?.ToString() ?? "";
            txtCorreo.Text = fila["Correo"]?.ToString() ?? "";
            // Primero asignamos el tipo.          
            cmbTipo.Text = fila["Tipo"]?.ToString() ?? "";
            // Después seleccionamos la carrera o área
            cmbArea.Text = fila["Area"]?.ToString() ?? "";
            txtGrado.Text = fila["Grado"]?.ToString() ?? "";
            txtGrupo.Text = fila["Grupo"]?.ToString() ?? "";
            txtNumcasa.Text = fila["NumCasa"]?.ToString() ?? "";
            txtColonia.Text = fila["Colonia"]?.ToString() ?? "";
            txtCalle.Text = fila["Calle"]?.ToString() ?? "";
            txtCP.Text = fila["CP"]?.ToString() ?? "";

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            esEdicion = true;

            ActualizarColorBoton();
        }

        //Metodo para eliminar usuarios
        private void EliminarUsuario()
        {
            try
            {
                coneccion = new clsConexion();
                MySqlConnection con = coneccion.getConection();
                string consulta = "";
                string tablaOrigen = tablaOrigenSeleccionada.Trim().ToLower();

                if (tablaOrigen == "alumno")
                {
                    consulta = "DELETE FROM alumno WHERE matricula = @identi";
                }
                else if (tablaOrigen == "trabajador")
                {
                    consulta = "DELETE FROM trabajador WHERE num_trabajador = @identi";
                }

                MySqlCommand command = new MySqlCommand(consulta, con);
                command.Parameters.AddWithValue("@identi", matriculaSeleccionada);

                int filasAfectadas = command.ExecuteNonQuery();
                con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro eliminado exitosamente...");
                    cargaDatos();
                }
                else
                {
                    MessageBox.Show("Fallo al eliminar el registro...");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el registro : " + ex.Message);
            }

        }

        //Metodo para editar un registro
        private void EditarAlumno()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            try
            {
                int idcarrera = ObtenerIdCarrera(con,cmbArea.Text);
                string consulta = @"UPDATE alumno SET nombres = @nombres,apellido_paterno = @apellidoPaterno,apellido_materno = @apellidoMaterno,telefono = @telefono,correo = @correo,codigo_postal = @codigoPostal,calle = @calle,colonia = @colonia,numero_casa = @numeroCasa,grado = @grado,grupo = @grupo,id_carrera = @idcarrera
                    WHERE matricula = @matricula";

                MySqlCommand command = new MySqlCommand(consulta, con);

                command.Parameters.AddWithValue("@matricula", txtMatricula.Text.Trim());
                command.Parameters.AddWithValue("@nombres", txtNombre.Text.Trim());
                command.Parameters.AddWithValue("@apellidoPaterno", txtAPaterno.Text.Trim());
                command.Parameters.AddWithValue("@apellidoMaterno", txtAMaterno.Text.Trim());
                command.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                command.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                command.Parameters.AddWithValue("@codigoPostal", txtCP.Text.Trim());
                command.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
                command.Parameters.AddWithValue("@colonia", txtColonia.Text.Trim());
                command.Parameters.AddWithValue("@numeroCasa", txtNumcasa.Text.Trim());
                command.Parameters.AddWithValue("@grado", txtGrado.Text.Trim());
                command.Parameters.AddWithValue("@grupo", txtGrupo.Text.Trim());
                command.Parameters.AddWithValue("@idcarrera", idcarrera);

                int filasAfectadas = command.ExecuteNonQuery();
                con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Edicion Exitosa...");
                    cargaDatos();
                }
                else
                {
                    MessageBox.Show("Error al editar...");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al editar el registro : " + ex.Message);
            }
        }
        //Metodo para edotar un trabajador
        private void EditarTrabajador()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            try
            {
                int idarea = ObtenerIdArea(con, cmbArea.Text);
                int rol = ObtenerIdRol(con,cmbTipo.Text);

                string consulta = @"UPDATE trabajador SET nombres = @nombres, apellido_paterno = @apellidoPaterno,apellido_materno = @apellidoMaterno,telefono = @telefono,correo = @correo,codigo_postal = @codigoPostal,calle = @calle,colonia = @colonia,numero_casa = @numeroCasa,id_area = @idarea,id_rol = @idrol
                 WHERE num_trabajador = @numeroTrabajador";

                MySqlCommand command = new MySqlCommand(consulta, con);

                command.Parameters.AddWithValue("@numeroTrabajador", txtMatricula.Text.Trim());
                command.Parameters.AddWithValue("@nombres", txtNombre.Text.Trim());
                command.Parameters.AddWithValue("@apellidoPaterno", txtAPaterno.Text.Trim());
                command.Parameters.AddWithValue("@apellidoMaterno", txtAMaterno.Text.Trim());
                command.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                command.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                command.Parameters.AddWithValue("@codigoPostal", txtCP.Text.Trim());
                command.Parameters.AddWithValue("@calle", txtCalle.Text.Trim());
                command.Parameters.AddWithValue("@colonia", txtColonia.Text.Trim());
                command.Parameters.AddWithValue("@numeroCasa", txtNumcasa.Text.Trim());
                command.Parameters.AddWithValue("@idarea", idarea);
                command.Parameters.AddWithValue("@idrol", rol);

                int filasAfectadas = command.ExecuteNonQuery();
                con.Close();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Edicion Exitosa...");
                    cargaDatos();
                }
                else
                {
                    MessageBox.Show("Error al editar...");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al editar el registro : " + ex.Message);
            }
        }

        private void txtFiltroMatricula_TextChanged(object sender, EventArgs e)
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();
            if (con != null)
            {
                TextBox txt = (TextBox)sender;

                string consulta = @"
                SELECT *
                FROM vw_usuarios_catalogo
                WHERE Matricula LIKE @busqueda
                ORDER BY Matricula";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(consulta, con);

                adapter.SelectCommand.Parameters.AddWithValue(
                    "@busqueda",
                    "%" + txt.Text.Trim() + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvUsuarios.DataSource = dt;
            }
        }
    }
}