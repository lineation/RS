using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformUI.Module.Model;

namespace UniformUI.Module.DAL
{
    class SysUserService
    {
        #region 创建系统用户表
        /// <summary>
        /// 创建系统用户表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="conn">数据库连接</param>
        public void CreateUserTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(username varchar(50) PRIMARY KEY UNIQUE NOT NULL, password varchar(50) NOT NULL, loginMode integer NOT NULL)";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }
        #endregion

        #region 根据用户名查询用户密码和登陆模式
        /// <summary>
        /// 根据用户名查询用户密码和登陆模式
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public  List<string> SelectUserByUsername(SQLiteConnection conn, string username)
        {
            List<string> list = new List<string>();
            string password;
            LoginMode loginMode;
            string sql = "SELECT password,loginMode FROM User WHERE username = " + "'" + username + "' ";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    password = reader.GetString(0);
                    list.Add(password);
                    loginMode = (LoginMode)reader.GetInt16(1);
                    list.Add(loginMode.ToString().Trim());
                }
            }
            return list;
        }
        #endregion
    }
}
