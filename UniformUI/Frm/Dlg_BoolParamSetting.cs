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
using UniformUI.Module;
using UniformUI.Module.Model;
using UniformUI.Utils;

namespace UniformUI.Frm
{
    /// <summary>
    /// 版权所有(C)2017，
    /// 内容摘要：参数设置页的布尔参数在编辑（isEditMode=true）或者添加新参数时弹出该对话框
    /// 完成日期：
    /// 版    本：
    /// 作    者：
    /// </summary>
    public partial class Dlg_BoolParamSetting : Form
    {
        #region 字段、属性
        private OpaqueLayer m_OpaqueLayer = null;
        private Point offset;
        private static log4net.ILog logger = null;
        private Frm_Setting settingForm = new Frm_Setting();
        private List<string> existedParamNames;
        private string paramName = null;
        private string paramValue = null;
        private string pwd = null;
        private int editIndex;
        private bool isEditMode;
        private DataTable paramsBoolDataTable = null;
        private SQLiteDataAdapter paramsBoolDataAdapter = null;

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
        public Dlg_BoolParamSetting()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 180;
            this.StartPosition = FormStartPosition.Manual;
            int x = SystemInformation.PrimaryMonitorSize.Width / 2 - this.Width / 2;
            int y = SystemInformation.PrimaryMonitorSize.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
        }
        #region 引入窗体动画效果方法
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion

        private void Dlg_BoolParamSetting_Load(object sender, EventArgs e)
        {
            logger = log4net.LogManager.GetLogger(this.GetType());
            paramsBoolDataTable = settingForm.ParamsBoolDataTable;
            paramsBoolDataAdapter = settingForm.ParamsBoolDataAdapter;
            if (isEditMode)
            {
	            List<string> boolList = GetDataTableRowValue(paramsBoolDataTable, editIndex);
	            tb_BoolParamName.Text = boolList[1];
	            switchButton_BoolValue.Value = Convert.ToBoolean(boolList[2]);
                paramName = boolList[1];
                paramValue = boolList[2];
                lbl_Title.Text = "编辑布尔参数";
            }
            if (!isEditMode)
            {
                lbl_Title.Text = "添加布尔参数";
            }

            OpaqueLayerUtils.ShowOpaqueLayer(this.Owner, out m_OpaqueLayer, 170, false);
            AnimateWindow(this.Handle, 500, Convert.ToInt32(WindowsEffect.AW_BLEND));
            StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }
        //实现窗体圆角样式
        private void Dlg_BoolParamSetting_Paint(object sender, PaintEventArgs e)
        {
            StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }
        //框体拖动
        private void Dlg_BoolParamSetting_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void Dlg_BoolParamSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        //响应确认
        private void lbl_EditBoolOk_MouseEnter(object sender, EventArgs e)
        {
            lbl_EditBoolOk.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_EditBoolOk_MouseLeave(object sender, EventArgs e)
        {
            lbl_EditBoolOk.BackColor = Color.White;
        }
        private void lbl_EditBoolOk_Click(object sender, EventArgs e)
        {
            AccessControlUtils user = new AccessControlUtils();
            if (CheckData())
            {
                if (user.IsAuthorized(LoginMode.ENGINEERING_MODE))
                {
                    SaveDialogValue();
                    OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    lbl_Tip.ForeColor = Color.Red;
                    lbl_Tip.Text = "密码错误！";
                }

            }
        }
        //响应取消
        private void lbl_EditBoolCancel_MouseEnter(object sender, EventArgs e)
        {
            lbl_EditBoolCancel.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_EditBoolCancel_MouseLeave(object sender, EventArgs e)
        {
            lbl_EditBoolCancel.BackColor = Color.White;
        }
        private void lbl_EditBoolCancel_Click(object sender, EventArgs e)
        {
            OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
            this.DialogResult = DialogResult.Cancel;
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
        private bool CheckData()
        {
            string currentParamName = tb_BoolParamName.Text;
            string currentParamValue = switchButton_BoolValue.Value.ToString();
            pwd = tb_Password.Text;

            if (String.IsNullOrEmpty(currentParamName))
            {
                lbl_Tip.Text = "参数名称不能为空";
                return false;
            }
            if (!isEditMode)
            {
	            existedParamNames = DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_Bool, 0);
                if (existedParamNames.Contains(currentParamName))
	            {
	                lbl_Tip.Text = "该布尔参数名称已经存在";
	                return false;
	            }
            }
            if (isEditMode)
            {
                existedParamNames = DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_Bool, 0);
                if (existedParamNames.Contains(currentParamName) && !paramName.Equals(currentParamName))
                {
                    lbl_Tip.Text = "该布尔参数名称已经存在";
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 保存对话框中的参数到数据源，并更新到数据库和datagridview中
        /// </summary>
        private void SaveDialogValue()
        {
            if (isEditMode)
            {
	            try
	            {
	                paramsBoolDataTable.Rows[editIndex][1] = tb_BoolParamName.Text;
	                paramsBoolDataTable.Rows[editIndex][2] = switchButton_BoolValue.Value.ToString();
	                settingForm.dgv_Bool.DataSource = paramsBoolDataTable;
	                paramsBoolDataAdapter.Update(paramsBoolDataTable);
	            }
	            catch (System.Exception ex)
	            {
	                logger.Debug("修改浮点参数失败！" + ex.Message);
	            }
            }

            if (!isEditMode)
            {
	            DataRow dr = paramsBoolDataTable.NewRow();
                dr[1] = tb_BoolParamName.Text; ;
                dr[2] = switchButton_BoolValue.Value.ToString(); ;
	            paramsBoolDataTable.Rows.Add(dr);
	            settingForm.dgv_Bool.DataSource = paramsBoolDataTable;
	            try
	            {
	                paramsBoolDataAdapter.Update(paramsBoolDataTable);
	            }
	            catch (System.Exception ex)
	            {
	                logger.Debug("添加布尔参数失败！" + ex.Message);
	            }
            }
        }
       
    }
}
