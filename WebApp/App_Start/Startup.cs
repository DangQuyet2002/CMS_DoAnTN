using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Utilities;

[assembly: OwinStartup(typeof(WebApp.App_Start.Startup))]

namespace WebApp.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions()
                {
                    // Sets the ClientId, authority, RedirectUri as obtained from web.config
                    ClientId = CommonConstants.clientId,
                    Authority = CommonConstants.authenUrl,
                    RedirectUri = CommonConstants.redirectUri,
                    RequireHttpsMetadata = false,
                    // PostLogoutRedirectUri is the page that users will be redirected to after sign-out. In this case, it is using the home page
                    PostLogoutRedirectUri = CommonConstants.logoutRedirectUri,
                    Scope = OpenIdConnectScope.OpenIdProfile + " " + OpenIdConnectScope.OfflineAccess + " " + "apicore",

                    // ResponseType is set to request the code id_token - which contains basic information about the signed-in user
                    ResponseType = OpenIdConnectResponseType.CodeIdToken,
                    // ValidateIssuer set to false to allow personal and work accounts from any organization to sign in to your application
                    // To only allow users from a single organizations, set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name
                    // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false // This is a simplification
                    },
                    // OpenIdConnectAuthenticationNotifications configures OWIN to send notification of failed authentications to OnAuthenticationFailed method
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed,
                    },
                    SaveTokens = true
                }
            );
        }

        //public void Configuration(IAppBuilder app)
        //{
        //    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        //    app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = "Cookies"
        //    });
        //    JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        //    app.UseOpenIdConnectAuthentication(
        //        new OpenIdConnectAuthenticationOptions()
        //        {
        //            // Sets the ClientId, authority, RedirectUri as obtained from web.config
        //            //ClientId = "3a7cf120-94f1-461c-bacf-a0d9f888da3d",
        //            ClientId = "9ae13404-227c-400b-b682-581c2e0125b1",
        //            Authority = "https://sso.hnmu.essoft.vn/",
        //            RedirectUri = "https://sinhvien.test.essoft.vn/signin-oidc",
        //            RequireHttpsMetadata = false,
        //            // PostLogoutRedirectUri is the page that users will be redirected to after sign-out. In this case, it is using the home page
        //            PostLogoutRedirectUri = "https://sinhvien.test.essoft.vn/",
        //            Scope = OpenIdConnectScope.OpenIdProfile + " " + OpenIdConnectScope.OfflineAccess + " " + "apicore",

        //            // ResponseType is set to request the code id_token - which contains basic information about the signed-in user
        //            ResponseType = OpenIdConnectResponseType.CodeIdToken,
        //            // ValidateIssuer set to false to allow personal and work accounts from any organization to sign in to your application
        //            // To only allow users from a single organizations, set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name
        //            // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter
        //            TokenValidationParameters = new TokenValidationParameters()
        //            {
        //                ValidateIssuer = false // This is a simplification
        //            },
        //            // OpenIdConnectAuthenticationNotifications configures OWIN to send notification of failed authentications to OnAuthenticationFailed method
        //            Notifications = new OpenIdConnectAuthenticationNotifications
        //            {
        //                AuthenticationFailed = OnAuthenticationFailed,
        //            },
        //            SaveTokens = true
        //        }
        //    );
        //}

        /// <summary>
        /// Handle failed authentication requests by redirecting the user to the home page with an error in the query string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }
    }
}