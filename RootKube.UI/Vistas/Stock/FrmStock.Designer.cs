namespace RootKube.UI.Vistas.Stock
{
    partial class FrmStock
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnAgregarStock; 
        private System.Windows.Forms.Button btnGestionarCategorias; 
        private System.Windows.Forms.Label lblTitulo;

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
            dgvStock = new DataGridView();
            btnAgregarProducto = new Button();
            btnAgregarStock = new Button();
            lblTitulo = new Label();
            btnGestionarCategorias = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // dgvStock
            // 
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(23, 69);
            dgvStock.Margin = new Padding(4, 3, 4, 3);
            dgvStock.Name = "dgvStock";
            dgvStock.Size = new Size(583, 346);
            dgvStock.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(630, 69);
            btnAgregarProducto.Margin = new Padding(4, 3, 4, 3);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(175, 46);
            btnAgregarProducto.TabIndex = 1;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnAgregarStock
            // 
            btnAgregarStock.Location = new Point(630, 127);
            btnAgregarStock.Margin = new Padding(4, 3, 4, 3);
            btnAgregarStock.Name = "btnAgregarStock";
            btnAgregarStock.Size = new Size(175, 46);
            btnAgregarStock.TabIndex = 2;
            btnAgregarStock.Text = "Agregar Stock";
            btnAgregarStock.UseVisualStyleBackColor = true;
            btnAgregarStock.Click += btnAgregarStock_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(23, 23);
            lblTitulo.Margin = new Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(168, 22);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Stock";
            // 
            // btnGestionarCategorias
            // 
            btnGestionarCategorias.Location = new Point(630, 185);
            btnGestionarCategorias.Name = "btnGestionarCategorias";
            btnGestionarCategorias.Size = new Size(175, 46);
            btnGestionarCategorias.TabIndex = 0;
            btnGestionarCategorias.Text = "Gestionar Categorías";
            btnGestionarCategorias.UseVisualStyleBackColor = true;
            btnGestionarCategorias.Click += btnGestionarCategorias_Click;
            // 
            // FrmStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(840, 462);
            Controls.Add(btnGestionarCategorias);
            Controls.Add(lblTitulo);
            Controls.Add(dgvStock);
            Controls.Add(btnAgregarProducto);
            Controls.Add(btnAgregarStock);
            Margin = new Padding(5, 3, 5, 3);
            Name = "FrmStock";
            Text = "Gestión de Stock";
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
