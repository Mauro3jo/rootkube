using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Autenticacion;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Administracion;
using RootKube.UI.Vistas.Comunes; // 🔹 Asegurar el `using` correcto

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
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;

            // 🔹 Ahora obtenemos el usuario completo
            Usuario usuario = _authService.AutenticarUsuario(correo, contraseña);

            if (usuario == null)
            {
                lblMensaje.Text = "❌ Usuario o contraseña incorrectos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            MessageBox.Show($"✅ Inicio de sesión exitoso como {usuario.Rol}", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int idLocal;

            if (usuario.Rol == "Administrador")
            {
                FrmSeleccionarLocal frmSeleccionarLocal = new FrmSeleccionarLocal();
                frmSeleccionarLocal.ShowDialog();

                if (frmSeleccionarLocal.IdLocalSeleccionado == null)
                {
                    MessageBox.Show("Debes seleccionar un local para continuar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                idLocal = frmSeleccionarLocal.IdLocalSeleccionado.Value;
            }
            else
            {
                var usuarioLocal = _context.UsuarioLocales.FirstOrDefault(ul => ul.IdUsuario == usuario.IdUsuario);
                if (usuarioLocal == null)
                {
                    MessageBox.Show("❌ No tienes un local asignado. Contacta al Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                idLocal = usuarioLocal.IdLocal;
            }

            FrmPrincipal frmPrincipal = new FrmPrincipal(usuario, idLocal);
            frmPrincipal.Show();
            this.Hide();
        }


        private void btnIrRegistro_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            frmRegistro.ShowDialog(); // 🔹 Abrimos el formulario de registro
        }

    }
}
