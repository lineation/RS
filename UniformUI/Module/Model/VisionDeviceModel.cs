using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.Model
{
    class VisionDeviceModel
    {
        private string m_DeviceName;

        public string DeviceName
        {
            get { return m_DeviceName; }
            set { m_DeviceName = value; }
        }
    }
}
