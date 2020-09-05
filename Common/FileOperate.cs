using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// 文件Action
/// </summary>
public class FileOperate
{
    #region    ------  Delete文件   -----

    /// <summary>
    /// Delete文件
    /// </summary>
    /// <param name="strFileName">文件Item Name（包括路径）</param>
    /// <returns></returns>
    public static bool DeleteFile(string strFileName)
    {
        if (strFileName.Trim() == "" || strFileName.Trim() == String.Empty)
        {
            return false;
        }
        else
        {
            string filepath=System.Web.HttpContext.Current.Server.MapPath(strFileName);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    #endregion


    #region   ------  Delete信息中本地的图片 -----

    /// <summary>
    /// Delete内容中的图片
    /// </summary>
    /// <param name="htmlStr"></param>
    /// <returns></returns>
    public static void GetImgTag(string htmlStr)
    {
        Regex regObj = new Regex("<img.+?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        foreach (Match matchItem in regObj.Matches(htmlStr))
        {
            string imgUrl = GetImgUrl(matchItem.Value);
            if (imgUrl != "")
            {
                string img = System.Web.HttpContext.Current.Server.MapPath("~/") + imgUrl;
                if (File.Exists(img))
                {
                    File.Delete(img);
                }
            }
        }
    }

    /// <summary>
    /// 取出新闻中图片的URL地址
    /// </summary>
    /// <param name="imgTagStr"></param>
    /// <returns></returns>
    public static string GetImgUrl(string imgTagStr)
    {
        string str = "";
        if (imgTagStr.IndexOf("http") != -1)
        {
            str = "";
        }
        else
        {//获取本地图片的路径
            str = getLocalHostImg(imgTagStr);

        }
        return str;
    }

    /// <summary>
    /// 取出本地Upload的图片路径
    /// </summary>
    /// <param name="strImg"></param>
    /// <returns></returns>
    public static string getLocalHostImg(string strImg)
    {
        int num = strImg.IndexOf("src=");
        string str = "", file = "";
        if (num != -1)
        {
            str = strImg.Substring(num + 4);
            int num2 = str.IndexOf(" ");
            file = str.Substring(0, num2 + 1);
            if (file.IndexOf("\"") != -1)
            {
                file = file.Substring(file.IndexOf("\"") + 1);
                if (file.IndexOf("\"") != -1)
                {
                    file = file.Substring(0, file.IndexOf("\""));//取出本地图片路径
                }
            }
        }
        return file;//返回本地图片路径
    }

    #endregion


    #region   -----   备份文件Action  -----

    /// <summary>
    /// 备份文件
    /// </summary>
    /// <param name="sourceFileName">源文件名</param>
    /// <param name="destFileName">目标文件名</param>
    /// <param name="overwrite">当目标文件存在时是否覆盖</param>
    /// <returns>Action是否成功</returns>
    public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
    {
        if (!System.IO.File.Exists(sourceFileName))
        {
            throw new FileNotFoundException(sourceFileName + "文件不存在！");
        }
        if (!overwrite && System.IO.File.Exists(destFileName))
        {
            return false;
        }
        try
        {
            System.IO.File.Copy(sourceFileName, destFileName, true);
            return true;
        }
        catch (Exception e)
        {
            throw e;
        }
    }


    /// <summary>
    /// 备份文件,当目标文件存在时覆盖
    /// </summary>
    /// <param name="sourceFileName">源文件名</param>
    /// <param name="destFileName">目标文件名</param>
    /// <returns>Action是否成功</returns>
    public static bool BackupFile(string sourceFileName, string destFileName)
    {
        return BackupFile(sourceFileName, destFileName, true);
    }


    /// <summary>
    /// 恢复文件
    /// </summary>
    /// <param name="backupFileName">备份文件名</param>
    /// <param name="targetFileName">要恢复的文件名</param>
    /// <param name="backupTargetFileName">要恢复文件再次备份的Item Name,如果为null,则不再备份恢复文件</param>
    /// <returns>Action是否成功</returns>
    public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
    {
        try
        {
            if (!System.IO.File.Exists(backupFileName))
            {
                throw new FileNotFoundException(backupFileName + "文件不存在！");
            }
            if (backupTargetFileName != null)
            {
                if (!System.IO.File.Exists(targetFileName))
                {
                    throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                }
                else
                {
                    System.IO.File.Copy(targetFileName, backupTargetFileName, true);
                }
            }
            System.IO.File.Delete(targetFileName);
            System.IO.File.Copy(backupFileName, targetFileName);
        }
        catch (Exception e)
        {
            throw e;
        }
        return true;
    }

    public static bool RestoreFile(string backupFileName, string targetFileName)
    {
        return RestoreFile(backupFileName, targetFileName, null);
    }

    #endregion


}
