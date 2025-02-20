using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Autenticacion;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Administracion;
using RootKube.UI.Vistas.Comunes;
using RootKube.UI.Vistas.Stock;
using RootKube.UI.Vistas.Ventas;
using RootKube.UI.Vistas.Autenticacion; // 🔹 Importamos FrmLogin

namespace RootKube.UI
{
    public partial class FrmPrincipal : FrmBase
    {
        private Usuario _usuario;
        private int _idLocal;
        private int _idSesion; // 🔹 Guardamos el ID de la sesión activa
        private AuthService _authService;
        private bool menuExpandido = true;

        // 🔹 Ahora `FrmPrincipal` recibe `idSesion`
        public FrmPrincipal(Usuario usuario, int idLocal, int idSesion)
        {
            InitializeComponent();
            _authService = new AuthService();
            _usuario = usuario;
            _idLocal = idLocal;
            _idSesion = idSesion; // 🔹 Guardamos el ID de la sesión

            MostrarInformacion();
            ConfigurarNavbar();
        }

        private void MostrarInformacion()
        {
            lblUsuario.Text = $"Bienvenido: {_usuario.Nombre}";
            lblLocal.Text = $"Local: {ObtenerNombreLocal()}";
        }

        private string ObtenerNombreLocal()
        {
            using (var context = new RootKubeDbContext())
            {
                var local = context.Locales.FirstOrDefault(l => l.IdLocal == _idLocal);
                return local != null ? local.Nombre : "No asignado";
            }
        }

        private void ConfigurarNavbar()
        {
            pnlNavbar.Controls.Clear();

            Button btnToggle = new Button
            {
                Text = "☰",
                Width = 40,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.FromArgb(45, 45, 45),
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            btnToggle.Click += (s, e) => ToggleMenu();
            pnlNavbar.Controls.Add(btnToggle);

            switch (_usuario.Rol)
            {
                case "Administrador":
                    AgregarBotonNavbar("🏢 Gestión de Locales", () => AbrirFormulario(new FrmSeleccionarLocal()));
                    AgregarBotonNavbar("👥 Gestión de Usuarios", () => MessageBox.Show("Gestión de Usuarios en desarrollo"));
                    AgregarBotonNavbar("📦 Gestión de Stock", () => AbrirFormulario(new FrmStock(_usuario, _idLocal)));
                    AgregarBotonNavbar("🛒 Ventas", () => AbrirFormulario(new FrmVentas(_usuario, _idLocal)));
                    break;

                case "Gerente":
                    AgregarBotonNavbar("📦 Gestión de Stock", () => AbrirFormulario(new FrmStock(_usuario, _idLocal)));
                    AgregarBotonNavbar("🛒 Ventas", () => AbrirFormulario(new FrmVentas(_usuario, _idLocal)));
                    break;

                case "Empleado":
                    AgregarBotonNavbar("📦 Ver Stock", () => AbrirFormulario(new FrmStock(_usuario, _idLocal)));
                    AgregarBotonNavbar("🛒 Ventas", () => AbrirFormulario(new FrmVentas(_usuario, _idLocal)));
                    break;

                default:
                    MessageBox.Show("❌ Rol desconocido. Contacta al Administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }

            // 🔹 Agregar botón de Cerrar Sesión
            AgregarBotonNavbar("🚪 Cerrar Sesión", CerrarSesion);

            pnlNavbar.Refresh();
        }

        private void AgregarBotonNavbar(string texto, Action accion)
        {
            Button btn = new Button
            {
                Text = texto,
                Width = 200,
                Height = 50,
                FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.FromArgb(50, 50, 50),
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(10)
            };

            btn.MouseEnter += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(70, 70, 70);
            btn.MouseLeave += (s, e) => btn.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            btn.Click += (s, e) => accion.Invoke();

            pnlNavbar.Controls.Add(btn);
        }

        private void ToggleMenu()
        {
            menuExpandido = !menuExpandido;
            pnlNavbar.Width = menuExpandido ? 220 : 50;

            foreach (Control ctrl in pnlNavbar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Text = menuExpandido ? btn.Tag?.ToString() ?? btn.Text : "🔹";
                }
            }
        }

        private void AbrirFormulario(Form formulario)
        {
            pnlContenido.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Add(formulario);
            formulario.Show();
        }

        // 🔹 Método para Cerrar Sesión con ID de sesión validado
        private void CerrarSesion()
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas cerrar sesión?", "Cerrar Sesión",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // 🔹 Registrar el cierre de sesión SOLO de la sesión actual
                bool sesionCerrada = _authService.CerrarSesion(_usuario.IdUsuario, _idSesion);
                if (!sesionCerrada)
                {
                    MessageBox.Show("❌ No se pudo cerrar la sesión. Intenta de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Eliminar token del usuario
                using (var context = new RootKubeDbContext())
                {
                    var token = context.Tokens.FirstOrDefault(t => t.IdUsuario == _usuario.IdUsuario);
                    if (token != null)
                    {
                        context.Tokens.Remove(token);
                        context.SaveChanges();
                    }
                }

                // 🔹 Redirigir al Login
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
