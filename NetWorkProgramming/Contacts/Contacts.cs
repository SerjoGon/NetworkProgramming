using System.Net.Sockets;

namespace Contacts
{
    public class ClientContacts
    {
        public Socket Socket { get; set; }
        public string Name { get; set; }
        string _password;
        string _email;
        string _phone;
        public ClientContacts(Socket socket, string name, string email, string phone, string password)
        {
            Socket = socket;
            Name = name;
            _password = password;
            _email = email;
            _phone = phone;
        }
    }
}