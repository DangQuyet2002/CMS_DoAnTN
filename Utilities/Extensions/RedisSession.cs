using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class RedisSession
    {
        private static readonly RedisClient _redisClient = new RedisClient(ConfigurationManager.AppSettings["RedisSession:Host"]
            , int.Parse(ConfigurationManager.AppSettings["RedisSession:Port"])
            , ConfigurationManager.AppSettings["RedisSession:Password"]);
        /// <summary>
        /// Tạo giá trị lưu cache theo key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        /// <returns>True nếu thành công. False nếu xảy ra lỗi</returns>
        public static bool Set(string key, object value, int seconds)
        {
            try
            {
                if (_redisClient.Set(key, value))
                {
                    _redisClient.Expire(key, seconds);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// Lấy giá trị lưu cache theo key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            try
            {
                if (_redisClient.Exists(key) > 0)
                {
                    return _redisClient.Get<T>(key);
                }
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        /// <summary>
        /// Xóa bỏ cache theo key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True nếu thành công. False nếu xảy ra lỗi</returns>
        public static bool Delete(string key)
        {
            try
            {
                return _redisClient.Del(key) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public static bool DeleteByFindKey(string key)
        //{
        //    try
        //    {
        //        return _redisClient.Del(key) > 0;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
