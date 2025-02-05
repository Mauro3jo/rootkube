using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Stock;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Stock
{
    public partial class FrmEditarProducto : FrmBase
    {
        private StockService _stockService;
        private int _idProducto;

        // 🔹 Evento para notificar cuando se actualiza un producto
        public event Action ProductoEditado;

        public FrmEditarProducto(int idProducto)
        {
            InitializeComponent();
            _stockService = new StockService();
            _idProducto = idProducto;
            CargarDatos();
        }

        private void CargarDatos()
        {
            var producto = _stockService.ObtenerProductos().FirstOrDefault(p => p.IdProducto == _idProducto);
            if (producto != null)
            {
                txtNombre.Text = producto.Nombre;
                txtUnidad.Text = producto.UnidadMedida;
                nudPrecio.Value = producto.Precio;
                cmbCategoria.DataSource = _stockService.ObtenerCategorias();
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "IdCategoria";
                cmbCategoria.SelectedValue = producto.IdCategoria;
            }
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

            bool resultado = _stockService.ModificarProducto(
                _idProducto,
                txtNombre.Text.Trim(),
                (int)cmbCategoria.SelectedValue,
                txtUnidad.Text.Trim(),
                nudPrecio.Value
            );

            if (resultado)
            {
                MessageBox.Show("✅ Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔹 Dispara el evento para actualizar FrmStock
                ProductoEditado?.Invoke();

                this.Close();
            }
            else
            {
                MessageBox.Show("❌ Error al actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
