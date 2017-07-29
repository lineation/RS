using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using DevComponents.DotNetBar.Controls;

using UniformUI.Module;
using NPOI.HSSF.UserModel;
using UniformUI.Module.Model;


namespace UniformUI.Utils
{
    class FileWRUtils
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("FileWRUtils");

        #region 打印日志到txt文件
        /// <summary>
        /// 打印日志到txt文件
        /// </summary>
        /// <param name="strLog">日志描述</param>
        public static void WriteLogToTxt(string strLog)
        {
            
            String System_Now_Time  = null;
            String File_Create_Time = null;

            System_Now_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            File_Create_Time = DateTime.Now.ToString("yyyyMMdd");
            string logDocument = File_Create_Time + ".txt";
            
            string str = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string logFilePath = str.Substring(0, str.LastIndexOf("\\")) + "\\Log";
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }
            logFilePath = logFilePath + "//" + logDocument;
            FileStream fs = new FileStream(logFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(System_Now_Time + ":   " + strLog);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        #endregion
            
        #region 将DataGridView中的数据导出到Excel中，支持CSV、XLS和XLSX格式
        /// <summary>
        /// 将datagridview中的数据写到文件中，保存格式可选择CSV、XLS和XLSX格式
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="excelFullPath">保存文件的全路径</param>
        /// <param name="format">格式可选择CSV、XLS和XLSX</param>
        public static void SaveDataGridViewToExcel(DataGridViewX dgv, string excelFullPath, SaveDataFormat format) 
        {
            int columnCount = dgv.ColumnCount;
            int rowCount = dgv.RowCount;
            string strLine = "";

            switch (format)
            {

                case SaveDataFormat.CSV:

                    #region 保存为CSV格式
                    try
                    {
                        StreamWriter sw = new StreamWriter(excelFullPath, true, System.Text.Encoding.GetEncoding(-0));
                        for (int i = 0; i < columnCount; i++)
                        {
                            if (i > 0)
                                strLine += ",";
                            strLine += dgv.Columns[i].HeaderText;
                        }

                        strLine.Remove(strLine.Length - 1);
                        sw.WriteLine(strLine);

                        for (int j = 0; j < rowCount; j++)
                        {
                            strLine = "";
                            for (int k = 0; k < columnCount; k++)
                            {
                                if (k > 0)
                                    strLine += ",";
                                if (dgv.Rows[j].Cells[k].Value == null)
                                    strLine += "";
                                else
                                {
                                    string m = dgv.Rows[j].Cells[k].Value.ToString().Trim();
                                    strLine += m.Replace(",", "，");
                                }
                            }
                            strLine.Remove(strLine.Length - 1);
                            sw.WriteLine(strLine);
                        }
                        sw.Close();
                    }
                    catch (System.Exception ex)
                    {
                        logger.Error("导出为CSV格式失败");
                    }
                    break;
                    #endregion

                case SaveDataFormat.XLS:

                    #region 保存为XLS格式
                    ThreadPool.QueueUserWorkItem((pp) =>
                    {
                        HSSFWorkbook npoiwb = new HSSFWorkbook();
                        HSSFSheet sheet = (HSSFSheet)npoiwb.CreateSheet("11");
                        HSSFRow headRow = (HSSFRow)sheet.CreateRow(0);
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            HSSFCell headCell = (HSSFCell)headRow.CreateCell(i, CellType.String);
                            headCell.SetCellValue(dgv.Columns[i].HeaderText);
                        }
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            HSSFRow row = (HSSFRow)sheet.CreateRow(i + 1);
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                HSSFCell cell = (HSSFCell)row.CreateCell(j);
                                if (dgv.Rows[i].Cells[j].Value == null)
                                {
                                    cell.SetCellType(CellType.Blank);
                                }
                                else
                                {
                                    if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Int32"))
                                    {
                                        cell.SetCellValue(Convert.ToInt32(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.String"))
                                    {
                                        cell.SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Single"))
                                    {
                                        cell.SetCellValue(Convert.ToSingle(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Double"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Decimal"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.DateTime"))
                                    {
                                        cell.SetCellValue(Convert.ToDateTime(dgv.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd"));
                                    }
                                }

                            }

                        }
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sheet.AutoSizeColumn(i);
                        }
                        using (FileStream fs = new FileStream(excelFullPath, FileMode.Create))
                        {
                            npoiwb.Write(fs);
                        }
                    });
                    break;
                    #endregion

                case SaveDataFormat.XLSX:

                    #region 保存为XLSX格式
                    ThreadPool.QueueUserWorkItem((pp) =>
                    {
                        XSSFWorkbook npoiwb = new XSSFWorkbook();
                        XSSFSheet sheet = (XSSFSheet)npoiwb.CreateSheet("11");
                        XSSFRow headRow = (XSSFRow)sheet.CreateRow(0);
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            XSSFCell headCell = (XSSFCell)headRow.CreateCell(i, CellType.String);
                            headCell.SetCellValue(dgv.Columns[i].HeaderText);
                        }
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            XSSFRow row = (XSSFRow)sheet.CreateRow(i + 1);
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                XSSFCell cell = (XSSFCell)row.CreateCell(j);
                                if (dgv.Rows[i].Cells[j].Value == null)
                                {
                                    cell.SetCellType(CellType.Blank);
                                }
                                else
                                {
                                    if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Int32"))
                                    {
                                        cell.SetCellValue(Convert.ToInt32(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.String"))
                                    {
                                        cell.SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Single"))
                                    {
                                        cell.SetCellValue(Convert.ToSingle(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Double"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Decimal"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.DateTime"))
                                    {
                                        cell.SetCellValue(Convert.ToDateTime(dgv.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd"));
                                    }
                                }

                            }

                        }
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sheet.AutoSizeColumn(i);
                        }
                        using (FileStream fs = new FileStream(excelFullPath, FileMode.Create))
                        {
                            npoiwb.Write(fs);
                        }
                    });
                    break; 
                    #endregion

                default:
                    logger.Error("将datagridview写入到excel失败！");
                    break;
            }
        }
        public static void SaveDataGridViewToExcel(DataGridView dgv, string excelFullPath, SaveDataFormat format) 
        {
             
            int columnCount = dgv.ColumnCount;
            int rowCount = dgv.RowCount;
            string strLine = "";

            switch(format)
            {
               
                case SaveDataFormat.CSV:

                    #region 保存为CSV格式
                    try
                    {
	                    StreamWriter sw = new StreamWriter(excelFullPath, true, System.Text.Encoding.GetEncoding(-0)); 
	                    for (int i = 0; i < columnCount; i++ )
	                    {
	                        if (i > 0)
	                            strLine += ",";
	                        strLine += dgv.Columns[i].HeaderText;
	                    }
	
	                    strLine.Remove(strLine.Length - 1);  
	                    sw.WriteLine(strLine);  
	
	                    for (int j = 0; j < rowCount; j++)
	                    {
	                        strLine = "";
	                        for (int k = 0; k < columnCount; k++)
	                        {
	                            if (k > 0)
	                                strLine += ",";
	                            if (dgv.Rows[j].Cells[k].Value == null)
	                                strLine += "";
	                            else
	                            {
	                                string m = dgv.Rows[j].Cells[k].Value.ToString().Trim();
	                                strLine += m.Replace(",", "，");
	                            }
	                        }
	                        strLine.Remove(strLine.Length - 1);
	                        sw.WriteLine(strLine);
	                    }
	                    sw.Close(); 
                    }
                    catch (System.Exception ex)
                    {
                        logger.Error("导出为CSV格式失败");
                    }
                    break;
                    #endregion

                case SaveDataFormat.XLS:

                    #region 保存为XLS格式
                    //由于导出较慢，这里采用多线程，后台执行excel导出
//                     ThreadPool.QueueUserWorkItem((pp)=>{
//                         DateTime time = DateTime.Now;
//                         string[,] saveDataArray = new string[rowCount - 1, columnCount - 1];
//                         string Version;//excel版本号
//                         int FormatNum;
//                         Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
//                         Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(System.Reflection.Missing.Value);
//                         Microsoft.Office.Interop.Excel.Worksheet ws = null;
//                         int iRows = 0;
//                         int iCols = 0;
//                         int iTrueCols = 0;
//                         if (wb.Worksheets.Count > 0)
//                         {
//                             ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
//                         }
//                         else
//                         {
//                             wb.Worksheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
//                             ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
//                         }
//                         if (ws != null)
//                         {
//                             ws.Name = "SheetName";
// 
//                             iRows = dgv.Rows.Count;
//                             iTrueCols = dgv.Columns.Count;
//                             //求列数，省略Visible = false的列    
//                             for (int i = 0; i < columnCount; i++)
//                             {
//                                 if (dgv.Columns[i].Visible)
//                                 {
//                                     iCols++;
//                                 }
//                             }
//                             string[,] dimArray = new string[iRows + 1, iCols];
// 
//                             for (int j = 0, k = 0; j < iTrueCols; j++)
//                             {
//                                 if (dgv.Columns[j].Visible)
//                                 {
//                                     dimArray[0, k] = dgv.Columns[j].HeaderText;
//                                     k++;
//                                 }
//                             }
// 
//                             for (int i = 0; i < iRows; i++)
//                             {
//                                 for (int j = 0, k = 0; j < iTrueCols; j++)
//                                 {
//                                     if (dgv.Columns[j].Visible)
//                                     {
//                                         if (dgv.Rows[i].Cells[j].Value != null)
//                                             dimArray[i + 1, k] = dgv.Rows[i].Cells[j].Value.ToString();
//                                         else
//                                             dimArray[i + 1, k] = "";
//                                         k++;
//                                     }
//                                 }
//                             }
//                             ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[iRows + 1, iCols] as Microsoft.Office.Interop.Excel.Range).Value2 = dimArray;
//                             ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[1, iCols] as Microsoft.Office.Interop.Excel.Range).Font.Bold = true;
//                             ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[iRows + 1, iCols] as Microsoft.Office.Interop.Excel.Range).Font.Size = 10.0;
//                             ws.get_Range(ws.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range, ws.Cells[iRows + 1, iCols] as Microsoft.Office.Interop.Excel.Range).RowHeight = 14.25;
//                         }
//                         //列宽自适应
//                         ws.Columns.EntireColumn.AutoFit();
//                         //获取excel的版本号
//                         Version = app.Version;
//                         if (Convert.ToDouble(Version) < 12)
//                         {
//                             //Excel 97-2003 
//                             FormatNum = -4143;
//                         }
//                         else
//                         {
//                             //excel 2007 or later   
//                             FormatNum = 56;
//                         }
//                         try
//                         {
//                             //设置禁止弹出保存和覆盖的询问提示框  
//                             app.DisplayAlerts = false;
//                             app.AlertBeforeOverwriting = false;
//                             //保存工作簿  
//                             app.Application.Workbooks.Add(true).Save();
//                             wb.Saved = true;
//                             wb.SaveAs(excelFullPath, FormatNum);
//                         }
//                         catch (System.Exception se)
//                         {
//                             WriteLogToTxt("将datagridview写入到excel失败：" + se);
//                         }
//                         app.Quit();
//                         GC.Collect();
//                     });
                    ThreadPool.QueueUserWorkItem((pp) =>
                    {
                        HSSFWorkbook npoiwb = new HSSFWorkbook();
                        HSSFSheet sheet = (HSSFSheet)npoiwb.CreateSheet("11");
                        HSSFRow headRow = (HSSFRow)sheet.CreateRow(0);
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            HSSFCell headCell = (HSSFCell)headRow.CreateCell(i, CellType.String);
                            headCell.SetCellValue(dgv.Columns[i].HeaderText);
                        }
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            HSSFRow row = (HSSFRow)sheet.CreateRow(i + 1);
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                HSSFCell cell = (HSSFCell)row.CreateCell(j);
                                if (dgv.Rows[i].Cells[j].Value == null)
                                {
                                    cell.SetCellType(CellType.Blank);
                                }
                                else
                                {
                                    if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Int32"))
                                    {
                                        cell.SetCellValue(Convert.ToInt32(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.String"))
                                    {
                                        cell.SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Single"))
                                    {
                                        cell.SetCellValue(Convert.ToSingle(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Double"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Decimal"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.DateTime"))
                                    {
                                        cell.SetCellValue(Convert.ToDateTime(dgv.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd"));
                                    }
                                }

                            }

                        }
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sheet.AutoSizeColumn(i);
                        }
                        using (FileStream fs = new FileStream(excelFullPath, FileMode.Create))
                        {
                            npoiwb.Write(fs);
                        }
                    });
                    break;
                    #endregion

                case SaveDataFormat.XLSX:

                    #region 保存为XLSX格式
                    ThreadPool.QueueUserWorkItem((pp) =>
                    {
                        XSSFWorkbook npoiwb = new XSSFWorkbook();
                        XSSFSheet sheet = (XSSFSheet)npoiwb.CreateSheet("11");
                        XSSFRow headRow = (XSSFRow)sheet.CreateRow(0);
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            XSSFCell headCell = (XSSFCell)headRow.CreateCell(i, CellType.String);
                            headCell.SetCellValue(dgv.Columns[i].HeaderText);
                        }
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            XSSFRow row = (XSSFRow)sheet.CreateRow(i + 1);
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                XSSFCell cell = (XSSFCell)row.CreateCell(j);
                                if (dgv.Rows[i].Cells[j].Value == null)
                                {
                                    cell.SetCellType(CellType.Blank);
                                }
                                else
                                {
                                    if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Int32"))
                                    {
                                        cell.SetCellValue(Convert.ToInt32(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.String"))
                                    {
                                        cell.SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Single"))
                                    {
                                        cell.SetCellValue(Convert.ToSingle(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Double"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.Decimal"))
                                    {
                                        cell.SetCellValue(Convert.ToDouble(dgv.Rows[i].Cells[j].Value));
                                    }
                                    else if (dgv.Rows[i].Cells[j].ValueType.FullName.Contains("System.DateTime"))
                                    {
                                        cell.SetCellValue(Convert.ToDateTime(dgv.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd"));
                                    }
                                }

                            }

                        }
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sheet.AutoSizeColumn(i);
                        }
                        using (FileStream fs = new FileStream(excelFullPath, FileMode.Create))
                        {
                            npoiwb.Write(fs);
                        }
                    });
                    break; 
                    #endregion

                default:
                    logger.Error("将datagridview写入到excel失败！");
                    break;
            }
        }
        #endregion
    }
}
