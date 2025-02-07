using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Ventas;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Comunes;
using RootKube.UI.Vistas.Stock;

namespace RootKube.UI.Vistas.Ventas
{
    public partial class FrmVentas : FrmBase
    {
        private VentasService _ventasService;
        private Usuario _usuario;
        private int _idLocal;
        private List<DetalleVentum> _detalleVenta;

        public FrmVentas(Usuario usuario, int idLocal)
        {
            InitializeComponent();
            _ventasService = new VentasService(new RootKubeDbContext());
            _usuario = usuario;
            _idLocal = idLocal;
            _detalleVenta = new List<DetalleVentum>();

            ConfigurarInterfaz();

            this.TopLevel = false; // 🔹 Evita que sea una ventana independiente
            this.FormBorderStyle = FormBorderStyle.None; // 🔹 Quita bordes
            this.Dock = DockStyle.Fill; // 🔹 Se ajusta automáticamente al panel
        }

        private void ConfigurarInterfaz()
        {
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta");
            cmbMetodoPago.Items.Add("Transferencia");
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProducto frm = new FrmSeleccionarProducto(_idLocal);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Producto producto = frm.ProductoSeleccionado;
                decimal cantidad = frm.CantidadSeleccionada;

                DetalleVentum detalle = new DetalleVentum
                {
                    IdProducto = producto.IdProducto, // Solo guardamos la clave foránea
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio,
                    Subtotal = cantidad * producto.Precio
                };

                _detalleVenta.Add(detalle);
                CargarCarrito();
            }
        }




        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count > 0)
            {
                int indice = dgvCarrito.SelectedRows[0].Index;
                _detalleVenta.RemoveAt(indice);
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            dgvCarrito.Rows.Clear(); // Limpia las filas existentes
            decimal total = 0;

            foreach (var item in _detalleVenta)
            {
                // Verificar que `IdProductoNavigation` no sea nulo
                string nombreProducto = item.IdProductoNavigation?.Nombre ?? "Producto Desconocido";

                dgvCarrito.Rows.Add(item.IdProducto, nombreProducto, item.Cantidad, item.PrecioUnitario, item.Subtotal);
                total += item.Subtotal;
            }

            lblTotal.Text = $"Total: {total:C}";
        }


        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (_detalleVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar productos a la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ventaRegistrada = _ventasService.RegistrarVenta(_usuario.IdUsuario, _idLocal, cmbMetodoPago.SelectedItem.ToString(), _detalleVenta);

            if (ventaRegistrada)
            {
                MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _detalleVenta.Clear();
                CargarCarrito();
            }
            else
            {
                MessageBox.Show("No hay suficiente stock para completar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
