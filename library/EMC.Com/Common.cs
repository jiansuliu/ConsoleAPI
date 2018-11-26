using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace EMC.Com
{
    /// <summary>
    /// 基本操作类
    /// </summary>
    public class Common
    {
        #region 全局方法
        private const string SESSION_TEMP = "SESSION_TEMP";//临时验证Session名称

        /// <summary>
        /// 设置验证码
        /// </summary>
        /// <param name="validate">验证码字符</param>
        public static void SetValidate(string validate)
        {
            HttpContext.Current.Session[SESSION_TEMP] = validate;
        }

        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="validate">验证码字符</param>
        /// <returns>是否验证正确</returns>
        public static bool InvalidValidate(string validate)
        {
            if (HttpContext.Current.Session[SESSION_TEMP] == null)
            {
                return false;
            }
            else
            {
                if (HttpContext.Current.Session[SESSION_TEMP].ToString() != validate)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 对输入的字符串进行md5加密
        /// </summary>
        public static string StringToMD5(string pass)
        {
            //把要加密的字符串转化为Byte[]数组 
            byte[] data = System.Text.Encoding.Unicode.GetBytes(pass.ToCharArray());
            //作为密码方式加密 
            string strSecurityPass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5");
            //返回加密的密码 
            return strSecurityPass;
        }

        /// <summary>
        /// 得到IP地址
        /// </summary>
        public static string GetIPAddress()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null) // 服务器
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else//如果没有使用代理服务器或者得不到客户端的ip 
            {
                //得到服务端的地址
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称</param>
        public static void DeleteFiles(string filePath, string fileName)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(filePath) + fileName))
            {
                File.Delete(HttpContext.Current.Server.MapPath(filePath) + fileName);
            }
        }
        #endregion
    }
}
