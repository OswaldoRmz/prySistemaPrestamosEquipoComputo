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
    public partial class frmVentanaInventario : Form
    {
        public frmVentanaInventario()
        {
            InitializeComponent();

            // Agrega esta línea para activar el clic del botón Inicio
            this.pcbInicio.Click += new System.EventHandler(this.pcbInicio_Click);
        }

        private void frmVentanaInventario_Load(object sender, EventArgs e)
        {
            // Limpiamos filas antes de cargar por si acaso
            dgvInventario.Rows.Clear();

            // --- PROYECTORES Y AUDIO ---
            dgvInventario.Rows.Add("102", "Proyector Epson EB-S05", "EPSON-EB-805", "En Prestamo");
            dgvInventario.Rows.Add("95", "Proyector BenQ MX560", "PDN6J01234", "Disponible");
            dgvInventario.Rows.Add("303", "Bocina Portátil JBL Flip 6", "TL0123-JBL", "En Prestamo");
            dgvInventario.Rows.Add("304", "Micrófono Inalámbrico Shure BLX24", "SHURE-BLX-99", "Disponible");

            // --- CABLES Y ADAPTADORES ---
            dgvInventario.Rows.Add("501", "Cable HDMI v2.0 (10 metros)", "CAB-HDMI-10M-01", "Disponible");
            dgvInventario.Rows.Add("605", "Adaptador Mini DisplayPort a VGA", "ADAP-MDP-VGA-12", "Disponible");

            // --- EQUIPOS DE CÓMPUTO ---
            dgvInventario.Rows.Add("201", "Laptop HP ProBook 450 G9 i5", "5CD2341XYZ", "Disponible");
            dgvInventario.Rows.Add("202", "Laptop Dell Latitude 3420 i7", "CN-0F73MD-02", "En Prestamo");

            // --- ACCESORIOS DE ENERGÍA Y RED ---
            dgvInventario.Rows.Add("406", "Extensión Eléctrica Uso Rudo (5 metros)", "EXT-ELEC-05M-11", "En Prestamo");
            dgvInventario.Rows.Add("510", "Cable de Red Ethernet Cat6 (15 metros)", "CAB-NET-15M-09", "Disponible");
        }
        private void pcbInicio_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal inicio = new frmPantallaPrincipal();
            inicio.Show();
            this.Close(); // Cierra esta ventana para que no consuma memoria
        }
    }
    
}
