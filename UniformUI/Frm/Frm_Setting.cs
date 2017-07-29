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
using HalconDotNet;
using UniformUI.Module;
using UniformUI.Module.BLL;
using UniformUI.Module.DAL;
using UniformUI.Utils;

namespace UniformUI.Frm
{
    public interface IHWindowGraphicStack
    {
        void DisplayResults();
        void AddToStack(HObject o);
    }
    public partial class Frm_Setting : Form, IHWindowGraphicStack
    {
        #region 成员变量：窗体、控件、DataGridView数据初始化，字段属性定义

        private static log4net.ILog m_Logger;
        private int[] m_RGB = new int[] { 238, 238, 239 };
        private Dlg_FloatAndIntParamsSetting m_ParamsSettingDialog;
        private Dlg_BoolParamSetting m_BoolParamSettingDialog;
        private Dlg_StringParamSetting m_StringParamSettingDialog;
        private Dlg_HomingSetting m_HomingSettingDialog;

        private List<HDrawingObject> drawing_objects = new List<HDrawingObject>();
        private UserActions user_actions;
        private Stack<HObject> graphic_stack = new Stack<HObject>();
        private HDrawingObject selected_drawing_object = new HDrawingObject(250, 250, 100);
        private HImage background_image = null;
        private object stack_lock = new object();

        #region 数据库相关属性
        //
        private SQLiteConnection m_Conn = Utils.SQLiteUtils.GetConnection("test1"); 
        //IO设置页
        private SQLiteDataAdapter m_Card0InputDataAdapter;
        private SQLiteDataAdapter m_Card0OutputDataAdapter;
        private SQLiteDataAdapter m_Card1InputDataAdapter;
        private SQLiteDataAdapter m_Card1OutputDataAdapter;
        private DataTable m_Card0InputDataTable;
        private DataTable m_Card0OutputDataTable;
        private DataTable m_Card1InputDataTable;
        private DataTable m_Card1OutputDataTable;
        //参数设置页
        private SQLiteDataAdapter m_ParamsFloatDataAdapter;
        private SQLiteDataAdapter m_ParamsIntDataAdapter;
        private SQLiteDataAdapter m_ParamsBoolDataAdapter;
        private SQLiteDataAdapter m_ParamsStringDataAdapter;
        private DataTable m_ParamsFloatDataTable;
        private DataTable m_ParamsIntDataTable;
        private DataTable m_ParamsBoolDataTable;
        private DataTable m_ParamsStringDataTable;
        //回零设置页
        private SQLiteDataAdapter m_HomingDataAdapter;
        private DataTable m_HomingDataTable;

        public SQLiteDataAdapter HomingDataAdapter
        {
            get { return m_HomingDataAdapter; }
            set { m_HomingDataAdapter = value; }
        }
        public DataTable HomingDataTable
        {
            get { return m_HomingDataTable; }
            set { m_HomingDataTable = value; }
        }

        public SQLiteDataAdapter Card0InputDataAdapter
        {
            get 
            {
                return m_Card0InputDataAdapter;
            }
        }
        public SQLiteDataAdapter Card0OutputDataAdapter
        {
            get
            {
                return m_Card0OutputDataAdapter;
            }
        }
        public SQLiteDataAdapter Card1InputDataAdapter
        {
            get
            {
                return m_Card1InputDataAdapter;
            }
        }
        public SQLiteDataAdapter Card1OutputDataAdapter
        {
            get
            {
                return m_Card1OutputDataAdapter;
            }
        }
        public SQLiteDataAdapter ParamsFloatDataAdapter
        {
            get
            {
                return m_ParamsFloatDataAdapter;
            }
        }
       
        public SQLiteDataAdapter ParamsIntDataAdapter
        {
            get
            {
                return m_ParamsIntDataAdapter;
            }
        }
        public SQLiteDataAdapter ParamsBoolDataAdapter
        {
            get
            {
                return m_ParamsBoolDataAdapter;
            }
        }

        public SQLiteDataAdapter ParamsStringDataAdapter
        {
            get
            {
                return m_ParamsStringDataAdapter;
            }
        }
        public DataTable ParamsFloatDataTable
        {
            get
            {
                return m_ParamsFloatDataTable;
            }
        }
        
        public DataTable ParamsIntDataTable
        {
            get
            {
                return m_ParamsIntDataTable;
            }
        }
        public DataTable ParamsBoolDataTable
        {
            get
            {
                return m_ParamsBoolDataTable;
            }
        }
        public DataTable ParamsStringDataTable
        {
            get
            {
                return m_ParamsStringDataTable;
            }
        }
        public HImage BackgroundImage 
        { 
            get 
            {
                return background_image; 
            } 
        }
        #endregion

        public Frm_Setting()
        {
            InitializeComponent();
            //按屏幕分辨率布局窗体
            FrmLayout();
            //绑定数据源到DataGridview
            DgvBindSource();

            HTuple width, height;
            background_image = new HImage("fabrik");
            background_image.GetImageSize(out width, out height);
            halconWindow.HalconWindow.SetPart(0, 0, height.I - 1, width.I - 1);
            halconWindow.HalconWindow.AttachBackgroundToWindow(background_image);
            user_actions = new UserActions(this);
            this.AttachDrawObj(selected_drawing_object);
        }

        #endregion

        #region 事件：窗体加载事件
        private void SettingForm_Load(object sender, EventArgs e)
        {
            //日志
            m_Logger = log4net.LogManager.GetLogger(this.GetType());
        }
        #endregion

