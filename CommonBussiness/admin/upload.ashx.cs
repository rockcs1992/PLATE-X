using System;
using System.Web;
using System.IO;
using System.Drawing;

namespace CommonBussiness.admin
{
    /// <summary>
    /// upload1 的摘要说明
    /// </summary>
    public class upload1 : IHttpHandler
    {
        public string ImgFormat = ".jpg|.png|.gif|.jpeg|.bmp|";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            HttpPostedFile file;
            if (context.Request.Files["Filedata"] == null)//通过编辑器上传的图片
            {
            }
            else //通过SWFupload上传的图片
            {
                file = context.Request.Files["Filedata"];//接收文件.
                string fileName = Path.GetFileName(file.FileName);//获取文件名.
                string fileExt = Path.GetExtension(fileName).ToLower();//获取文件扩展名
                Random rnd = new Random();
                if (ImgFormat.IndexOf(fileExt) > -1)
                {
                    string dir = "/UploadImg/ProImg/";//文件保存路径
                    // string _thumb = "/uploadimg/thumb/";
                    Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(dir)));//创建目录文件夹
                    //Directory.CreateDirectory(Path.GetDirectoryName(context.Server.MapPath(_thumb)));//创建缩略图目录文件夹
                    string fn = DateTime.Now.ToString("yyyyMMddhhmmssff") + rnd.Next(100000).ToString();
                    string fullDir = dir + fn + fileExt;//MD5校验文件
                    file.SaveAs(context.Server.MapPath(fullDir));//保存文件
                    //string thumb = Thumbnail(fullDir, _thumb);
                    context.Response.Write(fullDir);
                }
            }
        }
        //生成缩略图
        protected string Thumbnail(string path, string thumbpath)
        {
            string thumb = string.Empty;
            string src = path;   //源图像文件的绝对路径
            string filename = System.IO.Path.GetFileName(path);
            string dest = thumbpath + filename;    //生成的缩略图图像文件的绝对路径
            int thumbWidth = Convert.ToInt32(300);    //要生成的缩略图的宽度
            System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(src)); //利用Image对象装载源图像
            //接着创建一个System.Drawing.Bitmap对象，并设置你希望的缩略图的宽度和高度。
            int srcWidth = image.Width;
            int srcHeight = image.Height;
            int thumbHeight = srcHeight * thumbWidth / srcWidth;
            Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
            //从Bitmap创建一个System.Drawing.Graphics对象，用来绘制高质量的缩小图。
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            //设置 System.Drawing.Graphics对象的SmoothingMode属性为HighQuality
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //下面这个也设成高质量
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //下面这个设成High
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //把原始图像绘制成上面所设置宽高的缩小图
            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
            //保存图像
            bmp.Save(System.Web.HttpContext.Current.Server.MapPath(dest));
            thumb = dest;
            //释放资源
            bmp.Dispose();
            image.Dispose();
            return thumb;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}