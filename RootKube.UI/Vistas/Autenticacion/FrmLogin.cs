using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Autenticacion;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Administracion;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Autenticacion
{
    public partial class FrmLogin : FrmBase
    {
        private AuthService _authService;
        private RootKubeDbContext _context;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
            _context = new RootKubeDbContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                lblMensaje.Text = "⚠️ Debes completar ambos campos.";
                lblMensaje.ForeColor = System.Drawing.Color.Orange;
                return;
            }

            // 🔹 Limpieza de tokens expirados antes de autenticar
            _authService.LimpiarTokensExpirados();

            // 🔹 Autenticar usuario y obtener el ID de sesión
            var (usuario, idSesion) = _authService.AutenticarUsuario(correo, contraseña);

            if (usuario == null)
            {
                lblMensaje.Text = "❌ Usuario o contraseña incorrectos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // 🔹 Mensaje de bienvenida
            MessageBox.Show($"✅ Bienvenido {usuario.Nombre} ({usuario.Rol})", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 🔹 Obtener el local asignado
            int? idLocal = ObtenerLocalAsignado(usuario);
            if (idLocal == null)
            {
                MessageBox.Show("❌ No tienes un local asignado. Contacta al Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 🔹 Redirigir a `FrmPrincipal`, ahora pasando `idSesion`
            FrmPrincipal frmPrincipal = new FrmPrincipal(usuario, idLocal.Value, idSesion);
            frmPrincipal.Show();
            this.Hide();
        }

        // 🔹 Método para obtener el local asignado
        private int? ObtenerLocalAsignado(Usuario usuario)
        {
            if (usuario.Rol == "Administrador")
            {
                FrmSeleccionarLocal frmSeleccionarLocal = new FrmSeleccionarLocal();
                frmSeleccionarLocal.ShowDialog();

                return frmSeleccionarLocal.IdLocalSeleccionado;
            }
            else
            {
                var usuarioLocal = _context.UsuarioLocales.FirstOrDefault(ul => ul.IdUsuario == usuario.IdUsuario);
                return usuarioLocal?.IdLocal;
            }
        }

        private void btnIrRegistro_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            frmRegistro.ShowDialog();
        }
    }
}
