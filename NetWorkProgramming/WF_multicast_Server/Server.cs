using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_multicast_Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        static string message = "";
        Thread sender = new Thread(new ThreadStart(Sender));
        static void Sender()
        {
            while (true)
            {

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
                IPAddress dest = IPAddress.Parse("234.5.5.5");
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(dest));
                IPEndPoint point = new IPEndPoint(dest, 4567);
                socket.Connect(point);
                socket.Send(Encoding.UTF8.GetBytes(message));
                socket.Close();
                Thread.Sleep(1000);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            message = richTextBox1.Text;
        }
    }
}
