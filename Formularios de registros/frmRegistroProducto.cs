using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using prySistemaPrestamosEquipoComputo.Clases;
namespace prySistemaPrestamosEquipoComputo
{
    public partial class frmRegistroProducto : Form
    {
        public frmRegistroProducto()
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

            //cuando cambia el texto de los campos
            txtNSerie.TextChanged += new EventHandler(Campos_TextChanged);
            txtNombre.TextChanged += new EventHandler(Campos_TextChanged);
            txtDescripcion.TextChanged += new EventHandler(Campos_TextChanged);
            txtColor.TextChanged += new EventHandler(Campos_TextChanged);
            txtMarca.TextChanged += new EventHandler(Campos_TextChanged);            
            nupCantidad.ValueChanged += new EventHandler(Campos_TextChanged);
            cmbCategoria.SelectedIndexChanged += new EventHandler(cmbCategoria_SelectedIndexChanged);

            //deshabilita botones al inicio
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;           

            //cambia el color de botones
            ActualizarColorBoton();
        }
        
        private clsConexion coneccion;
        // Se utilizarán después para editar y eliminar
        private int idEquipoSeleccionado = 0;
        private int idEjemplarSeleccionado = 0;
        //cargar datos
        private void CargarProductos()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            try
            {
                string consulta = @"
            SELECT
                e.id_equipo AS IDEquipo,
                e.numero_serie AS NumeroSerie,
                e.nombre AS Nombre,
                e.descripcion AS Descripcion,
                e.color AS Color,
                e.cantidad AS Cantidad,
                c.nombre AS Categoria,
                m.nombre AS Marca,
                IFNULL(ej.estado, 'Disponible') AS Estado,
                ej.id_ejemplar AS IDEjemplar
            FROM equipo e
            INNER JOIN categoria c
                ON e.id_categoria = c.id_categoria
            INNER JOIN marca m
                ON e.id_marca = m.id_marca
            LEFT JOIN ejemplar ej
                ON e.id_equipo = ej.id_equipo
            ORDER BY e.nombre";

                MySqlDataAdapter adaptador =
                    new MySqlDataAdapter(consulta, con);

                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                dgvProductos.DataSource = tabla;

                dgvProductos.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvProductos.MultiSelect = false;
                dgvProductos.ReadOnly = true;
                dgvProductos.AllowUserToAddRows = false;

                dgvProductos.Columns["IDEquipo"].Visible = false;
                dgvProductos.Columns["IDEjemplar"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los productos:\n" + ex.Message,
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
        //actualizar colores de botones
        private void ActualizarColorBoton()
        {
            bool camposLlenos =                
                txtNombre.Text != "" &&
                txtDescripcion.Text != "" &&
                txtColor.Text != "" &&
                cmbCategoria.Text != "" &&
                cmbEstado.Text != "" &&
                txtMarca.Text != "" &&
                nupCantidad.Value > 0;

            if (cmbCategoria.Text == "Equipo")
            {
                camposLlenos = camposLlenos && txtNSerie.Text != "" && cmbEstado.Text != "";
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
        //validar campos
        private bool ValidarCampos()
        {
            errorProvider1.Clear();

            if (cmbCategoria.Text == "")
            {
                errorProvider1.SetError(cmbCategoria,"Seleccione una categoría");

                cmbCategoria.Focus();
                return false;
            }

            // Solo los equipos requieren número de serie
            if (cmbCategoria.Text == "Equipo" && string.IsNullOrWhiteSpace(txtNSerie.Text))
            {
                errorProvider1.SetError(txtNSerie,"Número de serie requerido");

                txtNSerie.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre,"Nombre requerido");

                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider1.SetError(txtDescripcion,"Descripción requerida");

                txtDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                errorProvider1.SetError(txtColor,"Color requerido");

                txtColor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                errorProvider1.SetError(txtMarca,"Marca requerida");

                txtMarca.Focus();
                return false;
            }

            if (cmbCategoria.Text == "Equipo" && cmbEstado.Text == "")
            {
                errorProvider1.SetError(cmbEstado,"Seleccione un estado");

                cmbEstado.Focus();
                return false;
            }

            if (nupCantidad.Value <= 0)
            {
                errorProvider1.SetError(nupCantidad,"La cantidad debe ser mayor que cero");

                nupCantidad.Focus();
                return false;
            }

            return true;
        }
        //evento text changed
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            ActualizarColorBoton();
        }
        //obtner id categoria
        private int ObtenerIdCategoria(MySqlConnection con,MySqlTransaction transaccion,string nombreCategoria)
        {
            string consulta = @"SELECT id_categoria FROM categoria WHERE nombre = @nombre LIMIT 1";

            MySqlCommand comando = new MySqlCommand(consulta, con, transaccion);

            comando.Parameters.AddWithValue(
                "@nombre",
                nombreCategoria.Trim());

            object resultado = comando.ExecuteScalar();

            if (resultado == null || resultado == DBNull.Value)
            {
                return 0;
            }

            return Convert.ToInt32(resultado);
        }
        //agregar o seleccionar la marca
        private int ObtenerOCrearIdMarca(MySqlConnection con,MySqlTransaction transaccion,string nombreMarca)
        {
            string buscar = @"SELECT id_marca FROM marca WHERE nombre = @nombre LIMIT 1";

            MySqlCommand cmdBuscar = new MySqlCommand(buscar, con, transaccion);

            cmdBuscar.Parameters.AddWithValue("@nombre",nombreMarca.Trim());

            object resultado = cmdBuscar.ExecuteScalar();

            if (resultado != null && resultado != DBNull.Value)
            {
                return Convert.ToInt32(resultado);
            }

            string insertar = @"INSERT INTO marca (nombre) VALUES (@nombre)";

            MySqlCommand cmdInsertar =new MySqlCommand(insertar, con, transaccion);

            cmdInsertar.Parameters.AddWithValue("@nombre",nombreMarca.Trim());

            cmdInsertar.ExecuteNonQuery();

            return Convert.ToInt32(cmdInsertar.LastInsertedId);
        }
        //boton agregar un producto
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos todos los campos del formulario
            if (ValidarCampos() == false)
            {
                return;
            }
            AgregarProducto();
        }
        private void cmbCategoria_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cmbCategoria.Text == "Equipo")
            {
                txtNSerie.Enabled = true;
                txtNSerie.BackColor = Color.White;

                cmbEstado.Enabled = true;
                cmbEstado.BackColor = Color.White;

                nupCantidad.Value = 1;
                nupCantidad.Enabled = false;

                if (cmbEstado.Text == "")
                {
                    cmbEstado.Text = "Disponible";
                }
            }
            else if (cmbCategoria.Text == "Consumible")
            {
                txtNSerie.Clear();
                txtNSerie.Enabled = false;
                txtNSerie.BackColor = SystemColors.Control;

                cmbEstado.Text = "Disponible";
                cmbEstado.Enabled = false;
                cmbEstado.BackColor = SystemColors.Control;

                nupCantidad.Enabled = true;

                if (nupCantidad.Value <= 0)
                {
                    nupCantidad.Value = 1;
                }
            }

