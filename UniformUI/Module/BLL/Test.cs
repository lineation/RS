using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS_FindLine;
using HalconDotNet;
namespace UniformUI.Module.BLL
{
    class Test
    {
        RS_Find_Line fl = new RS_Find_Line();
        public Test()
        {
            fl.Intil_Path();
            HObject image;
            HTuple file_path;
            file_path = "D:\\20170629120641.jpg";
            HOperatorSet.ReadImage(out image,file_path);
            Double line_X,line_Y;
            Double line2X, line2Y;
            fl.Intil_Path();
            fl.Run(image, 170, 718, 714, 1263, 1, 100, 150, 20, 1, 0.8, 35, out line_X, out line_Y, out line2X, out line2Y);
        }
        
    }
}
