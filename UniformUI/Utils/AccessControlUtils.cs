using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniformUI.Module;
using UniformUI.Module.DAL;
using UniformUI.Module.Model;

namespace UniformUI.Utils
{
    public class AccessControlUtils
    {
        private static string _username;
        private static string _password;
        private static LoginMode _loginMode;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public LoginMode LoginMode
        {
            get { return _loginMode; }
            set { _loginMode = value; }
        }
        /// <summary>
        /// 判断当前用户是否有某种授权
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized(LoginMode loginMode)
        {
            SQLiteConnection conn = SQLiteUtils.GetConnection("test1");
            SysUserService sysUser = new SysUserService();
            sysUser.CreateUserTable("User", conn);
            List<string> user = sysUser.SelectUserByUsername(conn, _username);
            if (user.Count != 0)
            {
                if (user[0] == _password && user[1] == _loginMode.ToString().Trim() && user[1] == loginMode.ToString().Trim())
                {
                    return true;
                }
            }
            
            return false;
        }
        public bool IsAuthorized(string username, string password)
        {
            SQLiteConnection conn = SQLiteUtils.GetConnection("test1");
            SysUserService sysUser = new SysUserService();
            sysUser.CreateUserTable("User", conn);
            List<string> user = sysUser.SelectUserByUsername(conn, username);
            if (user.Count != 0)
            {
                if (user[0] == password)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
