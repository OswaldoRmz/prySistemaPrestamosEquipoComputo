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

        public static bool TieneRol(params string[] roles)
        {
            foreach (string rol in roles)
            {
                if (Rol.Equals(
                    rol,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        public static void CerrarSesion()
        {
            NumTrabajador = "";
            NombreCompleto = "";
            Rol = "";
        }
    }
}
