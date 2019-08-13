using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace MVCHelperClasses.Helpers
{
    public class PictureHelper
    {
        /// <summary>
		/// 定义并初始化图片宽(下限)
		/// </summary>
		protected static int minHeight = 0;
        /// <summary>
        /// 定义并初始化图片长(下限)
        /// </summary>
        protected static int minWidth = 0;
        /// <summary>
        /// 定义并初始化图片宽(上限)
        /// </summary>
        protected static int maxHeight = 600;
        /// <summary>
        /// 定义并初始化图片长(上限)
        /// </summary>
        protected static int maxWidth = 800;
        /// <summary>
        /// 定义并初始化图片长(实际值)
        /// </summary>
        protected static int width = 0;
        /// <summary>
        /// 定义并初始化图片宽(实际值)
        /// </summary>
        protected static int height = 0;
        /// <summary>
        /// 定义文件对象
        /// </summary>
        protected static HttpPostedFileBase file;
        /// <summary>
        /// 定义并初始化文件后缀列表
        /// </summary>
        protected static readonly List<string> pictureext = new List<string>() { "jpg", "png" };
        /// <summary>
        /// 定义并初始化文件大小
        /// </summary>
        protected static readonly int picturesize = 2;//MB


        /// <summary>
        /// 构造函数
        /// </summary>  
        /// <param name="f">文件</param>
        public PictureHelper(HttpPostedFileBase f)
        {
            file = f;
        }


        /// <summary>
        /// 判断图片格式是否正确（默认）
        /// </summary>  
        public static bool IsPicture()
        {
            return IsPicture(pictureext);
        }


        /// <summary>
        /// 判断图片格式是否正确（指定格式）
        /// </summary>  
        /// <param name="picextention">指定格式列表</param>
        public static bool IsPicture(List<string> picextention)
        {
            bool ispicture = false;
            string fileext = Path.GetExtension(file.FileName).Trim().ToLower();
            if (picextention.Contains(fileext))
                ispicture = true;
            return ispicture;
        }


        /// <summary>
        /// 判断图片大小是否正确（默认）
        /// </summary>  
        public static bool CheckSize()
        {

            return CheckSize(picturesize);
        }


        /// <summary>
        /// 判断图片大小是否正确（指定最大值）
        /// </summary>  
        /// <param name="maxsize">图片最大值</param>
        public static bool CheckSize(int maxsize)
        {
            bool size = false;
            int sizenum = maxsize * 1024 * 1024;
            if (0 <= file.ContentLength && file.ContentLength <= sizenum)
                size = true;
            return size;
        }


        /// <summary>
        /// 获取图片像素
        /// </summary>  
        /// <param name="height">宽</param>
        /// <param name="width">长</param>
        public static void GetPicturePixel(out int width, out int height)
        {
            Image image = Image.FromStream(file.InputStream);
            width = image.Width;
            height = image.Height;
        }


        /// <summary>
        /// 判断图片像素是否正确（指定范围）
        /// </summary>  
        /// <param name="maxheight">图片宽上限</param>
        /// <param name="maxwidth">图片长上限</param>
        /// <param name="minheight">图片宽下限</param>
        /// <param name="minwidth">图片长下限</param>
        public static bool CheckPixel(int minwidth, int minheight, int maxwidth, int maxheight)
        {
            if (width < minwidth || width > maxwidth || height < minheight || height > maxheight)
                return false;
            return true;
        }


        /// <summary>
        /// 判断图片像素是否正确（指定最大值）
        /// </summary>  
        /// <param name="maxheight">图片宽上限</param>
        /// <param name="maxwidth">图片长上限</param>
        public static bool CheckPixel(int maxwidth, int maxheight)
        {
            return CheckPixel(minWidth, minHeight, maxwidth, maxheight);
        }


        /// <summary>
        /// 判断图片像素是否正确（默认）
        /// </summary>  
        public static bool CheckPixel()
        {
            return CheckPixel(maxWidth, maxHeight);
        }


        /// <summary>
        /// 保存图片（指定后缀名）
        /// </summary> 
        /// <param name="extname">后缀名</param>
        /// <param name="path">路径</param>
        /// <param name="picturename">图片名</param>
        public static void SavePicture(string path, string picturename, string extname)
        {
            string fullpath = Path.Combine(path, picturename + extname);
            file.SaveAs(fullpath);
        }


        /// <summary>
        /// 保存图片（默认）
        /// </summary> 
        /// <param name="path">路径</param>
        /// <param name="picturename">图片名</param>
        public static void SavePicture(string path, string picturename)
        {
            string fileext = Path.GetExtension(file.FileName).Trim().ToLower();
            SavePicture(path, picturename, fileext);
        }


        /// <summary>
        /// 保存图片（指定路径和文件名）
        /// </summary> 
        /// <param name="fullname">路径和文件名</param>
        public static void SavePicture(string fullname)
        {
            file.SaveAs(fullname);
        }


        /// <summary>
        /// 图片压缩，并保存
        /// </summary>
        /// <param name="startImgUrl">原图片地址</param>
        /// <param name="endImgUrl">压缩后图片地址</param>
        /// <param name="height">高度</param>
        /// <param name="width">宽度</param>
        /// <param name="flag">压缩质量 1-100</param>
        /// <returns></returns>
        public void PicThumbnail(string startImgUrl, string endImgUrl, int height, int width, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(startImgUrl);
            ImageFormat iformat = iSource.RawFormat;
            int sW = 0, sH = 0;
            //按比例缩放
            Size re_zize = new Size(iSource.Width, iSource.Height);//原图比例
            if (re_zize.Width > height || re_zize.Width > width)
            {
                if ((re_zize.Width * height) > (re_zize.Height * width))
                {
                    sW = width;
                    sH = (width * re_zize.Height) / re_zize.Width;
                }
                else
                {
                    sH = height;
                    sW = (re_zize.Width * height) / re_zize.Height;
                }
            }
            else
            {
                sW = re_zize.Width;
                sH = re_zize.Height;
            }

            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(iSource, new Rectangle((width - sW) / 2, (height - sH) / 2, sW, sH),
                0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            //保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    bm.Save(endImgUrl, jpegICIinfo, ep);
                }
                else
                {
                    bm.Save(endImgUrl, iformat);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                iSource.Dispose();
                bm.Dispose();
            }
        }
}