using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace MVCHelperClasses.Helpers
{
    public class CacheHelper
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="timeout"></param>
        public static void SetCache(string CacheKey, object objObject, int timeout = 600)
        {
            try
            {
                if (objObject == null) return;
                var objCache = HttpRuntime.Cache;
                //相对过期  
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null);  
                //绝对过期时间  
                objCache.Insert(CacheKey, objObject, null, DateTime.Now.AddSeconds(timeout), TimeSpan.Zero, CacheItemPriority.High, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取指定缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static int RemoveCache(string CacheKey)
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            _cache.Remove(CacheKey);
            return _cache.Count;
        }
    }
}