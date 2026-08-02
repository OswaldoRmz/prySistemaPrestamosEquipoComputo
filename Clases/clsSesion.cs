using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prySistemaPrestamosEquipoComputo.Clases
{
    internal class clsSesion
    {
        public static string NumTrabajador { get; set; } = "";
        public static string NombreCompleto { get; set; } = "";
        public static string Rol { get; set; } = "";

        public static bool EsAdministrador
        {
            get
            {
                return Rol.Equals(
                    "Administrador",
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        public static void CerrarSesion()
        {
            NumTrabajador = "";
            NombreCompleto = "";
            Rol = "";
        }
    }
}
