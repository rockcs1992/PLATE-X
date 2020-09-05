using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;
using System.IO;
/// <summary>
/// Password加密
/// </summary>
public class encrypt
{
	public encrypt()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    const string KEY_64 = "VavicApp";//注意了，是8个字符，64位

    const string IV_64 = "VavicApp";

  

    /// <summary>
    /// 可逆加密
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string Encode(string data)
    {
        byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
        byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        int i = cryptoProvider.KeySize;
        MemoryStream ms = new MemoryStream();
        CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey,byIV), CryptoStreamMode.Write);

        StreamWriter sw = new StreamWriter(cst);
        sw.Write(data);
        sw.Flush();
        cst.FlushFinalBlock();
        sw.Flush();
        return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

    }

    /// <summary>
    ///可逆解密 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static String Decode(string data)
    {
        byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
        byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

        byte[] byEnc;
        try
        {
            byEnc = Convert.FromBase64String(data);
        }
        catch
        {
            return null;
        }

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream ms = new MemoryStream(byEnc);
        CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey,byIV), CryptoStreamMode.Read);
        StreamReader sr = new StreamReader(cst);
        return sr.ReadToEnd();
    }

    //md5加密源码
    public static String Encrypt(string password)
    {
        Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
        Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
        return BitConverter.ToString(hashedBytes);

    }
    #region 辅助方法

    public static string MD5(string pwd)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.UTF8.GetBytes(pwd);
        byte[] md5data = md5.ComputeHash(data);
        md5.Clear();
        string str = "";
        for (int i = 0; i < md5data.Length; i++)
        {
            str += md5data[i].ToString("x").PadLeft(2, '0');
        }
        return str;
    }
    #endregion
    /// <summary>
    /// Password加密
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static String EncryptMd5(string code)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(code, "MD5").ToLower();
    }
}
