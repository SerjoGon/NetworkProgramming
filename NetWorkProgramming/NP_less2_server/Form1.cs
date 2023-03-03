using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NP_less2_server
{
    public partial class Form1 : Form
    {
        Socket? server;
        IPEndPoint? point;
        bool runServer;
        public Form1()
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
            try
            {
                server.Bind(point);
                server.Listen(100);
                server.BeginAccept((IAsyncResult result) =>
                {
                    Socket clientsocket = server.EndAccept(result);
                    rtb_clients.Text += clientsocket.RemoteEndPoint.ToString();
                    clientsocket.Send(Encoding.UTF8.GetBytes("Успешное подключение."));
                }, server);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                /*
                 rtb_clients.Text += client.RemoteEndPoint.ToString();
                ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Успешное подключение."));
                client.SendAsync(buffer, SocketFlags.None);
                */
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}