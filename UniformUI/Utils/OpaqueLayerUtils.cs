using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniformUI.Module;

namespace UniformUI.Utils
{
    class OpaqueLayerUtils
    {
       
        #region 半透层显示和隐藏方法
        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="alpha">透明度</param>
        /// <param name="isShowLoadingImage">是否显示图标</param>
        public static void ShowOpaqueLayer(Control control, out OpaqueLayer op, int alpha, bool isShowLoadingImage)
        {
           
            op = new OpaqueLayer(alpha, isShowLoadingImage);
            try
            {
                control.Controls.Add(op);
                op.Dock = DockStyle.Fill;
                op.BringToFront();
                
                op.Enabled = true;
                op.Visible = true;
            }
            catch
            {
                throw new UserException("半透显示失败！");
            }
        }
        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        public static void HideOpaqueLayer(OpaqueLayer op)
        {
            try
            {
                if (op != null)
                {
                    op.Visible = false;
                    op.Enabled = false;
                    op.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new UserException("半透销毁失败！"+ex.Message);
            }
        }
        #endregion

    }
}
