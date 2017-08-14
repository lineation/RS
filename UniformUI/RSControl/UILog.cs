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
            this.txtLogMsg.Multiline = true;
            this.txtLogMsg.ScrollBars = ScrollBars.Vertical;
            this.txtLogMsg.ReadOnly = true; 
            this.txtLogMsg.TextChanged += txtLogMsg_TextChanged;
            //int.TryParse(System.Configuration.ConfigurationManager.AppSettings["MAX_LOGMSG_TEXT_LENGTH"], out _maxLogmsgTextLength);//优先使用配置文件配置的值
        }

        private void txtLogMsg_TextChanged(object sender, EventArgs e)
        {
            txtLogMsg.SelectionStart = txtLogMsg.Text.Length + 10;
            txtLogMsg.SelectionLength = 0;
            txtLogMsg.ScrollToCaret();
        }

        public void AppendLogMsg(string msg)
        {
            //在UI线程中执行
            txtLogMsg.BeginInvoke(new Action(() =>
            {
                txtLogMsg.AppendText(DateTime.Now.ToString()+ "：" + msg );
                txtLogMsg.AppendText(Environment.NewLine);
            }));
        }

        private void UILog_ClientSizeChanged(object sender, EventArgs e)
        {
            txtLogMsg.Width = this.Width;
            txtLogMsg.Height = this.Height;
        }
    }
}
