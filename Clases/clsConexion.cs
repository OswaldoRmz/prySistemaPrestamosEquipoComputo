using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace prySistemaPrestamosEquipoComputo.Clases
{
    internal class clsConexion
    {
        private readonly string cadena;

        public clsConexion()
        {
            cadena = "Server=127.0.0.1; Database=bd_prestamos_pruebas; Uid=root; Pwd=; Port=3306";
        }

        public MySqlConnection getConection()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(cadena);
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de coneccion : " + ex.Message);
                return null;
            }
        }
    }
}
