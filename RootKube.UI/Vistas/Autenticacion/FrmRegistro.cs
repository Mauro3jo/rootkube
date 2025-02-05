using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Autenticacion;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Autenticacion
{
    public partial class FrmRegistro : FrmBase
    {
        private AuthService _authService;
        private RootKubeDbContext _context;

        public FrmRegistro()
        {
            InitializeComponent();
            _authService = new AuthService();
            _context = new RootKubeDbContext();
            CargarLocales();
        }

        private void CargarLocales()
        {
            cmbLocal.DataSource = _context.Locales.ToList();
            cmbLocal.DisplayMember = "Nombre";
            cmbLocal.ValueMember = "IdLocal";
            cmbLocal.Enabled = false; // Inicialmente deshabilitado
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;
            string claveProducto = txtClaveProducto.Text;
            string rolSeleccionado = cmbRol.SelectedItem?.ToString();
            int? idLocal = cmbLocal.Enabled ? (int?)cmbLocal.SelectedValue : null;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(claveProducto))
            {
                lblMensaje.Text = "❌ Todos los campos son obligatorios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            bool registrado = _authService.RegistrarUsuario(nombre, correo, contraseña, claveProducto, rolSeleccionado, idLocal);

            if (registrado)
            {
                MessageBox.Show("✅ Usuario registrado correctamente. Ahora puedes iniciar sesión.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cierra FrmRegistro y vuelve a FrmLogin
            }
            else
            {
                lblMensaje.Text = "❌ Error en el registro. Verifica los datos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedItem.ToString() == "Administrador")
            {
                cmbLocal.Enabled = false; // Administradores no necesitan local
            }
            else
            {
                cmbLocal.Enabled = true; // Habilitar selección de local para Gerentes y Empleados
            }
        }
    }
}
