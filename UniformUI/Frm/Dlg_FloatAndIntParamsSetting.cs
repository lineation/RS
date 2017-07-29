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
using System.Data.SQLite;

using UniformUI.Utils;
using UniformUI.Module;
using UniformUI.Module.Model;


namespace UniformUI.Frm
{
    /// <summary>
    /// 版权所有(C)2017，
    /// 内容摘要：参数设置页的浮点参数和整型参数在编辑（isEditMode=true）或者添加新参数时弹出该对话框
    /// 完成日期：
    /// 版    本：
    /// 作    者：
    /// </summary>
    public partial class Dlg_FloatAndIntParamsSetting : Form
    {
        #region 字段、属性
        private Point offset;
        private string dgvName;
        private bool isEditMode;
        private int editIndex;
        private List<string> existedParamNames;
        private static log4net.ILog logger = null;
        private OpaqueLayer m_OpaqueLayer = null;
        private Frm_Setting settingForm = new Frm_Setting();
        private string paramName = null;
        private string paramValue = null;
        private string paramMaxValue = null;
        private string paramMinValue = null;
        private string pwd = null;
        private DataTable paramsFloatDataTable = null;
        private SQLiteDataAdapter paramsFloatDataAdapter = null;
        private DataTable paramsIntDataTable = null;
        private SQLiteDataAdapter paramsIntDataAdapter = null;
        private DataTable paramsStringDataTable = null;
        private SQLiteDataAdapter paramsStringDataAdapter = null;

        public string DgvName
        {
            set 
            {
                dgvName = value;
            }
        }
        public bool IsEditMode
        {
            set
            {
                isEditMode = value;
            }
        }
        public int EditIndex
        {
            set 
            {
                editIndex = value;
            }
        }
        #endregion

