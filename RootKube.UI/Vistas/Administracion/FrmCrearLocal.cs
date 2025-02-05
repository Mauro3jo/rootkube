using System;
using System.Windows.Forms;
using RootKube.BLL.Administracion;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Administracion
{
    public partial class FrmCrearLocal : FrmBase
    {
        private LocalesService _localesService;

        public FrmCrearLocal()
        {
            InitializeComponent();
            _localesService = new LocalesService();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre del local es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = _localesService.CrearLocal(nombre, direccion);
            if (resultado)
            {
                MessageBox.Show("Local creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al crear el local. Verifica los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
