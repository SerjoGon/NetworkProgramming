using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Multicast
{
    public partial class ClientMulticast : Form
    {
        public ClientMulticast()
        {
            InitializeComponent();
            Thread reciverTrhread = new Thread(new ThreadStart(Reciver));
            reciverTrhread.IsBackground = true;
            reciverTrhread.Start();
        }
        delegate void receiverDelegate(string text);
        void RecieveDel(string text)
        {
            richTextBox1.Text= text;
        }
         void Reciver()
        {
            while(true)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 4567);
                socket.Bind(point);
                IPAddress address = IPAddress.Parse("234.5.5.5");
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(address,IPAddress.Any));
                byte[] buffer = new byte[1024];
                socket.Receive(buffer);
                richTextBox1.Invoke(new receiverDelegate(RecieveDel),Encoding.UTF8.GetString(buffer));
                socket.Close();
            }
        }
    }
}
