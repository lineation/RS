using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniformUI.Utils
{
    public class DataGridViewUtils
    {
        #region 得到某列的所有值
        /// <summary>
        /// 得到某列的所有值
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static List<string> GetDataGridViewColumnValue(DataGridView dgv,int columnIndex)
        {
            List<string> ls = new List<string>();
            string cellValue;
            try
            {
	            for (int i = 0; i < dgv.Rows.Count-0; i++)
	            {
	                if (!dgv.Rows[i].IsNewRow)
	                 {
	                 	 cellValue = dgv.Rows[i].Cells[columnIndex].Value.ToString();
	                     ls.Add(cellValue);
	                 }
	            }
            }
            catch (System.Exception ex)
            {
                return ls;
            }
            return ls;
        }
       #endregion
        #region 得到某行的所有值
        /// <summary>
        /// 得到某行的所有值
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static List<string> GetDataGridViewRowValue(DataGridView dgv,int rowIndex)
        {
            List<string> ls = new List<string>();

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                string cellValue = dgv.Rows[rowIndex].Cells[i].Value.ToString();
                ls.Add(cellValue);
            }
            return ls;
        }
        #endregion
        #region 获得DataGridView当前选中行的数据
        /// <summary>
        /// 获得DataGridView当前选中行的数据
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <returns>返回List</returns>
        public static List<string> GetDataGridViewCurrentValues(DataGridView dgv)
        {
            List<string> list = new List<string>();
            int cnt = dgv.CurrentRow.Cells.Count;
            string cell = null;
            for (int i = 0; i < cnt; i++)
            {
                cell = dgv.CurrentRow.Cells[i].Value.ToString();
                list.Add(cell);
            }
            return list;
        }
        #endregion
        #region 获得DataGridView当前选中行，指定列的cell值
        /// <summary>
        /// 获得DataGridView当前选中行，指定列的cell值
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static string GetDataGridViewCurrentRowCellValue(DataGridView dgv,int columnIndex)
        {
            string cell = dgv.CurrentRow.Cells[columnIndex].Value.ToString();
            return cell;
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
        public static bool RefreshDGV(DataGridView dgv, out DataTable dt, SQLiteDataAdapter sda)
        {
            dt = new DataTable();
            sda.Fill(dt);
            dgv.DataSource = dt;
            return true;
        }
        #endregion
    }
}
