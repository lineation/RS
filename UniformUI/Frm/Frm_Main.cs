using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using UniformUI.Utils;
using UniformUI.Frm;
using System.Reflection;
using DevComponents.DotNetBar.Keyboard;

namespace UniformUI.Frm
{
    public partial class Frm_Main : Form
    {
        #region 窗体初始化
        Frm_Setting settingForm = null;
        Frm_Home homeForm = null;
        Frm_Login loginForm = null;
        Dlg_FloatAndIntParamsSetting paramsSettingDialog = null;
        Frm_LockScreen lockScreenForm = new Frm_LockScreen();
        Frm_Vision visionFrom = new Frm_Vision();
        Dlg_Version versionDialog = new Dlg_Version();
        
        #region 解决闪烁问题
        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        public Frm_Main()
        {
            InitializeComponent();
            settingForm = new Frm_Setting();
            homeForm = new Frm_Home();
            loginForm = new Frm_Login();
            paramsSettingDialog = new Dlg_FloatAndIntParamsSetting();


//             string xmlPath =  FileUtils.GetAppDirectory() + @"\Config\setting.xml";
//             XmlUtils xmlUtils = new XmlUtils(xmlPath);
//             meiz = xmlUtils.GetValue(@"//root/meiz");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //修改主窗体的样式
            StyleUtils.MainFormStyle(this);
            //修改子窗体的样式
            StyleUtils.SetMdiStyle(this, homeForm, 0, frToolbar1.Height);
            StyleUtils.SetMdiStyle(this, settingForm, 0, frToolbar1.Height);
            StyleUtils.SetMdiStyle(this, loginForm, 0, frToolbar1.Height);
            StyleUtils.SetMdiStyle(this, visionFrom, 0, frToolbar1.Height);
            //设置toolbar的宽度
            int gap = 10;
            var currentWidth = Screen.PrimaryScreen.Bounds.Width-gap;
            frToolbar1.Width = currentWidth;
            frToolbar1.Location = new Point(gap,0);

//             Type frToolbarType = frToolbar1.GetType();
//             PropertyInfo property = frToolbarType.GetProperty("FrButtonA2",
//                   BindingFlags.Instance | BindingFlags.NonPublic);
//             frButtonA1.Caption2 = "tool-A";
//             property.SetValue(frToolbar1, frButtonA1, null);

            
            homeForm.Show();

        }
        #endregion

        #region 按ESC键，退出程序
        /// <summary>
        /// 按ESC退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_ESCKeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Escape)
            {
                 this.DialogResult = DialogResult.OK;
                 this.Close();
            }
        }
        #endregion
        
        #region 响应frToolbar点击事件
        /// <summary>
        /// Toolbar control 
        /// </summary>
        /// <param name="Index">toolbar button index</param>
        private void frToolbar1_ButtonClick(int Index)
        {
            
            switch (Index) 
            {
                case 1:
                    visionFrom.Hide();
                    settingForm.Hide();
                    loginForm.Hide();
                    homeForm.Show();

                    
                    break;
                case 2:
                    visionFrom.Hide();
                    homeForm.Hide();
                    loginForm.Hide();
                    settingForm.Show();

                    break;
                case 3:
                    visionFrom.Show();
                    settingForm.Hide();
                    loginForm.Hide();
                    homeForm.Hide();

                    break;
                case 4: 
                    
                     break;
                case 5: 
                   
                    break;
                case 6:
                    versionDialog.ShowDialog(this);

                    break;
                case 7: 
                   
                    break;
                case 8: 
                    
                    break;
                case 9: 
                    
                    break;
                case 10: 
                    
                    break;
                case 11: 
                   
                    break;
                case 12:
                    settingForm.Hide();
                    homeForm.Hide();
                    loginForm.Show();
                    break;
                default: MessageBox.Show("toolbar error : toolbar index is out of the range !"); break;
            }
        }
        #endregion

        private void btn_LockScreen_Click(object sender, EventArgs e)
        {
            lockScreenForm.ShowDialog(this);
        }


        private void btn_TouchKeyBoard_Click(object sender, EventArgs e)
        {
            this.touchKeyboard1.ShowKeyboard(this, TouchKeyboardStyle.Inline);
        }

    }
}
