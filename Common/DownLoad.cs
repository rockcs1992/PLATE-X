using  System.Net;  

using  System.IO;
using System.Text;
using System.Web;
public class download
{
    public download()
    {

    }
    /// <summary>

    /// 下载文件

    /// </summary>

    /// <param >要下载文件网址</param>

    public static void downloadfile(string URL)
    {
        
        WebClient client = new WebClient();

        int n = URL.LastIndexOf('/');

        string URLAddress = URL.Substring(0, n);  //取得网址

        string fileName = URL.Substring(n + 1, URL.Length - n - 1);  //取得文件名

        string Dir = HttpContext.Current.Server.MapPath("./");  //下载文件存放路径



        string Path = Dir + '\\' + fileName; //下载文件存放完整路径



        Stream stream = client.OpenRead(URL);



        StreamReader reader = new StreamReader(stream);

        byte[] mbyte = new byte[100000];

        int allbyte = (int)mbyte.Length;

        int startbyte = 0;

        while (allbyte > 0)  //循环读取
        {

            int m = stream.Read(mbyte, startbyte, allbyte);

            if (m == 0)

                break;



            startbyte += m;

            allbyte -= m;

        }



        FileStream fstr = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);

        fstr.Write(mbyte, 0, startbyte);  //写文件

        stream.Close();

        fstr.Close();

    }
}
