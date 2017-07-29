using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UniformUI.Module.DAL
{
    class ParamSettingServices
    {
        #region 创建参数设置页的浮点、整型、布尔和字符串类型的表
        /// <summary>
        /// 创建参数设置页浮点参数表，FloatParams表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateFloatParamsTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY , 参数名称 varchar(50) UNIQUE NOT NULL, 浮点值 FLOAT DEFAULT 0.0, 最大值 FLOAT, 最小值 FLOAT)";

            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }


        /// <summary>
        /// 创建参数设置页整形参数表，IntParams表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateIntParamsTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY , 参数名称 varchar(50) UNIQUE NOT NULL, 整型值 integer DEFAULT 0, 最大值 integer, 最小值 integer)";

            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }


        /// <summary>
        /// 创建参数设置页布尔参数表，BoolParams表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateBoolParamsTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY , 参数名称 varchar(50) UNIQUE NOT NULL, 布尔值 BOOLEAN NOT NULL DEFAULT 0)";

            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }


        /// <summary>
        /// 创建参数设置页字符串参数表，StringParams表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateStringParamsTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY , 参数名称 varchar(50) UNIQUE NOT NULL, 字符串值 varchar(50) DEFAULT null)";

            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }
        #endregion
    }
}
