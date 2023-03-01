using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Timers;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace NPLesson1client
{
    internal class Program
    {
        //static Socket socket= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        // static IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            while(timer.Enabled)
            {

            }
           Console.ReadLine();
        }
        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
            Console.WriteLine("Elapsed event was raised at{0}", e.SignalTime);
            try
            {
                socket.Connect(point);
                byte[] buffer = new byte[1024];
                int c;
                do
                {
                    c = socket.Receive(buffer);
                    Console.WriteLine(Encoding.ASCII.GetString(buffer));
                }
                while (c > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
            }

        }
       
    }
}