            ActualizarColorBoton();
        }
        //Limpiar campos
        private void LimpiarCampos()
        {
            txtNSerie.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtColor.Clear();
            txtMarca.Clear();

            cmbCategoria.Text = "";
            cmbEstado.Text = "";

            nupCantidad.Value = 1;

            txtNSerie.Enabled = true;
            cmbEstado.Enabled = true;
            nupCantidad.Enabled = true;

            idEquipoSeleccionado = 0;
            idEjemplarSeleccionado = 0;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            errorProvider1.Clear();
            ActualizarColorBoton();
        }
        //metodo para agregar prodcutos
        private void AgregarProducto()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            MySqlTransaction transaccion = null;

            try
            {               
                transaccion = con.BeginTransaction();

                int idCategoria = ObtenerIdCategoria(con,transaccion,cmbCategoria.Text);                
                int idMarca = ObtenerOCrearIdMarca(con,transaccion,txtMarca.Text);

                bool esEquipo = cmbCategoria.Text == "Equipo";

                string consulta = @"INSERT INTO equipo(nombre,descripcion,numero_serie,color,cantidad,id_marca,id_categoria)
                VALUES (@nombre,@descripcion,@numeroSerie,@color,@cantidad,@idMarca,@idCategoria)";

                MySqlCommand command = new MySqlCommand(consulta, con, transaccion);

                command.Parameters.AddWithValue("@nombre",txtNombre.Text.Trim());
                command.Parameters.AddWithValue("@descripcion",txtDescripcion.Text.Trim());
                if (esEquipo)
                {
                    command.Parameters.AddWithValue("@numeroSerie",txtNSerie.Text.Trim());
                }
                else
                {
                    command.Parameters.AddWithValue("@numeroSerie",DBNull.Value);
                }
                command.Parameters.AddWithValue("@color",txtColor.Text.Trim());
                command.Parameters.AddWithValue("@cantidad",esEquipo? 1: Convert.ToInt32(nupCantidad.Value));
                command.Parameters.AddWithValue("@idMarca",idMarca);
                command.Parameters.AddWithValue("@idCategoria",idCategoria);

                command.ExecuteNonQuery();

                int idEquipo = Convert.ToInt32(command.LastInsertedId);

                // Si es equipo, creamos también su ejemplar
                if (esEquipo)
                {
                    string insertarEjemplar = @"INSERT INTO ejemplar(num_inventario,estado,id_equipo)
                    VALUES (@numeroInventario,@estado,@idEquipo)";

                    MySqlCommand cmdEjemplar =new MySqlCommand(insertarEjemplar,con,transaccion);
                    
                    cmdEjemplar.Parameters.AddWithValue("@numeroInventario",txtNSerie.Text.Trim());
                    cmdEjemplar.Parameters.AddWithValue("@estado",cmbEstado.Text.Trim());
                    cmdEjemplar.Parameters.AddWithValue("@idEquipo",idEquipo);

                    cmdEjemplar.ExecuteNonQuery();
                }

                transaccion.Commit();
                con.Close();
                MessageBox.Show("Producto agregado correctamente.","Registro exitoso",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProductos();
            }           
            catch (Exception ex)
            {
                transaccion?.Rollback();
                MessageBox.Show("No se pudo agregar el producto:\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
        }
        //metodo para eliminar productos
        private void EliminarProducto()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            MySqlTransaction transaccion = null;
            try
            {
                
                transaccion = con.BeginTransaction();

                //eliminar el ejemplar
                string eliminarEjemplar = @"DELETE FROM ejemplar WHERE id_equipo = @idEquipo";

                MySqlCommand cmdEjemplar = new MySqlCommand(eliminarEjemplar,con,transaccion);

                cmdEjemplar.Parameters.AddWithValue("@idEquipo",idEquipoSeleccionado);

                cmdEjemplar.ExecuteNonQuery();

                //eliminamos el producto
                string eliminarEquipo = @"DELETE FROM equipo WHERE id_equipo = @idEquipo";

                MySqlCommand cmdEquipo = new MySqlCommand(eliminarEquipo,con,transaccion);

                cmdEquipo.Parameters.AddWithValue("@idEquipo",idEquipoSeleccionado);

                int filasAfectadas = cmdEquipo.ExecuteNonQuery();
                
                if (filasAfectadas == 0)
                {
                    throw new Exception("El producto ya no existe en la base de datos.");
                }

                transaccion.Commit();
                con.Close();
                MessageBox.Show("Producto eliminado correctamente.","Eliminación exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProductos();
                dgvProductos.ClearSelection();
            }            
            catch(MySqlException ex)
            {
                transaccion?.Rollback();
                MessageBox.Show("No se pudo eliminar el producto:\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }
        //cargar datos
        private void frmRegistroProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        //boton para elimar un producto
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //verificar que haya seleccionado un usuario
            if (idEquipoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirmacion
            DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar a " + txtNombre.Text + "?","Confirmar eliminación",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            //si
            if (respuesta == DialogResult.Yes)
            {
                EliminarProducto();
                LimpiarCampos();
                btnEditar.Enabled = false;                
            }
        }
        //al seleccionar algo del data griev view
        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataRowView fila = dgvProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;

            if (fila == null)
            {
                return;
            }

            idEquipoSeleccionado = Convert.ToInt32(fila["IDEquipo"]);

            // Los consumibles no tienen ejemplar
            if (fila["IDEjemplar"] == DBNull.Value)
            {
                idEjemplarSeleccionado = 0;
            }
            else
            {
                idEjemplarSeleccionado = Convert.ToInt32(fila["IDEjemplar"]);
            }

            // Primero asignamos la categoría porque activa
            // o desactiva número de serie, estado y cantidad
            cmbCategoria.Text = fila["Categoria"]?.ToString() ?? "";
            txtNSerie.Text = fila["NumeroSerie"]?.ToString() ?? "";
            txtNombre.Text = fila["Nombre"]?.ToString() ?? "";
            txtDescripcion.Text = fila["Descripcion"]?.ToString() ?? "";
            txtColor.Text = fila["Color"]?.ToString() ?? "";
            txtMarca.Text = fila["Marca"]?.ToString() ?? "";
            cmbEstado.Text = fila["Estado"]?.ToString() ?? "Disponible";
            
            if (fila["Cantidad"] != DBNull.Value)
            {
                nupCantidad.Value = Convert.ToDecimal(fila["Cantidad"]);
            }

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

            ActualizarColorBoton();
        }
        //boton cancelar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        //boton para editar datos
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //verifica el producto que se selecciono
            if (idEquipoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCampos() == false)
            {
                return;
            }
            EditarProducto();
            LimpiarCampos();
        }
        //metodo para editar productos
        private void EditarProducto()
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();

            MySqlTransaction transaccion = null;

            try
            {
                transaccion = con.BeginTransaction();

                int idCategoria = ObtenerIdCategoria(con, transaccion, cmbCategoria.Text);
                int idMarca = ObtenerOCrearIdMarca(con, transaccion, txtMarca.Text);

                bool esEquipo = cmbCategoria.Text == "Equipo";

                string consultaEquipo = @"UPDATE equipo SET nombre = @nombre, descripcion = @descripcion,numero_serie = @numeroSerie,color = @color,cantidad = @cantidad,id_marca = @idMarca,id_categoria = @idCategoria
                    WHERE id_equipo = @idEquipo";

                MySqlCommand cmdEquipo = new MySqlCommand(consultaEquipo, con, transaccion);

                cmdEquipo.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmdEquipo.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());
                if (esEquipo)
                {
                    cmdEquipo.Parameters.AddWithValue("@numeroSerie", txtNSerie.Text.Trim());
                }
                else
                {
                    cmdEquipo.Parameters.AddWithValue("@numeroSerie", DBNull.Value);
                }
                cmdEquipo.Parameters.AddWithValue("@color", txtColor.Text.Trim());
                cmdEquipo.Parameters.AddWithValue("@cantidad",esEquipo? 1: Convert.ToInt32(nupCantidad.Value));
                cmdEquipo.Parameters.AddWithValue("@idMarca",idMarca);
                cmdEquipo.Parameters.AddWithValue("@idCategoria",idCategoria);
                cmdEquipo.Parameters.AddWithValue("@idEquipo",idEquipoSeleccionado);

                int filasAfectadas = cmdEquipo.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new Exception("El producto no existe o no se realizaron cambios.");
                }
                    //si es equipo actualiza el ejemplar                
                if (esEquipo && idEjemplarSeleccionado > 0)
                {
                    string actualizarEjemplar = @"UPDATE ejemplar SET num_inventario = @numeroInventario,estado = @estado WHERE id_ejemplar = @idEjemplar";

                    MySqlCommand cmdEjemplar = new MySqlCommand(actualizarEjemplar,con,transaccion);

                    cmdEjemplar.Parameters.AddWithValue("@numeroInventario",txtNSerie.Text.Trim());
                    cmdEjemplar.Parameters.AddWithValue("@estado",cmbEstado.Text.Trim());
                    cmdEjemplar.Parameters.AddWithValue("@idEjemplar",idEjemplarSeleccionado);
                    cmdEjemplar.ExecuteNonQuery();
                }               

                transaccion.Commit();
                con.Close();
                MessageBox.Show("Producto editado correctamente.","Edición exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProductos();
                dgvProductos.ClearSelection();
            }        
            catch (MySqlException ex)
            {
                transaccion?.Rollback();

                MessageBox.Show("No se pudo editar el producto:\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }
        //busqueda por nombre de producto
        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();
            if (con != null)
            {
                TextBox txt = (TextBox)sender;

                string consulta = @"
                SELECT *
                FROM vw_productos_catalogo
                WHERE Nombre LIKE @busqueda
                ORDER BY Nombre";

                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, con);

                adapter.SelectCommand.Parameters.AddWithValue("@busqueda","%" + txt.Text.Trim() + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProductos.DataSource = dt;

                dgvProductos.Columns["IDEquipo"].Visible = false;
                dgvProductos.Columns["IDEjemplar"].Visible = false;
            }
        }

        private void pcbInicio_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal principal = new frmPantallaPrincipal();
            principal.WindowState = FormWindowState.Maximized;
            principal.Show();
            this.Hide();
        }

        private void pcbPrestamos_Click(object sender, EventArgs e)
        {
            frmVentanaPrestamos prestamo = new frmVentanaPrestamos();
            prestamo.Show();
            prestamo.WindowState = FormWindowState.Maximized;
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