        #region 事件：绘制DataGridView样式
        //修改IO设置页的DataGridView样式
        private void card0Input_dataGridView_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Card0Input, e, m_RGB);
        }

        private void card1Input_dataGridView_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Card1Input, e, m_RGB);
        }

        private void card0Output_dataGridView_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Card0Output, e, m_RGB);
        }

        private void card1Output_dataGridView_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Card1Output, e, m_RGB);
        }

        private void dgv_Card0Input_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StyleUtils.DataGridViewCellBackcolorPaint(dgv_Card0Input, m_Card0InputDataTable, 4);
        }

        private void dgv_Card0Output_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StyleUtils.DataGridViewCellBackcolorPaint(dgv_Card0Output, m_Card0OutputDataTable, 4);
        }

        private void dgv_Card1Input_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StyleUtils.DataGridViewCellBackcolorPaint(dgv_Card1Input, m_Card1InputDataTable, 4);
        }

        private void dgv_Card1Output_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StyleUtils.DataGridViewCellBackcolorPaint(dgv_Card1Output, m_Card1OutputDataTable, 4);
        }


        //修改参数设置页的DataGridView样式
        private void dgv_Float_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Float, e, m_RGB);
        }

        private void dgv_Int_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Int, e, m_RGB);
        }

        private void dgv_Bool_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_Bool, e, m_RGB);
        }

        private void dgv_String_Paint(object sender, PaintEventArgs e)
        {
            Utils.StyleUtils.SetDataGridViewStyle(dgv_String, e, m_RGB);
        }
        #endregion

        #region 事件："全部保存按钮"点击
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (CheckData(dgv_Card0Input)&&CheckData(dgv_Card0Output)&&CheckData(dgv_Card1Input)&&CheckData(dgv_Card1Output))
            {
	            try
	            {
	                //保存I/O设置页
	                m_Card0InputDataAdapter.Update(m_Card0InputDataTable); 
	                m_Card0OutputDataAdapter.Update(m_Card0OutputDataTable);
	                m_Card1InputDataAdapter.Update(m_Card1InputDataTable);
	                m_Card1OutputDataAdapter.Update(m_Card1OutputDataTable);
	                //保存参数设置页
	                m_ParamsBoolDataAdapter.Update(m_ParamsBoolDataTable);
	                m_ParamsStringDataAdapter.Update(m_ParamsStringDataTable); 
	            }
	            catch (System.Exception ex)
	            {
	                m_Logger.Error("全部保存失败！" + ex.Message);
	            }
            } 
            else
            {
                m_Logger.Error("全部保存失败！" );
                Dlg_Comfirm confirmDialog = confirmDialog = new Dlg_Comfirm("提示框", "全部保存失败！");
                confirmDialog.ShowDialog(this);
            }
        }
        #endregion

        #region 事件：I/O设置页保存、刷新和删除的点击
        private void cms_Card0Input_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == toolStripMenuItem_Save)
            {
                if (CheckData(dgv_Card0Input))
                {
	                try
	                {
	                    dgv_Card0Input.CurrentCell = null;
	                    m_Card0InputDataAdapter.Update(m_Card0InputDataTable);
                        RefreshDGV(dgv_Card0Input, out m_Card0InputDataTable, m_Card0InputDataAdapter);
	                }
	                catch(Exception se)
	                {
	                    m_Logger.Error("保存失败！" + se.Message);
	                    SQLiteUtils.CloseDB(m_Conn);
	                    string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card0Input, 0);
	                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡0输入参数：" + cellValue + "失败！");
	                    confirmDialog.ShowDialog(this);
	                }
                }
                else
                {
                    string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card0Input, 0);
                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡0输入参数：" + cellValue + "失败！请检查该轴下是否已有相同点位。");
                    confirmDialog.ShowDialog(this);
                }
            } 
            else if(e.ClickedItem == toolStripMenuItem_update)
            {
                RefreshDGV(dgv_Card0Input, out m_Card0InputDataTable, m_Card0InputDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_delete && !dgv_Card0Input.CurrentRow.IsNewRow)
            {
                string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card0Input, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除卡0输入参数：" + cellValue + "吗？");
                if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (DataGridViewRow dataGridViewRow in dgv_Card0Input.SelectedRows)
                    {
                        if (!dataGridViewRow.IsNewRow)
                        {
                            dgv_Card0Input.Rows.Remove(dataGridViewRow);
                        }
                    }
                    try
                    {
                        dgv_Card0Input.CurrentCell = null;
                        m_Card0InputDataAdapter.Update(m_Card0InputDataTable);
                        RefreshDGV(dgv_Card0Input,out m_Card0InputDataTable, m_Card0InputDataAdapter);
                    }
                    catch (Exception se)
                    {
                        m_Logger.Error("删除失败！" + se.Message);
                        SQLiteUtils.CloseDB(m_Conn);
                    }
                }
            }
        }
        private void cms_Card0Output_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == stripMenuItem_Save)
            {
                if (CheckData(dgv_Card0Output))
                {
	                try
	                {
	                    dgv_Card0Output.CurrentCell = null;
	                    m_Card0OutputDataAdapter.Update(m_Card0OutputDataTable);
                        RefreshDGV(dgv_Card0Output, out m_Card0OutputDataTable, m_Card0OutputDataAdapter);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("保存失败！" + se.Message);
	                    SQLiteUtils.CloseDB(m_Conn);
	                    string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card0Output, 0);
	                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡0输出参数：" + cellValue + "失败！");
	                    confirmDialog.ShowDialog(this);
	                }
                }else
                {
                    string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card0Output, 0);
                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡0输出参数：" + cellValue + "失败！请检查该轴下是否已有相同点位。");
                    confirmDialog.ShowDialog(this);
                }
            }
            else if (e.ClickedItem == stripMenuItem_Update)
            {
                RefreshDGV(dgv_Card0Output, out m_Card0OutputDataTable, m_Card0OutputDataAdapter);
            }
            else if (e.ClickedItem == stripMenuItem_Delete && !dgv_Card0Output.CurrentRow.IsNewRow)
            {
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card0Output, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除卡0输出参数：" + cellValue + "吗？");
                 if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                 {
                     foreach (DataGridViewRow dataGridViewRow in dgv_Card0Output.SelectedRows)
                     {
                         if (!dataGridViewRow.IsNewRow)
                         {
                             dgv_Card0Output.Rows.Remove(dataGridViewRow);
                         }
                     }
                     try
                     {
                         dgv_Card0Output.CurrentCell = null;
                         m_Card0OutputDataAdapter.Update(m_Card0OutputDataTable);
                         RefreshDGV(dgv_Card0Output, out m_Card0OutputDataTable, m_Card0OutputDataAdapter);
                     }
                     catch (Exception se)
                     {
                         m_Logger.Error("删除失败！" + se.Message);
                         Utils.SQLiteUtils.CloseDB(m_Conn);
                     }
                 }
            }
        }
        private void cms_Card1Input_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == toolStripMenuItem_Card1_Input_Save)
            {
                if (CheckData(dgv_Card1Input))
                {
	                try
	                {
	                    dgv_Card1Input.CurrentCell = null;
	                    m_Card1InputDataAdapter.Update(m_Card1InputDataTable);
                        RefreshDGV(dgv_Card1Input, out m_Card1InputDataTable, m_Card1InputDataAdapter);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("保存失败！" + se.Message);
	                    SQLiteUtils.CloseDB(m_Conn);
	                    string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card1Input, 0);
	                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡1输入参数：" + cellValue + "失败！");
	                    confirmDialog.ShowDialog(this);
	                }
                }else
                {
                    string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card1Input, 0);
                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡1输入参数：" + cellValue + "失败！请检查该轴下是否已有相同点位。");
                    confirmDialog.ShowDialog(this);
                }
            }
            else if (e.ClickedItem == toolStripMenuItem_Card1_Input_Update)
            {
                RefreshDGV(dgv_Card1Input, out m_Card1InputDataTable, m_Card1InputDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_Card1_Input_Delete && !dgv_Card1Input.CurrentRow.IsNewRow)
            {
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card1Input, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除卡1输入参数：" + cellValue + "吗？");
                 if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                 {
                     foreach (DataGridViewRow dataGridViewRow in dgv_Card1Input.SelectedRows)
                     {
                         if (!dataGridViewRow.IsNewRow)
                         {
                             dgv_Card1Input.Rows.Remove(dataGridViewRow);
                         }
                     }
                     try
                     {
                         dgv_Card1Input.CurrentCell = null;
                         m_Card1InputDataAdapter.Update(m_Card1InputDataTable);
                         RefreshDGV(dgv_Card1Input, out m_Card1InputDataTable, m_Card1InputDataAdapter);
                     }
                     catch (Exception se)
                     {
                         m_Logger.Error("删除失败！" + se.Message);
                         Utils.SQLiteUtils.CloseDB(m_Conn);
                     }
                 }
            }

        }
        private void cms_Card1Output_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == toolStripMenuItem_Card1_Output_Save)
            {
                if (CheckData(dgv_Card1Output))
                {
	                try
	                {
	                    dgv_Card1Output.CurrentCell = null;
	                    m_Card1OutputDataAdapter.Update(m_Card1OutputDataTable);
                        RefreshDGV(dgv_Card1Output, out m_Card1OutputDataTable, m_Card1OutputDataAdapter);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("保存失败！" + se.Message);
	                    Utils.SQLiteUtils.CloseDB(m_Conn);
	                    string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card1Output, 0);
	                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡1输出参数：" + cellValue + "失败！");
	                    confirmDialog.ShowDialog(this);
	                }
                }else
                {
                    string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card1Output, 0);
                    confirmDialog = new Dlg_Comfirm("提示框", "保存卡1输出参数：" + cellValue + "失败！请检查该轴下是否已有相同点位。");
                    confirmDialog.ShowDialog(this);
                }
            }
            else if (e.ClickedItem == toolStripMenuItem_Card1_Output_Update)
            {
                RefreshDGV(dgv_Card1Output, out m_Card1OutputDataTable, m_Card1OutputDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_Card1_Output_Delete && !dgv_Card1Output.CurrentRow.IsNewRow)
            {
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Card1Output, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除卡1输出参数：" + cellValue + "吗？");
                 if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                 {
                     foreach (DataGridViewRow dataGridViewRow in dgv_Card1Output.SelectedRows)
                     {
                         if (!dataGridViewRow.IsNewRow)
                         {
                             dgv_Card1Output.Rows.Remove(dataGridViewRow);
                         }
                     }
                     try
                     {
                         dgv_Card1Output.CurrentCell = null;
                         m_Card1OutputDataAdapter.Update(m_Card1OutputDataTable);
                         RefreshDGV(dgv_Card1Output, out m_Card1OutputDataTable, m_Card1OutputDataAdapter);
                     }
                     catch (Exception se)
                     {
                         m_Logger.Error("删除失败！" + se.Message);
                         Utils.SQLiteUtils.CloseDB(m_Conn);
                     }
                 }
            }
        }
        #endregion

        #region 事件：参数设置页添加、更新和删除的点击
        private void cms_ParamsFloat_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == toolStripMenuItem_Float_New)
            {
                m_ParamsSettingDialog = new Dlg_FloatAndIntParamsSetting();
                m_ParamsSettingDialog.DgvName = this.dgv_Float.Name;
                m_ParamsSettingDialog.IsEditMode = false;
                if (m_ParamsSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_Float.CurrentCell = null;
                        m_ParamsFloatDataAdapter.Update(m_ParamsFloatDataTable);
                        RefreshDGV(dgv_Float, out m_ParamsFloatDataTable, m_ParamsFloatDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("添加浮点参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                        string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Float, 0);
                        confirmDialog = new Dlg_Comfirm("提示框", "添加浮点参数：" + cellValue + "失败！");
                        confirmDialog.ShowDialog(this);
                    }
                }
            }
            else if (e.ClickedItem == toolStripMenuItem_Float_Update)
            {
                RefreshDGV(dgv_Float, out m_ParamsFloatDataTable, m_ParamsFloatDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_Float_Delete && !dgv_Float.CurrentRow.IsNewRow)
            {
                //弹出删除确认框
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Float, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除浮点参数：" + cellValue + "吗？");
                if (confirmDialog.ShowDialog(this) == DialogResult.OK) 
                {
                    //删除SelectedRows
                    foreach (DataGridViewRow dataGridViewRow in dgv_Float.SelectedRows)
                    {
                        if (!dataGridViewRow.IsNewRow)
                        {
                            dgv_Float.Rows.Remove(dataGridViewRow);
                        }
                    }
                    //更新到数据源
                    try
                    {
                        dgv_Float.CurrentCell = null;
                        m_ParamsFloatDataAdapter.Update(m_ParamsFloatDataTable);
                        RefreshDGV(dgv_Float, out m_ParamsFloatDataTable, m_ParamsFloatDataAdapter);
                    }
                    catch (Exception se)
                    {
                        m_Logger.Error("删除失败！" + se.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                    }
                }
            }
            
        }
        private void cms_ParamsInt_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == toolStripMenuItem_Int_New)
            {
                m_ParamsSettingDialog = new Dlg_FloatAndIntParamsSetting();
                m_ParamsSettingDialog.DgvName = this.dgv_Int.Name;
                m_ParamsSettingDialog.IsEditMode = false;
                if (m_ParamsSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_Int.CurrentCell = null;
                        m_ParamsIntDataAdapter.Update(m_ParamsIntDataTable);
                        RefreshDGV(dgv_Int, out m_ParamsIntDataTable, m_ParamsIntDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("添加整型参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                        string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Int, 0);
                        confirmDialog = new Dlg_Comfirm("提示框", "添加整型参数：" + cellValue + "失败！");
                        confirmDialog.ShowDialog(this);
                    }
                }
            }
            else if (e.ClickedItem == toolStripMenuItem_Int_Update)
            {
                RefreshDGV(dgv_Int, out m_ParamsIntDataTable, m_ParamsIntDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_Int_Delete && !dgv_Int.CurrentRow.IsNewRow)
            {
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Int, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除整型参数：" + cellValue + "吗？");
                if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                {
	                foreach (DataGridViewRow dataGridViewRow in dgv_Int.SelectedRows)
	                {
	                    if (!dataGridViewRow.IsNewRow)
	                    {
	                        dgv_Int.Rows.Remove(dataGridViewRow);
	                    }
	                }
	                try
	                {
	                    dgv_Int.CurrentCell = null;
	                    m_ParamsIntDataAdapter.Update(m_ParamsIntDataTable);
                        RefreshDGV(dgv_Int, out m_ParamsIntDataTable, m_ParamsIntDataAdapter);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("删除失败！" + se.Message);
	                    Utils.SQLiteUtils.CloseDB(m_Conn);
	                }
                }

            }
        }
        private void cms_ParamsBool_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog =  null;
            if (e.ClickedItem == toolStripMenuItem_Bool_New)
            {
                m_BoolParamSettingDialog = new Dlg_BoolParamSetting();
                m_BoolParamSettingDialog.IsEditMode = false;
                if (m_BoolParamSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_Bool.CurrentCell = null;
                        m_ParamsBoolDataAdapter.Update(m_ParamsBoolDataTable);
                        RefreshDGV(dgv_Bool, out m_ParamsBoolDataTable, m_ParamsBoolDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("添加布尔参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                        string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Bool, 0);
                        confirmDialog = new Dlg_Comfirm("提示框", "添加布尔参数：" + cellValue + "失败！");
                        confirmDialog.ShowDialog(this);
                    }
                }
            }
            else if (e.ClickedItem == toolStripMenuItem_Bool_Update)
            {
                RefreshDGV(dgv_Bool, out m_ParamsBoolDataTable, m_ParamsBoolDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_Bool_Delete && !dgv_Bool.CurrentRow.IsNewRow)
            {
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Bool, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除布尔参数：" + cellValue + "吗？");
                if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                {
	                foreach (DataGridViewRow dataGridViewRow in dgv_Bool.SelectedRows)
	                {
	                    if (!dataGridViewRow.IsNewRow)
	                    {
	                        dgv_Bool.Rows.Remove(dataGridViewRow);
	                    }
	                }
	                try
	                {
	                    dgv_Bool.CurrentCell = null;
	                    m_ParamsBoolDataAdapter.Update(m_ParamsBoolDataTable);
                        RefreshDGV(dgv_Bool, out m_ParamsBoolDataTable, m_ParamsBoolDataAdapter);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("删除失败！" + se.Message);
	                    Utils.SQLiteUtils.CloseDB(m_Conn);
	                }
                }

            }
        }
        private void cms_ParasString_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == toolStripMenuItem_String_New)
            {
                m_StringParamSettingDialog = new Dlg_StringParamSetting();
                m_StringParamSettingDialog.IsEditMode = false;
                if (m_StringParamSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_String.CurrentCell = null;
                        m_ParamsStringDataAdapter.Update(m_ParamsStringDataTable);
                        RefreshDGV(dgv_String, out m_ParamsStringDataTable, m_ParamsStringDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("添加字符串参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                        string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_String, 0);
                        confirmDialog = new Dlg_Comfirm("提示框", "添加字符串参数：" + cellValue + "失败！");
                        confirmDialog.ShowDialog(this);
                    }
                }
            }
            else if (e.ClickedItem == toolStripMenuItem_String_Update)
            {
                RefreshDGV(dgv_String, out m_ParamsStringDataTable, m_ParamsStringDataAdapter);
            }
            else if (e.ClickedItem == toolStripMenuItem_String_Delete && !dgv_String.CurrentRow.IsNewRow)
            {
                string cellValue = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_String, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除字符串参数：" + cellValue + "吗？");
                if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                {
	                foreach (DataGridViewRow dataGridViewRow in dgv_String.SelectedRows)
	                {
	                    if (!dataGridViewRow.IsNewRow)
	                        dgv_String.Rows.Remove(dataGridViewRow);
	                }
	           }
	                try
	                {
	                    dgv_String.CurrentCell = null;
	                    m_ParamsStringDataAdapter.Update(m_ParamsStringDataTable);
                        RefreshDGV(dgv_String, out m_ParamsStringDataTable, m_ParamsStringDataAdapter);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("删除失败！" + se.Message);
	                    Utils.SQLiteUtils.CloseDB(m_Conn);
	                }
                }
        }
        #endregion

        #region 事件：cell进入编辑状态时, 弹出编辑对话框
        //dgv_Float, cell进入编辑状态时, 弹出编辑对话框
        private void dgv_Float_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgv_Float.CurrentRow.IsNewRow)
            {
	            m_ParamsSettingDialog = new Dlg_FloatAndIntParamsSetting();
	            m_ParamsSettingDialog.IsEditMode = true;
	            m_ParamsSettingDialog.DgvName = this.dgv_Float.Name;
	            m_ParamsSettingDialog.EditIndex = e.RowIndex;
                if (m_ParamsSettingDialog.ShowDialog(this) == DialogResult.OK)
	            {
                    try
                    {
                        //更新dgv_Float
                        dgv_Float.CurrentCell = null;
                        m_ParamsFloatDataAdapter.Update(m_ParamsFloatDataTable);
                        m_ParamsFloatDataTable = new DataTable();
                        m_ParamsFloatDataAdapter.Fill(m_ParamsFloatDataTable);
                        dgv_Float.DataSource = m_ParamsFloatDataTable;
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("编辑该行数据失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                    }
	            }
                else
                {
                    //定位焦点到首行首列
                    dgv_Float.CurrentCell = dgv_Float[0, 0];
                }
            }
        }
        //dgv_Int,cell进入编辑状态时, 弹出编辑对话框
        private void dgv_Int_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgv_Int.CurrentRow.IsNewRow)
            {
	            m_ParamsSettingDialog = new Dlg_FloatAndIntParamsSetting();
	            m_ParamsSettingDialog.IsEditMode = true;
	            m_ParamsSettingDialog.DgvName = this.dgv_Int.Name;
	            m_ParamsSettingDialog.EditIndex = e.RowIndex;
	            if (m_ParamsSettingDialog.ShowDialog(this)==DialogResult.OK)
	            {
                    try
                    {
                        dgv_Int.CurrentCell = null;
                        m_ParamsIntDataAdapter.Update(m_ParamsIntDataTable);
                        RefreshDGV(dgv_Int, out m_ParamsIntDataTable, m_ParamsIntDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("编辑整型参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                    }
	            }
                else 
                {
                    dgv_Int.CurrentCell = dgv_Int[0, 0];
                }
            }
        }
        //dgv_Bool,cell进入编辑状态时, 弹出编辑对话框
        private void dgv_Bool_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgv_Bool.CurrentRow.IsNewRow)
            {
                m_BoolParamSettingDialog = new Dlg_BoolParamSetting();
                m_BoolParamSettingDialog.EditIndex = e.RowIndex;
                m_BoolParamSettingDialog.IsEditMode = true;
                if (m_BoolParamSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_Bool.CurrentCell = null;
                        m_ParamsBoolDataAdapter.Update(m_ParamsBoolDataTable);
                        RefreshDGV(dgv_Bool, out m_ParamsBoolDataTable, m_ParamsBoolDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("编辑布尔参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                    }
                }
            }
        }
        //dgv_String,cell进入编辑状态时, 弹出编辑对话框
        private void dgv_String_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgv_String.CurrentRow.IsNewRow)
            {
                m_StringParamSettingDialog = new Dlg_StringParamSetting();
                m_StringParamSettingDialog.EditIndex = e.RowIndex;
                m_StringParamSettingDialog.IsEditMode = true;
                if (m_StringParamSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_String.CurrentCell = null;
                        m_ParamsStringDataAdapter.Update(m_ParamsStringDataTable);
                        RefreshDGV(dgv_String, out m_ParamsStringDataTable, m_ParamsStringDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("编辑字符串参数失败！" + ex.Message);
                        Utils.SQLiteUtils.CloseDB(m_Conn);
                    }
                }
                else
                {
                    dgv_String.CurrentCell = dgv_String[0, 0];
                }
            }
        }
        #endregion

        #region 事件：执行单元格点击时，改变状态单元格的背景色
        //卡0
        private void dgv_Card0Output_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean flag = false;
            int currentRowIndex = 0;
            try
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgv_Card0Output.CurrentRow.Cells["卡零执行"];
                flag = Convert.ToBoolean(checkCell.Value);
                currentRowIndex = dgv_Card0Output.CurrentRow.Index;
            }
            catch
            {
                return;
            }

            if (!flag)
            {
                dgv_Card0Output.CurrentCell = null;
                dgv_Card0Output.Rows[currentRowIndex].Cells[3].Style.BackColor = Color.Red;
                m_Card0OutputDataAdapter.Update(m_Card0OutputDataTable);
                RefreshDGV(dgv_Card0Output, out m_Card0OutputDataTable, m_Card0OutputDataAdapter);
            }
            if (flag)
            {
                dgv_Card0Output.CurrentCell = null;
                dgv_Card0Output.Rows[currentRowIndex].Cells[3].Style.BackColor = Color.White;
                m_Card0OutputDataAdapter.Update(m_Card0OutputDataTable);
                RefreshDGV(dgv_Card0Output, out m_Card0OutputDataTable, m_Card0OutputDataAdapter);
            }
        }
        //卡1
        private void dgv_Card1Output_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Boolean flag = false;
            int currentRowIndex = 0;
            try
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgv_Card1Output.CurrentRow.Cells["卡一执行"];
                flag = Convert.ToBoolean(checkCell.Value);
                currentRowIndex = dgv_Card1Output.CurrentRow.Index;
            }
            catch
            {
                return;
            }

            if (!flag)
            {
                dgv_Card1Output.CurrentCell = null;
                dgv_Card1Output.Rows[currentRowIndex].Cells[3].Style.BackColor = Color.Red;
                m_Card1OutputDataAdapter.Update(m_Card1OutputDataTable);
                RefreshDGV(dgv_Card1Output, out m_Card1OutputDataTable, m_Card1OutputDataAdapter);
            }
            if (flag)
            {
                dgv_Card1Output.CurrentCell = null;
                dgv_Card1Output.Rows[currentRowIndex].Cells[3].Style.BackColor = Color.White;
                m_Card1OutputDataAdapter.Update(m_Card1OutputDataTable);
                RefreshDGV(dgv_Card1Output, out m_Card1OutputDataTable, m_Card1OutputDataAdapter);
            }
        }
        #endregion

        #region 方法：I/O参数，修改和保存时,检查同轴下，是否有相同点位
        /// <summary>
        /// I/O参数，修改和保存时需要确保同轴下，不能有相同点位
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private bool CheckData(DataGridView dgv) 
        {
            string currentAxisName = dgv.CurrentRow.Cells[1].Value.ToString();
            string currentPositionName = dgv.CurrentRow.Cells[2].Value.ToString();
            string axisName;
            string positionName;
            
            for (int i = 0; i < dgv.Rows.Count - 2; i++)
            {
                axisName = dgv.Rows[i].Cells[1].Value.ToString();
                positionName = dgv.Rows[i].Cells[2].Value.ToString();
                if (Convert.ToInt16(dgv.CurrentRow.Index.ToString()) != i && axisName.Equals(currentAxisName) && positionName.Equals(currentPositionName))
                {
                    return false;
                }
            }
            int index = 0;
            int count = dgv.Rows.Count - 1;
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (!dgvr.IsNewRow)
                {
	                index = dgvr.Index;
	                currentAxisName = dgv.Rows[index].Cells[1].Value.ToString();
	                currentPositionName = dgv.Rows[index].Cells[2].Value.ToString();
	                for (int i = index + 1; i < count; i++)
	                {
	                    axisName = dgv.Rows[i].Cells[1].Value.ToString();
	                    positionName = dgv.Rows[i].Cells[2].Value.ToString();
	                    if (axisName.Equals(currentAxisName) && positionName.Equals(currentPositionName))
	                    {
	                        return false;
	                    }
	                }
                }
            }
            return true;
        }
        #endregion

        #region 方法：将数据库中的值刷新到datagridview
        /// <summary>
        /// 刷新datagridview
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="dt">DataTable</param>
        /// <param name="sda">SQLiteDataAdapter</param>
        /// <returns></returns>
        private bool RefreshDGV(DataGridView dgv,out DataTable dt,  SQLiteDataAdapter sda)
        {
            dt = new DataTable();
            sda.Fill(dt);
            dgv.DataSource = dt;
            return true;
        }
        #endregion

        #region 方法：绑定数据源到DataGridview
        /// <summary>
        /// 绑定数据源到DataGridview
        /// </summary>
        private void DgvBindSource()
        {
            //IO设置页
            IOSettingServices ios = new IOSettingServices();
            ios.CreateInputSettingTable("InputSetting_Card0", m_Conn);
            ios.CreateInputSettingTable("InputSetting_Card1", m_Conn);
            ios.CreateOutputSettingTable("OutputSetting_Card0", m_Conn);
            ios.CreateOutputSettingTable("OutputSetting_Card1", m_Conn);
            m_Card0InputDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Card0Input, out m_Card0InputDataAdapter, "test1", "InputSetting_Card0");
            m_Card0OutputDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Card0Output, out m_Card0OutputDataAdapter, "test1", "OutputSetting_Card0");
            m_Card1InputDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Card1Input, out m_Card1InputDataAdapter, "test1", "InputSetting_Card1");
            m_Card1OutputDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Card1Output, out m_Card1OutputDataAdapter, "test1", "OutputSetting_Card1");
            //参数设置页
            ParamSettingServices ps = new ParamSettingServices();
            ps.CreateFloatParamsTable("FloatParams", m_Conn);
            ps.CreateIntParamsTable("IntParams", m_Conn);
            ps.CreateBoolParamsTable("BoolParams", m_Conn);
            ps.CreateStringParamsTable("StringParams", m_Conn);
            m_ParamsFloatDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Float, out m_ParamsFloatDataAdapter, "test1", "FloatParams");
            m_ParamsIntDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Int, out m_ParamsIntDataAdapter, "test1", "IntParams");
            m_ParamsBoolDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Bool, out m_ParamsBoolDataAdapter, "test1", "BoolParams");
            m_ParamsStringDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_String, out m_ParamsStringDataAdapter, "test1", "StringParams");
            //回零设置页
            HomeSettingServices hs = new HomeSettingServices();
            hs.CreatHomeSettingTable("HomingSetting", m_Conn);
            m_HomingDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_Home, out m_HomingDataAdapter, "test1", "HomingSetting");
        }
        #endregion

        #region 方法：窗体、控件布局，适应不同分辨率
        /// <summary>
        /// 窗体、控件布局，适应不同分辨率
        /// </summary>
        private void FrmLayout()
        {
            //IO设置页
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Card0Input);
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Card0Output);
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Card1Input);
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Card1Output);
            //参数设置页
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Float);
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Bool);
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_Int);
            Utils.StyleUtils.SetSettingPageDGVStyle(dgv_String);

            int userWidth = Screen.PrimaryScreen.Bounds.Width;
            int userHeight = Screen.PrimaryScreen.Bounds.Height;
            int frToolbar1_Height = 86;
            int gap = 20;
            int xStart_Panel = gap;
            int yStart_Panel = gap;


            //I/O设置页
            int lbl_Card0_Hight = gap;
            int xStart_dgv = gap + xStart_Panel;
            int yStart_dgv = lbl_Card0_Hight + yStart_Panel + 5;
            int frPanel_Width_IO = userWidth / 2 - 3 * gap / 2;
            int frPanel_Height_IO = userHeight - frToolbar1_Height - 4 * gap;
            int dgv_Height_IO = frPanel_Height_IO - 2 * gap - lbl_Card0_Hight + 15;
            int dgv_Input_Width_IO = frPanel_Width_IO / 2 - 2 * gap / 2 - 10;
            int dgv_Output_Width_IO = frPanel_Width_IO / 2 - 2 * gap / 2 + 10;

            Point frPanel_Card0_StartPoint = new Point(xStart_Panel, yStart_Panel);
            Point frPanel_Card1_StartPoint = new Point(xStart_Panel + gap + frPanel_Width_IO, yStart_Panel);
            Point card0Input_dataGridView_StartPoint = new Point(xStart_dgv, yStart_dgv);
            Point card0Output_dataGridView_StartPoint = new Point(xStart_dgv + dgv_Input_Width_IO + gap, yStart_dgv);
            Point card1Input_dataGridView_StartPoint = new Point(xStart_dgv + frPanel_Width_IO + gap, yStart_dgv);
            Point card1Output_dataGridView_StartPoint = new Point(xStart_dgv + frPanel_Width_IO + 2 * gap + dgv_Input_Width_IO, yStart_dgv);
            Utils.StyleUtils.SetControlRelativePosition(frPanel_Card0, frPanel_Card0_StartPoint, frPanel_Width_IO, frPanel_Height_IO);
            Utils.StyleUtils.SetControlRelativePosition(frPanel_Card1, frPanel_Card1_StartPoint, frPanel_Width_IO, frPanel_Height_IO);

            Utils.StyleUtils.SetControlRelativePosition(dgv_Card0Input, card0Input_dataGridView_StartPoint, dgv_Input_Width_IO, dgv_Height_IO);
            Utils.StyleUtils.SetControlRelativePosition(dgv_Card0Output, card0Output_dataGridView_StartPoint, dgv_Input_Width_IO, dgv_Height_IO);
            Utils.StyleUtils.SetControlRelativePosition(dgv_Card1Input, card1Input_dataGridView_StartPoint, dgv_Input_Width_IO, dgv_Height_IO);
            Utils.StyleUtils.SetControlRelativePosition(dgv_Card1Output, card1Output_dataGridView_StartPoint, dgv_Input_Width_IO, dgv_Height_IO);

            Utils.StyleUtils.SetControlRelativePosition(lbl_Card0, new Point(xStart_dgv + dgv_Input_Width_IO, gap + 5), 100, lbl_Card0_Hight);
            Utils.StyleUtils.SetControlRelativePosition(lbl_Card1, new Point(xStart_dgv + frPanel_Width_IO + gap + dgv_Input_Width_IO, gap + 5), 100, lbl_Card0_Hight);

            //参数设置页
            int frPanel_Width_Params = (userWidth - 5 * gap) / 4;
            int frPanel_Height_Params = userHeight - frToolbar1_Height - 4 * gap;
            xStart_dgv = gap / 2 + xStart_Panel;
            yStart_dgv = gap / 2 + yStart_Panel;
            int dgv_Height_Params = frPanel_Height_Params - gap;
            int dgv_Width_Params = frPanel_Width_Params - gap;

            Utils.StyleUtils.SetControlRelativePosition(frPanel_Float, new Point(xStart_Panel, yStart_Panel), frPanel_Width_Params, frPanel_Height_Params);
            Utils.StyleUtils.SetControlRelativePosition(frPanel_Int, new Point(xStart_Panel + gap + frPanel_Width_Params, yStart_Panel), frPanel_Width_Params, frPanel_Height_Params);
            Utils.StyleUtils.SetControlRelativePosition(frPanel_Bool, new Point(xStart_Panel + 2 * gap + 2 * frPanel_Width_Params, yStart_Panel), frPanel_Width_Params, frPanel_Height_Params);
            Utils.StyleUtils.SetControlRelativePosition(frPanel_String, new Point(xStart_Panel + 3 * gap + 3 * frPanel_Width_Params, yStart_Panel), frPanel_Width_Params, frPanel_Height_Params);

            Utils.StyleUtils.SetControlRelativePosition(dgv_Float, new Point(xStart_dgv, yStart_dgv), dgv_Width_Params, dgv_Height_Params);
            Utils.StyleUtils.SetControlRelativePosition(dgv_Int, new Point(xStart_dgv + gap + frPanel_Width_Params, yStart_dgv), dgv_Width_Params, dgv_Height_Params);
            Utils.StyleUtils.SetControlRelativePosition(dgv_Bool, new Point(xStart_dgv + 2 * gap + 2 * frPanel_Width_Params, yStart_dgv), dgv_Width_Params, dgv_Height_Params);
            Utils.StyleUtils.SetControlRelativePosition(dgv_String, new Point(xStart_dgv + 3 * gap + 3 * frPanel_Width_Params, yStart_dgv), dgv_Width_Params, dgv_Height_Params);

            btnSaveAll.ThemeAware = true;
        }
        #endregion

        private void cms_Homing_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Dlg_Comfirm confirmDialog = null;
            if (e.ClickedItem == tsmi_Add)
            {
                m_HomingSettingDialog = new Dlg_HomingSetting();
                m_HomingSettingDialog.IsEditMode = false;
                if (m_HomingSettingDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        dgv_Home.CurrentCell = null;
                        m_HomingDataAdapter.Update(m_HomingDataTable);
                        RefreshDGV(dgv_Home, out m_HomingDataTable, m_HomingDataAdapter);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.Error("添加回零参数失败！" + ex.Message);
                        SQLiteUtils.CloseDB(m_Conn);
                        string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Home, 0);
                        confirmDialog = new Dlg_Comfirm("提示框", "添加回零参数：" + cellValue + "失败！");
                        confirmDialog.ShowDialog(this);
                    }
                }
            }
            else if (e.ClickedItem == tsmi_Update)
            {
                RefreshDGV(dgv_Home, out m_HomingDataTable, m_HomingDataAdapter);
            }
            else if (e.ClickedItem == tsmi_Delete && !dgv_Home.CurrentRow.IsNewRow)
            {
                //弹出删除确认框
                string cellValue = DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_Home, 0);
                confirmDialog = new Dlg_Comfirm("确认框", "确认删除回零参数：" + cellValue + "吗？");
                if (confirmDialog.ShowDialog(this) == DialogResult.OK)
                {
                    //删除SelectedRows
                    foreach (DataGridViewRow dataGridViewRow in dgv_Home.SelectedRows)
                    {
                        if (!dataGridViewRow.IsNewRow)
                        {
                            dgv_Home.Rows.Remove(dataGridViewRow);
                        }
                    }
                    //更新到数据源
                    try
                    {
                        dgv_Home.CurrentCell = null;
                        m_HomingDataAdapter.Update(m_HomingDataTable);
                        RefreshDGV(dgv_Home, out m_HomingDataTable, m_HomingDataAdapter);
                    }
                    catch (Exception se)
                    {
                        m_Logger.Error("删除失败！" + se.Message);
                        SQLiteUtils.CloseDB(m_Conn);
                    }
                }
            }
        }

        #region 方法：Halcon DrawingObjects

        private void OnSelectDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            selected_drawing_object = dobj;
            user_actions.SobelFilter(dobj, hwin, type);
        }

        private void AttachDrawObj(HDrawingObject obj)
        {
            drawing_objects.Add(obj);
            // The HALCON/C# interface offers convenience methods that
            // encapsulate the set_drawing_object_callback operator.
            obj.OnDrag(user_actions.SobelFilter);
            obj.OnAttach(user_actions.SobelFilter);
            obj.OnResize(user_actions.SobelFilter);
            obj.OnSelect(OnSelectDrawingObject);
            obj.OnAttach(user_actions.SobelFilter);
            halconWindow.HalconWindow.AttachDrawingObjectToWindow(obj);
        }

        private void DisplayGraphicStack()
        {
            lock (stack_lock)
            {
                HOperatorSet.SetSystem("flush_graphic", "false");
                halconWindow.HalconWindow.ClearWindow();
                while (graphic_stack.Count > 0)
                {
                    halconWindow.HalconWindow.DispObj(graphic_stack.Pop());
                }
                HOperatorSet.SetSystem("flush_graphic", "true");
            }
            //halconWindow.HalconWindow.DispCross(-10.0, -10.0, 3.0, 0.0);
        }

        /// <summary>
        /// Forces a context switch, so that objects are display in UI thread
        /// </summary>
        public void DisplayResults()
        {
            try
            {
                halconWindow.BeginInvoke((MethodInvoker)delegate() { DisplayGraphicStack(); });
            }
            catch (HalconException hex)
            {
                MessageBox.Show(hex.GetErrorMessage(), "HALCON error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "HALCON error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddToStack(HObject obj)
        {
            lock (stack_lock)
            {
                graphic_stack.Push(obj);
            }
        }

        private void dashedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_drawing_object != null)
                selected_drawing_object.SetDrawingObjectParams(new HTuple("line_style"), new HTuple(20, 5));
        }

        private void continuousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_drawing_object != null)
                selected_drawing_object.SetDrawingObjectParams(new HTuple("line_style"), new HTuple());
        }

        private void rectangle1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDrawingObject rect1 = HDrawingObject.CreateDrawingObject(
            HDrawingObject.HDrawingObjectType.RECTANGLE1, 100, 100, 210, 210);
            rect1.SetDrawingObjectParams("color", "green");
            AttachDrawObj(rect1);
        }

        private void rectangle2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDrawingObject rect2 = HDrawingObject.CreateDrawingObject(
            HDrawingObject.HDrawingObjectType.RECTANGLE2, 100, 100, 0, 100, 50);
            rect2.SetDrawingObjectParams("color", "yellow");
            AttachDrawObj(rect2);
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDrawingObject circle = HDrawingObject.CreateDrawingObject(
            HDrawingObject.HDrawingObjectType.CIRCLE, 200, 200, 70);
            circle.SetDrawingObjectParams("color", "magenta");
            AttachDrawObj(circle);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDrawingObject ellipse = HDrawingObject.CreateDrawingObject(
            HDrawingObject.HDrawingObjectType.ELLIPSE, 50, 50, 0, 100, 50);
            ellipse.SetDrawingObjectParams("color", "blue");
            AttachDrawObj(ellipse);
        }


        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_drawing_object != null)
                selected_drawing_object.SetDrawingObjectParams("color", "red");
        }

        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_drawing_object != null)
                selected_drawing_object.SetDrawingObjectParams("color", "yellow");
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_drawing_object != null)
                selected_drawing_object.SetDrawingObjectParams("color", "green");
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_drawing_object != null)
                selected_drawing_object.SetDrawingObjectParams("color", "blue");
        }

        private void halconWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                cms_Halcom.Show(this, new Point(e.X, e.Y));
        }

        private void clearAllObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (stack_lock)
            {
                foreach (HDrawingObject dobj in drawing_objects)
                {
                    dobj.Dispose();
                }
                drawing_objects.Clear();
                graphic_stack.Clear();
            }
            DisplayGraphicStack();
        }

        #endregion
       
    }
}
