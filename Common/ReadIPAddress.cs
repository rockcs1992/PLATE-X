using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// 读取IP地址
/// </summary>
public class ReadIPAddress
{

    static private string _dataPath = System.Web.HttpContext.Current.Server.MapPath("~/QQDataBase/QQ.Dat");
    static private string country;
    static private string local;
    static private long firstStartIp = 0;
    static private long lastStartIp = 0;
    static private FileStream objfs = null;
    static private long startIp = 0;
    static private long endIp = 0;
    static private int countryFlag = 0;
    static private long endIpOff = 0;

    #region 搜索匹配数据

    private static byte[] IPLib;

    private static byte[] GetIPLib()
    {
        if (IPLib == null)
        {
            IPLib = ReadData();
        }

        return IPLib;

    }

    private static byte[] ReadData()
    {
        objfs = new FileStream(_dataPath, FileMode.Open, FileAccess.Read);


        int count = (int)objfs.Length;

        byte[] lib = new byte[objfs.Length];
        objfs.Read(lib, 0, count);

        objfs.Close();


        return lib;
    }

    private static byte[] GetSome(long start, long length)
    {
        byte[] some = new byte[length];

        for (long i = start; i < start + length; i++)
        {
            some[i - start] = ReadIPAddress.GetIPLib()[i];
        }
        CurrentPos = start + length;

        return some;
    }
    static private int QQwry(string ip)
    {
        string pattern = @"(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))";
        Regex objRe = new Regex(pattern);
        Match objMa = objRe.Match(ip);
        if (!objMa.Success)
        {
            return 4;
        }


        long ip_Int = IpToInt(ip);
        int nRet = 0;
        if (ip_Int >= IpToInt("127.0.0.0") && ip_Int <= IpToInt("127.255.255.255"))
        {
            country = "本机内部环回地址";
            local = "";
            nRet = 1;
        }
        else if ((ip_Int >= IpToInt("0.0.0.0") && ip_Int <= IpToInt("2.255.255.255")) || (ip_Int >= IpToInt("64.0.0.0") && ip_Int <= IpToInt("126.255.255.255")) || (ip_Int >= IpToInt("58.0.0.0") && ip_Int <= IpToInt("60.255.255.255")))
        {
            country = "网络保留地址";
            local = "";
            nRet = 1;
        }

        try
        {
            CurrentPos = 0;


            //objfs.Seek(0,SeekOrigin.Begin); 



            byte[] buff = GetSome(0, 8);
            firstStartIp = buff[0] + buff[1] * 256 + buff[2] * 256 * 256 + buff[3] * 256 * 256 * 256;
            lastStartIp = buff[4] * 1 + buff[5] * 256 + buff[6] * 256 * 256 + buff[7] * 256 * 256 * 256;
            long recordCount = Convert.ToInt64((lastStartIp - firstStartIp) / 7.0);
            if (recordCount <= 1)
            {
                country = "FileDataError";

                return 2;
            }
            long rangE = recordCount;
            long rangB = 0;
            long recNO = 0;
            while (rangB < rangE - 1)
            {
                recNO = (rangE + rangB) / 2;
                GetStartIp(recNO);
                if (ip_Int == startIp)
                {
                    rangB = recNO;
                    break;
                }
                if (ip_Int > startIp)
                    rangB = recNO;
                else
                    rangE = recNO;
            }
            GetStartIp(rangB);
            GetEndIp();

            if (startIp <= ip_Int && endIp >= ip_Int)
            {
                GetCountry();
                local = local.Replace("（我们一定要解放台湾！！！）", "");

            }
            else
            {
                nRet = 3;
                country = "未知";
                local = "";

            }

            return nRet;
        }
        catch
        {
            return 1;
        }

    }
    #endregion

    #region IP地址转换成Int数据
    static private long IpToInt(string ip)
    {
        string[] ipArr = ip.Split('.');
        if (ipArr.Length == 3)
            ip = ip + ".0";
        ipArr = ip.Split('.');

        long ip_Int = 0;

        long p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
        long p2 = long.Parse(ipArr[1]) * 256 * 256;
        long p3 = long.Parse(ipArr[2]) * 256;
        long p4 = long.Parse(ipArr[3]);

        ip_Int = p1 + p2 + p3 + p4;
        return ip_Int;
    }
    #endregion

