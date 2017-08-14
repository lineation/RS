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
    class FileUtils
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("FileWRUtils");

        #region 获得当前应用所在目录
        /// <summary>
        /// 获得当前应用所在目录
        /// </summary>
        /// <returns></returns>
        public static string GetAppDirectory()
        {
            string str = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string logFilePath = str.Substring(0, str.LastIndexOf("\\"));
            return logFilePath;
        }
        #endregion

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
    
        #region 检测指定目录是否存在
        /// <summary>
        /// 检测指定目录是否存在
        /// </summary>
        /// <param name="directoryPath">目录的绝对路径</param>
        /// <returns></returns>
        public static bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        #endregion

        #region 检测指定文件是否存在,如果存在返回true
        /// <summary>
        /// 检测指定文件是否存在,如果存在则返回true。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }
        #endregion

        #region 获取指定目录中的文件列表
        /// <summary>
        /// 获取指定目录中所有文件列表
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>        
        public static string[] GetFileNames(string directoryPath)
        {
            //如果目录不存在，则抛出异常
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            //获取文件列表
            return Directory.GetFiles(directoryPath);
        }
        #endregion

        #region 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.
        /// <summary>
        /// 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>        
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 获取指定目录及子目录中所有文件列表
        /// <summary>
        /// 获取指定目录及子目录中所有文件列表
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>
        /// <param name="isSearchChild">是否搜索子目录</param>
        public static string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            //如果目录不存在，则抛出异常
            if (!IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }

            try
            {
                if (isSearchChild)
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetFiles(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 检测指定目录是否为空
        /// <summary>
        /// 检测指定目录是否为空
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>        
        public static bool IsEmptyDirectory(string directoryPath)
        {
            try
            {
                //判断是否存在文件
                string[] fileNames = GetFileNames(directoryPath);
                if (fileNames.Length > 0)
                {
                    return false;
                }

                //判断是否存在文件夹
                string[] directoryNames = GetDirectories(directoryPath);
                if (directoryNames.Length > 0)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                //这里记录日志
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                return true;
            }
        }
        #endregion

        #region 检测指定目录中是否存在指定的文件
        /// <summary>
        /// 检测指定目录中是否存在指定的文件,若要搜索子目录请使用重载方法.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>        
        public static bool Contains(string directoryPath, string searchPattern)
        {
            try
            {
                //获取指定的文件列表
                string[] fileNames = GetFileNames(directoryPath, searchPattern, false);

                //判断指定文件是否存在
                if (fileNames.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
            }
        }

        /// <summary>
        /// 检测指定目录中是否存在指定的文件
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param> 
        /// <param name="isSearchChild">是否搜索子目录</param>
        public static bool Contains(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                //获取指定的文件列表
                string[] fileNames = GetFileNames(directoryPath, searchPattern, true);

                //判断指定文件是否存在
                if (fileNames.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
            }
        }
        #endregion

        #region 根据时间得到目录名 / 格式:yyyyMMdd 或者 HHmmssff
        /// <summary>
        /// 根据时间得到目录名yyyyMMdd
        /// </summary>
        /// <returns></returns>
        public static string GetDateDir()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
        /// <summary>
        /// 根据时间得到文件名HHmmssff
        /// </summary>
        /// <returns></returns>
        public static string GetDateFile()
        {
            return DateTime.Now.ToString("HHmmssff");
        }
        #endregion

        #region 复制文件夹
        /// <summary>
        /// 复制文件夹(递归)
        /// </summary>
        /// <param name="varFromDirectory">源文件夹路径</param>
        /// <param name="varToDirectory">目标文件夹路径</param>
        public static void CopyFolder(string varFromDirectory, string varToDirectory)
        {
            Directory.CreateDirectory(varToDirectory);

            if (!Directory.Exists(varFromDirectory)) return;

            string[] directories = Directory.GetDirectories(varFromDirectory);

            if (directories.Length > 0)
            {
                foreach (string d in directories)
                {
                    CopyFolder(d, varToDirectory + d.Substring(d.LastIndexOf("\\")));
                }
            }
            string[] files = Directory.GetFiles(varFromDirectory);
            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    File.Copy(s, varToDirectory + s.Substring(s.LastIndexOf("\\")), true);
                }
            }
        }
        #endregion

        #region 检查文件,如果文件不存在则创建
        /// <summary>
        /// 检查文件,如果文件不存在则创建  
        /// </summary>
        /// <param name="FilePath">路径,包括文件名</param>
        public static void ExistsFile(string FilePath)
        {
            //if(!File.Exists(FilePath))    
            //File.Create(FilePath);    
            //以上写法会报错,详细解释请看下文.........   
            if (!File.Exists(FilePath))
            {
                FileStream fs = File.Create(FilePath);
                fs.Close();
            }
        }
        #endregion

        #region 删除指定文件夹对应其他文件夹里的文件
        /// <summary>
        /// 删除指定文件夹对应其他文件夹里的文件
        /// </summary>
        /// <param name="varFromDirectory">指定文件夹路径</param>
        /// <param name="varToDirectory">对应其他文件夹路径</param>
        public static void DeleteFolderFiles(string varFromDirectory, string varToDirectory)
        {
            Directory.CreateDirectory(varToDirectory);

            if (!Directory.Exists(varFromDirectory)) return;

            string[] directories = Directory.GetDirectories(varFromDirectory);

            if (directories.Length > 0)
            {
                foreach (string d in directories)
                {
                    DeleteFolderFiles(d, varToDirectory + d.Substring(d.LastIndexOf("\\")));
                }
            }


            string[] files = Directory.GetFiles(varFromDirectory);

            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    File.Delete(varToDirectory + s.Substring(s.LastIndexOf("\\")));
                }
            }
        }
        #endregion

        #region 从文件的绝对路径中获取文件名( 包含扩展名 )
        /// <summary>
        /// 从文件的绝对路径中获取文件名( 包含扩展名 )
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static string GetFileName(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Name;
        }
        #endregion

        #region 创建一个目录
        /// <summary>
        /// 创建一个目录
        /// </summary>
        /// <param name="directoryPath">目录的绝对路径</param>
        public static void CreateDirectory(string directoryPath)
        {
            //如果目录不存在则创建该目录
            if (!IsExistDirectory(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
        #endregion

        #region 创建一个文件
        /// <summary>
        /// 创建一个文件。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void CreateFile(string filePath)
        {
            try
            {
                //如果文件不存在则创建该文件
                if (!IsExistFile(filePath))
                {
                    //创建一个FileInfo对象
                    FileInfo file = new FileInfo(filePath);

                    //创建文件
                    FileStream fs = file.Create();

                    //关闭文件流
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// 创建一个文件,并将字节流写入文件。
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="buffer">二进制流数据</param>
        public static void CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                //如果文件不存在则创建该文件
                if (!IsExistFile(filePath))
                {
                    //创建一个FileInfo对象
                    FileInfo file = new FileInfo(filePath);

                    //创建文件
                    FileStream fs = file.Create();

                    //写入二进制流
                    fs.Write(buffer, 0, buffer.Length);

                    //关闭文件流
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteTraceLog(TraceLogLevel.Error, ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">要删除的文件路径和名称</param>
        public static void DeleteFile(string file)
        {
            if (File.Exists(file))
                File.Delete(file);
        }
        #endregion

        #region 获取文本文件的行数
        /// <summary>
        /// 获取文本文件的行数
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static int GetLineCount(string filePath)
        {
            //将文本文件的各行读到一个字符串数组中
            string[] rows = File.ReadAllLines(filePath);

            //返回行数
            return rows.Length;
        }
        #endregion

        #region 获取一个文件的长度
        /// <summary>
        /// 获取一个文件的长度,单位为Byte
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static int GetFileSize(string filePath)
        {
            //创建一个文件对象
            FileInfo fi = new FileInfo(filePath);

            //获取文件的大小
            return (int)fi.Length;
        }
        #endregion

        #region 获取指定目录中的子目录列表
        /// <summary>
        /// 获取指定目录及子目录中所有子目录列表
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>
        /// <param name="isSearchChild">是否搜索子目录</param>
        public static string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                if (isSearchChild)
                {
                    return Directory.GetDirectories(directoryPath, searchPattern, SearchOption.AllDirectories);
                }
                else
                {
                    return Directory.GetDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 向文本文件写入内容

        /// <summary>
        /// 向文本文件中写入内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="text">写入的内容</param>
        /// <param name="encoding">编码</param>
        public static void WriteText(string filePath, string text, Encoding encoding)
        {
            //向文件写入内容
            File.WriteAllText(filePath, text, encoding);
        }
        #endregion

        #region 向文本文件的尾部追加内容
        /// <summary>
        /// 向文本文件的尾部追加内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="content">写入的内容</param>
        public static void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }
        #endregion

        #region 将现有文件的内容复制到新文件中
        /// <summary>
        /// 将源文件的内容复制到目标文件中
        /// </summary>
        /// <param name="sourceFilePath">源文件的绝对路径</param>
        /// <param name="destFilePath">目标文件的绝对路径</param>
        public static void Copy(string sourceFilePath, string destFilePath)
        {
            File.Copy(sourceFilePath, destFilePath, true);
        }
        #endregion

        #region 将文件移动到指定目录
        /// <summary>
        /// 将文件移动到指定目录
        /// </summary>
        /// <param name="sourceFilePath">需要移动的源文件的绝对路径</param>
        /// <param name="descDirectoryPath">移动到的目录的绝对路径</param>
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            //获取源文件的名称
            string sourceFileName = GetFileName(sourceFilePath);

            if (IsExistDirectory(descDirectoryPath))
            {
                //如果目标中存在同名文件,则删除
                if (IsExistFile(descDirectoryPath + "\\" + sourceFileName))
                {
                    DeleteFile(descDirectoryPath + "\\" + sourceFileName);
                }
                //将文件移动到指定目录
                File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFileName);
            }
        }
        #endregion


        #region 从文件的绝对路径中获取文件名( 不包含扩展名 )
        /// <summary>
        /// 从文件的绝对路径中获取文件名( 不包含扩展名 )
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static string GetFileNameNoExtension(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Name.Split('.')[0];
        }
        #endregion

        #region 从文件的绝对路径中获取扩展名
        /// <summary>
        /// 从文件的绝对路径中获取扩展名
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>        
        public static string GetExtension(string filePath)
        {
            //获取文件的名称
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }
        #endregion

        #region 清空指定目录
        /// <summary>
        /// 清空指定目录下所有文件及子目录,但该目录依然保存.
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static void ClearDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                //删除目录中所有的文件
                string[] fileNames = GetFileNames(directoryPath);
                for (int i = 0; i < fileNames.Length; i++)
                {
                    DeleteFile(fileNames[i]);
                }

                //删除目录中所有的子目录
                string[] directoryNames = GetDirectories(directoryPath);
                for (int i = 0; i < directoryNames.Length; i++)
                {
                    DeleteDirectory(directoryNames[i]);
                }
            }
        }
        #endregion

        #region 清空文件内容
        /// <summary>
        /// 清空文件内容
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        public static void ClearFile(string filePath)
        {
            //删除文件
            File.Delete(filePath);

            //重新创建该文件
            CreateFile(filePath);
        }
        #endregion

        #region 删除指定目录
        /// <summary>
        /// 删除指定目录及其所有子目录
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static void DeleteDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }
        #endregion
    }
}
