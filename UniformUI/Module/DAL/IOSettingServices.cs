using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.DAL
{
    class IOSettingServices
    {
        #region 创建IO设置页的IO设置表
        /// <summary>
        /// 创建IOSeting，InputSetting表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateInputSettingTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY , Input名称 varchar(50) UNIQUE NOT NULL, 轴名称 integer NOT NULL, 点位名称 integer NOT NULL, 状态 BOOLEAN NOT NULL DEFAULT 0)";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }


        /// <summary>
        /// 创建IOSeting，OutputSetting表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateOutputSettingTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY , Output名称 varchar(50) UNIQUE NOT NULL, 轴名称 integer NOT NULL, 点位名称 integer NOT NULL, 执行 BOOLEAN NOT NULL DEFAULT 0)";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }
        #endregion
    }
}
