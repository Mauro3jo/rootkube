using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Stock;
using RootKube.Models.Entidades;

namespace RootKube.UI.Vistas.Stock
{
    public partial class FrmCategoria : Form
    {
        private StockService _stockService;
        private Categoria _categoriaEditando;

        public FrmCategoria()
        {
            InitializeComponent();
            _stockService = new StockService();
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            dgvCategorias.DataSource = _stockService.ObtenerCategorias()
                .Select(c => new { c.IdCategoria, c.Nombre })
                .ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreCategoria = txtNombreCategoria.Text.Trim();
            if (string.IsNullOrEmpty(nombreCategoria))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool resultado;
            if (_categoriaEditando == null)
            {
                resultado = _stockService.CrearCategoria(nombreCategoria);
            }
            else
            {
                resultado = _stockService.ModificarCategoria(_categoriaEditando.IdCategoria, nombreCategoria);
            }

            if (resultado)
            {
                MessageBox.Show("Categoría guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreCategoria.Clear();
                _categoriaEditando = null;
                CargarCategorias();
            }
            else
            {
                MessageBox.Show("Error: la categoría ya existe o hubo un problema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                int idCategoria = Convert.ToInt32(dgvCategorias.SelectedRows[0].Cells["IdCategoria"].Value);
                _categoriaEditando = _stockService.ObtenerCategorias().FirstOrDefault(c => c.IdCategoria == idCategoria);
                if (_categoriaEditando != null)
                {
                    txtNombreCategoria.Text = _categoriaEditando.Nombre;
                }
            }
            else
            {
                MessageBox.Show("Selecciona una categoría para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
