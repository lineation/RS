using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniformUI.Module.Model
{
    class SysUserModel
    {
        private static string m_Username;
        private static string m_Password;
        private static LoginMode m_LoginMode;

        public string Username
        {
            get { return m_Username; }
            set { m_Username = value; }
        }
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        public LoginMode LoginMode
        {
            get { return m_LoginMode; }
            set { m_LoginMode = value; }
        }
    }
}
