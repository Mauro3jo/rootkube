namespace RootKube.UI.Vistas.Autenticacion
{
    partial class FrmRegistro
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtClaveProducto;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.ComboBox cmbLocal;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblClaveProducto;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblLocal;

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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtClaveProducto = new System.Windows.Forms.TextBox();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblClaveProducto = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 15);
            this.lblNombre.Text = "Nombre";
            this.Controls.Add(this.lblNombre);

            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(30, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 23);
            this.Controls.Add(this.txtNombre);

            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(30, 60);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(42, 15);
            this.lblCorreo.Text = "Correo";
            this.Controls.Add(this.lblCorreo);

            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(30, 80);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(200, 23);
            this.Controls.Add(this.txtCorreo);

            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(30, 110);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(67, 15);
            this.lblContraseña.Text = "Contraseña";
            this.Controls.Add(this.lblContraseña);

            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(30, 130);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(200, 23);
            this.txtContraseña.PasswordChar = '*';
            this.Controls.Add(this.txtContraseña);

            // 
            // lblClaveProducto
            // 
            this.lblClaveProducto.AutoSize = true;
            this.lblClaveProducto.Location = new System.Drawing.Point(30, 160);
            this.lblClaveProducto.Name = "lblClaveProducto";
            this.lblClaveProducto.Size = new System.Drawing.Size(92, 15);
            this.lblClaveProducto.Text = "Clave Producto";
            this.Controls.Add(this.lblClaveProducto);

            // 
            // txtClaveProducto
            // 
            this.txtClaveProducto.Location = new System.Drawing.Point(30, 180);
            this.txtClaveProducto.Name = "txtClaveProducto";
            this.txtClaveProducto.Size = new System.Drawing.Size(200, 23);
            this.Controls.Add(this.txtClaveProducto);

            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(30, 210);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(25, 15);
            this.lblRol.Text = "Rol";
            this.Controls.Add(this.lblRol);

            // 
            // cmbRol
            // 
            this.cmbRol.Location = new System.Drawing.Point(30, 230);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(200, 23);
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Items.AddRange(new object[] { "Administrador", "Gerente", "Empleado" });
            this.cmbRol.SelectedIndexChanged += new System.EventHandler(this.cmbRol_SelectedIndexChanged);
            this.Controls.Add(this.cmbRol);

            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(30, 260);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(35, 15);
            this.lblLocal.Text = "Local";
            this.Controls.Add(this.lblLocal);

            // 
            // cmbLocal
            // 
            this.cmbLocal.Location = new System.Drawing.Point(30, 280);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(200, 23);
            this.cmbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocal.Enabled = false; // Inicialmente deshabilitado
            this.Controls.Add(this.cmbLocal);

            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(30, 320);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(200, 30);
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            this.Controls.Add(this.btnRegistrar);

            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(30, 360);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);
            this.Controls.Add(this.lblMensaje);

            // 
            // FrmRegistro
            // 
            this.ClientSize = new System.Drawing.Size(280, 400);
            this.Name = "FrmRegistro";
            this.Text = "Registro de Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
