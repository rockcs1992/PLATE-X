using System;
using System.Collections.Generic;
using System.Text;
using System.IO;




/// <summary>
///  �����ļ�
/// </summary>
public class PrintFile
{

    /// <summary>
    /// ����js�ļ�
    /// </summary>
    /// <param name="content">����</param>
    /// <param name="path">·��</param>
    /// <returns></returns>
    public static bool PrintJs(string content, string path)
    {
        try
        {
            StreamWriter write = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            write.Write(content);
            write.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

}
