using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            //在服务端创建一个负责监听的Ip地址和端口的Socket
            Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("192.168.1.202");
            //创建端口号对象
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtPoint.Text));
            socketWatch.Bind(point);
            ShowMsg("监听成功！");
            socketWatch.Listen(10);

            Thread th = new Thread(Listen);
            th.IsBackground = true;
            th.Start(socketWatch);

        }
        Dictionary<string, Socket> dic = new Dictionary<string, Socket>();
        Socket socketSend;
        /// <summary>
        /// 等待客户端的连接，并创建一之对应的socket
        /// </summary>
        void Listen(object obj)
        {
            Socket socketWatch = obj as Socket;
            //等待客户端连接并且创建一个负责通信的socket
            while (true)
            {
                socketSend = socketWatch.Accept();
                //将远程连接的Ip地址和连接存入集合中
                dic.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                cobIPList.Items.Add(socketSend.RemoteEndPoint.ToString());
                MessageBox.Show("连接成功");
              //  ShowMsg(socketWatch.RemoteEndPoint.ToString() + ":" + "连接成功！");

                Thread th = new Thread(Recviec);
                th.IsBackground = true;
                th.Start(socketSend);

            }
        }
        /// <summary>
        /// 服务器端不停的接收客户端发送的消息
        /// </summary>
        /// <param name="obj"></param>
        void Recviec(object obj)
        {
            Socket socketSend = obj as Socket;
            while (true)
            {
                //客户端连接成功后，服务端应接受客户端发送多来的消息
                byte[] buffer = new byte[1024 * 1024 * 2];
                //实际接收到的文件字节数
                int r = socketSend.Receive(buffer);
                if (r == 0) { break; }
                string str = Encoding.UTF8.GetString(buffer, 0, r);
                ShowMsg(socketSend.RemoteEndPoint + ":" + str);
            }
        }

        void ShowMsg(string str)
        {
            txtSendMsg.AppendText(str + "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 服务端给客户端发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            string ip = cobIPList.SelectedItem.ToString();
            byte[] buffer = Encoding.UTF8.GetBytes(txtSendMsg.Text.Trim());
            List<byte> list = new List<byte>();
            list.Add(0);
            list.AddRange(buffer);
            dic[ip].Send(list.ToArray());
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "请选择要发送的文件";
            open.InitialDirectory = @"C:\Users\Administrator\Desktop";
            open.Filter = "所有文件|*.*";
            open.ShowDialog();

            txtPath.Text = open.FileName;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            //获得要发送文件的路径
            string path = txtPath.Text.Trim();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fs.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);
                list.AddRange(buffer);
                dic[socketSend.RemoteEndPoint.ToString()].Send(list.ToArray(), 0, r+1 , SocketFlags.None);
            }
        }

        private void btnShock_Click(object sender, EventArgs e)
        {
            byte[] buffer= new byte[1];
            buffer[0] = 2;
            dic[socketSend.RemoteEndPoint.ToString()].Send(buffer);
        }
    }
}
