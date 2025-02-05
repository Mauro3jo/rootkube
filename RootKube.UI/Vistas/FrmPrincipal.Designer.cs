namespace RootKube.UI
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.FlowLayoutPanel pnlNavbar;
        private System.Windows.Forms.Panel pnlContenido;

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
            lblUsuario = new Label();
            lblLocal = new Label();
            pnlNavbar = new FlowLayoutPanel();
            pnlContenido = new Panel();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(230, 20);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(112, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Bienvenido, Usuario";
            // 
            // lblLocal
            // 
            lblLocal.AutoSize = true;
            lblLocal.ForeColor = Color.White;
            lblLocal.Location = new Point(230, 50);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(91, 15);
            lblLocal.TabIndex = 2;
            lblLocal.Text = "Local Asignado:";
            // 
            // pnlNavbar
            // 
            pnlNavbar.AutoScroll = true;
            pnlNavbar.BackColor = Color.FromArgb(30, 30, 30);
            pnlNavbar.FlowDirection = FlowDirection.TopDown;
            pnlNavbar.Location = new Point(0, 0);
            pnlNavbar.Name = "pnlNavbar";
            pnlNavbar.Padding = new Padding(5);
            pnlNavbar.Size = new Size(220, 500);
            pnlNavbar.TabIndex = 0;
            pnlNavbar.WrapContents = false;
            // 
            // pnlContenido
            // 
            pnlContenido.Location = new Point(220, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(780, 500);
            pnlContenido.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(lblUsuario);
            Controls.Add(lblLocal);
            Controls.Add(pnlNavbar);
            Controls.Add(pnlContenido);
            IsMdiContainer = true;
            Name = "FrmPrincipal";
            Text = "RootKube - Panel Principal";
            FormClosing += FrmPrincipal_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
