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
using UniformUI.Module.Model;
using UniformUI.Utils;

namespace UniformUI.Frm
{
    public partial class Dlg_HomingSetting : Form
    {

        #region 字段、属性
        private OpaqueLayer m_OpaqueLayer = null;
        private Point offset;
        private static log4net.ILog logger = null;
        private Frm_Setting settingForm = new Frm_Setting();
        private List<string> existedAxisNames;
        private string paramName = null;
        private string paramValue = null;
        private string pwd = null;
        private int editIndex;
        private bool isEditMode;
        private DataTable homingDataTable = null;
        private SQLiteDataAdapter homingDataAdapter = null;
        public int EditIndex
        {
            set
            {
                editIndex = value;
            }
        }
        public bool IsEditMode
        {
            set
            {
                isEditMode = value;
            }
        }
        #endregion

        public Dlg_HomingSetting()
        {
            InitializeComponent();

            this.Width = 300;
            this.Height = 460;
            this.StartPosition = FormStartPosition.Manual;
            int x = SystemInformation.PrimaryMonitorSize.Width / 2 - this.Width / 2;
            int y = SystemInformation.PrimaryMonitorSize.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);

            
        }

        #region 引入窗体动画效果方法
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

        private void Dlg_HomingSetting_Load(object sender, EventArgs e)
        {
            logger = log4net.LogManager.GetLogger(this.GetType());
            homingDataTable = settingForm.HomingDataTable;
            homingDataAdapter = settingForm.HomingDataAdapter;
            if (isEditMode)
            {
                List<string> stringList = GetDataTableRowValue(homingDataTable, editIndex);
                cb_AxisName.Text = stringList[1];
                tb_AxisNum.Text = stringList[2];

                paramName = stringList[1];
                paramValue = stringList[2];

                lbl_Title.Text = "编辑回零参数";
            }
            if (!isEditMode)
            {
                lbl_Title.Text = "添加回零参数";
            }

            OpaqueLayerUtils.ShowOpaqueLayer(this.Owner, out m_OpaqueLayer, 170, false);
            AnimateWindow(this.Handle, 500, Convert.ToInt32(WindowsEffect.AW_BLEND));
            StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }

        #region 获取DataTable中的指定行数据
        /// <summary>
        /// 获取DataTable中的指定行数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private List<string> GetDataTableRowValue(DataTable dt, int rowIndex)
        {
            List<string> ls = new List<string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ls.Add(dt.Rows[rowIndex][i].ToString());
            }
            return ls;
        }
        #endregion

        private void Dlg_HomingSetting_Paint(object sender, PaintEventArgs e)
        {
            StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }

        private void lbl_EditHomingOk_MouseEnter(object sender, EventArgs e)
        {
            lbl_EditHomingOk.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void lbl_EditHomingOk_MouseLeave(object sender, EventArgs e)
        {
            lbl_EditHomingOk.BackColor = Color.White;
        }

        private void lbl_EditHomingOk_Click(object sender, EventArgs e)
        {
            //AccessControlUtils user = new AccessControlUtils();
            //if (CheckData())
            //{
            //    if (user.IsAuthorized(LoginMode.ENGINEERING_MODE))
            //    {
            //        SaveDialogValue();
            //        OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
            //        this.DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        lbl_Tip.ForeColor = Color.Red;
            //        lbl_Tip.Text = "密码错误！";
            //    }

            //}
        }

        private void lbl_EditHomingCancel_MouseEnter(object sender, EventArgs e)
        {
            lbl_EditHomingCancel.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void lbl_EditHomingCancel_MouseLeave(object sender, EventArgs e)
        {
            lbl_EditHomingCancel.BackColor = Color.White;
        }

        private void lbl_EditHomingCancel_Click(object sender, EventArgs e)
        {
            OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
            this.DialogResult = DialogResult.Cancel;
        }

       
    }
}
