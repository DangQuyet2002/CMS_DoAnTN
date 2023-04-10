using APIServices;
using APIServices.CMS;
using APIServices.CMS.QuanLyMenu;
using Autofac;
using Autofac.Integration.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Utilities;

namespace WebApp
{
    public class ServiceProvider
    {
        public static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            //register web controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //register services
            builder.RegisterAssemblyTypes(typeof(STULopApiService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            //autofac container
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (tbl_UserModel)filterContext.HttpContext.Session[Constants.SSUserLogIn];
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index", area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class AuthorTrangNguoiDung : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var BackUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            var user = (List<tbl_SettingMenu_CategoryModel>)filterContext.HttpContext.Session[Constants.SSMenu];
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }


    public static class SessionHelper
    {
        public static void AddObject(string key, object value, int seconds = 3600)
        {
            UserClaims user = SessionControl.GetUserClaims();
            key = CommonConstants.clientId + "_" + user.sub + "_" + key;
            SessionControl.AddObject(key, value, seconds);
        }

        public static T GetObject<T>(string key)
        {
            UserClaims user = SessionControl.GetUserClaims();
            if (user != null)
            {
                key = CommonConstants.clientId + "_" + user.sub + "_" + key;
                return SessionControl.GetObject<T>(key);
            }
            return default(T);
        }
    }

    public static class ConvertNumberRoMan
    {
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public static int RomanToInteger(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }
            return number;
        }
    }

    public static class Utils
    {
        //Trang hien tai-so banghi tren 1 trang -Tong so ban ghi
        public static string HtmlPaging(int currentPage, int rowPerPage, int totalRecord)
        {
            //So bản ghi
            int totalPage = totalRecord > 0 ? ((totalRecord % rowPerPage == 0) ? totalRecord / rowPerPage : ((totalRecord - (totalRecord % rowPerPage)) / rowPerPage) + 1) : 0;
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<nav aria-label=\"Page navigation example\" style=\"float:right\"><ul class=\"pagination pagination-separated justify-content-center justify-content-sm-end mb-sm-0\">");
            if (totalRecord > 0)
            {
                if (currentPage != 1)
                {
                    strBuilder.AppendFormat("<li class=\"page-item\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\"><i class=\"mdi mdi-chevron-left\"></i></a> </li>", currentPage - 1, rowPerPage);
                }

                if (totalPage <= 5)
                {
                    for (int itemPage = 1; itemPage <= totalPage; itemPage++)
                    {
                        if (currentPage == itemPage)
                        {
                            strBuilder.AppendFormat("<li class=\"page-item active\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\">" + itemPage + "</a> </li>", itemPage, rowPerPage);
                        }
                        else
                        {
                            strBuilder.AppendFormat("<li class=\"page-item\"> <a href=\"#\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\">" + itemPage + "</a> </li>", itemPage, rowPerPage);
                        }
                    }
                }
                else if ((totalPage - currentPage) >= 5)
                {
                    if (currentPage > 1)
                    {
                        strBuilder.AppendFormat("<li class=\"page-item disabled\"> <a href=\"javascript:void(0)\" class=\"page-link\">...</a> </li>");
                    }
                    for (int itemPage = currentPage; itemPage <= currentPage + 5; itemPage++)
                    {
                        if (currentPage == itemPage)
                        {
                            strBuilder.AppendFormat("<li class=\"page-item active\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\">" + itemPage + "</a> </li>", itemPage, rowPerPage);
                        }
                        else
                        {
                            strBuilder.AppendFormat("<li class=\"page-item\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\">" + itemPage + "</a> </li>", itemPage, rowPerPage);
                        }
                    }
                    if ((totalPage - currentPage) > 5)
                    {
                        strBuilder.AppendFormat("<li class=\"page-item disabled\"> <a href=\"javascript:void(0)\" class=\"page-link\">...</a> </li>");
                    }
                }
                else if ((totalPage - currentPage) < 5)
                {
                    var kcBanGhi = 5 - (totalPage - currentPage);
                    if (currentPage - kcBanGhi > 1)
                    {
                        strBuilder.AppendFormat("<li class=\"page-item disabled\"> <a href=\"javascript:void(0)\" class=\"page-link\">...</a> </li>");
                    }
                    for (int itemPage = currentPage - kcBanGhi; itemPage <= totalPage; itemPage++)
                    {
                        if (currentPage == itemPage)
                        {
                            strBuilder.AppendFormat("<li class=\"page-item active\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\">" + itemPage + "</a> </li>", itemPage, rowPerPage);
                        }
                        else
                        {
                            strBuilder.AppendFormat("<li class=\"page-item\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\">" + itemPage + "</a> </li>", itemPage, rowPerPage);
                        }
                    }
                }
                if (currentPage != totalPage)
                {
                    strBuilder.AppendFormat("<li class=\"page-item\"> <a href=\"javascript:void(0)\"  onclick=\"LoadPage({0},{1})\" class=\"page-link\"><i class=\"mdi mdi-chevron-right\"></i></a> </li>", currentPage + 1, rowPerPage);
                }
            }
            else
            {
                strBuilder.Append("<div class=\"bottom-pager\"><span></span></div>\r\n");
            }
            return strBuilder.ToString();
        }

        public static string convertToUnSign2(string s = "")
        {

            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            string StrUrl = (sb.ToString().Normalize(NormalizationForm.FormD)).ToString();
            StrUrl = Regex.Replace(StrUrl, @"[^0-9A-Za-z\s]", "").Replace(" ", "-");
            StrUrl = Regex.Replace(StrUrl, @"(\s+|@|&|'|\(|\)|<|>|#)", "_");
            return StrUrl;
        }

        public static string GetYouTubeVideoIdFromUrl(string url)
        {
            Uri uri = null;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                try
                {
                    uri = new UriBuilder("http", url).Uri;
                }
                catch
                {
                    // invalid url
                    return "";
                }
            }

            string host = uri.Host;
            string[] youTubeHosts = { "www.youtube.com", "youtube.com", "youtu.be", "www.youtu.be" };
            if (!youTubeHosts.Contains(host))
                return "";

            var query = HttpUtility.ParseQueryString(uri.Query);

            if (query.AllKeys.Contains("v"))
            {
                return Regex.Match(query["v"], @"^[a-zA-Z0-9_-]{11}$").Value;
            }
            else if (query.AllKeys.Contains("u"))
            {
                // some urls have something like "u=/watch?v=AAAAAAAAA16"
                return Regex.Match(query["u"], @"/watch\?v=([a-zA-Z0-9_-]{11})").Groups[1].Value;
            }
            else
            {
                // remove a trailing forward space
                var last = uri.Segments.Last().Replace("/", "");
                if (Regex.IsMatch(last, @"^v=[a-zA-Z0-9_-]{11}$"))
                    return last.Replace("v=", "");

                string[] segments = uri.Segments;
                if (segments.Length > 2 && segments[segments.Length - 2] != "v/" && segments[segments.Length - 2] != "watch/")
                    return "";

                return Regex.Match(last, @"^[a-zA-Z0-9_-]{11}$").Value;
            }
        }
    }
}