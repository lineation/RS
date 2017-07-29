using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformUI.Utils;

namespace UniformUI.Module.DAL
{
    class VisionDeviceInfoServices
    {
        public void CreatVisionDeviceInfoTable(string tableName)
        {
            SQLiteConnection m_Conn = SQLiteUtils.GetConnection("test1");
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(ID integer PRIMARY KEY  , Name varchar(50), HardwareInfo varchar(50) )";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, m_Conn);
            cmdCreateTable.ExecuteNonQuery();
            m_Conn.Close();
        }

        public void InsertVisionDeviceInfoTable(string tableName, string deviceName, string deviceInfo)
        {
            SQLiteConnection m_Conn = SQLiteUtils.GetConnection("test1");
            string sql = "INSERT INTO " + tableName + " (Name,Hardware-Info) VALUES (" + "'" + deviceName + "'," + "'" + deviceInfo + "'" + ")";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, m_Conn);
            cmdCreateTable.ExecuteNonQuery();
            m_Conn.Close();
        }

        public string SelectMaxID(string tableName)
        {
            SQLiteConnection m_Conn = SQLiteUtils.GetConnection("test1");
            string sql = "select max(ID)  FROM  " + tableName;
            SQLiteCommand cmd = new SQLiteCommand(sql, m_Conn);

            string ret = cmd.ExecuteScalar().ToString();
            m_Conn.Close();

            return ret;
           
        }
    }
}
