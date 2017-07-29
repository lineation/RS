using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.Model
{
    /// <summary>
    /// HomingSetting:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class HomingSetting
    {
        public HomingSetting()
        { }
        #region Model
        private string _轴名称;
        private int _轴号;
        private decimal _导程;
        private string _模式;
        private string _搜索方向;
        private string _z相信号;
        private string _曲线;
        private decimal? _速度;
        private decimal? _加速度;
        private int? _偏移;
        private int? _顺序;
        /// <summary>
        /// 
        /// </summary>
        public string 轴名称
        {
            set { _轴名称 = value; }
            get { return _轴名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int 轴号
        {
            set { _轴号 = value; }
            get { return _轴号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 导程
        {
            set { _导程 = value; }
            get { return _导程; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 模式
        {
            set { _模式 = value; }
            get { return _模式; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 搜索方向
        {
            set { _搜索方向 = value; }
            get { return _搜索方向; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Z相信号
        {
            set { _z相信号 = value; }
            get { return _z相信号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 曲线
        {
            set { _曲线 = value; }
            get { return _曲线; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 速度
        {
            set { _速度 = value; }
            get { return _速度; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 加速度
        {
            set { _加速度 = value; }
            get { return _加速度; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 偏移
        {
            set { _偏移 = value; }
            get { return _偏移; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 顺序
        {
            set { _顺序 = value; }
            get { return _顺序; }
        }
        #endregion Model

    }
}