    #region int转换成IP
    static private string IntToIP(long ip_Int)
    {
        long seg1 = (ip_Int & 0xff000000) >> 24;
        if (seg1 < 0)
            seg1 += 0x100;
        long seg2 = (ip_Int & 0x00ff0000) >> 16;
        if (seg2 < 0)
            seg2 += 0x100;
        long seg3 = (ip_Int & 0x0000ff00) >> 8;
        if (seg3 < 0)
            seg3 += 0x100;
        long seg4 = (ip_Int & 0x000000ff);
        if (seg4 < 0)
            seg4 += 0x100;
        string ip = seg1.ToString() + "." + seg2.ToString() + "." + seg3.ToString() + "." + seg4.ToString();
        return ip;
    }
    #endregion

    #region 获取起始IP范围
    static private long GetStartIp(long recNO)
    {
        long offSet = firstStartIp + recNO * 7;
        //objfs.Seek(offSet,SeekOrigin.Begin); 
        //objfs.Position=offSet; 
        byte[] buff = GetSome(offSet, 7);

        endIpOff = Convert.ToInt64(buff[4].ToString()) + Convert.ToInt64(buff[5].ToString()) * 256 + Convert.ToInt64(buff[6].ToString()) * 256 * 256;
        startIp = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256 + Convert.ToInt64(buff[3].ToString()) * 256 * 256 * 256;
        return startIp;
    }
    #endregion

    private static long CurrentPos = 0;

    #region 获取结束IP
    static private long GetEndIp()
    {
        //objfs.Seek(endIpOff,SeekOrigin.Begin); 
        //objfs.Position=endIpOff; 
        byte[] buff = GetSome(endIpOff, 5);

        endIp = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256 + Convert.ToInt64(buff[3].ToString()) * 256 * 256 * 256;
        countryFlag = buff[4];
        return endIp;
    }
    #endregion

    #region 获取国家/区域偏移量
    static private string GetCountry()
    {
        switch (countryFlag)
        {
            case 1:
            case 2:
                country = GetFlagStr(endIpOff + 4);
                local = (1 == countryFlag) ? " " : GetFlagStr(endIpOff + 8);
                break;
            default:
                country = GetFlagStr(endIpOff + 4);
                local = GetFlagStr(CurrentPos);
                break;
        }
        return " ";
    }
    #endregion

    #region 获取国家/区域字符串
    static private string GetFlagStr(long offSet)
    {
        int flag = 0;
        byte[] buff = new Byte[3];
        while (1 == 1)
        {
            //objfs.Seek(offSet,SeekOrigin.Begin); 
            CurrentPos = offSet;
            flag = (int)GetSome(CurrentPos, 1)[0];
            if (flag == 1 || flag == 2)
            {
                buff = GetSome(CurrentPos, 3);
                if (flag == 2)
                {
                    countryFlag = 2;
                    endIpOff = offSet - 4;
                }
                offSet = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256;
            }
            else
            {
                break;
            }
        }
        if (offSet < 12)
            return " ";
        CurrentPos = offSet;
        return GetStr();
    }
    #endregion

    #region GetStr
    static private string GetStr()
    {
        byte lowC = 0;
        byte upC = 0;
        string str = "";
        byte[] buff = new byte[2];
        while (1 == 1)
        {
            lowC = GetSome(CurrentPos, 1)[0];
            if (lowC == 0)
                break;
            if (lowC > 127)
            {
                upC = GetSome(CurrentPos, 1)[0];
                buff[0] = lowC;
                buff[1] = upC;
                System.Text.Encoding enc = System.Text.Encoding.GetEncoding("GB2312");
                str += enc.GetString(buff);
            }
            else
            {
                str += (char)lowC;
            }
        }
        return str;
    }
    #endregion

    /// <summary>
    /// 通过IP查找地理位置
    /// </summary>
    /// <param name="ip">ip地址</param>
    /// <returns>地理位置</returns>
    static public string FindIP(string ip)
    {
        try
        {
            QQwry(ip.Trim());
            string info = country;//+" "+ local;
            info = info.Replace("CZ88.NET", "").Replace(",", " ");
            return info;
        }
        catch
        {
            return "";
        }
    }



 
}
