using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace UniformUI.Utils
{
    
    public static class StyleUtils
    {
        #region 设置主窗体样式
        /// <summary>
        /// 设置主窗体样式
        /// </summary>
        /// <param name="form"></param>
        public static void MainFormStyle(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.WindowState = FormWindowState.Maximized;
            form.KeyPreview = true;
            form.AutoScroll = false;
            form.IsMdiContainer = true;
            //修改父窗体背景色
            MdiClient ctlMDI;
            foreach (Control ctl in form.Controls)
            {
                if (ctl.GetType().ToString() != "System.Windows.Forms.MdiClient")
                {
                    continue;
                }
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = form.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    FileWRUtils.WriteLogToTxt("改变窗体" + form.Text + "颜色异常：" + exc.Message + ctl.Name);
                }
            }
        }
        #endregion

        #region 改变DataGridView样式
        /// <summary>
        ///  改变DataGridView的外边框
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="RGB"></param>
        public static void SetDataGridViewStyle(DataGridView dataGridView, PaintEventArgs e, int[] RGB)
        {
            //重绘外边框
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(RGB[0], RGB[1], RGB[2])),
                new Rectangle(0, 0, dataGridView.Width - 1,
                     dataGridView.Height - 1));
            
            //dataGridView.BackgroundColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = 0;
            //dataGridView.RowHeadersVisible = false;
            dataGridView.Cursor = Cursors.Hand;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        #endregion

        #region 设置Mdi窗体的样式
        /// <summary>
        /// 设置Mdi窗体的样式
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="childForm"></param>
        /// <param name="x_Start"></param>
        /// <param name="y_Start"></param>
        /// <returns></returns>
        public static bool SetMdiStyle(Form parentForm, Form childForm, int x_Start, int y_Start)
        {
            childForm.MdiParent = parentForm;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(x_Start, y_Start-2);
            childForm.Width = SystemInformation.PrimaryMonitorSize.Width-5;
            childForm.Height = SystemInformation.PrimaryMonitorSize.Height - y_Start - 3;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.BackColor = Color.White;
            childForm.AutoScroll = false;
            //form2.WindowState = FormWindowState.Maximized;
            return true;
        }
        #endregion

        #region 绘制圆角窗体
        public static void DrowRoundedForm(Control sender, int p, double tension)
        {
            GraphicsPath oPath = new GraphicsPath();
            oPath.AddClosedCurve(new Point[] {
                new Point(0, sender.Height / p),
                new Point(sender.Width / p, 0),
                new Point(sender.Width - sender.Width / p, 0),
                new Point(sender.Width, sender.Height / p),
                new Point(sender.Width, sender.Height - sender.Height / p),
                new Point(sender.Width - sender.Width / p, sender.Height),
                new Point(sender.Width / p, sender.Height),
                new Point(0, sender.Height - sender.Height / p) }, (float)tension);
            sender.Region = new Region(oPath);
        }
        #endregion

        #region 关闭DataGridView的AutoGenerateColumns，开启双缓冲
        /// <summary>
        /// 关闭DataGridView的AutoGenerateColumns
        /// </summary>
        /// <param name="dgv"></param>
         public static void SetSettingPageDGVStyle(DataGridView dgv) 
         {
             dgv.AutoGenerateColumns = false;

             Type dgvType = dgv.GetType();
             PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                   BindingFlags.Instance | BindingFlags.NonPublic);
             pi.SetValue(dgv, true, null);
         }
        #endregion

        #region 根据DataTable中的某一列，绘制DataGridView指定列cell背景色
         /// <summary>
         /// 根据DataTable中的某一列，绘制DataGridView指定列cell背景色
         /// </summary>
         /// <param name="dataGridView"></param>
         /// <param name="colIndex"></param>
         public static void DataGridViewCellBackcolorPaint(DataGridView dataGridView, DataTable dataTable, int colIndex)
         {
             List<string> list_Status = new List<string>();
             for (int i = 0; i < dataTable.Rows.Count; i++)
             {
                 list_Status.Add(dataTable.Rows[i][colIndex].ToString());
             }
             
             for (int i = 0; i < list_Status.Count; i++)
             {
                 bool flg = false;
                 try
                 {
                     flg = Convert.ToBoolean(list_Status[i]);
                 }
                 catch
                 {
                     return;
                 }
                 if (flg == true)
                 {
                     dataGridView.Rows[i].Cells[3].Style.BackColor = Color.Red;
                 }
                 if (flg == false)
                 {
                     dataGridView.Rows[i].Cells[3].Style.ForeColor = Color.White;
                 }
             }
         }
        #endregion

        #region 设置Control相对位置
        /// <summary>
         /// 设置Control相对位置
        /// </summary>
         /// <param name="control"></param>
        /// <param name="p">左上角位置</param>
        /// <param name="w">宽度</param>
        /// <param name="h">高度</param>
        /// <returns></returns>
        public static bool SetControlRelativePosition(Control control, Point p, int w, int h)
        {
            control.Location = p;
            control.Height = h;
            control.Width = w;

            return true;
        }
        #endregion
    }
}
