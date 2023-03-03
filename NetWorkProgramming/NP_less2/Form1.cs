using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NP_less2
{
    public partial class Form1 : Form
    {
        Socket? client;
        IPEndPoint? point;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connection_Click(object sender, EventArgs e)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
                client.BeginConnect(point,(IAsyncResult result)=>
                {
                    client.EndConnect();
                });
                byte[] buffer = new byte[1024];
                int answerServer = client.Receive(buffer);
                while(answerServer > 0)
                {
                    rtb_chat.Text = Encoding.UTF8.GetString(buffer);
                    answerServer = client.Receive(buffer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_sendmsg_Click(object sender, EventArgs e)
        {

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
    }
}