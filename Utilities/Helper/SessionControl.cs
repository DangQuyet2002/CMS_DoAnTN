using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Security;

namespace Utilities
{
    public static class SessionControl
    {
        #region RedisCache
        /// <summary>
        /// Thêm object vào Redis Cache theo key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        public static void AddObject(string key, object value, int seconds = 3600)
        {
            RedisSession.Set(key, value, seconds);
        }
        /// <summary>
        /// Lấy object từ Redis Cache theo key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(string key)
        {
            try
            {
                return RedisSession.Get<T>(key);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        /// <summary>
        /// Xóa object từ Redis Cache theo key
        /// </summary>
        /// <param name="key"></param>
        public static void DelObject(string key)
        {
            RedisSession.Delete(key);
        }
        #endregion

        #region Thông tin User
        /// <summary>
        /// Lấy thông tin User từ Cookie
        /// </summary>
        /// <returns></returns>
        public static UserClaims GetUserClaims()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    var encTicket = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;

                    return JsonConvert.DeserializeObject<UserClaims>(FormsAuthentication.Decrypt(encTicket).UserData);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy User Id từ cookies
        /// </summary>
        /// <returns></returns>
        public static string GetUserIdClaims()
        {
            try
            {
                var GetCookies = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
                if (GetCookies != null)
                {
                    var encTicket = GetCookies.Value;

                    return JsonConvert.DeserializeObject<UserClaims>(FormsAuthentication.Decrypt(encTicket).UserData).sub;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Lấy thông tin User theo HR
        /// </summary>
        /// <returns></returns>
        public static HRLyLich GetUserInfo()
        {
            try
            {
                UserClaims userClaims = GetUserClaims();
                if (userClaims != null)
                {
                    return new HRLyLich(userClaims);
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region Sessions
        /// <summary>
        /// Set object to session
        /// </summary>
        /// <param name="strSessionName"></param>
        /// <param name="objValue"></param>
        /// <param name="timeout"></param>
        public static void AddSession(string strSessionName, string objValue, int timeout = 60)
        {
            HttpContext.Current.Session.Remove(strSessionName);
            HttpContext.Current.Session[strSessionName] = Encryptor.Encrypt(objValue, strSessionName);
            HttpContext.Current.Session.Timeout = timeout;
        }
        /// <summary>
        /// Get object from session
        /// </summary>
        /// <param name="strSessionName"></param>
        /// <returns></returns>
        public static string GetSession(string strSessionName)
        {
            try
            {
                var GetSession = HttpContext.Current.Session[strSessionName];
                if (GetSession != null)
                {
                    return Encryptor.Decrypt(GetSession.ToString(), strSessionName);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// Clear Object from session
        /// </summary>
        /// <param name="strSessionName"></param>
        public static void ClearSession(string strSessionName)
        {
            HttpContext.Current.Session.Remove(strSessionName);
        }
        /// <summary>
        /// Xóa toàn bộ Session và Cookies
        /// </summary>
        public static void DelAll()
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", null));
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, null)
            {
                Expires = DateTime.Now.AddDays(-10)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
        }

        public static void AddNormalSession(string strSessionName, object objValue, int timeout = 60)
        {
            HttpContext.Current.Session.Remove(strSessionName);
            HttpContext.Current.Session[strSessionName] = objValue;
            HttpContext.Current.Session.Timeout = timeout;
        }
        public static object GetNormalSession(string strSessionName)
        {
            return HttpContext.Current.Session[strSessionName];
        }
        #endregion
    }
}