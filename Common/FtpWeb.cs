using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;

/// <summary>   
/// FtpWeb 的摘要说明   
/// </summary>   
public class FtpWeb   
{   
    //private string _ftpServerIP;   
    //private string _ftpRemotePath;
    //private string _ftpUserID;
    //private string _ftpPassword;
    //private string _ftpURI;
    //public string ftpServerIP
    //{
    //    set { _ftpServerIP = value; }
    //    get { return _ftpServerIP; }
    //}
    //public string ftpRemotePath
    //{
    //    set { _ftpRemotePath = value; }
    //    get { return _ftpRemotePath; }
    //}
    //public string ftpUserID
    //{
    //    set { _ftpUserID = value; }
    //    get { return _ftpUserID; }
    //}
    //public string ftpPassword
    //{
    //    set { _ftpPassword = value; }
    //    get { return _ftpPassword; }
    //}
    //public string ftpURI
    //{
    //    set { _ftpURI = value; }
    //    get { return _ftpURI; }
    //}

    string ftpServerIP;
    string ftpRemotePath;
    string ftpUserID;
    string ftpPassword;
    string ftpURI;

    /// <summary>
    /// 连接FTP   
    /// </summary>   
    /// <param name="FtpServerIP">FTP连接地址</param>   
    /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>   
    /// <param name="FtpUserID">Username</param>
    /// <param name="FtpPassword">Password</param>
    public FtpWeb(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)   
    {   
        ftpServerIP = FtpServerIP;
        ftpRemotePath = FtpRemotePath;
        ftpUserID = FtpUserID;
        ftpPassword = FtpPassword;
        ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
    }   
  
    /// <summary>   
    /// Upload   
    /// </summary>   
    /// <param name="filename"></param>   
    public bool Upload(string filename, out string errorMsg)   
    {   
        errorMsg = "";   
        FileInfo fileInf = new FileInfo(filename);   
        string uri = ftpURI + fileInf.Name;   
        FtpWebRequest reqFTP;   
  
        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));   
        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);   
        reqFTP.KeepAlive = false;   
        reqFTP.Method = WebRequestMethods.Ftp.UploadFile;   
        reqFTP.UseBinary = true;   
        reqFTP.ContentLength = fileInf.Length;   
        int buffLength = 2048; //开辟2KB缓存区   
        byte[] buff = new byte[buffLength];   
        int contentLen;   
        FileStream fs = fileInf.OpenRead();   
        try  
        {   
            Stream strm = reqFTP.GetRequestStream();   
            contentLen = fs.Read(buff, 0, buffLength);   
            while (contentLen != 0)   
            {   
                strm.Write(buff, 0, contentLen);   
                contentLen = fs.Read(buff, 0, buffLength);   
            }   
            strm.Close();   
            fs.Close();   
            return true;   
        }   
        catch (Exception ex)   
        {   
            errorMsg = ex.Message;   
            return false;   
        }   
    }   
  
    /// <summary>   
    /// 下载   
    /// </summary>   
    /// <param name="filePath"></param>   
    /// <param name="fileName"></param>   
    public bool Download(string filePath, string fileName, out string errorMsg)   
    {   
        errorMsg = "";   
        FtpWebRequest reqFTP;   
        try  
        {   
            FileStream outputStream = new FileStream(HttpContext.Current.Server.MapPath(filePath + "\\" + fileName), FileMode.Create);   
  
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));   
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;   
            reqFTP.UseBinary = true;   
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);   
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();   
            Stream ftpStream = response.GetResponseStream();   
            long cl = response.ContentLength;
            int bufferSize = 2048;   
            int readCount;   
            byte[] buffer = new byte[bufferSize];
  
           readCount = ftpStream.Read(buffer, 0, bufferSize);   
            while (readCount > 0)   
            {   
                outputStream.Write(buffer, 0, readCount);   
                readCount = ftpStream.Read(buffer, 0, bufferSize);   
            }   
  
            ftpStream.Close();   
            outputStream.Close();   
            response.Close();   
            return true;   
        }   
        catch (Exception ex)   
        {   
            errorMsg = ex.Message;   
            return false;   
        }   
    }    
}  
