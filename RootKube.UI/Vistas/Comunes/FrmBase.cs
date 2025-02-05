using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace RootKube.UI.Vistas.Comunes
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();

            // 🔹 Evita cargar el ícono si estamos en el Designer
            if (!IsInDesignMode())
            {
                CargarIcono();
            }
        }

        private void CargarIcono()
        {
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagenes", "IcoRootKube.ico");

            // 🔹 Carga el ícono solo si el archivo existe
            if (File.Exists(iconPath))
            {
                this.Icon = new System.Drawing.Icon(iconPath);
            }
        }

        // 🔹 Método para detectar el modo diseño de manera confiable
        private bool IsInDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime) ||
                   (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
        }
    }
}
