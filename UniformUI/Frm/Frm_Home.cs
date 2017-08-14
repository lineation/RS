using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniformUI.Module.Model;

namespace UniformUI.Frm
{
    
    public partial class Frm_Home : Form
    {
        public Frm_Home()
        {
            InitializeComponent();
            Common.AppendUiLog += uiLog.AppendLogMsg;
        }

        private void Frm_Home_Load(object sender, EventArgs e)
        {
            Common.AppendUiLog("home页面加载成功...");
        }
    }
}
