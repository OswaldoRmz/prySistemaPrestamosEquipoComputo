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
    public partial class frmVentanaPrestamos : Form
    {
        private clsConexion conexion;
        private string identificadorSolicitante = "";
        private string tablaSolicitante = "";
        private string tipoSolicitante = "";
        private string tipoProductoSeleccionado = "";
        private int idEquipoSeleccionado = 0;
        private int idEjemplarSeleccionado = 0;
        private int existenciasDisponibles = 0;
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

            //cargar datos del usuario a las cajas
            string consulta = @"
            SELECT
                Matricula,
                Nombre,
                ApellidoPaterno,
                ApellidoMaterno,
                Telefono,
                Correo,
                Tipo,
                TablaOrigen
            FROM vw_usuarios_catalogo
            WHERE Matricula = @identificador
            LIMIT 1";


            conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            MySqlCommand cmd = new MySqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@identificador", txtMatricula.Text);

            MySqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                identificadorSolicitante = lector["Matricula"].ToString();

                tablaSolicitante = lector["TablaOrigen"].ToString();
                tipoSolicitante = lector["Tipo"].ToString();
                txtNombre.Text = lector["Nombre"].ToString();
                txtAPaterno.Text = lector["ApellidoPaterno"].ToString();
                txtAMaterno.Text = lector["ApellidoMaterno"].ToString();
                txtTelefono.Text = lector["Telefono"].ToString();
                txtCorreo.Text = lector["Correo"].ToString();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.");
                identificadorSolicitante = "";
                tablaSolicitante = "";
                tipoSolicitante = "";
                txtNombre.Clear();
                txtAPaterno.Clear();
                txtAMaterno.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
            }

            lector.Close();
            con.Close();
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
            //validamos el campo nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Llene el campo\nAntes de aceptar ");
                txtNombre.Focus();
                return;
            }
            //validamos el campo apelldio paterno
            if (string.IsNullOrWhiteSpace(txtAPaterno.Text))
            {
                errorProvider1.SetError(txtAPaterno, "Llene el campo\nAntes de aceptar ");
                txtAPaterno.Focus();
                return;
            }
            //validamos el campo apellido materno
            if (string.IsNullOrWhiteSpace(txtAMaterno.Text))
            {
                errorProvider1.SetError(txtAMaterno, "Llene el campo\nAntes de aceptar ");
                txtAMaterno.Focus();
                return;
            }
            //validamos el campo telefono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                errorProvider1.SetError(txtTelefono, "Llene el campo\nAntes de aceptar ");
                txtTelefono.Focus();
                return;
            }
            //validamos el campo correo
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                errorProvider1.SetError(txtCorreo, "Llene el campo\nAntes de aceptar ");
                txtCorreo.Focus();
                return;
            }
            //validamos el campo dispositivo
            if (string.IsNullOrWhiteSpace(cmbDispositivo.Text))
            {
                errorProvider1.SetError(cmbDispositivo, "Llene el campo\nAntes de aceptar ");
                cmbDispositivo.Focus();
                return;
            }
            //validamos el campo garantia
            if (string.IsNullOrWhiteSpace(txtGarantia.Text))
            {
                errorProvider1.SetError(txtGarantia, "Llene el campo\nAntes de aceptar ");
                txtGarantia.Focus();
                return;
            }
            //validamos el campo prestamo
            if (string.IsNullOrWhiteSpace(dtmPrestamo.Text))
            {
                errorProvider1.SetError(dtmPrestamo, "Llene el campo\nAntes de aceptar ");
                dtmPrestamo.Focus();
                return;
            }
            //validamos el campo devolucion
            if (string.IsNullOrWhiteSpace(dtmDevolucion.Text))
            {
                errorProvider1.SetError(dtmDevolucion, "Llene el campo\nAntes de aceptar ");
                dtmDevolucion.Focus();
                return;
            }

            if (tipoProductoSeleccionado == "Consumible" &&
    nupCantidadPrestamo.Value >
    existenciasDisponibles)
            {
                errorProvider1.SetError(
                    nupCantidadPrestamo,
                    "No existen suficientes unidades");

                nupCantidadPrestamo.Focus();
                return;
            }

            if (dtmDevolucion.Value.Date <
                dtmPrestamo.Value.Date)
            {
                errorProvider1.SetError(
                    dtmDevolucion,
                    "La fecha de devolución no puede ser anterior");

                return;
            }

            RegistrarPrestamo();
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

        private void frmVentanaPrestamos_Load(object sender, EventArgs e)
        {
            // Datos encontrados del solicitante
            txtNombre.ReadOnly = true;
            txtAPaterno.ReadOnly = true;
            txtAMaterno.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCorreo.ReadOnly = true;

            //Fechas iniciales
            dtmPrestamo.Value = DateTime.Today;
            dtmDevolucion.Value = DateTime.Today.AddDays(7);

            dtmPrestamo.MinDate = DateTime.Today;
            dtmDevolucion.MinDate = DateTime.Today;

            //Permitir buscar dentro del ComboBox
            cmbDispositivo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargar únicamente equipos disponibles
            CargarProductosDisponibles();
        }

        private void CargarProductosDisponibles()
        {
            clsConexion conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            try
            {
                string consulta = @"
            SELECT
                'Equipo' AS Tipo,
                ej.id_ejemplar AS IDEjemplar,
                e.id_equipo AS IDEquipo,
                e.numero_serie AS NumeroSerie,
                e.nombre AS NombreProducto,
                1 AS Existencias,
                CONCAT(
                    '[Equipo] ',
                    e.numero_serie,
                    ' - ',
                    e.nombre
                ) AS Dispositivo
            FROM ejemplar ej
            INNER JOIN equipo e
                ON ej.id_equipo = e.id_equipo
            INNER JOIN categoria c
                ON e.id_categoria = c.id_categoria
            WHERE ej.estado = 'Disponible'
              AND c.nombre = 'Equipo'
              AND e.numero_serie IS NOT NULL
              AND e.numero_serie <> ''

            UNION ALL

            SELECT
                'Consumible' AS Tipo,
                NULL AS IDEjemplar,
                e.id_equipo AS IDEquipo,
                e.numero_serie AS NumeroSerie,
                e.nombre AS NombreProducto,
                e.cantidad AS Existencias,
                CONCAT(
                    '[Consumible] ',
                    e.nombre,
                    ' - Existencias: ',
                    e.cantidad
                ) AS Dispositivo
            FROM equipo e
            INNER JOIN categoria c
                ON e.id_categoria = c.id_categoria
            WHERE c.nombre = 'Consumible'
              AND e.cantidad > 0

            ORDER BY Tipo, NombreProducto";

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(consulta, con);

                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                cmbDispositivo.DataSource = null;

                // Lo que verá el usuario
                cmbDispositivo.DisplayMember = "Dispositivo";

                // No utilizaremos ValueMember porque necesitamos
                // leer varios datos de la fila seleccionada
                cmbDispositivo.DataSource = tabla;

                cmbDispositivo.SelectedIndex = -1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Error al cargar los productos disponibles:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null &&
                    con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void cmbDispositivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbDispositivo.SelectedItem is DataRowView fila))
            {
                tipoProductoSeleccionado = "";
                idEquipoSeleccionado = 0;
                idEjemplarSeleccionado = 0;
                existenciasDisponibles = 0;

                nupCantidadPrestamo.Value = 1;
                nupCantidadPrestamo.Enabled = false;
                return;
            }

            tipoProductoSeleccionado =
                fila["Tipo"].ToString();

            idEquipoSeleccionado =
                Convert.ToInt32(fila["IDEquipo"]);

            existenciasDisponibles =
                Convert.ToInt32(fila["Existencias"]);

            if (fila["IDEjemplar"] == DBNull.Value)
            {
                idEjemplarSeleccionado = 0;
            }
            else
            {
                idEjemplarSeleccionado =
                    Convert.ToInt32(fila["IDEjemplar"]);
            }

            if (tipoProductoSeleccionado == "Equipo")
            {
                // Cada ejemplar se presta individualmente
                nupCantidadPrestamo.Enabled = false;
                nupCantidadPrestamo.Minimum = 1;
                nupCantidadPrestamo.Maximum = 1;
                nupCantidadPrestamo.Value = 1;
            }
            else if (tipoProductoSeleccionado == "Consumible")
            {
                // Permitir seleccionar unidades
                nupCantidadPrestamo.Enabled = true;
                nupCantidadPrestamo.Minimum = 1;
                nupCantidadPrestamo.Maximum =
                    existenciasDisponibles;

                nupCantidadPrestamo.Value = 1;
            }


        }
        private void RegistrarPrestamo()
        {
            clsConexion conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            MySqlTransaction transaccion = null;

            try
            {
                if (con == null)
                {
                    throw new Exception(
                        "No se pudo conectar con la base de datos.");
                }

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                transaccion = con.BeginTransaction();


                //=========================================
                // 1. INSERTAR CABECERA DEL PRESTAMO
                //=========================================

                string insertarPrestamo = @"
        INSERT INTO prestamo
        (
            garantia,
            fecha_prestamo,
            fecha_devolucion_programada,
            fecha_devolucion_real,
            estado,
            observaciones,
            matricula,
            num_trabajador_solicitante,
            num_trabajador
        )
        VALUES
        (
            @garantia,
            @fechaPrestamo,
            @fechaDevolucion,
            NULL,
            'Activo',
            NULL,
            @matricula,
            @trabajadorSolicitante,
            @trabajadorRegistra
        )";


                long idPrestamo;


                using (MySqlCommand cmdPrestamo =
                       new MySqlCommand(
                           insertarPrestamo,
                           con,
                           transaccion))
                {

                    cmdPrestamo.Parameters.AddWithValue(
                        "@garantia",
                        txtGarantia.Text.Trim());


                    cmdPrestamo.Parameters.AddWithValue(
                        "@fechaPrestamo",
                        dtmPrestamo.Value.Date);


                    cmdPrestamo.Parameters.AddWithValue(
                        "@fechaDevolucion",
                        dtmDevolucion.Value.Date);


                    cmdPrestamo.Parameters.AddWithValue(
                        "@matricula",
                        tablaSolicitante == "Alumno"
                        ? (object)identificadorSolicitante
                        : DBNull.Value);


                    cmdPrestamo.Parameters.AddWithValue(
                        "@trabajadorSolicitante",
                        tablaSolicitante == "Trabajador"
                        ? (object)identificadorSolicitante
                        : DBNull.Value);


                    cmdPrestamo.Parameters.AddWithValue(
                        "@trabajadorRegistra",
                        clsSesion.NumTrabajador);


                    cmdPrestamo.ExecuteNonQuery();


                    idPrestamo =
                        cmdPrestamo.LastInsertedId;
                }



                int cantidadPrestada = 1;



                //=========================================
                // 2. ACTUALIZAR INVENTARIO
                //=========================================


                if (tipoProductoSeleccionado == "Equipo")
                {

                    cantidadPrestada = 1;


                    string actualizarEquipo = @"
            UPDATE ejemplar
            SET estado='Prestado'
            WHERE id_ejemplar=@idEjemplar
            AND estado='Disponible'";


                    using (MySqlCommand cmdEquipo =
                           new MySqlCommand(
                               actualizarEquipo,
                               con,
                               transaccion))
                    {

                        cmdEquipo.Parameters.AddWithValue(
                            "@idEjemplar",
                            idEjemplarSeleccionado);


                        int filas =
                            cmdEquipo.ExecuteNonQuery();


                        if (filas == 0)
                        {
                            throw new Exception(
                                "El equipo ya no está disponible.");
                        }
                    }
                }


                else if (tipoProductoSeleccionado == "Consumible")
                {

                    cantidadPrestada =
                        Convert.ToInt32(
                            nupCantidadPrestamo.Value);



                    string actualizarConsumible = @"
            UPDATE equipo
            SET cantidad = cantidad - @cantidad
            WHERE id_equipo=@idEquipo
            AND cantidad >= @cantidad";



                    using (MySqlCommand cmdConsumible =
                           new MySqlCommand(
                               actualizarConsumible,
                               con,
                               transaccion))
                    {


                        cmdConsumible.Parameters.AddWithValue(
                            "@cantidad",
                            cantidadPrestada);


                        cmdConsumible.Parameters.AddWithValue(
                            "@idEquipo",
                            idEquipoSeleccionado);



                        int filas =
                            cmdConsumible.ExecuteNonQuery();



                        if (filas == 0)
                        {
                            throw new Exception(
                                "No hay suficientes existencias.");
                        }
                    }
                }


                else
                {
                    throw new Exception(
                        "No se pudo identificar el producto.");
                }





                //=========================================
                // 3. INSERTAR DETALLE DEL PRESTAMO
                //=========================================


                string insertarDetalle = @"
        INSERT INTO detalle_prestamo
        (
            cantidad,
            estado,
            fecha_devolucion,
            id_ejemplar,
            id_equipo,
            id_prestamo
        )
        VALUES
        (
            @cantidad,
            'Prestado',
            NULL,
            @idEjemplar,
            @idEquipo,
            @idPrestamo
        )";



                using (MySqlCommand cmdDetalle =
                       new MySqlCommand(
                           insertarDetalle,
                           con,
                           transaccion))
                {


                    cmdDetalle.Parameters.AddWithValue(
                        "@cantidad",
                        cantidadPrestada);



                    //============================
                    // EQUIPO
                    //============================

                    if (tipoProductoSeleccionado == "Equipo")
                    {

                        cmdDetalle.Parameters.AddWithValue(
                            "@idEjemplar",
                            idEjemplarSeleccionado);


                        cmdDetalle.Parameters.AddWithValue(
                            "@idEquipo",
                            idEquipoSeleccionado);

                    }


                    //============================
                    // CONSUMIBLE
                    //============================

                    else
                    {

                        cmdDetalle.Parameters.AddWithValue(
                            "@idEjemplar",
                            DBNull.Value);


                        cmdDetalle.Parameters.AddWithValue(
                            "@idEquipo",
                            idEquipoSeleccionado);

                    }



                    cmdDetalle.Parameters.AddWithValue(
                        "@idPrestamo",
                        idPrestamo);



                    cmdDetalle.ExecuteNonQuery();

                }



                // Confirmar cambios

                transaccion.Commit();



                MessageBox.Show(
                    "Préstamo registrado correctamente.\n\n" +
                    "Producto: " + cmbDispositivo.Text +
                    "\nCantidad: " + cantidadPrestada,
                    "Préstamo exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);



                // Actualizar lista

                CargarProductosDisponibles();



                // Limpiar datos del producto seleccionado

                cmbDispositivo.SelectedIndex = -1;

                nupCantidadPrestamo.Value = 1;


                tipoProductoSeleccionado = "";

                idEquipoSeleccionado = 0;

                idEjemplarSeleccionado = 0;

                existenciasDisponibles = 0;

            }


            catch (Exception ex)
            {

                try
                {
                    transaccion?.Rollback();
                }
                catch
                {

                }


                MessageBox.Show(
                    "No se pudo registrar el préstamo:\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }


            finally
            {

                if (con != null &&
                    con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
        }
    }
}
