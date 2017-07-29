using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.Model
{
    class VisionDeviceInfoModel
    {
        private int id;
        private string name;
        private string info;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}
