using IdentityModel.Client;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Utilities;

namespace WebApp.Controllers
{
    public class AuthenController : Controller
    {


        //private readonly ICommonService _CommonService;

        //public AuthenController(ICommonService CommonService)
        //{
        //    _CommonService = CommonService;

        //}

        //// GET: Authen
        //public ActionResult Index()
        //{
        //    return View();
        //}
        ///// <summary>
        ///// Send an OpenID Connect sign-in request.
        ///// Alternatively, you can just decorate the SignIn method with the  attribute
        ///// </summary>
        //public void SignIn()
        //{
        //    if (!Request.IsAuthenticated)
        //    {
        //        HttpContext.GetOwinContext().Authentication.Challenge(
        //            new AuthenticationProperties { RedirectUri = Url.Action("GetToken", "Authen") },
        //            OpenIdConnectAuthenticationDefaults.AuthenticationType);
        //    }
        //    else
        //    {
        //        Response.Redirect("~/Authen/GetToken");
        //    }
        //}

        ///// <summary>
        ///// Send an OpenID Connect sign-out request.
        ///// </summary>
        //public void Signout()
        //{
        //    FormsAuthentication.SignOut();
        //    //SessionControl.DelAll();
        //    HttpContext.GetOwinContext().Authentication.SignOut();
        //}
        ////
        //public async Task<ActionResult> GetToken()
        //{
        //    try
        //    {
        //        var client = new HttpClient();

        //        #region Models UserClaims
        //        // public class UserClaims
        //        //{
        //        //  public string sub { get; set; }
        //        //  public string name { get; set; }
        //        //  public string given_name { get; set; }
        //        //  public string family_name { get; set; }
        //        //  public string preferred_username { get; set; } //UserName
        //        //  public string access_token { get; set; }
        //        //  public string expires_at { get; set; }
        //        //  public string roles { get; set; }
        //        //}
        //        #endregion
        //        var userclaims = new UserClaims();

        //        // Lấy thông tin các Document của IdentityServer
        //        var disco = await client.GetDiscoveryDocumentAsync(CommonConstants.authenUrl); //url IdentityServer

        //        // Kiểm tra cấp document nếu gặp lỗi thì xử lý
        //        if (disco.IsError)
        //        {
        //            //Do SaveLog Error\
        //            return RedirectToAction("SignOut");
        //            //return RedirectToAction("Index", "Home");
        //        }

        //        //Gửi yêu cầu cấp access token
        //        var tokenendpoint = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //        {
        //            Address = disco.TokenEndpoint,
        //            ClientId = CommonConstants.clientId,
        //            ClientSecret = CommonConstants.clientSecret,
        //            Scope = CommonConstants.scope
        //        });
        //        // Kiểm tra cấp token nếu gặp lỗi thì xử lý
        //        if (tokenendpoint.IsError)
        //        {
        //            //Do SaveLog Error
        //            return RedirectToAction("SignOut");
        //            // return RedirectToAction("Index", "Home");
        //        }

        //        // Convert thông tin người dùng sang Claims
        //        var claims = User.Identity as ClaimsIdentity;
        //        foreach (var item in claims.Claims)
        //        {
        //            switch (item.Type)
        //            {
        //                case "sub":
        //                    userclaims.sub = item.Value;
        //                    break;

        //                case "name":
        //                    userclaims.name = item.Value;
        //                    break;

        //                case "given_name":
        //                    userclaims.given_name = item.Value;
        //                    break;

        //                case "family_name":
        //                    userclaims.family_name = item.Value;
        //                    break;

        //                case "preferred_username":
        //                    userclaims.preferred_username = item.Value;
        //                    break;
        //            }
        //        }

        //        // Xử lý lấy thông tin access token và thời hạn của token lưu vào ticket
        //        //userclaims.access_token = tokenendpoint.AccessToken;
        //        //userclaims.expires_at = DateTime.UtcNow.AddSeconds(tokenendpoint.ExpiresIn).ToLocalTime().ToString(System.Globalization.CultureInfo.InvariantCulture);


        //        if(!string.IsNullOrEmpty(userclaims.sub))
        //        {
        //            var TTNguoiDung = await _CommonService.ThongTinNguoiDung(userclaims.sub);
        //            userclaims.ID_dv = TTNguoiDung.ID_dv;
        //        }    
        //        JavaScriptSerializer serializer = new JavaScriptSerializer();

        //        string userData = serializer.Serialize(userclaims);

        //        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
        //                 1,
        //                 userclaims.preferred_username,
        //                 DateTime.Now,
        //                 DateTime.Now.AddSeconds(tokenendpoint.ExpiresIn - 1),
        //                 false,
        //                 userData);

        //        string encTicket = FormsAuthentication.Encrypt(authTicket);
        //        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

        //        if (Request.IsLocal)
        //        {
        //            faCookie.Secure = false;
        //        }
        //        Response.Cookies.Add(faCookie);

        //        return RedirectToAction("Index", "Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
    }
}