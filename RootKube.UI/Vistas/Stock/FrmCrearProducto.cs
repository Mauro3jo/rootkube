using System;
using System.Windows.Forms;
using RootKube.BLL.Stock;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Stock
{
    public partial class FrmCrearProducto : FrmBase
    {
        private StockService _stockService;

        // 🔹 Evento para notificar cuando se agregue un producto nuevo
        public event Action ProductoAgregado;

        public FrmCrearProducto()
        {
            InitializeComponent();
            _stockService = new StockService();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            cmbCategoria.DataSource = _stockService.ObtenerCategorias();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "IdCategoria";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbCategoria.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtUnidad.Text) ||
                nudPrecio.Value <= 0)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = _stockService.CrearProducto(
                txtNombre.Text.Trim(),
                (int)cmbCategoria.SelectedValue,
                txtUnidad.Text.Trim(),
                nudPrecio.Value
            );

            if (resultado)
            {
                MessageBox.Show("✅ Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Llamamos al evento para notificar a `FrmStock`
                ProductoAgregado?.Invoke();

                this.Close(); // 🔹 Cerramos el formulario después de agregar el producto
            }
            else
            {
                MessageBox.Show("❌ Error: El producto ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
