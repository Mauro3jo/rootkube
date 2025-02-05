using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Stock;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Stock
{
    public partial class FrmStock : FrmBase
    {
        private StockService _stockService;
        private Usuario _usuario;
        private int _idLocal;

        public FrmStock(Usuario usuario, int idLocal)
        {
            InitializeComponent();
            _stockService = new StockService();
            _usuario = usuario;
            _idLocal = idLocal;
            CargarStock();
            ConfigurarPermisos();

            this.TopLevel = false; // 🔹 Evita que se abra como ventana independiente
            this.FormBorderStyle = FormBorderStyle.None; // 🔹 Quita bordes
            this.Dock = DockStyle.Fill; // 🔹 Se ajusta automáticamente al panel
        }


        private void CargarStock()
        {
            dgvStock.DataSource = _stockService.ObtenerStockPorLocal(_idLocal)
                .Select(s => new
                {
                    s.IdProductoNavigation.Nombre,
                    s.IdProductoNavigation.UnidadMedida,
                    s.Cantidad
                })
                .ToList();
        }

        private void ConfigurarPermisos()
        {
            if (_usuario.Rol == "Empleado")
            {
                btnAgregarProducto.Visible = false;
                btnAgregarStock.Visible = false;
                btnGestionarCategorias.Visible = false;

            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            FrmCrearProducto frm = new FrmCrearProducto();

            // 🔹 Suscribimos el método `CargarStock()` al evento `ProductoAgregado`
            frm.ProductoAgregado += CargarStock;

            frm.ShowDialog(); // 🔹 Se abre como modal
        }


        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            FrmAgregarStock frm = new FrmAgregarStock(_idLocal);
            frm.ShowDialog(); // 🔹 Se abre como modal, no como MDI
            CargarStock();
        }
        private void btnGestionarCategorias_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.ShowDialog(); // 🔹 Se abre como modal
            CargarStock();
        }

    }
}