        #region 初始化窗体
        public Dlg_FloatAndIntParamsSetting()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 300;
            this.StartPosition = FormStartPosition.Manual;
            int x = SystemInformation.PrimaryMonitorSize.Width / 2 - this.Width / 2;
            int y = SystemInformation.PrimaryMonitorSize.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);
        }
        #endregion

        #region 窗体加载时，显示半透遮罩,设置起始鼠标焦点,根据编辑模式设置窗体样式
        private void Dialog_ParamsSetting_Load(object sender, EventArgs e)
        {
            logger = log4net.LogManager.GetLogger(this.GetType());
            if (dgvName == "dgv_Float")
            {
                paramsFloatDataTable = settingForm.ParamsFloatDataTable;
                paramsFloatDataAdapter = settingForm.ParamsFloatDataAdapter;
                if (isEditMode)
                {
                    List<string> floatList = GetDataTableRowValue(paramsFloatDataTable, editIndex);
                	lbl_Title.Text = "编辑浮点参数";
                    tb_ParamName.Text = floatList[1];
                    tb_ParamValue.Text = floatList[2];
                    tb_ParamValue_Max.Text = floatList[3];
                    tb_ParamValue_Min.Text = floatList[4];
                    tb_ParamValue_Max.Enabled = false;
                    tb_ParamValue_Min.Enabled = false;
                    paramName = floatList[1];
                } 
                else
                {
                    lbl_Title.Text = "添加浮点参数";
                }
            }
            else if(dgvName == "dgv_Int")
            {
                paramsIntDataTable = settingForm.ParamsIntDataTable;
                paramsIntDataAdapter = settingForm.ParamsIntDataAdapter;
                if (isEditMode)
                {
                    List<string> intList = GetDataTableRowValue(paramsIntDataTable, editIndex);
                    lbl_Title.Text = "编辑整型参数";
                    tb_ParamName.Text = intList[1];
                    tb_ParamValue.Text = intList[2];
                    tb_ParamValue_Max.Text = intList[3];
                    tb_ParamValue_Min.Text = intList[4];
                    tb_ParamValue_Max.Enabled = false;
                    tb_ParamValue_Min.Enabled = false;

                    paramName = intList[1];
                }
                else
                {
                    lbl_Title.Text = "添加整型参数";
                }
            }
            Utils.OpaqueLayerUtils.ShowOpaqueLayer(this.Owner, out m_OpaqueLayer, 170, false);
            AnimateWindow(this.Handle, 500, Convert.ToInt32(WindowsEffect.AW_BLEND));
            Utils.StyleUtils.DrowRoundedForm(this, 25, 0.1);
            //光标焦点设置
            tb_ParamName.Focus();
        }
        #endregion

        #region 实现窗体圆角样式
        private void Dialog_ParamsSetting_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.DrowRoundedForm(this, 25, 0.2);
        }
        #endregion

        #region 实现任意位置拖动窗体效果
        private void Dialog_ParamsSetting_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void Dialog_ParamsSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        #endregion

        #region 处理"保存"和"取消"相关事件
        private void lbl_Ok_MouseEnter(object sender, EventArgs e)
        {
            lbl_Ok.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_Ok_MouseLeave(object sender, EventArgs e)
        {
            lbl_Ok.BackColor = Color.White;
        }
        private void lbl_Ok_Click(object sender, EventArgs e)
        {
            AccessControlUtils user = new AccessControlUtils();
            if (CheckData(dgvName))
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
                    lbl_Tip.Text = "密码错误";
                }

            }
        }

        private void lbl_Cancel_MouseLeave(object sender, EventArgs e)
        {
            lbl_Cancel.BackColor = Color.White;
        }
        private void lbl_Cancel_MouseEnter(object sender, EventArgs e)
        {
            lbl_Cancel.BackColor = Color.FromArgb(174, 218, 151);
        }
        private void lbl_Cancel_Click(object sender, EventArgs e)
        {
            Utils.OpaqueLayerUtils.HideOpaqueLayer(m_OpaqueLayer);
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region 将弹出窗体中用户输入的数据保存到数据库

        private void SaveDialogValue()
        {
            if ("dgv_Float" == dgvName)
            {
                if (!isEditMode)
                {
	                DataRow dr = paramsFloatDataTable.NewRow();
                    dr[1] = tb_ParamName.Text;
	                dr[2] = paramValue;
	                if (!String.IsNullOrEmpty(paramMaxValue))
	                {
	                    dr[3] = paramMaxValue;
	                }
	                if (!String.IsNullOrEmpty(paramMinValue))
	                {
	                    dr[4] = paramMinValue;
	                }
	
	                paramsFloatDataTable.Rows.Add(dr);
	                settingForm.dgv_Float.DataSource = paramsFloatDataTable;
	                try
	                {
	                	paramsFloatDataAdapter.Update(paramsFloatDataTable);
	                }
	                catch (System.Exception ex)
	                {
                        logger.Debug("添加浮点参数失败！" + ex.Message);
	                }
                } 
                else
                {
                    try
                    {
	                    paramsFloatDataTable.Rows[editIndex][1] = tb_ParamName.Text;
	                    paramsFloatDataTable.Rows[editIndex][2] = tb_ParamValue.Text;
	                    settingForm.dgv_Float.DataSource = paramsFloatDataTable;
	                    paramsFloatDataAdapter.Update(paramsFloatDataTable);
                    }
                    catch (System.Exception ex)
                    {
                        logger.Debug("修改浮点参数失败！" + ex.Message);
                    }
                }
            }
            else if ("dgv_Int" == dgvName)
            {
                if (!isEditMode)
                {
	                DataRow dr = paramsIntDataTable.NewRow();
	                dr[1] = tb_ParamName.Text;
	                dr[2] = paramValue;
	                if (!String.IsNullOrEmpty(paramMaxValue))
	                {
	                    dr[3] = paramMaxValue;
	                }
	                if (!String.IsNullOrEmpty(paramMinValue))
	                {
	                    dr[4] = paramMinValue;
	                }
	                try
	                {
		                paramsIntDataTable.Rows.Add(dr);
		                settingForm.dgv_Float.DataSource = paramsIntDataTable;
		                paramsIntDataAdapter.Update(paramsIntDataTable);
	                }
	                catch (System.Exception ex)
	                {
                        logger.Debug("添加整型参数失败！" + ex.Message);
	                }
                } 
                else
                {
                    try
                    {
	                    paramsIntDataTable.Rows[editIndex][1] = tb_ParamName.Text;
	                    paramsIntDataTable.Rows[editIndex][2] = tb_ParamValue.Text;
	                    settingForm.dgv_Int.DataSource = paramsIntDataTable;
	                    paramsIntDataAdapter.Update(paramsIntDataTable);
                    }
                    catch (System.Exception ex)
                    {
                        logger.Debug("修改整型参数失败！" + ex.Message);
                    }
                }
            }
            else
            {
                paramsStringDataTable = settingForm.ParamsStringDataTable;
                paramsStringDataAdapter = settingForm.ParamsStringDataAdapter;

                DataRow dr = paramsStringDataTable.NewRow();
                dr[1] = tb_ParamName.Text;
                dr[2] = paramValue;
                if (!String.IsNullOrEmpty(paramMaxValue))
                {
                    dr[3] = paramMaxValue;
                }
                if (!String.IsNullOrEmpty(paramMinValue))
                {
                    dr[4] = paramMinValue;
                }
                paramsStringDataTable.Rows.Add(dr);
                settingForm.dgv_Float.DataSource = paramsStringDataTable;
                paramsStringDataAdapter.Update(paramsStringDataTable);
            }
        }

        #region 方法：检查输入数据合法性
        /// <summary>
        /// 检查输入数据合法性
        /// </summary>
        /// <param name="paramType">参数类型，分浮点Float和整型Int</param>
        /// <returns></returns>
        private bool CheckData(string paramType)
        {
            string currentParamName = tb_ParamName.Text;
            paramValue = tb_ParamValue.Text;
            paramMaxValue = tb_ParamValue_Max.Text;
            paramMinValue = tb_ParamValue_Min.Text;
            pwd = tb_Password.Text;

            if (String.IsNullOrEmpty(currentParamName))
            {
                lbl_Tip.Text = "参数名称不能为空";
                return false;
            }
            if (String.IsNullOrEmpty(paramValue))
            {
                lbl_Tip.Text = "参数值不能为空";
                return false;
            }
            if (!String.IsNullOrEmpty(paramMaxValue) && !String.IsNullOrEmpty(paramMaxValue))
            {
                if (paramType == "dgv_Int")
                {
                    //值必须在最大和最小之间
                    int max=0;
                    int min=0;
                    int val=0;
                    try
                    {
                        max = Convert.ToInt32(paramMaxValue);
                        min = Convert.ToInt32(paramMinValue);
                        val = Convert.ToInt32(paramValue);
                    }
                    catch (System.Exception ex)
                    {
                        lbl_Tip.Text = "请输入合法的整型值";
                        return false;
                    }
                   
                    if (val > max)
                    {
                        lbl_Tip.Text = "参数值必须小于最大值";
                        return false;
                    }else if (val < min)
                    {
                        lbl_Tip.Text = "参数值必须大于最小值";
                        return false;
                    }
                }
                else
                {
                    double max = Convert.ToDouble(paramMaxValue);
                    double min = Convert.ToDouble(paramMinValue);
                    double val = Convert.ToDouble(paramValue);
                    if (val > max)
                    {
                        lbl_Tip.Text = "参数值必须小于最大值";
                        return false;
                    }
                    else if (val < min)
                    {
                        lbl_Tip.Text = "参数值必须大于最小值";
                        return false;
                    }
                }
            }
            if (paramType == "dgv_Int")
            {
                if (!isEditMode)
                {
	                existedParamNames = Utils.DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_Int, 0);
                    if (existedParamNames.Contains(currentParamName))
	                {
	                    lbl_Tip.Text = "该整型参数已经存在";
	                    return false;
	                }
                }
                if (isEditMode)
                {
                    existedParamNames = Utils.DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_Int, 0);
                    if (existedParamNames.Contains(currentParamName) && !paramName.Equals(currentParamName))
                    {
                        lbl_Tip.Text = "该整型参数已经存在";
                        return false;
                    }
                }
            }
            else if (paramType == "dgv_Float")
            {
                if (!isEditMode)
                {
	                existedParamNames = Utils.DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_Float, 0);
                    if (existedParamNames.Contains(currentParamName))
	                {
                        lbl_Tip.Text = "该浮点型已经存在";
	                    return false;
	                }
                }
                if (isEditMode)
                {
                    existedParamNames = Utils.DataGridViewUtils.GetDataGridViewColumnValue(settingForm.dgv_Float, 0);
                    if (existedParamNames.Contains(currentParamName) && !paramName.Equals(currentParamName))
                    {
                        lbl_Tip.Text = "该浮点型参数已经存在";
                        return false;
                    }
                }
            }
            return true;
        }


        //控制参数值、最大值、最小值3个TextBox只能输入数字、小数点和退格键
        private void tb_ParamValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//允许输入退格键  
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46))
                {
                    e.Handled = true;
                }
            }
        }
        private void tb_ParamValue_Max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//允许输入退格键  
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46))
                {
                    e.Handled = true;
                }
            }
        }
        private void tb_ParamValue_Min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//允许输入退格键  
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion
        
        #endregion

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
            for (int i = 0; i < dt.Columns.Count; i++ )
            {
                ls.Add(dt.Rows[rowIndex][i].ToString());
            }
            return ls;
        }
        #endregion

        #region 引入窗体动画效果方法
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        #endregion
    }
}
        