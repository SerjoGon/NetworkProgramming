using System.Net;
using System.Net.Sockets;
using System.Text;
using Contacts;

namespace NP_less2
{
    public partial class FormClient : Form
    {
        Socket client;
        IPEndPoint point;
        ClientContacts Contacts = new ClientContacts(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP),
            "Serj","password123","www.uncleserjy@yandex.ru","+79896667649");
        public FormClient()
        {
            InitializeComponent();

        }

        private void btn_connection_Click(object sender, EventArgs e)
        {
            try
            {
                client = Contacts.Socket;
                point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
                client.BeginConnect(point, (IAsyncResult result) =>
                {
                    Socket clientAsync = (Socket)result.AsyncState;
                    if (clientAsync.Connected)
                    {
                        byte[] buffer = new byte[1024];
                        int answerServer = client.Receive(buffer);
                        while (answerServer > 0)
                        {
                            rtb_chat.Text += Encoding.UTF8.GetString(buffer);
                            answerServer = client.Receive(buffer);
                        }
                    }
                    client.EndConnect(result);
                }, client);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_sendmsg_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(tb_message.Text);
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer, 0, buffer.Length);
            client.SendAsync(segment, SocketFlags.None);
        }

        private void btn_choos_Click(object sender, EventArgs e)
        {

        }

        private void btn_closeconnection_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tb_message_TextChanged(object sender, EventArgs e)
        {

        }
        class Client
        {
            Socket _clientSocket;

        }
    }
}