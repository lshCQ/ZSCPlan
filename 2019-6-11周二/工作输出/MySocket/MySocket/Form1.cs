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

namespace MySocket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int port = 6000;
            string host = "127.0.0.1";
            //创建ip对象
            IPAddress ip = IPAddress.Parse(host);
            //创建网络端口,包括ip和端口
            IPEndPoint ipe = new IPEndPoint(ip, port);
            //实例化一个套接字（IP4寻找协议,流式协议,TCP协议)
            Socket serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定套接字
            serversocket.Bind(ipe);
            //设置最大监听数10个
            serversocket.Listen(10);
            MessageBox.Show("监听已经打开，请等待");

        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }
    }
}
