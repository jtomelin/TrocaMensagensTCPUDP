using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace TrocaMensagens
{
    public partial class Form1 : Form
    {
        public bool bManterAberto;
        public ConnectionControl ConnectionCtrl { get; set; }
        public List<Usuario> Usuarios;
        public Dictionary<int, string> mapMensagens;

        Thread threadMensagens;
        Thread threadUsuarios;

        public Form1()
        {
            this.ConnectionCtrl = new ConnectionControl();

            bManterAberto = true;

            Login log = new Login();
            log.ConnectionCtrl = this.ConnectionCtrl;

            if (log.ShowDialog() == DialogResult.Cancel)
                bManterAberto = false;

            if (bManterAberto)
            {
                ConnectionCtrl.sLogin = log.sLogin;
                ConnectionCtrl.sSenha = log.sSenha;

                Usuarios = ConnectionCtrl.GetUsuarios();
            }

            /*System.Timers.Timer TimerMensagem = new System.Timers.Timer(2000);
            TimerMensagem.Elapsed += TimerMensagem_Elapsed;
            TimerMensagem.Start();

            System.Timers.Timer TimerUsuarios = new System.Timers.Timer(5000);
            TimerUsuarios.Elapsed += TimerUsuarios_Elapsed;
            TimerUsuarios.Start();*/

            threadMensagens = new Thread(new ThreadStart(OnGetMessages));
            threadMensagens.IsBackground = true;
            threadMensagens.Start();

            threadUsuarios = new Thread(new ThreadStart(OnGetUsers));
            threadUsuarios.IsBackground = true;
            threadUsuarios.Start();

            InitializeComponent();

            mapMensagens = new Dictionary<int, string>();

            if (Usuarios != null)
            {
                for (int i = 0; i < Usuarios.Count; i++)
                {
                    if (Usuarios[i].iCodigo == Int32.Parse(ConnectionCtrl.sLogin))
                        continue;

                    this.listBox1.Items.Add(Usuarios[i]);
                    mapMensagens[Usuarios[i].iCodigo] = "";
                }
            }
        }

        private void TimerUsuarios_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnGetUsers();
        }

        private void TimerMensagem_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnGetMessages();
        }

        void Form1_Closing(object sender, CancelEventArgs e)
        {
            threadMensagens.Abort();
            threadUsuarios.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario) this.listBox1.SelectedItem;

            if (usuario == null && !chkEnviarTodos.Checked)
            {
                MessageBox.Show("Usuário deve ser informado", "Troca de Mensagens", MessageBoxButtons.OK);
                return;
            }

            string sMensagem = "[Você] - " + edtMensagem.Text + "\r\n";

            int iCodigo = 0;

            if (!chkEnviarTodos.Checked)
                iCodigo = usuario.iCodigo;

            if (ConnectionCtrl.EnviarMensagem(iCodigo, edtMensagem.Text))
            {
                if (chkEnviarTodos.Checked)
                {
                    for (int i = 0; i < Usuarios.Count; i++)
                    {
                        string sMensagens;
                        mapMensagens.TryGetValue(Usuarios[i].iCodigo, out sMensagens);
                        sMensagens += sMensagem;

                        mapMensagens[Usuarios[i].iCodigo] = sMensagens;
                    }

                    if (usuario != null)
                        rtbMensagens.AppendText(sMensagem);
                }
                else
                {
                    string sMensagens;
                    mapMensagens.TryGetValue(usuario.iCodigo, out sMensagens);

                    sMensagens += sMensagem;
                    rtbMensagens.AppendText(sMensagem);
                    mapMensagens[usuario.iCodigo] = sMensagens;
                }
            }

            edtMensagem.Text = "";
        }

        private void OnSelectedItemList(object sender, System.EventArgs e)
        {
            rtbMensagens.Clear();

            Usuario usuario = (Usuario)this.listBox1.SelectedItem;

            if (usuario == null)
                return;

            string sMensagens;

            mapMensagens.TryGetValue(usuario.iCodigo, out sMensagens);
            rtbMensagens.Text = sMensagens;
        }

        private void OnGetMessages()
        {
            while (true)
            {
                string dataReceived;

                if (ConnectionCtrl.ReceberMensagens(out dataReceived))
                {
                    if (dataReceived.IndexOf('\0') != -1)
                        GetMessage(dataReceived);

                }
            }
        }

        delegate void GetMessageCallback(string dataReceived);
        void GetMessage(string dataReceived)
        {
            if (InvokeRequired)
            {
                GetMessageCallback callback = GetMessage;
                Invoke(callback, dataReceived);
            }
            else
            {
                string sAux;

                int index = dataReceived.IndexOf('\0');

                sAux = dataReceived.Substring(0, index);
                if (sAux.ElementAt(0) != ':')
                {
                    index = sAux.IndexOf(':');
                    int iCodigoUsuario = 0;
                    string sMensagem;

                    if (index != -1)
                    {
                        iCodigoUsuario = Int32.Parse(sAux.Substring(0, index));
                        index++;
                        sMensagem = sAux.Substring(index, sAux.Length - index);

                        string sMensagens = "";
                        string sNomeUsuario = "";

                        for (int i = 0; i < Usuarios.Count; i++)
                        {
                            if (Usuarios[i].iCodigo == iCodigoUsuario)
                            {
                                sNomeUsuario = Usuarios[i].sNome;
                                break;
                            }
                        }

                        sMensagem = "[" + sNomeUsuario + "] - " + sMensagem;

                        mapMensagens.TryGetValue(iCodigoUsuario, out sMensagens);
                        sMensagens += sMensagem;

                        mapMensagens[iCodigoUsuario] = sMensagens;

                        Usuario usuario = (Usuario)this.listBox1.SelectedItem;

                        if (usuario != null)
                        {
                            if (usuario.iCodigo == iCodigoUsuario)
                                rtbMensagens.AppendText(sMensagem);
                        }
                    }
                }
            }
        }

        private void OnGetUsers()
        {
            while (true)
            {
                List<Usuario> usuariosNovos;
                usuariosNovos = ConnectionCtrl.GetUsuarios();

                for (int i = 0; i < usuariosNovos.Count; i++)
                {
                    if (usuariosNovos[i].iCodigo == Int32.Parse(ConnectionCtrl.sLogin))
                        continue;

                    if (!mapMensagens.ContainsKey(usuariosNovos[i].iCodigo))
                        AddUser(usuariosNovos[i]);
                }
            }
        }

        delegate void AddUserCallback(Usuario usuario);
        public void AddUser(Usuario usuario)
        {
            if (InvokeRequired)
            {
                AddUserCallback callback = AddUser;
                Invoke(callback, usuario);
            }
            else
            {
                mapMensagens[usuario.iCodigo] = "";
                Usuarios.Add(usuario);
                this.listBox1.Items.Add(usuario);
            }
        }
    }
}
