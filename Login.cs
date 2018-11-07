using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrocaMensagens
{
    public partial class Login : Form
    {
        public string sLogin { get; set; }
        public string sSenha { get; set; }
        public ConnectionControl ConnectionCtrl { get; set; }

        public Login()
        {
            InitializeComponent();

            edtLogin.Text = "9924";
            edtSenha.Text = "esmtk";
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.sLogin = edtLogin.Text;
            this.sSenha = edtSenha.Text;

            if (this.sLogin.Length == 0)
            {
                MessageBox.Show("Login deve ser informado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.sSenha.Length == 0)
            {
                MessageBox.Show("Senha deve ser informada", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConnectionCtrl.sLogin = this.sLogin;
            ConnectionCtrl.sSenha = this.sSenha;

            if (!ConnectionCtrl.ValidarUsuario())
            {
                MessageBox.Show("Usuário inválido", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
