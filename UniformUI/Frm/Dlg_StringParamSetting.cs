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
    /// 内容摘要：参数设置页的字符串参数在编辑（isEditMode=true）或者添加新参数时弹出该对话框
    /// 包括主要……模块、……函数及功能是…….
    /// 完成日期：
    /// 版    本：
    /// 作    者：
    /// </summary>
    public partial class Dlg_StringParamSetting : Form
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
        private DataTable paramsStringDataTable = null;
        private SQLiteDataAdapter paramsStringDataAdapter = null;
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

        public Dlg_StringParamSetting()
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

        //对话框加载时，初始化对话框中的数据
        private void Dlg_StringParamSetting_Load(object sender, EventArgs e)
        {
            logger = log4net.LogManager.GetLogger(this.GetType());
            paramsStringDataTable = settingForm.ParamsStringDataTable;
            paramsStringDataAdapter = settingForm.ParamsStringDataAdapter;
            if (isEditMode)
            {
                List<string> stringList = GetDataTableRowValue(paramsStringDataTable, editIndex);
                tb_StringParamName.Text = stringList[1];
                tb_StringParamValue.Text = stringList[2];

                paramName = stringList[1];
                paramValue = stringList[2];

                lbl_Title.Text = "编辑字符串参数";
            }
            if (!isEditMode)
            {
                lbl_Title.Text = "添加字符串参数";
            }

            OpaqueLayerUtils.ShowOpaqueLayer(this.Owner, out m_OpaqueLayer, 170, false);
            AnimateWindow(this.Handle, 500, Convert.ToInt32(WindowsEffect.AW_BLEND));
            StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }

        //重绘窗体为圆角
        private void Dlg_StringParamSetting_Paint(object sender, PaintEventArgs e)
        {
            StyleUtils.DrowRoundedForm(this, 25, 0.1);
        }

        //响应框体拖动事件
        private void Dlg_StringParamSetting_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void Dlg_StringParamSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        //响应确认事件
        private void lbl_EditStringOk_MouseEnter(object sender, EventArgs e)
        {
            lbl_EditStringOk.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_EditStringOk_MouseLeave(object sender, EventArgs e)
        {
            lbl_EditStringOk.BackColor = Color.White;
        }
        private void lbl_EditStringOk_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                AccessControlUtils user = new AccessControlUtils();
                if (user.IsAuthorized(LoginMode.ENGINEERING_MODE))
                {
                    SaveDialogValue();
                    OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    lbl_Tip.ForeColor = Color.Red;
                    lbl_Tip.Text = "密码错误";
                }

            }
        }

        //响应取消事件
        private void lbl_EditStringCancel_MouseEnter(object sender, EventArgs e)
        {
            lbl_EditStringCancel.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_EditStringCancel_MouseLeave(object sender, EventArgs e)
        {
            lbl_EditStringCancel.BackColor = Color.White;
        }
        private void lbl_EditStringCancel_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 检查参数的合法性
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            string currentParamName = tb_StringParamName.Text;
            string currentParamValue = tb_StringParamValue.Text;
            pwd = tb_Password.Text;

            if (String.IsNullOrEmpty(currentParamName))
            {
                lbl_Tip.Text = "参数名称不能为空";
                return false;
            }
            //如果是编辑模式，防止修改参数名称时，与已经存在的参数名称相同
            if (!isEditMode)
            {
                existedParamNames = DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_String, 0);
                if (existedParamNames.Contains(currentParamName))
                {
                    lbl_Tip.Text = "该字符串参数名称已经存在";
                    return false;
                }
            }
            //如果是新建参数，防止新建的参数名称，与已经存在的参数名称相同
            if (isEditMode)
            {
                existedParamNames = DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_String, 0);
                if (existedParamNames.Contains(currentParamName) && !paramName.Equals(currentParamName))
                {
                    lbl_Tip.Text = "该字符串参数名称已经存在";
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
            //编辑模式下，直接修改当前编辑行的参数名称和参数值
            if (isEditMode)
            {
                try
                {
                    paramsStringDataTable.Rows[editIndex][1] = tb_StringParamName.Text;
                    paramsStringDataTable.Rows[editIndex][2] = tb_StringParamValue.Text;
                    settingForm.dgv_Float.DataSource = paramsStringDataTable;
                    paramsStringDataAdapter.Update(paramsStringDataTable);
                }
                catch (System.Exception ex)
                {
                    logger.Debug("修改浮点参数失败！" + ex.Message);
                }
            }
            //新建模式下，直接新建一行
            if (!isEditMode)
            {
                DataRow dr = paramsStringDataTable.NewRow();
                dr[1] = tb_StringParamName.Text;
                dr[2] = tb_StringParamValue.Text;
                paramsStringDataTable.Rows.Add(dr);
                settingForm.dgv_String.DataSource = paramsStringDataTable;
                try
                {
                    paramsStringDataAdapter.Update(paramsStringDataTable);
                }
                catch (System.Exception ex)
                {
                    logger.Debug("添加布尔参数失败！" + ex.Message);
                }
            }
        } 
    }
}
