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
    public partial class frmVentanaDevoluciones : Form
    {
        clsConexion conexion;
        int idDetallePrestamoSeleccionado = 0;
        int idPrestamoSeleccionado = 0;
        int idEjemplarSeleccionado = 0;
        int idEquipoSeleccionado = 0;
        int cantidadSeleccionada = 0;
        public frmVentanaDevoluciones()
        {
            InitializeComponent();
            //Llamar el metodo para cargar los prestamos
            //CargarPrestamos();
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

        private void CargarEquiposPrestados()
        {
            conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            try
            {
                string consulta = @"
        SELECT
            dp.id_detalle_prestamo,
            p.id_prestamo,
            ej.id_ejemplar,
            e.id_equipo,
            CONCAT(a.nombres,' ',a.apellido_paterno,' ',a.apellido_materno) AS Alumno,
            CONCAT(t.nombres,' ',t.apellido_paterno,' ',t.apellido_materno) AS Trabajador,
            e.nombre AS Equipo,
            ej.num_inventario AS Serie,
            dp.cantidad,
            p.fecha_prestamo,
            p.fecha_devolucion_programada,
            dp.estado

        FROM detalle_prestamo dp

        INNER JOIN prestamo p
            ON dp.id_prestamo = p.id_prestamo

        INNER JOIN ejemplar ej
            ON dp.id_ejemplar = ej.id_ejemplar

        INNER JOIN equipo e
            ON ej.id_equipo = e.id_equipo

        LEFT JOIN alumno a
            ON p.matricula = a.matricula

        LEFT JOIN trabajador t
            ON p.num_trabajador_solicitante = t.num_trabajador

        INNER JOIN categoria c
            ON e.id_categoria = c.id_categoria

        WHERE dp.estado='Prestado'
        AND c.nombre='Equipo'
        ORDER BY p.fecha_prestamo DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dvgDevoluciones.DataSource = dt;

                dvgDevoluciones.Columns["id_detalle_prestamo"].Visible = false;
                dvgDevoluciones.Columns["id_prestamo"].Visible = false;
                dvgDevoluciones.Columns["id_ejemplar"].Visible = false;
                dvgDevoluciones.Columns["id_equipo"].Visible = false;

                if (!dvgDevoluciones.Columns.Contains("Accion"))
                {
                    DataGridViewButtonColumn boton = new DataGridViewButtonColumn();

                    boton.Name = "Accion";
                    boton.HeaderText = "Acción";
                    boton.Text = "Devolver";
                    boton.UseColumnTextForButtonValue = true;

                    dvgDevoluciones.Columns.Add(boton);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar equipos.\n\n" + ex.Message);
            }
        }
        private void CargarConsumiblesPrestados()
        {
            conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            try
            {
                string consulta = @"
        SELECT
            dp.id_detalle_prestamo,
            p.id_prestamo,
            e.id_equipo,
            CONCAT(a.nombres,' ',a.apellido_paterno,' ',a.apellido_materno) AS Alumno,
            CONCAT(t.nombres,' ',t.apellido_paterno,' ',t.apellido_materno) AS Trabajador,
            e.nombre AS Consumible,
            dp.cantidad,
            p.fecha_prestamo,
            p.fecha_devolucion_programada,
            dp.estado

        FROM detalle_prestamo dp

        INNER JOIN prestamo p
            ON dp.id_prestamo = p.id_prestamo

        INNER JOIN equipo e
            ON dp.id_equipo = e.id_equipo

        INNER JOIN categoria c
            ON e.id_categoria = c.id_categoria

        LEFT JOIN alumno a
            ON p.matricula = a.matricula

        LEFT JOIN trabajador t
            ON p.num_trabajador_solicitante = t.num_trabajador

        WHERE dp.estado='Prestado'
        AND c.nombre='Consumible'

        ORDER BY p.fecha_prestamo DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(consulta, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dvgDevoluciones.DataSource = dt;

                dvgDevoluciones.Columns["id_detalle_prestamo"].Visible = false;
                dvgDevoluciones.Columns["id_prestamo"].Visible = false;
                dvgDevoluciones.Columns["id_equipo"].Visible = false;

                if (!dvgDevoluciones.Columns.Contains("Accion"))
                {
                    DataGridViewButtonColumn boton = new DataGridViewButtonColumn();

                    boton.Name = "Accion";
                    boton.HeaderText = "Acción";
                    boton.Text = "Devolver";
                    boton.UseColumnTextForButtonValue = true;

                    dvgDevoluciones.Columns.Add(boton);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar consumibles.\n\n" + ex.Message);
            }
        }
        private void dvgDevoluciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dvgDevoluciones.Columns[e.ColumnIndex].Name != "Accion")
                return;

            if (cmbEstado.Text == "Equipo")
            {
                idDetallePrestamoSeleccionado =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["id_detalle_prestamo"].Value);

                idPrestamoSeleccionado =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["id_prestamo"].Value);

                idEjemplarSeleccionado =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["id_ejemplar"].Value);

                DevolverEquipo();
            }
            else
            {
                idDetallePrestamoSeleccionado =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["id_detalle_prestamo"].Value);

                idPrestamoSeleccionado =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["id_prestamo"].Value);

                idEquipoSeleccionado =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["id_equipo"].Value);

                cantidadSeleccionada =
                Convert.ToInt32(dvgDevoluciones.Rows[e.RowIndex].Cells["cantidad"].Value);

                DevolverConsumible();
            }
        }
        private void DevolverEquipo()
        {
            conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            try
            {
               

                string consulta = @"
        UPDATE detalle_prestamo 
        SET estado='Devuelto'
        WHERE id_detalle_prestamo=@idDetalle;

        UPDATE ejemplar
        SET estado='Disponible'
        WHERE id_ejemplar=@idEjemplar;
        ";

                MySqlCommand cmd = new MySqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@idDetalle", idDetallePrestamoSeleccionado);
                cmd.Parameters.AddWithValue("@idEjemplar", idEjemplarSeleccionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Equipo devuelto correctamente",
                    "Devolución",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                CargarEquiposPrestados();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al devolver equipo: \n" + ex.Message);
            }
        }
        private void DevolverConsumible()
        {
            conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();

            try
            {


                string consulta = @"
        UPDATE detalle_prestamo
        SET estado='Devuelto',
            fecha_devolucion=CURDATE()
        WHERE id_detalle_prestamo=@idDetalle;

        UPDATE equipo
        SET cantidad = cantidad + 
        (SELECT cantidad FROM detalle_prestamo 
         WHERE id_detalle_prestamo=@idDetalle)
        WHERE id_equipo=@idEquipo;
        ";


                MySqlCommand cmd = new MySqlCommand(consulta, con);


                cmd.Parameters.AddWithValue("@idDetalle",
                    idDetallePrestamoSeleccionado);

                cmd.Parameters.AddWithValue("@cantidad",
                    cantidadSeleccionada);

                cmd.Parameters.AddWithValue("@idEquipo",
                    idEquipoSeleccionado);


                cmd.ExecuteNonQuery();


                MessageBox.Show("Consumible devuelto correctamente",
                    "Devolución",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                CargarConsumiblesPrestados();


                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al devolver consumible:\n" + ex.Message);
            }
        }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.Text == "Equipo")
            {
                CargarEquiposPrestados();
            }
            else
            {
                CargarConsumiblesPrestados();
            }
        }
    }
}
