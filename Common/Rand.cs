using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// �����Action
/// </summary>
public class Rand
{
    public static string GetNumPwd(int num)//�������������
    {
        string a = "0123456789";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < num; i++)
        {
            sb.Append(a[new Random(Guid.NewGuid().GetHashCode()).Next(0, a.Length - 1)]);
        }

        return sb.ToString();
    }
    public static string GetAbcPwd(int num)//������ĸ�����
    {
        string a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < num; i++)
        {
            sb.Append(a[new Random(Guid.NewGuid().GetHashCode()).Next(0, a.Length - 1)]);
        }

        return sb.ToString();
    }
    public static string GetMixPwd(int num)//���ɻ�������
    {
        string a = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < num; i++)
        {
            sb.Append(a[new Random(Guid.NewGuid().GetHashCode()).Next(0, a.Length - 1)]);
        }

        return sb.ToString();
    }



    public static string GetValidCode() //���ɻ�������
    {
        string n = string.Empty;
        n = Guid.NewGuid().ToString().Substring(0, 6);
        //Response.Write(n);
        return n;
    }
    /// <summary>
    /// �����������
    /// </summary>
    /// <param name="length">���ɳ���</param>
    /// <returns></returns>
    public static string Number(int Length)
    {
        return Number(Length, false);
    }

    /// <summary>
    /// �����������
    /// </summary>
    /// <param name="Length">���ɳ���</param>
    /// <param name="Sleep">�Ƿ�Ҫ������ǰ����ǰ�߳���ֹ�Ա����ظ�</param>
    /// <returns></returns>
    public static string Number(int Length, bool Sleep)
    {
        if (Sleep)
            System.Threading.Thread.Sleep(3);
        string result = "";
        System.Random random = new Random();
        for (int i = 0; i < Length; i++)
        {
            result += random.Next(10).ToString();
        }
        return result;
    }

    /// <summary>
    /// ���������ĸ������
    /// </summary>
    /// <param name="IntStr">���ɳ���</param>
    /// <returns></returns>
    public static string Str(int Length)
    {
        return Str(Length, false);
    }
    /// <summary>
    /// ���������ĸ������
    /// </summary>
    /// <param name="Length">���ɳ���</param>
    /// <param name="Sleep">�Ƿ�Ҫ������ǰ����ǰ�߳���ֹ�Ա����ظ�</param>
    /// <returns></returns>
    public static string Str(int Length, bool Sleep)
    {
        if (Sleep)
            System.Threading.Thread.Sleep(3);
        char[] Pattern = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string result = "";
        int n = Pattern.Length;
        System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
        for (int i = 0; i < Length; i++)
        {
            int rnd = random.Next(0, n);
            result += Pattern[rnd];
        }
        return result;
    }


    /// <summary>
    /// �����������ĸ�����
    /// </summary>
    /// <param name="IntStr">���ɳ���</param>
    /// <returns></returns>
    public static string Str_char(int Length)
    {
        return Str_char(Length, false);
    }

    /// <summary>
    /// �����������ĸ�����
    /// </summary>
    /// <param name="Length">���ɳ���</param>
    /// <param name="Sleep">�Ƿ�Ҫ������ǰ����ǰ�߳���ֹ�Ա����ظ�</param>
    /// <returns></returns>
    public static string Str_char(int Length, bool Sleep)
    {
        if (Sleep)
            System.Threading.Thread.Sleep(3);
        char[] Pattern = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        string result = "";
        int n = Pattern.Length;
        System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
        for (int i = 0; i < Length; i++)
        {
            int rnd = random.Next(0, n);
            result += Pattern[rnd];
        }
        return result;
    }

}
