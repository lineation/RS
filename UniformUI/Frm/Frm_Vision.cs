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
using UniformUI.Module.DAL;
using UniformUI.RSControl;
using DevComponents.DotNetBar;

namespace UniformUI.Frm
{
    public partial class Frm_Vision : Form
    {
        private static log4net.ILog m_Logger;
        private AutoSizeForm asc = new AutoSizeForm();
        private Dlg_AddDevice addDeviceDialog = null;
        private SQLiteDataAdapter m_DeviceInfoDataAdapter;
        private DataTable m_DeviceInfoDataTable;
        private VisionDeviceInfoService m_VisionDeviceInfoService = new VisionDeviceInfoService();
        private Dictionary<string, SuperTabItem> stiNameDic = new Dictionary<string, SuperTabItem>();


        public DataTable DeviceInfoDataTable
        {
            get { return m_DeviceInfoDataTable; }
            set { m_DeviceInfoDataTable = value; }
        }
        public SQLiteDataAdapter DeviceInfoDataAdapter
        {
            get { return m_DeviceInfoDataAdapter; }
            set { m_DeviceInfoDataAdapter = value; }
        }


        public Frm_Vision()
        {
            InitializeComponent();
            stc_Device.CloseButtonOnTabsAlwaysDisplayed = true;
            stc_Device.CloseButtonOnTabsVisible = true;
            addDeviceDialog = new Dlg_AddDevice();
            m_VisionDeviceInfoService.CreatVisionDeviceInfoTable("VisionDeviceInfo");
            m_DeviceInfoDataTable = SQLiteUtils.DataSourceBindToDataGridView(dgv_VisionDeviceInfo, out m_DeviceInfoDataAdapter, "test1", "VisionDeviceInfo");
        }

        private void Frm_Vision_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            m_Logger = log4net.LogManager.GetLogger(this.GetType());
            //根据dgv_VisionDeviceInfo初始化stc_Device
            List<string> lists = DataGridViewUtils.GetDataGridViewColumnValue(dgv_VisionDeviceInfo, 2);
            foreach (string Name in lists)
            {
                SuperTabItem sti_Name = stc_Device.CreateTab(Name);
                stiNameDic.Add(Name, sti_Name);
            }

        }


        private void lbl_AddDevice_Click(object sender, EventArgs e)
        {
            if (addDeviceDialog.ShowDialog(this) == DialogResult.OK)
            {
                DataGridViewUtils.RefreshDGV(dgv_VisionDeviceInfo, out m_DeviceInfoDataTable, m_DeviceInfoDataAdapter);
                string Name= m_VisionDeviceInfoService.SelectMaxID("VisionDeviceInfo");
                SuperTabItem sti_Name = stc_Device.CreateTab(Name);
                stiNameDic.Add(Name, sti_Name);
            }
        }

        private void lbl_AddDevice_MouseEnter(object sender, EventArgs e)
        {
            lbl_AddDevice.BackColor = Color.FromArgb(174, 218, 151); 
        }

        private void lbl_AddDevice_MouseLeave(object sender, EventArgs e)
        {
            lbl_AddDevice.BackColor = Color.FromArgb(238, 238, 239);
        }

        private void lbl_DeleteDevice_MouseEnter(object sender, EventArgs e)
        {
            lbl_DeleteDevice.BackColor = Color.FromArgb(174, 218, 151);
        }

        private void lbl_DeleteDevice_MouseLeave(object sender, EventArgs e)
        {
            lbl_DeleteDevice.BackColor = Color.FromArgb(238, 238, 239);
        }

        private void lbl_DeleteDevice_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dgv_VisionDeviceInfo.CurrentRow;
            if (!dataGridViewRow.IsNewRow)
            {
	            //弹出删除确认框
                string name = Utils.DataGridViewUtils.GetDataGridViewCurrentRowCellValue(dgv_VisionDeviceInfo, 2);
                Dlg_Comfirm confirmDialog = new Dlg_Comfirm("确认框", "确认删除：" + name + "吗？");
	            
	            if (confirmDialog.ShowDialog(this) == DialogResult.OK)
	            {
	                //删除SelectedRows
                    dgv_VisionDeviceInfo.Rows.Remove(dataGridViewRow);
	                
	                //更新到数据源
	                try
	                {
	                    dgv_VisionDeviceInfo.CurrentCell = null;
	                    m_DeviceInfoDataAdapter.Update(m_DeviceInfoDataTable);
	                    DataGridViewUtils.RefreshDGV(dgv_VisionDeviceInfo, out m_DeviceInfoDataTable, m_DeviceInfoDataAdapter);
	
	                    stc_Device.CloseTab(stiNameDic[name]);
	                    stiNameDic.Remove(name);
	                }
	                catch (Exception se)
	                {
	                    m_Logger.Error("删除失败！" + se.Message);
	                }
	            }
            }
        }

       
    }
}
