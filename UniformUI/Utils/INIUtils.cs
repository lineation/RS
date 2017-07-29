using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Utils
{
    public class INIUtils
    {
        #region 引入API
        // 读写INI文件相关
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, int nSize, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);
        #endregion

        #region 属性
        private static string path = System.Environment.CurrentDirectory + "/Setting/IoSetting.ini";

        public static string Path
        {
            get { return path; }
            set { path = value; }
        }
        #endregion

        #region 向INI写入数据
        /// <summary>
        /// 向INI写入数据
        /// </summary>
        /// <PARAM name="Section">节点名</PARAM>
        /// <PARAM name="Key">键名</PARAM>
        /// <PARAM name="Value">值名。</PARAM>
        public static void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }
        #endregion

        #region 读取指定节下指定键的值
        /// <summary>
        /// 读取指定节下指定键的值
        /// </summary>
        /// <PARAM name="Section">节点名。</PARAM>
        /// <PARAM name="Key">键名。</PARAM>
        /// <returns>读取到的值</returns>
        public static string Read(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }
        #endregion

        #region 读取一个ini里面所有的节
        /// <summary>
        /// 读取一个ini里面所有的节
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static int GetAllSectionNames(out string[] sections)
        {
            int MAX_BUFFER = 32767;
            IntPtr pReturnedString = Marshal.AllocCoTaskMem(MAX_BUFFER);
            int bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, path);
            if (bytesReturned == 0)
            {
                sections = null;
                return -1;
            }
            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);

            sections = local.Substring(0, local.Length - 1).Split('\0');
            return 0;
        }
        #endregion

        #region 得到某个节点下面所有的key和value组合,组装到dictionary中
        /// <summary>
        /// 得到某个节点下面所有的key和value组合,组装到dictionary中
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public static Dictionary<string,string> GetAllKeyValues(string section)
        {
            uint MAX_BUFFER = 32767;
            string[] items = new string[0];

            //分配内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            int bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, path);
            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {
                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            //释放内存
            Marshal.FreeCoTaskMem(pReturnedString);     

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in items)
            {
                String[] keyValue = item.Split(new char[] { '=' });
                string key = keyValue[0];
                string val = keyValue[1];
                dic.Add(key, val);
            }
            return dic;
        }
        #endregion

    }
}
