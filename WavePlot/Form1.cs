using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WavePlot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udp = new UdpClient(7777);

            string msg = "Test";
            byte[] datagram = Encoding.UTF8.GetBytes(msg);

            udp.Send(datagram, datagram.Length, "127.0.0.1", 7777);
            label1.Text = ("[Send] 127.0.0.1:7777 로 {0} 바이트 전송", datagram.Length).ToString();

            IPEndPoint epRemote = new IPEndPoint(IPAddress.Any, 7777);
            byte[] bytes = udp.Receive(ref epRemote);
            label1.Text = ("[Receive] {0} 로부터 {1} 바이트 수신", epRemote.ToString(), bytes.Length).ToString();

            udp.Close();
        }
    }
}
