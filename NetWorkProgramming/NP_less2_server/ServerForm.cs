using System.Net;
using System.Net.Sockets;
using System.Text;
using Contacts;

namespace NP_less2_server
{
    public partial class ServerForm : Form
    {
        Socket server;
        IPEndPoint point;
        ClientContacts contacts;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (server == null)
                return;
            server.Bind(point);
            server.Listen(100);
            tmr_refreshconnection.Start();
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            tmr_refreshconnection.Stop();
            /*server.Shutdown(SocketShutdown.Both);
            server.Close();*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }
        private void tmr_refreshConnection_Tick(object sender, EventArgs e)
        {
            try
            {
                server.BeginAccept(ServerAcceptDelegate, server);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ServerAcceptDelegate(IAsyncResult result)
        {
            if (result != null)
            {
                Socket serv = (Socket)result.AsyncState;
                Socket clientsocket = serv.EndAccept(result);
                IAsyncResult updateText = rtb_clients.BeginInvoke(RichTextBoxDelegate);
                clientsocket.Send(Encoding.UTF8.GetBytes("Успешное подключение."));
                clientsocket.Shutdown(SocketShutdown.Send);
                clientsocket.Close();
                serv.BeginAccept(ServerAcceptDelegate, serv);
            }
        }
        void RichTextBoxDelegate(object obj, EventArgs e)
        {
            rtb_clients.Text +=(string) obj;
        }
    }
}