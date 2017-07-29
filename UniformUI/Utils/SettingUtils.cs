using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Utils
{
    public static class SettingUtils
    {
        /// <summary>
        /// 读取所有IO设置
        /// </summary>
        /// <returns>io设置键值对</returns>
        public static Dictionary<string, string> ReadIoSetting() 
        {
            // in_NameCol=到位信号
            // in_axisNameCol=1
            // in_positionNameCol=11
            // in_status=0
            Dictionary<string,string> keyValuePair = INIUtils.GetAllKeyValues("IoSetting");
            return keyValuePair;
        }
        /// <summary>
        /// 保存IO设置
        /// </summary>
        public static bool WriteIoSetting() 
        {
            return true;
        }
        
    }
}
