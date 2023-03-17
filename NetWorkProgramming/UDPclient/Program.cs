using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPclient
{
    internal class Program
    {
        static bool end = false;
        static void Main(string[] args)
        {
            Receiver();
            while(!end)
            {
                Thread.Sleep(100); 
            }
        }
       static async void Receiver()
        {
            using var udpClient = new UdpClient(8001);
            var brodcastAddress = IPAddress.Parse("235.5.5.11");
            udpClient.JoinMulticastGroup(brodcastAddress);
            Console.WriteLine("Начало прослушивания сообщений");
            while (true)
            {
                var result = await udpClient.ReceiveAsync();
                string message = Encoding.UTF8.GetString(result.Buffer);
                if (message == "END") break;
                Console.WriteLine(message);
            }
            udpClient.DropMulticastGroup(brodcastAddress);
            Console.WriteLine("Udp-клиент завершил свою работу");
            end = true;
        }
    }
}