using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientCommand
{
    public class ClientServerCommand
    {
        Socket client { get; set; }
        Socket server { get; set; }

        public string _answer = "";
        public string _eror = "";
        public bool ConnectServer(IPEndPoint point, Socket clientSocket)
        {
            try
            {
                client = clientSocket;
                client.BeginConnect(point, (IAsyncResult result) =>
                {
                    server = (Socket)result.AsyncState;
                    if (server.Connected)
                    {

                        byte[] buffer = new byte[1024];
                        ArraySegment<byte> segment = new ArraySegment<byte>(buffer,0,buffer.Length);
                        Task<int> message = server.ReceiveAsync(segment,SocketFlags.None);
                        if(message.IsCompleted)
                        {
                            _answer += Encoding.UTF8.GetString(buffer);
                        }
                    }
                }, client);
            }
            catch (Exception ex)
            {
                _eror = ex.Message;
            }
            return _answer == "Подключение успешно." ? true : false;
        }
        public void SendMessage(string message)
        {
            if (server.Connected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                ArraySegment<byte> segment = new ArraySegment<byte>(buffer, 0, buffer.Length);
                client.SendAsync(segment, SocketFlags.None);
            }
        }
        public bool ServerIsConnected()
        {
            return server != null ? true : false;
        }
    }
}