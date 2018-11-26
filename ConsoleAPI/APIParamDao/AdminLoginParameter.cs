using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp.APIParamDao
{
    /// <summary>
    /// 管理员登录参数
    /// </summary>
    public class AdminLoginParameter
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string vercode { get; set; }
    }
}