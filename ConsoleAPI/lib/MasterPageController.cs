using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json.Linq;

namespace ConsoleAPI.lib
{
    public class MasterPageController : ApiController
    {
        protected string PostInput = string.Empty;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }
        #region 页面输出JSON
        private JObject _returnJson;
        /// <summary>
        /// JSON返回值
        /// </summary>
        public JObject ReturnJson
        {
            get
            {
                if (_returnJson == null)
                {
                    _returnJson = new JObject();
                }
                return _returnJson;
            }
            set
            {
                if (value != null)
                {
                    _returnJson = value;
                }
            }
        }
        private JObject _returnErrorJson;
        /// <summary>
        /// JSON返回值
        /// </summary>
        public JObject ReturnErrorJson
        {
            get
            {
                if (_returnErrorJson == null)
                {
                    _returnErrorJson = new JObject();
                }
                return _returnErrorJson;
            }
            set
            {
                if (value != null)
                {
                    _returnErrorJson = value;
                }
            }
        }
        /// <summary>
        /// 返回json
        /// </summary>
        public HttpResponseMessage ResponseJson(string mes)
        {
            HttpResponseMessage ResponseMsg = new HttpResponseMessage { Content = new StringContent(mes, System.Text.Encoding.UTF8, "application/json") };
            ResponseMsg.Headers.Add("Access-Control-Allow-Origin", "*");
            return ResponseMsg;
        }
        #endregion

        /// <summary>
        /// 得到网站图片路径
        /// </summary>
        public static string GetImgServerPath()
        {
            return ConfigurationManager.AppSettings["ImgServer"].ToString();
        }
    }
}
