namespace RootKube.UI.Vistas.Administracion
{
    partial class FrmCrearLocal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnGuardar;

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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDireccion = new Label();
            txtDireccion = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(20, 20);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(55, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new System.Drawing.Point(20, 40);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(250, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new System.Drawing.Point(20, 80);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new System.Drawing.Size(60, 15);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new System.Drawing.Point(20, 100);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new System.Drawing.Size(250, 23);
            txtDireccion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new System.Drawing.Point(20, 140);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(250, 30);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Local";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmCrearLocal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            ClientSize = new System.Drawing.Size(300, 200);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(btnGuardar);
            Name = "FrmCrearLocal";
            Text = "Crear Local";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
