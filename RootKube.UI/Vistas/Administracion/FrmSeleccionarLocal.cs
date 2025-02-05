using System;
using System.Linq;
using System.Windows.Forms;
using RootKube.BLL.Administracion;
using RootKube.Models.Entidades;
using RootKube.UI.Vistas.Comunes;

namespace RootKube.UI.Vistas.Administracion
{
    public partial class FrmSeleccionarLocal : FrmBase
    {
        private LocalesService _localesService;
        public int? IdLocalSeleccionado { get; private set; }

        public FrmSeleccionarLocal()
        {
            InitializeComponent();
            _localesService = new LocalesService();
            CargarLocales();
        }

        private void CargarLocales()
        {
            var locales = _localesService.ObtenerLocales();
            flpLocales.Controls.Clear();

            if (locales.Count == 0)
            {
                Label lblNoLocales = new Label
                {
                    Text = "No hay locales disponibles. Crea uno nuevo.",
                    AutoSize = true
                };
                flpLocales.Controls.Add(lblNoLocales);

                Button btnCrearLocal = new Button
                {
                    Text = "Crear Local",
                    AutoSize = true
                };
                btnCrearLocal.Click += BtnCrearLocal_Click;
                flpLocales.Controls.Add(btnCrearLocal);
                return;
            }

            foreach (var local in locales)
            {
                Panel panel = new Panel
                {
                    Width = 250,
                    Height = 120,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblNombre = new Label
                {
                    Text = local.Nombre,
                    AutoSize = true,
                    Location = new System.Drawing.Point(10, 10)
                };

                Button btnSeleccionar = new Button
                {
                    Text = "Seleccionar",
                    Location = new System.Drawing.Point(10, 50),
                    Tag = local.IdLocal
                };
                btnSeleccionar.Click += BtnSeleccionar_Click;

                Button btnEditar = new Button
                {
                    Text = "Editar",
                    Location = new System.Drawing.Point(90, 50),
                    Tag = local.IdLocal
                };
                btnEditar.Click += BtnEditar_Click;

                Button btnEliminar = new Button
                {
                    Text = "Eliminar",
                    Location = new System.Drawing.Point(170, 50),
                    Tag = local.IdLocal
                };
                btnEliminar.Click += BtnEliminar_Click;

                panel.Controls.Add(lblNombre);
                panel.Controls.Add(btnSeleccionar);
                panel.Controls.Add(btnEditar);
                panel.Controls.Add(btnEliminar);
                flpLocales.Controls.Add(panel);
            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            IdLocalSeleccionado = (int)btn.Tag;
            this.Close();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            FrmEditarLocal frmEditarLocal = new FrmEditarLocal((int)btn.Tag);
            frmEditarLocal.ShowDialog();
            CargarLocales();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("¿Seguro que deseas eliminar este local?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _localesService.EliminarLocal((int)btn.Tag);
                CargarLocales();
            }
        }

        private void BtnCrearLocal_Click(object sender, EventArgs e)
        {
            FrmCrearLocal frmCrearLocal = new FrmCrearLocal();
            frmCrearLocal.ShowDialog();
            CargarLocales();
        }
    }
}
