using Microsoft.AspNetCore.Http;
using System.Net;

namespace WF_HTTP_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            string site = textBox1.Text;
           HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(site); 
            HttpResponseMessage response = client.GetAsync(site).Result;
            HttpContent content = response.Content;
            Stream stream = content.ReadAsStream();
            StreamReader reader = new StreamReader(stream);
            richTextBox1.Text= reader.ReadToEnd();

            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(site);
            client.GetAsync(site).Wait();
        */
            }
    }
}