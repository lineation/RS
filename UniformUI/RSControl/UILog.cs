using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniformUI.RSControl
{
    public partial class UILog : UserControl
    {
        private static int _maxLogmsgTextLength = 10000;//日志框最大输入
        public UILog()
        {
            InitializeComponent();
        }

        private void UILog_Load(object sender, EventArgs e)
        {
            this.txtLogMsg.Multiline = true;//多选， 一般在界面中就设置了
            this.txtLogMsg.ScrollBars = ScrollBars.Vertical;//日志输出显示纵向滚动条
            this.txtLogMsg.ReadOnly = true; //输出日志只读
            this.txtLogMsg.TextChanged += txtLogMsg_TextChanged;//注册改变事件
            //int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MAX_LOGMSG_TEXT_LENGTH"], out _maxLogmsgTextLength);//优先使用配置文件配置的值
        }

        private void txtLogMsg_TextChanged(object sender, EventArgs e)
        {
            txtLogMsg.SelectionStart = txtLogMsg.Text.Length + 10;//设置选中文字的开始位置为文本框的文字的长度，如果超过了文本长度，则默认为文本的最后。
            txtLogMsg.SelectionLength = 0;//设置被选中文字的长度为0（将光标移动到文字最后）
            txtLogMsg.ScrollToCaret();//将滚动条移动到光标位置
        }

        public void AppendLogMsg(string msg)
        {
            //在UI线程中执行
            txtLogMsg.BeginInvoke(new Action(() =>
            {
                txtLogMsg.AppendText(msg);
                txtLogMsg.AppendText(Environment.NewLine);//追加换行符
            }));
        }

        private void UILog_ClientSizeChanged(object sender, EventArgs e)
        {
            txtLogMsg.Width = this.Width;
            txtLogMsg.Height = this.Height;
        }
    }
}
