using System;
using System.Collections.Generic;
using System.Text;
using System.IO;




/// <summary>
///  生成文件
/// </summary>
public class PrintFile
{

    /// <summary>
    /// 生成js文件
    /// </summary>
    /// <param name="content">内容</param>
    /// <param name="path">路径</param>
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
