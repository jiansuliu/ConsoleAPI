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

namespace ConsoleAPI.Controllers
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class SystemController : MasterPageController
    {
        EMC.BLL.System dal_System = new EMC.BLL.System();
        /// <summary>
        /// 获取验证码
        /// </summary>
        public HttpResponseMessage GetValidateCode()
        {
            JObject data = new JObject();
            EMC.Com.ValidateCode ValidateCode = new EMC.Com.ValidateCode();
            string code = ValidateCode.CreateValidateCode(4);//生成验证码，传几就是几位验证码
            byte[] buffer = ValidateCode.CreateValidateGraphic(code);//把验证码画到画布
            data.Add("code", code);
            data.Add("img", buffer);
            ReturnJson.Add("Status", 0);
            ReturnJson.Add("Message", "操作成功");
            ReturnJson.Add("data", data);
            return ResponseJson(this.ReturnJson.ToString());
        }

        /// <summary>
        /// 获取系统信息
        /// </summary>
        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetSystemConfig()
        {
            JObject data = new JObject();
            int Status = 0;
            string Message = "操作成功";

            var userInfo = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            int mid = Convert.ToInt32(userInfo.ElementAt(0).Value);
            EMC.Model.tb001 model = EMC.DbUtility.Utility.GetModel<EMC.Model.tb001>(mid);
            data.Add("AdminName", model.F001TB001);

            List<EMC.Model.tb003> menuList = dal_System.GetMainMenu(mid);
            JArray listMenu = new JArray();
            foreach (EMC.Model.tb003 modelTB003 in menuList)
            {
                JObject j = new JObject();
                j.Add("ID", modelTB003.NOIDTB003);
                j.Add("Name", modelTB003.F001TB003);
                listMenu.Add(j);
            }
            data.Add("MainMenu", listMenu);

            ReturnJson.Add("Status", Status);
            ReturnJson.Add("Message", Message);
            ReturnJson.Add("data", data);
            return ResponseJson(this.ReturnJson.ToString());
        }

        /// <summary>
        /// 获取系统菜单
        /// </summary>
        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetMenu()
        {
            int meuid = Convert.ToInt32(HttpContext.Current.Request["meuid"]);
            JObject data = new JObject();
            int Status = 0;
            string Message = "操作成功";

            var userInfo = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            int mid = Convert.ToInt32(userInfo.ElementAt(0).Value);
            List<EMC.Model.tb004> menuList = dal_System.GetMenu(mid, meuid);
            JArray listMenu = new JArray();
            foreach (EMC.Model.tb004 modelTB004 in menuList)
            {
                JObject j = new JObject();
                j.Add("ID", modelTB004.NOIDTB004);
                j.Add("Name", modelTB004.F001TB004);
                #region 页面列表
                JArray listPage = new JArray();
                List<EMC.Model.tb002> pageList = dal_System.GetPage(mid, modelTB004.NOIDTB004);
                foreach (EMC.Model.tb002 modelTB002 in pageList)
                {
                    JObject p = new JObject();
                    p.Add("Name", modelTB002.F001TB002);
                    p.Add("Uir", modelTB002.F002TB002);
                    listPage.Add(p);
                }
                j.Add("Pages", listPage);
                #endregion
                listMenu.Add(j);
            }
            data.Add("Menu", listMenu);

            ReturnJson.Add("Status", Status);
            ReturnJson.Add("Message", Message);
            ReturnJson.Add("data", data);
            return ResponseJson(this.ReturnJson.ToString());
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        [Authorize]
        [HttpPost]
        public HttpResponseMessage ChangePassword()
        {
            string oldpwd = HttpContext.Current.Request["oldpwd"];
            string newpwd = HttpContext.Current.Request["newpwd"];
            JObject data = new JObject();
            int Status = 0;
            string Message = "操作成功";

            var userInfo = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            int mid = Convert.ToInt32(userInfo.ElementAt(0).Value);

            EMC.Model.tb001 model = EMC.DbUtility.Utility.GetModel<EMC.Model.tb001>(mid);
            if (model.F003TB001 != EMC.Com.Common.StringToMD5(oldpwd))
            {
                Status = 1;
                Message = "原始密码不正确";
            }
            else
            {
                model.F003TB001 = EMC.Com.Common.StringToMD5(newpwd);
                model.F200TB001 = mid;
                model.F201TB001 = DateTime.Now;
                EMC.DbUtility.Utility.Update<EMC.Model.tb001>(model);
            }

            ReturnJson.Add("Status", Status);
            ReturnJson.Add("Message", Message);
            ReturnJson.Add("data", data);
            return ResponseJson(this.ReturnJson.ToString());
        }

        /// <summary>
        /// 得到角色列表
        /// </summary>
        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetReloList()
        {
            string key = HttpContext.Current.Request["key"];
            int page = Convert.ToInt32(HttpContext.Current.Request["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request["limit"]);
            JObject data = new JObject();
            int Status = 0;
            string Message = "操作成功";

            var userInfo = HttpContext.Current.GetOwinContext().Authentication.User.Claims;
            int mid = Convert.ToInt32(userInfo.ElementAt(0).Value);

            int count = 0;
            List<EMC.Model.tb006> reloList = dal_System.GetReloList(key, page, limit, ref count);
            JArray listRelo = new JArray();
            foreach (EMC.Model.tb006 modelTB006 in reloList)
            {
                JObject j = new JObject();
                j.Add("id", modelTB006.NOIDTB006);
                j.Add("name", modelTB006.F001TB006);
                j.Add("explain", modelTB006.F002TB006);
                listRelo.Add(j);
            }
            data.Add("code", count > 0 ? 0 : 1);
            data.Add("msg", count > 0 ? "获取成功" : "没有数据");
            data.Add("total", count);
            data.Add("item", listRelo);

            ReturnJson.Add("Status", Status);
            ReturnJson.Add("Message", Message);
            ReturnJson.Add("data", data);
            return ResponseJson(this.ReturnJson.ToString());
        }

    }
}