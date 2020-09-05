using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// �ļ�Action
/// </summary>
public class FileOperate
{
    #region    ------  Delete�ļ�   -----

    /// <summary>
    /// Delete�ļ�
    /// </summary>
    /// <param name="strFileName">�ļ�Item Name������·����</param>
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


    #region   ------  Delete��Ϣ�б��ص�ͼƬ -----

    /// <summary>
    /// Delete�����е�ͼƬ
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
    /// ȡ��������ͼƬ��URL��ַ
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
        {//��ȡ����ͼƬ��·��
            str = getLocalHostImg(imgTagStr);

        }
        return str;
    }

    /// <summary>
    /// ȡ������Upload��ͼƬ·��
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
                    file = file.Substring(0, file.IndexOf("\""));//ȡ������ͼƬ·��
                }
            }
        }
        return file;//���ر���ͼƬ·��
    }

    #endregion


    #region   -----   �����ļ�Action  -----

    /// <summary>
    /// �����ļ�
    /// </summary>
    /// <param name="sourceFileName">Դ�ļ���</param>
    /// <param name="destFileName">Ŀ���ļ���</param>
    /// <param name="overwrite">��Ŀ���ļ�����ʱ�Ƿ񸲸�</param>
    /// <returns>Action�Ƿ�ɹ�</returns>
    public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
    {
        if (!System.IO.File.Exists(sourceFileName))
        {
            throw new FileNotFoundException(sourceFileName + "�ļ������ڣ�");
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
    /// �����ļ�,��Ŀ���ļ�����ʱ����
    /// </summary>
    /// <param name="sourceFileName">Դ�ļ���</param>
    /// <param name="destFileName">Ŀ���ļ���</param>
    /// <returns>Action�Ƿ�ɹ�</returns>
    public static bool BackupFile(string sourceFileName, string destFileName)
    {
        return BackupFile(sourceFileName, destFileName, true);
    }


    /// <summary>
    /// �ָ��ļ�
    /// </summary>
    /// <param name="backupFileName">�����ļ���</param>
    /// <param name="targetFileName">Ҫ�ָ����ļ���</param>
    /// <param name="backupTargetFileName">Ҫ�ָ��ļ��ٴα��ݵ�Item Name,���Ϊnull,���ٱ��ݻָ��ļ�</param>
    /// <returns>Action�Ƿ�ɹ�</returns>
    public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
    {
        try
        {
            if (!System.IO.File.Exists(backupFileName))
            {
                throw new FileNotFoundException(backupFileName + "�ļ������ڣ�");
            }
            if (backupTargetFileName != null)
            {
                if (!System.IO.File.Exists(targetFileName))
                {
                    throw new FileNotFoundException(targetFileName + "�ļ������ڣ��޷����ݴ��ļ���");
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
