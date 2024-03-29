using System.Net;
using System.Net.Sockets;
using System.Text;
using Contacts;
using ClientCommand;

namespace NP_less2
{
    public partial class FormClient : Form
    {
        Socket client;
        IPEndPoint point;
        ClientContacts Contacts;
        ClientServerCommand command;
        public FormClient()
        {
            InitializeComponent();

        }

        private async void btn_connection_Click(object sender, EventArgs e)
        {
            try
            {
                await command.ConnectServer(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80), Contacts.Socket);
                 rtb_chat.Text += command._answer + "\n";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_sendmsg_Click(object sender, EventArgs e)
        {
            if (command.ServerIsConnected())
                command.SendMessage("Contact|" + Contacts.ToString());
        }

        private void btn_choos_Click(object sender, EventArgs e)
        {

        }
        void RichTextBoxOutputDelegate(object obj)
        {
            rtb_chat.Text += (string)obj;
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
            if(command.client.Connected)
                command.client.Disconnect(false);
        }

        private void tb_message_TextChanged(object sender, EventArgs e)
        {

        }


        private void FormClient_Load(object sender, EventArgs e)
        {
            Contacts = new ClientContacts(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP),
            "Serj", "password123", "www.uncleserjy@yandex.ru", "+79896667649");
            command = new ClientServerCommand();
        }
    }
}