namespace RootKube.UI.Vistas.Stock
{
    partial class FrmSeleccionarProducto
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            txtBuscarProducto = new TextBox();
            lblBuscar = new Label();
            numCantidad = new NumericUpDown();
            lblCantidad = new Label();
            btnSeleccionar = new Button();
            btnCancelar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            SuspendLayout();

            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new System.Drawing.Point(23, 69);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new System.Drawing.Size(550, 250);
            dgvProductos.TabIndex = 0;

            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new System.Drawing.Point(100, 23);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new System.Drawing.Size(300, 23);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;

            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new System.Drawing.Point(23, 26);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(47, 15);
            lblBuscar.Text = "Buscar:";

            // 
            // numCantidad
            // 
            numCantidad.Location = new System.Drawing.Point(100, 340);
            numCantidad.Minimum = 1;
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new System.Drawing.Size(80, 23);
            numCantidad.TabIndex = 2;

            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new System.Drawing.Point(23, 342);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new System.Drawing.Size(58, 15);
            lblCantidad.Text = "Cantidad:";

            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new System.Drawing.Point(320, 340);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new System.Drawing.Size(120, 30);
            btnSeleccionar.TabIndex = 3;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;

            // 
            // btnCancelar
            // 
            btnCancelar.Location = new System.Drawing.Point(450, 340);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(120, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;

            // 
            // FrmSeleccionarProducto
            // 
            ClientSize = new System.Drawing.Size(600, 400);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscarProducto);
            Controls.Add(dgvProductos);
            Controls.Add(lblCantidad);
            Controls.Add(numCantidad);
            Controls.Add(btnSeleccionar);
            Controls.Add(btnCancelar);
            Text = "Seleccionar Producto";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
