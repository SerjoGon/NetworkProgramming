using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientCommand
{
    public class ClientServerCommand
    {
        Socket client { get; set; }
        Socket server { get; set; }

        string _answer = "";
        string _eror = "";
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
                        int answerServer = server.Receive(buffer);
                        while (answerServer > 0)
                        {
                            _answer += Encoding.UTF8.GetString(buffer);
                            answerServer = server.Receive(buffer);
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