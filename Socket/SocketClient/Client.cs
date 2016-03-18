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

namespace SocketClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        Socket socketSend;
        private void btnContent_Click(object sender, EventArgs e)
        {
            //创建负责通信的socket
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(txtIp.Text);
            //获取要链接的服务器的Ip和端口号 
            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txtPonit.Text));
            socketSend.Connect(point);
            ShowMsg(socketSend.RemoteEndPoint+":"+"连接成功！");
            //开启一个线程不停的接收

            Thread th = new Thread(Recviec);
            th.IsBackground = true;
            th.Start();
        }
        
        /// <summary>
        /// 客户端接收服务器消息
        /// </summary>
        void Recviec()
        {
            while (true)
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                int r = socketSend.Receive(buffer);
                if (r == 0) { break; }
                if (buffer[0] == 0)//发送的文字消息
                {
                    string str = Encoding.UTF8.GetString(buffer, 1, r - 1);
                    ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                }
                else if (buffer[0] == 1)//发送的文件
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        SaveFileDialog ssd = new SaveFileDialog();
                        ssd.InitialDirectory = @"C:\Users\Administrator\Desktop";
                        ssd.Title = "请选择要发送的文件";
                        ssd.Filter = "所有文件|*.*";
                        ssd.ShowDialog();
                        string path = ssd.FileName;
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fs.Write(buffer, 1, r - 1);
                            MessageBox.Show("保存成功！");
                        }
                    }));
                }
                else if (buffer[0] == 2)//发送的震动
                {
                    for (int i = 0; i < 500; i++)
                    {
                        this.Location = new Point(200, 200);
                        this.Location = new Point(230, 230);
                    }
                }
            }
        }


        void ShowMsg(string str)
        {
            txtLog.AppendText(str + "\r\n");
        }
        /// <summary>
        /// 客户端给服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string text = txtMsg.Text.Trim();
            socketSend.Send(Encoding.UTF8.GetBytes(text));
        }
    }
}
