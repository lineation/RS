using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniformUI.Module.DAL;
using UniformUI.Module.Model;
using UniformUI.Utils;

namespace UniformUI.Frm
{
    public partial class Dlg_AddDevice : Form
    {
        private Point m_Offset;
        private static log4net.ILog logger = null;
        private VisionDeviceService visionDevices = new VisionDeviceService();
        private VisionDeviceModel visionDeviceModel = new VisionDeviceModel();
        private SQLiteDataAdapter m_DeviceDataAdapter;
        private DataTable m_DeviceDataTable;
        private Frm_Vision visionForm = null;
        private static int runCount = 0;

        public Dlg_AddDevice()
        {
            InitializeComponent();
            lbl_AddDeviceCancel.BackColor = Color.FromArgb(238, 238, 239);
            lbl_AddDeviceOk.BackColor = Color.FromArgb(238, 238, 239);

            visionDevices.CreatVisionDeviceTable("VisionDevice");
            m_DeviceDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_VisionDevice, out m_DeviceDataAdapter, "test1", "VisionDevice");
        }

        #region 引入窗体动画效果方法
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

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

        private void Dlg_AddDevice_Load(object sender, EventArgs e)
        {
            logger = log4net.LogManager.GetLogger(this.GetType());
            if (runCount <= 0)
            {
                runCount++;
	            visionForm = new Frm_Vision();
	            m_DeviceDataAdapter = visionForm.DeviceInfoDataAdapter;
	            m_DeviceDataTable = visionForm.DeviceInfoDataTable;
            }

            //AnimateWindow(this.Handle, 1000, Convert.ToInt32(WindowsEffect.AW_BLEND));
        }

        #region 响应取消键
        private void lbl_AddDeviceCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lbl_AddDeviceCancel_MouseEnter(object sender, EventArgs e)
        {
            lbl_AddDeviceCancel.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void lbl_AddDeviceCancel_MouseLeave(object sender, EventArgs e)
        {
            lbl_AddDeviceCancel.BackColor = Color.FromArgb(238, 238, 239);
        }
        #endregion

        #region 响应确认键
        private void lbl_AddDeviceOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbl_SelectedInfo.Text))
            {
                DataRow dr = m_DeviceDataTable.NewRow();
                List<string> ls = DataGridViewUtils.GetDataGridViewColumnValue(visionForm.dgv_VisionDeviceInfo, 2);
                if (ls.Count != 0)
                {
                    dr[0] = (Convert.ToInt32(ls.Max())+1).ToString();
                }
                else
                {
                    dr[0] = "0";
                }
                dr[1] = lbl_SelectedInfo.Text; ;
                m_DeviceDataTable.Rows.Add(dr);
                visionForm.dgv_VisionDeviceInfo.DataSource = m_DeviceDataTable;
                try
                {
                    m_DeviceDataAdapter.Update(m_DeviceDataTable);
                }
                catch (System.Exception ex)
                {
                    logger.Debug("添加VisionDevice失败！" + ex.Message);
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            
        }

        private void lbl_AddDeviceOk_MouseEnter(object sender, EventArgs e)
        {
            lbl_AddDeviceOk.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void lbl_AddDeviceOk_MouseLeave(object sender, EventArgs e)
        {
            lbl_AddDeviceOk.BackColor = Color.FromArgb(238, 238, 239);
        }
        #endregion

        #region 窗体拖动
        private void lbl_Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            m_Offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void lbl_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - m_Offset.X, cur.Y - m_Offset.Y);
        }
        #endregion

        private void dgv_VisionDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> ls = DataGridViewUtils.GetDataGridViewCurrentValues(dgv_VisionDevice);
            lbl_SelectedInfo.Text = ls[0];
        }

       
    }
}
