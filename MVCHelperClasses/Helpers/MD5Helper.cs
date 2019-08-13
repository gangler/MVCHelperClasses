using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;


namespace MVCHelperClasses.Helpers
{
    public class CommonHelper
    {
       /// <summary>
       /// MD5加密（32位小写，字符编码UTF-8）
       /// </summary>
       /// <param name="str"></param>
        public static string CalcMD5(string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
			return CalcMD5(bytes).ToLower();
        }

        public static string CalcMD5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" + computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }

        public static string CalcMD5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" + computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }


        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="value"></param>
        public static string ToBase64String(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// base64解密
        /// </summary>
        /// <param name="value"></param>
        public static string FromBase64String(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
