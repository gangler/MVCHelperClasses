using System;
using System.Web;


namespace MVCHelperClasses.Helpers
{
    public class HttpHelper
    {

        /// <summary>
        /// 获取当前IP和端口号
        /// </summary>
        public static string GetServerUrl()
        {
            // 是否为SSL认证站点
            string secure = HttpContext.Current.Request.ServerVariables["HTTPS"];
            string httpProtocol = (secure == "on" ? "https://" : "http://");

            // 服务器名称
            string serverName = HttpContext.Current.Request.ServerVariables["Server_Name"];
            string port = HttpContext.Current.Request.Url.Port.ToString();
            return httpProtocol + serverName + ":" + port + "/";
        }


        public static string GetServerIpPort()
        {
            if (System.Web.HttpContext.Current == null
                || System.Web.HttpContext.Current.Request == null
                || System.Web.HttpContext.Current.Request.ServerVariables == null)
            {
                return "";
            }
            return System.Web.HttpContext.Current.Request.Url.Authority;//.ServerVariables.Get("Local_Addr").ToString() + ":" + System.Web.HttpContext.Current.Request.Url.Port;
            //            var requestIP = HttpContext.Current.Request.UserHostAddress;  //请求的IP地址
            //            var requestIPName = HttpContext.Current.Request.Url.DnsSafeHost;   //可能是DNS,或者域名,不一定为IP地址
            //            var port = HttpContext.Current.Request.Url.Port;  //当前请求HTTP的端口
            //            var serverIP = HttpContext.Current.Request.ServerVariables.Get("Local_Addr").ToString();   //获取服务端IP地址
            //            var ip = requestIP + ":" + port + "/HT/ " + " requestIP:" + requestIP + "==>requestIPName:" + requestIPName;
            //            获取IP
            //Request.ServerVariables["LOCAL_ADDR"].ToString()
            //获取域名
            //Request.ServerVariables["SERVER_NAME"].ToString()
            //获取语言
            //Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].ToString()
            //获取端口
            //Request.ServerVariables["SERVER_PORT"].ToString()
        }


        public static string GetWebClientIp()
        {

            string userIP = "未获取用户IP";

            try
            {
                if (System.Web.HttpContext.Current == null
                 || System.Web.HttpContext.Current.Request == null
                 || System.Web.HttpContext.Current.Request.ServerVariables == null)
                {
                    return "";
                }

                string CustomerIP = "";

                //CDN加速后取到的IP simone 090805
                CustomerIP = System.Web.HttpContext.Current.Request.Headers["Cdn-Src-Ip"];
                if (!string.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (!String.IsNullOrEmpty(CustomerIP))
                {
                    return CustomerIP;
                }

                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    if (CustomerIP == null)
                    {
                        CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    }
                }
                else
                {
                    CustomerIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                if (string.Compare(CustomerIP, "unknown", true) == 0 || String.IsNullOrEmpty(CustomerIP))
                {
                    return System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                return CustomerIP;
            }
            catch { }

            return userIP;
        }

    }
}