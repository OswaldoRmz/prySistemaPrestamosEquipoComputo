using MySql.Data.MySqlClient;
using prySistemaPrestamosEquipoComputo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySistemaPrestamosEquipoComputo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }            

        private void btnAcceso_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();                       
            //validamos el campo clave
            if (string.IsNullOrWhiteSpace(txtClaveAcceso.Text))
            {
                errorProvider1.SetError(txtClaveAcceso, "Campo vacio");
                txtClaveAcceso.Focus();
                return;
            }
            //vaidamos el campo contraseña            
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Campo vacio");
                txtPassword.Focus();
                return;
            }

            IniciarSesion();
        }
        //procedimiento para borrar las cajas de texto
        public void limpiarCajas()
        {            
            txtClaveAcceso.Clear();
            txtPassword.Clear();
        }
        //metodo para validar el incio de sesion
        private void IniciarSesion()
        {
            clsConexion conexion = new clsConexion();
            MySqlConnection con = conexion.getConection();
            try
            {                

                string consulta = @"SELECT t.num_trabajador,t.nombres,t.apellido_paterno,t.apellido_materno,t.contrasena,t.estado,r.tipo_rol FROM trabajador t
                    INNER JOIN rol r ON t.id_rol = r.id_rol WHERE t.num_trabajador = @claveTrabajador LIMIT 1";

                MySqlCommand comando = new MySqlCommand(consulta, con);

                comando.Parameters.AddWithValue("@claveTrabajador",txtClaveAcceso.Text.Trim());
                using (MySqlDataReader lector = comando.ExecuteReader())
                {
                    if (!lector.Read())
                    {
                        MessageBox.Show("Usuario, clave de acceso o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string estado = lector["estado"]?.ToString() ?? "";                    

                    string hashGuardado = lector["contrasena"]?.ToString() ?? "";

                    bool contrasenaCorrecta;

                    try
                    {
                        contrasenaCorrecta = BCrypt.Net.BCrypt.Verify(txtPassword.Text,hashGuardado);
                    }
                    catch
                    {
                        contrasenaCorrecta = false;
                    }

                    if (!contrasenaCorrecta)
                    {
                        MessageBox.Show("Usuario, clave de acceso o contraseña incorrectos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    clsSesion.NumTrabajador = lector["num_trabajador"]?.ToString() ?? "";

                    clsSesion.NombreCompleto = (lector["nombres"]?.ToString() + " " + lector["apellido_paterno"]?.ToString() + " " + lector["apellido_materno"]?.ToString()).Trim();

                    clsSesion.Rol = lector["tipo_rol"]?.ToString() ?? "";
                }
                con.Close();
                MessageBox.Show("Bienvenido " + clsSesion.NombreCompleto +"\nRol: " + clsSesion.Rol,"Inicio de sesión correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //Abrir la ventana de incio
                frmPantallaPrincipal principal = new frmPantallaPrincipal();

                principal.WindowState = FormWindowState.Maximized;
                principal.Show();

                this.Hide();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al iniciar sesión:\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }           
        }
    }
}
