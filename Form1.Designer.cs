using System.Windows.Forms;

namespace TrocaMensagens
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbMensagens = new System.Windows.Forms.RichTextBox();
            this.edtMensagem = new System.Windows.Forms.TextBox();
            this.chkEnviarTodos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 316);
            this.listBox1.TabIndex = 0;
            this.listBox1.Click += new System.EventHandler(this.OnSelectedItemList);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(757, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbMensagens
            // 
            this.rtbMensagens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMensagens.Location = new System.Drawing.Point(228, 12);
            this.rtbMensagens.Name = "rtbMensagens";
            this.rtbMensagens.ReadOnly = true;
            this.rtbMensagens.Size = new System.Drawing.Size(604, 316);
            this.rtbMensagens.TabIndex = 1;
            this.rtbMensagens.Text = "";
            // 
            // edtMensagem
            // 
            this.edtMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMensagem.Location = new System.Drawing.Point(228, 337);
            this.edtMensagem.Multiline = true;
            this.edtMensagem.Name = "edtMensagem";
            this.edtMensagem.Size = new System.Drawing.Size(523, 23);
            this.edtMensagem.TabIndex = 2;
            // 
            // chkEnviarTodos
            // 
            this.chkEnviarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnviarTodos.AutoSize = true;
            this.chkEnviarTodos.Location = new System.Drawing.Point(12, 337);
            this.chkEnviarTodos.Name = "chkEnviarTodos";
            this.chkEnviarTodos.Size = new System.Drawing.Size(109, 17);
            this.chkEnviarTodos.TabIndex = 4;
            this.chkEnviarTodos.Text = "Enviar para todos";
            this.chkEnviarTodos.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 381);
            this.Controls.Add(this.chkEnviarTodos);
            this.Controls.Add(this.edtMensagem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbMensagens);
            this.Controls.Add(this.listBox1);
            this.MinimumSize = new System.Drawing.Size(860, 420);
            this.Name = "Form1";
            this.Text = "Troca de Mensagens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

            CenterToScreen();
        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbMensagens;
        private System.Windows.Forms.TextBox edtMensagem;
        private CheckBox chkEnviarTodos;
    }
}

