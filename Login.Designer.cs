using System.Windows.Forms;

namespace TrocaMensagens
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.edtLogin = new System.Windows.Forms.TextBox();
            this.edtSenha = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(12, 16);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(12, 42);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 1;
            this.lblSenha.Text = "Senha:";
            // 
            // edtLogin
            // 
            this.edtLogin.Location = new System.Drawing.Point(54, 9);
            this.edtLogin.Name = "edtLogin";
            this.edtLogin.Size = new System.Drawing.Size(182, 20);
            this.edtLogin.TabIndex = 2;
            // 
            // edtSenha
            // 
            this.edtSenha.Location = new System.Drawing.Point(54, 35);
            this.edtSenha.Name = "edtSenha";
            this.edtSenha.PasswordChar = '*';
            this.edtSenha.Size = new System.Drawing.Size(182, 20);
            this.edtSenha.TabIndex = 3;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Location = new System.Drawing.Point(161, 61);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.TabIndex = 4;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 96);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.edtSenha);
            this.Controls.Add(this.edtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblSenha);
            this.MaximumSize = new System.Drawing.Size(269, 135);
            this.MinimumSize = new System.Drawing.Size(269, 135);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblLogin;
        private Label lblSenha;
        private TextBox edtLogin;
        private TextBox edtSenha;
        private Button btnEntrar;
    }
}