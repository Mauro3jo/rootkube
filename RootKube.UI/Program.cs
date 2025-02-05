using System;
using System.Windows.Forms;
using RootKube.UI.Vistas.Autenticacion;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmSplashScreen splash = new FrmSplashScreen())
            {
                splash.ShowDialog(); // Mostrar pantalla de carga
            }

            Application.Run(new FrmLogin()); // ✅ Ahora inicia después del Splash
        }
    }
}
