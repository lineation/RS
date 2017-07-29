using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Drawing;

namespace UniformUI.Utils
{
    class TCPIPUtils
    {
        private byte[] _clientSocketBuf;
        private byte[] _serverSocketBuf; 
        private Socket _clientSocket;      //客户端SOCKET
        private string _serverIP;          //服务器IP地址
        private string _serverPort;        //服务器端口号

        private string _serverLocalIP;     //服务器IP地址
        private string _serverLocalPort;   //服务器端口号

        private Boolean _clientConnOK;     //是否连接成功
        private Boolean _serverConnOK;     //是否连接成功
        private TcpListener _tcpListener;  //服务器端SOCKET
        private NetworkStream netStream;
        private StreamReader readStream;
        private StreamWriter writeStream;
        private Socket _conSocket;         //服务器端连接用SOCKET


        /// <summary>
        /// 初始化客户端
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <param name="serverIP"></param>
        /// <param name="serverPort"></param>
        public void InitClient(Socket clientSocket, string serverIP, string serverPort)
        {
            _clientSocket = clientSocket;
            _serverIP = serverIP;
            _serverPort = serverPort;
        }

       /// <summary>
       /// 初始化服务端
       /// </summary>
       /// <param name="serverLocalIP"></param>
       /// <param name="serverLocalPort"></param>
        public void InitServer(string serverLocalIP, string serverLocalPort)
        {
            _serverLocalIP = serverLocalIP;
            _serverLocalPort = serverLocalPort;
        }
        /// <summary>
        /// 释放客户端资源
        /// </summary>
        public void DisposeClient()
        {
            if (_clientSocket != null)
            {
                _clientSocket.Dispose();
            }
            _clientSocket = null;
        }
        /// <summary>
        /// 释放服务端资源
        /// </summary>
        public void DisposeServer()
        {
            if (_conSocket != null)
            {
                _conSocket.Dispose();
            }
            _conSocket = null;
            if (netStream != null)
            {
                netStream.Close();
                readStream.Close();
                writeStream.Close();
                netStream.Dispose();
                readStream.Dispose();
                writeStream.Dispose();
            }
            if (_tcpListener != null)
            {
                _tcpListener.Stop();
            }
            _tcpListener = null;
        }
        /// <summary>
        /// 客户端连接到服务端
        /// </summary>
        /// <returns></returns>
        public bool ClientConnectToServer()
        {
            string STR;
            try
            {
	            //创建负责通信的Socket
	            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	            IPAddress ip = IPAddress.Parse(_serverIP);
	            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(_serverPort));
	            //获得要连接的远程服务器应用程序的IP地址和端口号
	            _clientSocket.Connect(point);
	            if (_clientSocket.Connected == true)
	           {
	               _clientConnOK = true;
	               STR = _serverIP + "连接成功！";
	               return true;
	           }
	            else
	            {
	                _clientConnOK = false;
	                STR = _serverIP + "连接失败，请检查IP是否设置正确，及网线是否连接正常！";
	                return false;
	            }
            }
            catch
            {
                _clientConnOK = false;
                STR = _serverIP + "连接失败，请检查IP是否设置正确，及网线是否连接正常！";
                return false;
            }
        }
        /// <summary>
        /// 客户端发送数据到服务端
        /// </summary>
        /// <param name="data">要发送的数据</param>
        /// <param name="CBCRLF">是否加回车换行</param>
        /// <returns></returns>
        public bool ClientSendDataToServer(string data, bool CBCRLF)
        {
            byte[] msg;
            if (_clientConnOK)
            {
                if (_clientSocket.Connected == true)
                {
                    if (CBCRLF == false)
                    {
                        msg = Encoding.UTF8.GetBytes(data);
                    }
                    else
                    {
                        msg = Encoding.UTF8.GetBytes(data + Environment.NewLine);
                    }
                    _clientSocket.Send(msg);
                    return true;
                }
                return false;
            }
            else
            {
                MessageBox.Show("连接服务器" + _serverIP + "失败，无法发送数据！");
                return false;
            }
        }
        /// <summary>
        /// 客户端接收数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ClientReciveDataFromServer(string data)
        {
            if (_clientSocket.Connected == true)
            {
                try
                {
	                int bytesTotal = 0;
	                _clientSocketBuf = new byte[1024];
	                bytesTotal = _clientSocket.Receive(_clientSocketBuf);
	
	                if (bytesTotal != 0)
	                {
	                    data = Encoding.UTF8.GetString(_clientSocketBuf,0,bytesTotal).ToString().Trim();
	                    return true;
	                }
	                else if (bytesTotal == 0)
	                {
	                    data = "服务器" + _serverIP + "断开连接";
	                    return false;
	                }
                }
                catch (System.Exception ex)
                {
                    data = ex.ToString();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 服务端接收数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ServerReciveDataFromClient(string data)
        {
            if (_clientSocket.Connected == true)
            {
                try
                {
	                int bytesTotal;
	                _serverSocketBuf =new byte[1024];
	                _serverSocketBuf = null;
	                bytesTotal = _clientSocket.Receive(_serverSocketBuf);
	
	                if (bytesTotal != 0)
	                {
	                    data = Encoding.UTF8.GetString(_serverSocketBuf, 0, bytesTotal).ToString().Trim();
	                    return true;
	                }
	                else if(bytesTotal == 0)
	                {
	                    data = "服务器" + _serverIP + "断开连接";
	                    return false;
	                }
                }
                catch (System.Exception ex)
                {
                	data = ex.ToString();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 服务器断开连接，客户端重连
        /// </summary>
        /// <param name="control">用于显示的空间</param>
        /// <param name="reconnCounts">重连次数，默认5次</param>
        /// <param name="waitTime">重连等待时间，默认500ms</param>
        /// <returns></returns>
        public bool reconnect(Control control,int reconnCounts = 5, int waitTime = 500)
        {
            string str = "服务器断开连接，等待重连...";
            control.Text = str;
            control.ForeColor = Color.Red;
            bool pingAgain = true;
            Ping ping = new Ping();
            PingReply pingReply;

            for (int i = 0; i < reconnCounts; i++ )
            {
                IPAddress IP = IPAddress.Parse(_serverLocalIP);
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    Thread.Sleep(waitTime);
                    pingReply = ping.Send(_serverLocalIP);
                    if (pingReply.Status == IPStatus.Success)
                    {
                        _clientSocket.Connect(IPAddress.Parse(_serverLocalIP), Convert.ToInt32(_serverLocalPort));
                        if (_clientSocket.Connected == true)
                        {
                            str = "服务器重新连接上...";
                            control.Text = str;
                            control.ForeColor = Color.Green;
                            pingAgain = true;
                            break;
                        }
                    }
                    else
                    {
                        pingAgain = false;
                        str = "服务器重新连接失败"+i.ToString()+"次";
                        control.Text = str;
                        control.ForeColor = Color.Red;
                    }
                }
                catch
                {
                    pingAgain = false;
                    str = "服务器重新连接失败" + i.ToString() + "次";
                    control.Text = str;
                    control.ForeColor = Color.Red;
                }
            }
            if (pingAgain == false)
            {
                Thread.Sleep(1000);
                str = _serverIP + "重连失败！";
                control.Text = str;
                control.ForeColor = Color.Red;
                return false;
            }
            else
            {
                Thread.Sleep(1000);
                str = _serverIP + "重连成功！";
                control.Text = str;
                control.ForeColor = Color.Green;
                return false;
            }
        }
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="lb_Msg">用于显示消息的ListBox</param>
        /// <param name="msg">要显示的消息内容</param>
        public void DisplayMsg(ListBox lb_Msg, string msg )
        {
            if (msg != null)
            {
                msg = msg.Trim();
                if (lb_Msg.Items.Count <= 100)
                {
                    lb_Msg.Items.Add(DateTime.Now.TimeOfDay.ToString("HH:mm:ss") + "  " + msg);
                    lb_Msg.SelectedIndex = lb_Msg.Items.Count - 1;
                }
                else
                {
                    lb_Msg.Items.Clear();
                }
            }
        }

        /// <summary>
        /// 服务器开始监听
        /// </summary>
        /// <param name="serverMsg">返回的消息</param>
        /// <returns></returns>
        public bool ServerStartListen(ref string serverMsg)
        {
            try
            {
	            IPEndPoint IPPort = new IPEndPoint(IPAddress.Parse(_serverLocalIP),Convert.ToInt32(_serverLocalPort));
	            _tcpListener = new TcpListener(IPPort);
	            string homeName = String.Empty;
	            _tcpListener.Start();
	            _conSocket = _tcpListener.AcceptSocket();
	            serverMsg = "机械手等待连接！";
	            if (_conSocket.Connected == true)
	            {
	                netStream = new NetworkStream(_conSocket);
	                readStream = new StreamReader(netStream);
	                writeStream = new StreamWriter(netStream);
	                serverMsg = "机械手连接成功！";
	                _serverConnOK = true;
	                return true;
	            }
	            else
	            {
	                return false;
	            }
            }
            catch
            {
                serverMsg = "机械手连接失败！";
                _serverConnOK = false;
                ServerBreakListen();
                return false;
            }
        }
        /// <summary>
        /// TCP监控到客户端断开允许重连
        /// </summary>
        /// <returns></returns>
        public bool ServerBreakListen()
        {
            try
            {
	            if (!(netStream == null))
	            {
	                netStream.Close();
	                readStream.Close();
	                writeStream.Close();
	                netStream.Dispose();
	                readStream.Dispose();
	                writeStream.Dispose();
	            }
	            _tcpListener.Stop();
	            if (_conSocket != null)
	            {
	                _conSocket.Disconnect(true);
	                return true;
	            }
	            return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
