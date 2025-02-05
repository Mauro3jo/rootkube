using System;
using System.Windows.Forms;

namespace RootKube.UI.Vistas.Autenticacion
{

    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnIrRegistro;

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
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            btnLogin = new Button();
            lblCorreo = new Label();
            lblContraseña = new Label();
            lblMensaje = new Label();
            btnIrRegistro = new Button();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(35, 35);
            txtCorreo.Margin = new Padding(4, 3, 4, 3);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(233, 23);
            txtCorreo.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(35, 81);
            txtContraseña.Margin = new Padding(4, 3, 4, 3);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(233, 23);
            txtContraseña.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(35, 127);
            btnLogin.Margin = new Padding(4, 3, 4, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(233, 35);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(35, 12);
            lblCorreo.Margin = new Padding(4, 0, 4, 0);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(43, 15);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(35, 58);
            lblContraseña.Margin = new Padding(4, 0, 4, 0);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.Location = new Point(35, 173);
            lblMensaje.Margin = new Padding(4, 0, 4, 0);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 15);
            lblMensaje.TabIndex = 4;
            // 
            // btnIrRegistro
            // 
            btnIrRegistro.Location = new Point(35, 208);
            btnIrRegistro.Margin = new Padding(4, 3, 4, 3);
            btnIrRegistro.Name = "btnIrRegistro";
            btnIrRegistro.Size = new Size(233, 35);
            btnIrRegistro.TabIndex = 5;
            btnIrRegistro.Text = "Registrarse";
            btnIrRegistro.UseVisualStyleBackColor = true;
            btnIrRegistro.Click += btnIrRegistro_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(327, 231);
            Controls.Add(txtCorreo);
            Controls.Add(txtContraseña);
            Controls.Add(btnLogin);
            Controls.Add(lblCorreo);
            Controls.Add(lblContraseña);
            Controls.Add(lblMensaje);
            Controls.Add(btnIrRegistro);
            Margin = new Padding(5, 3, 5, 3);
            Name = "FrmLogin";
            Text = "Iniciar Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
