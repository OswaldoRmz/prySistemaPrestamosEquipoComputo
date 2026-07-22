using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
namespace prySistemaPrestamosEquipoComputo.Clases
{
    public class clsLectorSemantico
    {
        private SpeechSynthesizer voz;

        public clsLectorSemantico()
        {
            try
            {
                voz = new SpeechSynthesizer();
                voz.Volume = 100;
                voz.Rate = 1;
            }catch (Exception ex)
            {
                voz = null;
            }
        }

        public void Leer(Control control)
        {
            if (voz == null || control == null) return;

            if (!string.IsNullOrEmpty(control.AccessibleName))
            {
                voz.SpeakAsyncCancelAll();

                string mensaje = control.AccessibleName;

                if (!string.IsNullOrEmpty(control.AccessibleDescription))
                {
                    mensaje += ".  " + control.AccessibleDescription;

                    voz.SpeakAsync(mensaje);
                }
            }
        }
    }
}
