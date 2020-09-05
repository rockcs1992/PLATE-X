using System;
using System.IO;
using System.Web;
using System.Text;
using System.Threading;
/// <summary>
/// DoFile 的摘要说明。
/// </summary>
public class DoFile
{
    public DoFile()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// Delete指定文件
    /// </summary>
    /// <param name="filename">虚拟路径  不是 全部绝对路径</param>
    /// <returns></returns>
    public static int DeleteFile(string filename)
    {
        if (filename == string.Empty || filename == "" || filename == null)
            return 0;
        else
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(filename)))
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(filename));
                return 1;
            }
            return 0;
        }
    }

    public static bool MoveConfig(int type, string folder)
    {
        string file = "";
        if (type == 0)
        {
            //代表默认的程序-->修改为一
            file = HttpContext.Current.Server.MapPath("~/" + folder + "/config/html/web.config");


        }
        else
        {
            //修改为其他的
            file = HttpContext.Current.Server.MapPath("~/" + folder + "/config/aspx/web.config");
        }

        string newfile = HttpContext.Current.Server.MapPath("~/web.config");
        try
        {
            if (File.Exists(file))
            {
                if (File.Exists(newfile))
                {
                    File.Delete(newfile);
                }
                FileInfo fi = new FileInfo(file);

                FileInfo fi1 = fi.CopyTo(newfile);

            }
            return true;
        }
        catch
        {
            return false;
        }

    }



    //增加方法

    /// <summary>
    /// 文件地址
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="str">写入的内容</param>
    public static void WriteFile(string filename, string str)
    {
        if (!File.Exists(filename))
        {
            FileStream fs = File.Create(filename);
            fs.Close();//当时没有关闭此流
        }
         

        StreamWriter sw = new StreamWriter(filename,false, Encoding.UTF8);
        sw.Write(str);
        sw.Flush();
        sw.Close();
       


    }


    /// <summary>
    /// 输出硬盘文件，提供下载
    /// </summary>
    /// <param name="_Request">Page.Request对象</param>
    /// <param name="_Response">Page.Response对象</param>
    /// <param name="_fileName">下载文件名</param>
    /// <param name="_fullPath">带文件名下载路径</param>
    /// <param name="_speed">每秒允许下载的字节数</param>
    /// <returns>返回是否成功</returns>
    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);
            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;



                int pack = 10240; //10K bytes
                //int sleep = 200; //每秒5次 即5*10K bytes每秒
                int sleep = (int)Math.Floor((decimal)1000 * pack / _speed) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.Charset = "UTF-8";
                _Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));



                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((decimal)(fileLength - startBytes) / pack) + 1;



                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
                _Response.End();
            }
            catch (Exception ex)
            {
                _Response.Write(ex.Message);
                return false;
            }
            finally
            {
                br.Close();
                myFile.Close();
            }
        }
        catch (Exception ex)
        {
            _Response.Write(ex.Message);
            return false;
        }
        return true;
    }


    /// <summary>
    /// 读取文件内容
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string ReadFile(string filename)
    {
        StreamReader sr = new StreamReader(filename, System.Text.Encoding.GetEncoding("gb2312"));
        string str = sr.ReadToEnd();

        sr.Close();

        return str;
    }

    /// <summary>
    /// 导出文件，
    /// </summary>
    /// <param name="type">I am a</param>
    /// <param name="setfname">文件名</param>
    /// <param name="content">内容</param>
    public static void extendFile(extenFileType type, string setfname, string content)
    {
        HttpResponse response = HttpContext.Current.Response;

        if (type == extenFileType.excel)
        {
            response.ContentType = "application/vnd.ms-excel";
        }
        else
        {
            response.ContentType = "application/ms-word";
        }

        response.AddHeader("content-disposition", "inline;filename="
          + HttpUtility.UrlEncode(setfname, Encoding.UTF8));

        //s sb = new stringbuilder();
        //system.io.stringwriter sw = new system.io.stringwriter(sb);
        //system.web.ui.htmltextwriter hw = new system.web.ui.htmltextwriter(sw);
        //sb.append("<html><body>");
        //dgshow.rendercontrol(hw);
        //sb.append("</body></html>");
        response.Write(content);
        response.End();


    }


    /// <summary>
    /// 导出的文件I am a
    /// </summary>
    public enum extenFileType
    {
        word,
        excel
    }

}

