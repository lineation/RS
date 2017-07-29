using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformUI.Module.Model;
using UniformUI.Utils;

namespace UniformUI.Module.DAL
{
    class HomeSettingService
    {
        public void CreatHomeSettingTable(string tableName, SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS " + tableName + "(轴名称 varchar(50) PRIMARY KEY UNIQUE NOT NULL, 轴号 integer NOT NULL, 导程 FLOAT NOT NULL,模式 varchar(20),搜索方向 varchar(20),Z相信号 varchar(20),曲线 varchar(20),速度 FLOAT,加速度 FLOAT,偏移 integer, 顺序 int)";

            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();
        }

        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 轴名称)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HomingSetting");
            strSql.Append(" where 轴名称=@轴名称 ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@轴名称", DbType.String,50)};
            parameters[0].Value = 轴名称;

            return SQLiteUtils.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(HomingSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HomingSetting(");
            strSql.Append("轴名称,轴号,导程,模式,搜索方向,Z相信号,曲线,速度,加速度,偏移,顺序)");
            strSql.Append(" values (");
            strSql.Append("@轴名称,@轴号,@导程,@模式,@搜索方向,@Z相信号,@曲线,@速度,@加速度,@偏移,@顺序)");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@轴名称", DbType.String,50),
					new SQLiteParameter("@轴号", DbType.Int32,4),
					new SQLiteParameter("@导程", DbType.Decimal,8),
					new SQLiteParameter("@模式", DbType.String,20),
					new SQLiteParameter("@搜索方向", DbType.String,20),
					new SQLiteParameter("@Z相信号", DbType.String,20),
					new SQLiteParameter("@曲线", DbType.String,20),
					new SQLiteParameter("@速度", DbType.Decimal,8),
					new SQLiteParameter("@加速度", DbType.Decimal,8),
					new SQLiteParameter("@偏移", DbType.Int32,4),
					new SQLiteParameter("@顺序", DbType.Int32,4)};
            parameters[0].Value = model.轴名称;
            parameters[1].Value = model.轴号;
            parameters[2].Value = model.导程;
            parameters[3].Value = model.模式;
            parameters[4].Value = model.搜索方向;
            parameters[5].Value = model.Z相信号;
            parameters[6].Value = model.曲线;
            parameters[7].Value = model.速度;
            parameters[8].Value = model.加速度;
            parameters[9].Value = model.偏移;
            parameters[10].Value = model.顺序;

            SQLiteUtils.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HomingSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HomingSetting set ");
            strSql.Append("轴号=@轴号,");
            strSql.Append("导程=@导程,");
            strSql.Append("模式=@模式,");
            strSql.Append("搜索方向=@搜索方向,");
            strSql.Append("Z相信号=@Z相信号,");
            strSql.Append("曲线=@曲线,");
            strSql.Append("速度=@速度,");
            strSql.Append("加速度=@加速度,");
            strSql.Append("偏移=@偏移,");
            strSql.Append("顺序=@顺序");
            strSql.Append(" where 轴名称=@轴名称 ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@轴号", DbType.Int32,4),
					new SQLiteParameter("@导程", DbType.Decimal,8),
					new SQLiteParameter("@模式", DbType.String,20),
					new SQLiteParameter("@搜索方向", DbType.String,20),
					new SQLiteParameter("@Z相信号", DbType.String,20),
					new SQLiteParameter("@曲线", DbType.String,20),
					new SQLiteParameter("@速度", DbType.Decimal,8),
					new SQLiteParameter("@加速度", DbType.Decimal,8),
					new SQLiteParameter("@偏移", DbType.Int32,4),
					new SQLiteParameter("@顺序", DbType.Int32,4),
					new SQLiteParameter("@轴名称", DbType.String,50)};
            parameters[0].Value = model.轴号;
            parameters[1].Value = model.导程;
            parameters[2].Value = model.模式;
            parameters[3].Value = model.搜索方向;
            parameters[4].Value = model.Z相信号;
            parameters[5].Value = model.曲线;
            parameters[6].Value = model.速度;
            parameters[7].Value = model.加速度;
            parameters[8].Value = model.偏移;
            parameters[9].Value = model.顺序;
            parameters[10].Value = model.轴名称;

            int rows = SQLiteUtils.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string 轴名称)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HomingSetting ");
            strSql.Append(" where 轴名称=@轴名称 ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@轴名称", DbType.String,50)};
            parameters[0].Value = 轴名称;

            int rows = SQLiteUtils.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string 轴名称list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HomingSetting ");
            strSql.Append(" where 轴名称 in (" + 轴名称list + ")  ");
            int rows = SQLiteUtils.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HomingSetting GetModel(string 轴名称)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 轴名称,轴号,导程,模式,搜索方向,Z相信号,曲线,速度,加速度,偏移,顺序 from HomingSetting ");
            strSql.Append(" where 轴名称=@轴名称 ");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@轴名称", DbType.String,50)};
            parameters[0].Value = 轴名称;

            HomingSetting model = new HomingSetting();
            DataSet ds = SQLiteUtils.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.轴名称 = ds.Tables[0].Rows[0]["轴名称"].ToString();
                if (ds.Tables[0].Rows[0]["轴号"].ToString() != "")
                {
                    model.轴号 = int.Parse(ds.Tables[0].Rows[0]["轴号"].ToString());
                }
                if (ds.Tables[0].Rows[0]["导程"].ToString() != "")
                {
                    model.导程 = decimal.Parse(ds.Tables[0].Rows[0]["导程"].ToString());
                }
                model.模式 = ds.Tables[0].Rows[0]["模式"].ToString();
                model.搜索方向 = ds.Tables[0].Rows[0]["搜索方向"].ToString();
                model.Z相信号 = ds.Tables[0].Rows[0]["Z相信号"].ToString();
                model.曲线 = ds.Tables[0].Rows[0]["曲线"].ToString();
                if (ds.Tables[0].Rows[0]["速度"].ToString() != "")
                {
                    model.速度 = decimal.Parse(ds.Tables[0].Rows[0]["速度"].ToString());
                }
                if (ds.Tables[0].Rows[0]["加速度"].ToString() != "")
                {
                    model.加速度 = decimal.Parse(ds.Tables[0].Rows[0]["加速度"].ToString());
                }
                if (ds.Tables[0].Rows[0]["偏移"].ToString() != "")
                {
                    model.偏移 = int.Parse(ds.Tables[0].Rows[0]["偏移"].ToString());
                }
                if (ds.Tables[0].Rows[0]["顺序"].ToString() != "")
                {
                    model.顺序 = int.Parse(ds.Tables[0].Rows[0]["顺序"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 轴名称,轴号,导程,模式,搜索方向,Z相信号,曲线,速度,加速度,偏移,顺序 ");
            strSql.Append(" FROM HomingSetting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SQLiteUtils.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SQLiteParameter[] parameters = {
                    new SQLiteParameter("@tblName", DbType.VarChar, 255),
                    new SQLiteParameter("@fldName", DbType.VarChar, 255),
                    new SQLiteParameter("@PageSize", DbType.Int32),
                    new SQLiteParameter("@PageIndex", DbType.Int32),
                    new SQLiteParameter("@IsReCount", DbType.bit),
                    new SQLiteParameter("@OrderType", DbType.bit),
                    new SQLiteParameter("@strWhere", DbType.VarChar,1000),
                    };
            parameters[0].Value = "HomingSetting";
            parameters[1].Value = "轴名称";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return SQLiteUtils.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
