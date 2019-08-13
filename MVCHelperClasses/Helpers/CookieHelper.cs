using System;
using System.Web;


namespace MVCHelperClasses.Helpers
{
    public class CookieHelper
    {
        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        public static void ClearCookie(string cookiename)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie == null) return;

            cookie.Expires = DateTime.Now.AddYears(-3);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }


        /// <summary>
        /// 获取指定Cookie值
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        /// <returns></returns>
        public static string GetCookieValue(string cookiename)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookiename];
            var str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }


        /// <summary>
        /// 添加一个Cookie（24小时过期）
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        public static void SetCookie(string cookiename, string cookievalue)
        {
            SetCookie(cookiename, cookievalue, DateTime.Now.AddDays(1.0));
        }


        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">过期时间 DateTime 默认不过期</param>
        public static void SetCookie(string cookiename, string cookievalue, DateTime? expires)
        {
            var cookie = new HttpCookie(cookiename)
            {
                Value = cookievalue,
                Expires = expires ?? DateTime.MaxValue
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }


        //public static string GetEncryptCookieValue()
        //{
        //    string cookiename = FormsAuthentication.FormsCookieName;
        //    var cookie = HttpContext.Current.Request.Cookies[cookiename];
        //    var str = string.Empty;
        //    if (cookie != null)
        //    {
        //        FormsAuthenticationTicket tic = FormsAuthentication.Decrypt(cookie.Value);
        //        str = tic.UserData;
        //    }
        //    return str;
        //}


        /// <summary>
        /// 添加一个加密Cookie（24小时过期）
        /// </summary>
        /// <param name="cookiename"></param>
        /// <param name="cookievalue"></param>
        //public static void SetEncryptCookie(string cookiename, string cookievalue)
        //{
        //    SetEncryptCookie(cookiename, cookievalue, DateTime.Now.AddDays(1.0));
        //}

        /// <summary>
        /// 添加一个Cookie
        /// </summary>
        /// <param name="cookiename">cookie名</param>
        /// <param name="cookievalue">cookie值</param>
        /// <param name="expires">过期时间 DateTime 默认不过期</param>
        //public static void SetEncryptCookie(string cookiename, string cookievalue, DateTime? expires)
        //{
        //    FormsAuthenticationTicket tic = new FormsAuthenticationTicket(1, cookiename, System.DateTime.Now, expires ?? DateTime.MaxValue, false, cookievalue);

        //    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tic))
        //    {
        //        HttpOnly = true,
        //        Expires = expires ?? DateTime.MaxValue
        //    };
        //    HttpContext.Current.Response.Cookies.Add(cookie);
        //}
    }
}
