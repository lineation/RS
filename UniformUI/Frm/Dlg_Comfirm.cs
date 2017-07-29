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
    public partial class Dlg_Comfirm : Form
    {
        private OpaqueLayer m_OpaqueLayer = null;
        private Point offset;

        public Dlg_Comfirm(string title, string content)
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 180;
            this.StartPosition = FormStartPosition.Manual;
            int x = SystemInformation.PrimaryMonitorSize.Width / 2 - this.Width / 2;
            int y = SystemInformation.PrimaryMonitorSize.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);

            lbl_ConfirmTitle.Text = title;
            lbl_ConfirmContent.Text = content;
        }
        #region 引入窗体动画效果方法
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion
        private void Dlg_Comfirm_Load(object sender, EventArgs e)
        {
            //Utils.OpaqueLayerUtils.ShowOpaqueLayer(this.Owner, out m_OpaqueLayer, 170, false);
            AnimateWindow(this.Handle, 500, Convert.ToInt32(WindowsEffect.AW_BLEND));
            Utils.StyleUtils.DrowRoundedForm(this, 25, 0.1);
            this.lbl_ConfirmContent.WordWrap = true;
            this.lbl_ConfirmContent.AutoSize = false;
        }
        private void Dlg_Comfirm_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }
        //框体拖动
        private void Dlg_Comfirm_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void Dlg_Comfirm_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        //响应确认
        private void lbl_ConfirmOk_MouseEnter(object sender, EventArgs e)
        {
            lbl_ConfirmOk.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_ConfirmOk_MouseLeave(object sender, EventArgs e)
        {
            lbl_ConfirmOk.BackColor = Color.White;
        }
        private void lbl_ConfirmOk_Click(object sender, EventArgs e)
        {
            //Utils.OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
            this.DialogResult = DialogResult.OK;
        }
        //响应取消
        private void lbl_ConfirmCancel_MouseEnter(object sender, EventArgs e)
        {
            lbl_ConfirmCancel.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_ConfirmCancel_MouseLeave(object sender, EventArgs e)
        {
            lbl_ConfirmCancel.BackColor = Color.White;
        }
        private void lbl_ConfirmCancel_Click(object sender, EventArgs e)
        {
            //Utils.OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
            this.DialogResult = DialogResult.Cancel;
        }

        
    }
}
