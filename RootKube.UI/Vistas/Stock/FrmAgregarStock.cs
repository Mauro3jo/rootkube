using System;
using System.Windows.Forms;
using RootKube.BLL.Stock;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Stock
{
    public partial class FrmAgregarStock : FrmBase
    {
        private StockService _stockService;
        private int _idLocal;

        public FrmAgregarStock(int idLocal)
        {
            InitializeComponent();
            _stockService = new StockService();
            _idLocal = idLocal;
            CargarProductos();
        }

        private void CargarProductos()
        {
            cmbProducto.DataSource = _stockService.ObtenerProductos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null || nudCantidad.Value <= 0)
            {
                MessageBox.Show("Debe seleccionar un producto y una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = _stockService.AgregarStock(
                _idLocal,
                (int)cmbProducto.SelectedValue,
                nudCantidad.Value
            );

            if (resultado)
            {
                MessageBox.Show("✅ Stock agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ Error al agregar stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
