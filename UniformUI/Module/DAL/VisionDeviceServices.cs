using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformUI.Utils;

namespace UniformUI.Module.DAL
{
    
    class VisionDeviceServices
    {
        public void CreatVisionDeviceTable(string tableName)
        {
            SQLiteConnection m_Conn = SQLiteUtils.GetConnection("test1");
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(Devicetype varchar(50) PRIMARY KEY UNIQUE NOT NULL)";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, m_Conn);
            cmdCreateTable.ExecuteNonQuery();
        }

        public void InsertVisionDeviceTable(string tableName, string deviceName)
        {
            SQLiteConnection m_Conn = SQLiteUtils.GetConnection("test1");
            string sql = "INSERT INTO " + tableName + " (Devicetype) VALUES (" + "'" + deviceName + "'" + ")";
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, m_Conn);
            cmdCreateTable.ExecuteNonQuery();
        }
       
    }
}
