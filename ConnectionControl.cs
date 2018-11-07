using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TrocaMensagens
{
    public class ConnectionControl
    {
        private const string sServidor = "larc.inf.furb.br";
        public string sLogin;
        public string sSenha;
        private bool bConectouTCP { get; set; } = false;
        private bool bConectouUDP { get; set; } = false;

        private TcpClient tcpClient { get; set; }
        private UdpClient udpClient { get; set; }

        public ConnectionControl()
        {
            tcpClient = new TcpClient();
            udpClient = new UdpClient();
        }

        private object lockObject = new object();

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string returnData;

            try
            {
                lock (lockObject)
                {
                    ConectarTCP();
                    var serverStream = tcpClient.GetStream();
                    byte[] outStream = Encoding.UTF8.GetBytes($"GET USERS {sLogin}:{sSenha}");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    byte[] inStream = new byte[tcpClient.ReceiveBufferSize];
                    serverStream.Read(inStream, 0, tcpClient.ReceiveBufferSize);
                    returnData = Encoding.UTF8.GetString(inStream);
                }

                int iFirst = 0;
                int iLast = returnData.IndexOf(':');

                int iCodigoUsuario = 0;
                int iQtdJogosGanhos = 0;
                string sNomeUsuario = "";

                int iCount = 0;

                while (iLast != -1)
                {
                    string sAux = returnData.Substring(iFirst, iLast - iFirst);

                    iFirst = iLast + 1;
                    iLast = returnData.IndexOf(':', iFirst);

                    switch (iCount)
                    {
                        case 0: iCodigoUsuario = Int32.Parse(sAux); break;
                        case 1: sNomeUsuario = sAux; break;
                        case 2: iQtdJogosGanhos = Int32.Parse(sAux); break;
                    }

                    iCount++;

                    if (iCount == 3)
                    {
                        iCount = 0;

                        Usuario usuario = new Usuario();
                        usuario.iCodigo = iCodigoUsuario;
                        usuario.sNome = sNomeUsuario;
                        usuario.iQtdJogosGanhos = iQtdJogosGanhos;

                        usuarios.Add(usuario);
                    }
                }

            }
            catch (Exception exc)
            {
            }

            return usuarios;
        }

        public bool EnviarMensagem(int iCodigoUsuario, string sMensagem)
        {
            try
            {
                ConectarUDP();
                byte[] outStream = Encoding.UTF8.GetBytes($"SEND MESSAGE {sLogin}:{sSenha}:{iCodigoUsuario}:{sMensagem}");
                int result = udpClient.Send(outStream, outStream.Length);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }

        public bool ReceberMensagens(out string sMensagem)
        {
            sMensagem = "";

            try
            {
                lock (lockObject)
                {
                    ConectarTCP();
                    var serverStream = tcpClient.GetStream();
                    byte[] outStream = Encoding.UTF8.GetBytes($"GET MESSAGE {sLogin}:{sSenha}");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    byte[] inStream = new byte[tcpClient.ReceiveBufferSize];
                    serverStream.Read(inStream, 0, tcpClient.ReceiveBufferSize);
                    sMensagem = Encoding.UTF8.GetString(inStream);
                }

                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
        }


        public void ConectarTCP()
        {
            System.Threading.Thread.Sleep(50);

                if (!bConectouTCP)
                {
                    //tcpClient = new TcpClient();
                    tcpClient.Connect(sServidor, 1012);
                    bConectouTCP = true;
                }
        }


        public void ConectarUDP()
        {
            if (!bConectouUDP)
            {
                udpClient.Connect(sServidor, 1011);
                bConectouUDP = true;
            }
        }

        public bool ValidarUsuario()
        {
            try
            {
                lock (lockObject)
                {
                    ConectarTCP();
                    var serverStream = tcpClient.GetStream();
                    byte[] outStream = Encoding.UTF8.GetBytes($"GET USERS {sLogin}:{sSenha}");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();

                    byte[] inStream = new byte[tcpClient.ReceiveBufferSize];
                    serverStream.Read(inStream, 0, tcpClient.ReceiveBufferSize);
                    string receivedData = Encoding.UTF8.GetString(inStream);

                    int iLast = receivedData.IndexOf('\r');

                    if (iLast != -1)
                    {
                        string aux = receivedData.Substring(0, iLast);

                        if (aux == "Usuário inválido!")
                            return false;
                    }
                    else
                    {
                        return false;
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
