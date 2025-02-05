using System;
using System.Windows.Forms;
using RootKube.BLL.Administracion;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Administracion
{
    public partial class FrmEditarLocal : FrmBase
    {
        private LocalesService _localesService;
        private int _idLocal;

        public FrmEditarLocal(int idLocal)
        {
            InitializeComponent();
            _localesService = new LocalesService();
            _idLocal = idLocal;
            CargarDatos();
        }

        private void CargarDatos()
        {
            var local = _localesService.ObtenerLocales().FirstOrDefault(l => l.IdLocal == _idLocal);
            if (local != null)
            {
                txtNombre.Text = local.Nombre;
                txtDireccion.Text = local.Direccion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado = _localesService.ModificarLocal(_idLocal, txtNombre.Text.Trim(), txtDireccion.Text.Trim());
            if (resultado)
            {
                MessageBox.Show("Local modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al modificar el local.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
