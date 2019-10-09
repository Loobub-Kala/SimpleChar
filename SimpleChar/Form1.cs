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

namespace SimpleChar
{
    public partial class FormClient : Form
    {
        // 申明变量
        private TcpClient tcpClient = null;
        private NetworkStream networkStream = null;
        private BinaryReader reader;
        private BinaryWriter writer;

        // 申明委托
        // 显示消息
        private delegate void ShowMessage(string str);
        private ShowMessage showMessageCallback;

        // 清空消息
        private delegate void ResetMessage();
        private ResetMessage resetMessageCallBack;

        public FormClient()
        {
            InitializeComponent();

            // 实例化委托
            // 显示消息
            showMessageCallback = new ShowMessage(showMessage);

            // 重置消息
            resetMessageCallBack = new ResetMessage(resetMessage);
        }
        // 显示消息
        private void showMessage(string str)
        {
            charContent.AppendText(str);
        }
        // 清空消息
        private void resetMessage()
        {
            sendContent.Clear();
            sendContent.Focus();
        }

        //连接
        private void tsButton1_Click(object sender, EventArgs e)
        {
            if (tsButton1.Text == "连接")     //连接时
            {
                try
                {
                    //通过线程发起请求，多线程
                    Thread connectThread = new Thread(ConnectToServer);
                    connectThread.Start();
                    tsButton1.Text = "断开连接";
                    tsButton1.ToolTipText = "断开连接";
                    tsButton1.Image = Properties.Resources.取消连接__16_;
                    MessageBox.Show("连接成功了～\\(≧▽≦)/～");
                }
                catch
                {
                    MessageBox.Show("连接不上呢，请主人仔细检查一下错误吧〒▽〒");
                }
            }
            else//连接断开时
            {
                try
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (writer != null)
                    {
                        writer.Close();
                    }
                    // 断开连接
                    if (tcpClient != null)
                    {
                        tcpClient.Close();
                    }
                    tsButton1.Text = "连接";
                    tsButton1.ToolTipText = "连接";
                    tsButton1.Image = Properties.Resources.连接__16_;
                    MessageBox.Show("断开连接成功了～\\(≧▽≦)/～");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("断开失败了，请主人仔细检查一下错误吧〒▽〒" + "\n"+ex.Message);
                }
            }
        }
        //连接服务器
        private void ConnectToServer()
        {
            try
            {
                if(tsTextBox1.Text == String.Empty || tsTextBox2.Text == String.Empty)
                {
                    MessageBox.Show("主人您还没有告诉聊聊您的服务器的IP地址和端口号呢(⊙_⊙)?");
                }
                IPAddress ipAddress = IPAddress.Parse(tsTextBox1.Text);
                Int32 port = Int32.Parse(tsTextBox2.Text);
                tcpClient = new TcpClient();
                tcpClient.Connect(ipAddress,port);

                // 延时操作
                Thread.Sleep(300);

                //服务器已连上后
                if (tcpClient != null)
                {
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                }

                //启动接受消息的子线程
                Thread receiveThread = new Thread(receiveMessage);
                receiveThread.Start();

            }
            catch 
            {
                Thread.Sleep(300);
            }
        }

        // 接收消息
        private void receiveMessage()
        {
            try
            {
                while (reader != null)
                {
                    string receivemessage = reader.ReadString();
                    MessageBox.Show("22222" + receivemessage);
                    //这句不是很懂
                    //charContent.Invoke(showMessageCallback, tcpClient.Client.RemoteEndPoint + ": " + receivemessage + Environment.NewLine);
                    charContent.Invoke(showMessageCallback, "服务器" + ": " + receivemessage + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("聊聊没有成功接受消息呢，请主人仔细检查一下错误吧〒▽〒" + "\n" + ex.Message);
            }
        }

        //发送
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                writer.Write(sendContent.Text);
                writer.Flush();
                charContent.Invoke(showMessageCallback, "我: " + sendContent.Text + Environment.NewLine);
                sendContent.Invoke(resetMessageCallBack, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发送/接受消息失败了，请主人仔细检查一下错误吧〒▽〒" + "\n" + ex.Message);
            }
        }

        private void tsTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            //如果输入的不是数字键，也不是Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                MessageBox.Show("主人你得输入数字哦o(≧口≦)o" + "\n");
            }

        }

        private void FormClient_Activated(object sender, EventArgs e)
        {
            sendContent.Focus();
        }
    }
}
