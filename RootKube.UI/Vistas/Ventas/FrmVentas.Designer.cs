namespace RootKube.UI.Vistas.Ventas
{
    partial class FrmVentas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnConfirmarVenta;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotal;

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
            dgvCarrito = new DataGridView();
            btnAgregarProducto = new Button();
            btnEliminarProducto = new Button();
            btnConfirmarVenta = new Button();
            cmbMetodoPago = new ComboBox();
            lblTitulo = new Label();
            lblTotal = new Label();

            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();

            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new System.Drawing.Point(23, 69);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new System.Drawing.Size(583, 300);
            dgvCarrito.TabIndex = 0;

            // 🔹 Agregar columnas manualmente para evitar errores
            dgvCarrito.Columns.Add("IdProducto", "ID");
            dgvCarrito.Columns.Add("Nombre", "Producto");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new System.Drawing.Point(630, 69);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new System.Drawing.Size(175, 46);
            btnAgregarProducto.TabIndex = 1;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;

            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Location = new System.Drawing.Point(630, 127);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new System.Drawing.Size(175, 46);
            btnEliminarProducto.TabIndex = 2;
            btnEliminarProducto.Text = "Eliminar Producto";
            btnEliminarProducto.UseVisualStyleBackColor = true;
            btnEliminarProducto.Click += btnEliminarProducto_Click;

            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.Location = new System.Drawing.Point(23, 400);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new System.Drawing.Size(200, 25);
            cmbMetodoPago.TabIndex = 3;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitulo.Location = new System.Drawing.Point(23, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(145, 22);
            lblTitulo.Text = "Ventas";

            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotal.Location = new System.Drawing.Point(450, 410);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(120, 18);
            lblTotal.Text = "Total: $0.00";

            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.Location = new System.Drawing.Point(630, 400);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new System.Drawing.Size(175, 46);
            btnConfirmarVenta.TabIndex = 4;
            btnConfirmarVenta.Text = "Confirmar Venta";
            btnConfirmarVenta.UseVisualStyleBackColor = true;
            btnConfirmarVenta.Click += btnConfirmarVenta_Click;

            // 
            // FrmVentas
            // 
            ClientSize = new System.Drawing.Size(840, 480);
            Controls.Add(lblTitulo);
            Controls.Add(dgvCarrito);
            Controls.Add(btnAgregarProducto);
            Controls.Add(btnEliminarProducto);
            Controls.Add(cmbMetodoPago);
            Controls.Add(lblTotal);
            Controls.Add(btnConfirmarVenta);
            Text = "Gestión de Ventas";

            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
