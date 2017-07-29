using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniformUI.Module.Model;
using UniformUI.Utils;

namespace UniformUI.Frm
{
    public partial class Frm_LockScreen : Form
    {
        public Frm_LockScreen()
        {
            InitializeComponent();
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            this.WindowState = FormWindowState.Maximized;
            int x_Start = screenWidth / 2 - 80;
            int y_Start = screenHeight / 2 - 135;
            rl_CorpName.Location = new Point(x_Start,y_Start);
            pb_LockImage.Height = screenHeight - 100;
            pb_LockImage.Width = screenWidth;

            lbl_UserName.Location = new Point(screenWidth/2 - 80, screenHeight-80);
            tb_Username.Location = new Point(screenWidth / 2, screenHeight - 80);
            lbl_Pwd.Location = new Point(screenWidth / 2-80, screenHeight - 40);
            tb_Password.Location = new Point(screenWidth / 2, screenHeight - 40);
            rlbl_logo.Location = new Point(screenWidth / 2 - 250, screenHeight - 73);
            btn_Unlock.Location = new Point(screenWidth / 2 + 170, screenHeight - 82);
        }

        private void btn_Unlock_ButtonClick()
        {
            AccessControlUtils user = new AccessControlUtils();
            if (user.IsAuthorized(tb_Username.Text.Trim(), tb_Password.Text.Trim()))
            {
                this.Hide();
            }
        }

        private void tb_Username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                tb_Password.Focus();
            }
        }

        private void tb_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btn_Unlock_ButtonClick();
            }
        }


    }
}
