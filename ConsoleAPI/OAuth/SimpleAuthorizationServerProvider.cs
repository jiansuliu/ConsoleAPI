using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security.OAuth;

namespace ConsoleAPI.OAuth
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        EMC.BLL.System dal = new EMC.BLL.System();
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            return Task.FromResult<object>(null);
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string adminID = "";
            #region 登陆验证
            string userName = context.UserName;
            string password = EMC.Com.Common.StringToMD5(context.Password);
            string message = "";
            EMC.Model.tb001 model = null;

            int res = dal.AdminLogin(userName, password, EMC.Com.Common.GetIPAddress(), ref model, ref message);
            if (res != 0)
            {
                context.SetError("invalid_grant", message);
                return;
            }
            else
            {
                adminID = model.NOIDTB001.ToString();
            }
            #endregion
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("adminID", adminID));
            context.Validated(identity);
            await base.GrantResourceOwnerCredentials(context);
        }
    }
}