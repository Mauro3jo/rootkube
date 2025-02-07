using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Stock;
using RootKube.DAL.Contexto;
using RootKube.Models.Entidades;

namespace RootKube.UI.Vistas.Stock
{
    public partial class FrmSeleccionarProducto : Form
    {
        private ProductoService _productoService;
        private int _idLocal;
        public Producto ProductoSeleccionado { get; private set; }
        public decimal CantidadSeleccionada { get; private set; }

        public FrmSeleccionarProducto(int idLocal)
        {
            InitializeComponent();
            _productoService = new ProductoService(new RootKubeDbContext());
            _idLocal = idLocal;
            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = _productoService.ObtenerProductosDisponibles(_idLocal)
                .Select(p => new
                {
                    p.IdProducto,
                    p.Nombre,
                    p.UnidadMedida,
                    p.Precio
                }).ToList();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarProducto.Text.ToLower();
            dgvProductos.DataSource = _productoService.ObtenerProductosDisponibles(_idLocal)
                .Where(p => p.Nombre.ToLower().Contains(filtro))
                .Select(p => new
                {
                    p.IdProducto,
                    p.Nombre,
                    p.UnidadMedida,
                    p.Precio
                }).ToList();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = (int)dgvProductos.SelectedRows[0].Cells["IdProducto"].Value;
            ProductoSeleccionado = _productoService.ObtenerProductosDisponibles(_idLocal)
                .FirstOrDefault(p => p.IdProducto == idProducto);

            CantidadSeleccionada = numCantidad.Value;

            if (CantidadSeleccionada <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
