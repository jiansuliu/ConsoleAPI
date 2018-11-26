using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using Newtonsoft.Json.Linq;
using ConsoleAPI.lib;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Net.Security;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.Web;
using System.Xml.Serialization;
using ConsoleApp.APIParamDao;
using System.Web.Security;
using EMC.Com;

namespace ConsoleAPI.Controllers
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class AdminController : MasterPageController
    {
        /// <summary>
        /// 登录
        /// </summary>
        [Authorize]
        [HttpPost]
        public HttpResponseMessage AdminLogin([FromBody] AdminLoginParameter param)
        {
            var userInfo = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            int mid = Convert.ToInt32(userInfo.ElementAt(0).Value);

            JObject data = new JObject();

            ReturnJson.Add("Status", 0);
            ReturnJson.Add("Message", "操作成功");
            ReturnJson.Add("data", data);
            return ResponseJson(this.ReturnJson.ToString());
        }
    }
}