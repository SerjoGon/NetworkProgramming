using System.Net;
using System.Net.Sockets;
using System.Text;
using Contacts;
using ServerCommand;

namespace NP_less2_server
{
    public partial class ServerForm : Form
    {
        Socket server;
        IPEndPoint point;
        ServerClientCommand command = new ServerClientCommand();

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
            try
            {
                if (server != null)
                    tmr_refreshconnection.Stop();
                server.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                server.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tmr_refreshConnection_Tick(object sender, EventArgs e)
        {
            if(command.GetClientSocket(server))
            {
                if(command.clientSockets.Count >0)
                {
                    foreach(Socket client in command.clientSockets) 
                    {
                        command.CommandManage(command.ReciveMessage(client), client);
                    }
                }
            }
            else
            {
                MessageBox.Show(command._eror);
            }
        }

        void RichTextBoxOutputDelegate(object obj)
        {
            rtb_clients.Text += (string)obj;
        }

        private void btn_updateClientsList_Click(object sender, EventArgs e)
        {
            foreach (ClientContacts client in command.contacts)
            {
                rtb_clients.Text += client.ToString();
            }
        }
        
    }
}