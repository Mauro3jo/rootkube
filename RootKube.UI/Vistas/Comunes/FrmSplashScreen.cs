using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace RootKube.UI.Vistas.Comunes
{
    public partial class FrmSplashScreen : Form
    {
        public FrmSplashScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = System.Drawing.Image.FromFile(@"imagenes\LogoRootKube.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true; // Siempre al frente
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await Task.Delay(3000); // Espera 3 segundos
            this.Close(); // Cierra el splash screen
        }
    }
}
