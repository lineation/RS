using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniformUI.Module;
using UniformUI.Module.Model;
using UniformUI.Utils;

namespace UniformUI.Frm
{
    public partial class Frm_Login : Form
    {
        //登陆模式，默认Production Mode
        private LoginMode loginMode = LoginMode.PRODUCTION_MODE;
        private static log4net.ILog logger;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            #region 页面布局
            int userWidth = Screen.PrimaryScreen.Bounds.Width;
            int userHeight = Screen.PrimaryScreen.Bounds.Height;
            int gap = 15;
            int frToolbar1_Height = 86;
            int roundRect_Height = 70;
            this.fr_LoginMode.Width = 3 * (userWidth - 3 * gap) / 4;
            this.fr_LoginMode.Height = userHeight - frToolbar1_Height - 2 * gap - roundRect_Height;
            this.fr_Login.Width = (userWidth - 3 * 20) / 4;
            this.fr_Login.Height = (userHeight - frToolbar1_Height - 3 * gap) / 2;
            Point fr_LoginMode_StartPoint = new Point(gap, gap + roundRect_Height);
            Point fr_Login_StartPoint = new Point(fr_LoginMode.Width + 2 * gap, 0);
            fr_LoginMode.Location = fr_LoginMode_StartPoint;
            fr_Login.Location = fr_Login_StartPoint;
            #endregion
        }
        private void fr_Login_ButtonClick()
        {
            Login();
        }
        private void Login()
        {
            logger = log4net.LogManager.GetLogger(this.GetType());
            AccessControlUtils user = new AccessControlUtils();
            user.Username = fr_Login.Text1;
            user.Password = fr_Login.Text2;
            user.LoginMode = loginMode;

            if ((LoginMode.PRODUCTION_MODE) == loginMode)
            {
                if (user.IsAuthorized(LoginMode.PRODUCTION_MODE))
	            {
	                MessageBox.Show("Production Mode登陆成功！");
	            }
            }
            else if ((LoginMode.ENGINEERING_MODE) == loginMode)
            {
                if (user.IsAuthorized(LoginMode.ENGINEERING_MODE))
                {
                    MessageBox.Show("Engineering Mode登陆成功！");
                }
            }
            else if ((LoginMode.CPKGRR_MODE) == loginMode)
            {
                if (user.IsAuthorized(LoginMode.CPKGRR_MODE))
                {
                    MessageBox.Show("CPK/GRR Mode登陆成功！");
                }
            }
        }

        private void fr_LoginMode_ButtonClick(int Index)
        {
            switch (Index)
            {
                case 0:
                    loginMode = (LoginMode)Index;
                    break;
                case 1:
                    loginMode = (LoginMode)Index;
                    break;
                case 2:
                    loginMode = (LoginMode)Index;
                    break;
                default: logger.Error("登录模式错误！");
                    break;
            }
        }
    }
}
