namespace RootKube.UI.Vistas.Administracion
{
    partial class FrmSeleccionarLocal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flpLocales;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCrearLocal;

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
            flpLocales = new FlowLayoutPanel();
            lblTitulo = new Label();
            btnCrearLocal = new Button();
            SuspendLayout();
            // 
            // flpLocales
            // 
            flpLocales.AutoScroll = true;
            flpLocales.Location = new System.Drawing.Point(20, 50);
            flpLocales.Name = "flpLocales";
            flpLocales.Size = new System.Drawing.Size(350, 300);
            flpLocales.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitulo.Location = new System.Drawing.Point(20, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(170, 19);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Selecciona un Local:";
            // 
            // btnCrearLocal
            // 
            btnCrearLocal.Location = new System.Drawing.Point(20, 370);
            btnCrearLocal.Name = "btnCrearLocal";
            btnCrearLocal.Size = new System.Drawing.Size(350, 30);
            btnCrearLocal.TabIndex = 2;
            btnCrearLocal.Text = "Crear Nuevo Local";
            btnCrearLocal.UseVisualStyleBackColor = true;
            btnCrearLocal.Click += BtnCrearLocal_Click;
            // 
            // FrmSeleccionarLocal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            ClientSize = new System.Drawing.Size(400, 420);
            Controls.Add(lblTitulo);
            Controls.Add(flpLocales);
            Controls.Add(btnCrearLocal);
            Name = "FrmSeleccionarLocal";
            Text = "Seleccionar Local";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
