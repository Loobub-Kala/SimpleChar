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

namespace SimpleCharServer
{
    public partial class FormServer : Form
    {
        // 申明变量
        private TcpListener tcpListen = null;
        private TcpClient tcpClient = null;
        private Int32 port = 888;
        IPAddress ipAddress;
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

        public FormServer()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false

            // 实例化委托
            // 显示消息
            showMessageCallback = new ShowMessage(showMessage);

            // 重置消息
            resetMessageCallBack = new ResetMessage(resetMessage);

            //ipAddress = IPAddress.Parse("10.161.103.59");
            ipAddress = IPAddress.Parse("127.0.0.1");
            port = Int32.Parse(tsTextBox2.Text);

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

        private void tsButton1_Click(object sender, EventArgs e)
        {
            port = Int32.Parse(tsTextBox2.Text);
            if (tsButton1.Text == "启动")     //启动时
            {
                try
                {
                    //通过线程发起请求，多线程
                    tcpListen = new TcpListener(ipAddress, port);
                    tcpListen.Start();
                    // 启动一个线程来接受请求
                    Thread acceptThread = new Thread(acceptClientConnect);
                    acceptThread.Start();

                    tsButton1.Text = "停止";
                    tsButton1.ToolTipText = "停止";
                    tsButton1.Image = Properties.Resources.停止_16_;
                    MessageBox.Show("启动成功了～\\(≧▽≦)/～");
                }
                catch
                {
                    MessageBox.Show("启动不了呢，请主人仔细检查一下错误吧〒▽〒");
                }
            }
            else//停止时
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
                    // 停止
                    if (tcpClient != null)
                    {
                        tcpClient.Close();
                        tcpListen.Stop();
                    }
                    tsButton1.Text = "启动";
                    tsButton1.ToolTipText = "启动";
                    tsButton1.Image = Properties.Resources.一键启动_16_;
                    MessageBox.Show("停止成功了～\\(≧▽≦)/～");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("停止失败了，请主人仔细检查一下错误吧〒▽〒" + "\n" + ex.Message);
                }
            }
        }
        // 接受请求
        private void acceptClientConnect()
        {
            tsState.Text = "正在监听";
            Thread.Sleep(300);
            try
            {
                tsState.Text = "等待连接";
                while(tcpClient==null)
                    tcpClient = tcpListen.AcceptTcpClient();
                if (tcpClient != null)
                {
                    tsState.Text = "已连接";
                    networkStream = tcpClient.GetStream();
                    reader = new BinaryReader(networkStream);
                    writer = new BinaryWriter(networkStream);
                    Thread threadread = new Thread(new ThreadStart(receiveMessage));
                    threadread.Start();
                }
            }
            catch
            {
                tsState.Text = "停止监听";
                Thread.Sleep(300);
                tsState.Text = "就绪";
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        // 接收消息
        private void receiveMessage()
        {
            tsState.Text = "接收消息中";
            try
            {
                while (reader != null)
                {
                    string receivemessage = reader.ReadString();
                    //这句不是很懂
                    //charContent.Invoke(showMessageCallback, tcpClient.Client.RemoteEndPoint + ": " + receivemessage + Environment.NewLine);
                    charContent.Invoke(showMessageCallback, "客户端" + ": " + receivemessage + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("聊聊没有成功接受消息呢，请主人仔细检查一下错误吧〒▽〒" + "\n" + ex.Message);
            }
        }

        // 发送消息
        private void sendMessage()
        {
            try
            {
                tsState.Text = "正在发送";
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

        private void FormServer_Activated(object sender, EventArgs e)
        {
            sendContent.Focus();
        }
    }
}
