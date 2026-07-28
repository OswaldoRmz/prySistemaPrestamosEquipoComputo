using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
namespace prySistemaPrestamosEquipoComputo.Formularios_de_movientos
{
    public partial class frmReportes : Form
    {
        private int filaActualImpresion = 0;
        public frmReportes()
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
        private clsConexion coneccion;
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
        //cuando cargan el form
        private void frmReportes_Load(object sender, EventArgs e)
        {
            // Configuración del DataGridView
            dtgvReporteInventario.ReadOnly = true;
            dtgvReporteInventario.AllowUserToAddRows = false;
            dtgvReporteInventario.AllowUserToDeleteRows = false;
            dtgvReporteInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvReporteInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Selecciona "Todo" al abrir el formulario
            if (cmbFiltroEstado.Items.Count > 0)
            {
                cmbFiltroEstado.SelectedIndex = 0;
            }
        }
        //metodo para generar el data grievview reporte
        private void CargarInventario(string estado)
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();
            string consulta = @"
            SELECT
                ej.id_ejemplar AS ID,
                ej.num_inventario AS Inventario,
                eq.numero_serie AS Serie,
                eq.nombre AS Producto,
                c.nombre AS Categoria,
                m.nombre AS Marca,
                ej.estado AS Estado
            FROM ejemplar AS ej

            INNER JOIN equipo AS eq
                ON ej.id_equipo = eq.id_equipo

            INNER JOIN categoria AS c
                ON eq.id_categoria = c.id_categoria

            INNER JOIN marca AS m
                ON eq.id_marca = m.id_marca";

            // Cuando sea diferente de "Todo", aplica el filtro
            if (estado != "Todo")
            {
                consulta += " WHERE ej.estado = @estado";
            }

            consulta += " ORDER BY eq.nombre ASC";

            MySqlCommand command = new MySqlCommand(consulta, con);
            if (estado != "Todo")
            {
                command.Parameters.AddWithValue("@estado", estado);
            }

            MySqlDataAdapter adaptador = new MySqlDataAdapter(command);
            DataTable tablaInventario = new DataTable();

            adaptador.Fill(tablaInventario);

            dtgvReporteInventario.DataSource = tablaInventario;

        }
        //Cuando se seleccione algo en el combobox
        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarInventario(cmbFiltroEstado.Text);
        }

        private void pcbInicio_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal principal = new frmPantallaPrincipal();
            principal.Show();
            principal.WindowState = FormWindowState.Maximized;
            this.Hide();
        }
        //Evento click para generar un reporte de inventario
        private void btnReporteInventario_Click(object sender, EventArgs e)
        {
            if (dtgvReporteInventario.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos cargados en la tabla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            filaActualImpresion = 0;

            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

            pd.DefaultPageSettings.Landscape = true;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.WindowState = FormWindowState.Maximized;

            ppd.ShowDialog();
        }
        //Metodo para generar una vista previa del documento para impresión
        private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Times New Roman", 15, FontStyle.Bold);
            Font fuenteEncabezado = new Font("Times New Roman", 11, FontStyle.Bold);
            Font fuenteCuerpo = new Font("Times New Roman", 11, FontStyle.Regular);

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int altoFila = 28;

            int cantidadColumnas = dtgvReporteInventario.Columns.Count;
            int anchoColumna = e.MarginBounds.Width / cantidadColumnas;

            //Título
            e.Graphics.DrawString("REPORTE DE INVENTARIO", fuenteTitulo, Brushes.Black, x, y);
            y += 30;

            //Estado seleccionado
            e.Graphics.DrawString("Filtro: " + cmbFiltroEstado.Text, fuenteCuerpo, Brushes.Black, x, y);
            y += 20;

            //Fecha de impresión
            e.Graphics.DrawString("Fecha de impresión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteCuerpo, Brushes.Gray, x, y);
            y += 35;

            //Encabezados de columnas
            for (int i = 0; i < dtgvReporteInventario.Columns.Count; i++)
            {
                Rectangle rectangulo = new Rectangle(x + (i * anchoColumna), y, anchoColumna, altoFila);

                e.Graphics.FillRectangle(Brushes.LightGray, rectangulo);
                e.Graphics.DrawRectangle(Pens.Black, rectangulo);
                e.Graphics.DrawString(dtgvReporteInventario.Columns[i].HeaderText, fuenteEncabezado, Brushes.Black, rectangulo);
            }
            y += altoFila;

            //Imprimir las filas
            while (filaActualImpresion < dtgvReporteInventario.Rows.Count)
            {
                DataGridViewRow fila = dtgvReporteInventario.Rows[filaActualImpresion];

                if (fila.IsNewRow)
                {
                    filaActualImpresion++;
                    continue;
                }

                // Verifica si ya no hay espacio en la página
                if (y + altoFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                for (int i = 0; i < dtgvReporteInventario.Columns.Count; i++)
                {
                    string valor = fila.Cells[i].Value?.ToString() ?? "";

                    Rectangle rectangulo = new Rectangle(x + (i * anchoColumna), y, anchoColumna, altoFila);
                    e.Graphics.DrawRectangle(Pens.Black, rectangulo);

                    Rectangle rectanguloTexto = new Rectangle(rectangulo.X + 4, rectangulo.Y + 4, rectangulo.Width - 8, rectangulo.Height - 8);
                    e.Graphics.DrawString(valor, fuenteCuerpo, Brushes.Black, rectanguloTexto);
                }
                y += altoFila;
                filaActualImpresion++;
            }

            // Ya se imprimieron todos los registros
            e.HasMorePages = false;
            filaActualImpresion = 0;

            fuenteTitulo.Dispose();
            fuenteEncabezado.Dispose();
            fuenteCuerpo.Dispose();
        }

        private void CargarEquiposMasPrestados(string estado)
        {
            coneccion = new clsConexion();
            MySqlConnection con = coneccion.getConection();
            string consulta = @"
            SELECT
            e.nombre AS Equipo,
            COUNT(*) AS Total_Prestamos
            FROM prestamo p
            INNER JOIN detalle_prestamo dp
            ON p.id_prestamo = dp.id_prestamo
            INNER JOIN ejemplar ej
            ON dp.id_ejemplar = ej.id_ejemplar
            INNER JOIN equipo e
            ON ej.id_equipo = e.id_equipo
            GROUP BY e.nombre
            ORDER BY Total_Prestamos DESC";

            // Cuando sea diferente de "Todo", aplica el filtro
            if (estado != "Todo")
            {
                consulta += " WHERE ej.estado = @estado";
            }

            consulta += " ORDER BY eq.nombre ASC";

            MySqlCommand command = new MySqlCommand(consulta, con);
            if (estado != "Todo")
            {
                command.Parameters.AddWithValue("@estado", estado);
            }

            MySqlDataAdapter adaptador = new MySqlDataAdapter(command);
            DataTable tablaInventario = new DataTable();

            adaptador.Fill(tablaInventario);

            dtgvReporteInventario.DataSource = tablaInventario;

        }
    }
}