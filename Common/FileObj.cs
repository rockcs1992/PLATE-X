using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


/// <summary>
/// �ļ�Action��
/// </summary>
public class FileObj
{
    //private bool _alreadyDispose = false;

    //#region ���캯��
    //public FileObj()
    //{

    //}
    //~FileObj()
    //{
    //    Displose(); ;
    //}
    //protected virtual void Displose(bool isDisposing)
    //{
    //    _alreadyDispose = true;
    //}
    //#endregion

    //#region IDisposable ��Ա

    //void IDisposable.Dispose()
    //{
    //    Dispose(true);
    //    GC.SuppressFinalize(this);
    //}

    //#endregion

    #region ȡ���ļ���׺��
    /****************************************
         * ����Item Name��GetPostfixStr
         * ����˵����ȡ���ļ���׺��
         * ��    ����filename:�ļ�Item Name
         * ����ʾ�У�
         *           string filename = "aaa.aspx";        
         *           string s = EC.FileObj.GetPostfixStr(filename);         
        *****************************************/
    /// <summary>
    /// ȡ��׺��
    /// </summary>
    /// <param name="filename">�ļ���</param>
    /// <returns>.gif|.html��ʽ</returns>
    public static string GetPostfixStr(string filename)
    {
        int start = filename.LastIndexOf(".");
        int length = filename.Length;
        string postfix = filename.Substring(start, length - start);
        return postfix;
    }
    #endregion

    #region д�ļ�
    /****************************************
         * ����Item Name��WriteFile
         * ����˵����д�ļ�,�Ḳ�ǵ���ǰ������
         * ��    ����Path:�ļ�·��,Strings:�ı�����
         * ����ʾ�У�
         *           string Path = Server.MapPath("Default2.aspx");       
         *           string Strings = "������д�����ݰ�";
         *           EC.FileObj.WriteFile(Path,Strings);
        *****************************************/
    /// <summary>
    /// д�ļ�
    /// </summary>
    /// <param name="Path">�ļ�·��</param>
    /// <param name="Strings">�ļ�����</param>
    public static void WriteFile(string Path, string Strings)
    {
        if (!System.IO.File.Exists(Path))
        {
            System.IO.FileStream f = System.IO.File.Create(Path);
            f.Close();
        }
        System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, false, System.Text.Encoding.GetEncoding("gb2312"));
        f2.Write(Strings);
        f2.Close();
        f2.Dispose();
    }
    #endregion

    #region ���ļ�
    /****************************************
         * ����Item Name��ReadFile
         * ����˵������ȡ�ı�����
         * ��    ����Path:�ļ�·��
         * ����ʾ�У�
         *           string Path = Server.MapPath("Default2.aspx");       
         *           string s = EC.FileObj.ReadFile(Path);
        *****************************************/
    /// <summary>
    /// ���ļ�
    /// </summary>
    /// <param name="Path">�ļ�·��</param>
    /// <returns></returns>
    public static string ReadFile(string Path)
    {
        string s = "";
        if (!System.IO.File.Exists(Path))
            s = "��������Ӧ��Ŀ¼";
        else
        {
            StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
            s = f2.ReadToEnd();
            f2.Close();
            f2.Dispose();
        }

        return s;
    }
    #endregion

    #region ׷���ļ�
    /****************************************
         * ����Item Name��FileAdd
         * ����˵����׷���ļ�����
         * ��    ����Path:�ļ�·��,strings:����
         * ����ʾ�У�
         *           string Path = Server.MapPath("Default2.aspx");     
         *           string Strings = "��׷������";
         *           EC.FileObj.FileAdd(Path, Strings);
        *****************************************/
    /// <summary>
    /// ׷���ļ�
    /// </summary>
    /// <param name="Path">�ļ�·��</param>
    /// <param name="strings">����</param>
    public static void FileAdd(string Path, string strings)
    {
        StreamWriter sw = File.AppendText(Path);
        sw.Write(strings);
        sw.Flush();
        sw.Close();
    }
    #endregion

    #region �����ļ�
    /****************************************
         * ����Item Name��FileCoppy
         * ����˵���������ļ�
         * ��    ����OrignFile:ԭʼ�ļ�,NewFile:���ļ�·��
         * ����ʾ�У�
         *           string orignFile = Server.MapPath("Default2.aspx");     
         *           string NewFile = Server.MapPath("Default3.aspx");
         *           EC.FileObj.FileCoppy(OrignFile, NewFile);
        *****************************************/
    /// <summary>
    /// �����ļ�
    /// </summary>
    /// <param name="OrignFile">ԭʼ�ļ�</param>
    /// <param name="NewFile">���ļ�·��</param>
    public static void FileCoppy(string orignFile, string NewFile)
    {
        File.Copy(orignFile, NewFile, true);
    }

    #endregion

    #region Delete�ļ�
    /****************************************
         * ����Item Name��FileDel
         * ����˵����Delete�ļ�
         * ��    ����Path:�ļ�·��
         * ����ʾ�У�
         *           string Path = Server.MapPath("Default3.aspx");    
         *           EC.FileObj.FileDel(Path);
        *****************************************/
    /// <summary>
    /// Delete�ļ�
    /// </summary>
    /// <param name="Path">·��</param>
    public static void FileDel(string Path)
    {
        File.Delete(Path);
    }
    #endregion

    #region �ƶ��ļ�
    /****************************************
         * ����Item Name��FileMove
         * ����˵�����ƶ��ļ�
         * ��    ����OrignFile:ԭʼ·��,NewFile:���ļ�·��
         * ����ʾ�У�
         *            string orignFile = Server.MapPath("../˵��.txt");    
         *            string NewFile = Server.MapPath("../../˵��.txt");
         *            EC.FileObj.FileMove(OrignFile, NewFile);
        *****************************************/
    /// <summary>
    /// �ƶ��ļ�
    /// </summary>
    /// <param name="OrignFile">ԭʼ·��</param>
    /// <param name="NewFile">��·��</param>
    public static void FileMove(string orignFile, string NewFile)
    {
        File.Move(orignFile, NewFile);
    }
    #endregion

    #region �ڵ�ǰĿ¼�´���Ŀ¼
    /****************************************
         * ����Item Name��FolderCreate
         * ����˵�����ڵ�ǰĿ¼�´���Ŀ¼
         * ��    ����OrignFolder:��ǰĿ¼,NewFloder:��Ŀ¼
         * ����ʾ�У�
         *           string orignFolder = Server.MapPath("test/");    
         *           string NewFloder = "new";
         *           EC.FileObj.FolderCreate(OrignFolder, NewFloder); 
        *****************************************/
    /// <summary>
    /// �ڵ�ǰĿ¼�´���Ŀ¼
    /// </summary>
    /// <param name="OrignFolder">��ǰĿ¼</param>
    /// <param name="NewFloder">��Ŀ¼</param>
    public static void FolderCreate(string orignFolder, string NewFloder)
    {
        Directory.SetCurrentDirectory(orignFolder);
        Directory.CreateDirectory(NewFloder);
    }
    #endregion

    #region �ݹ�Delete�ļ���Ŀ¼���ļ�
    /****************************************
         * ����Item Name��DeleteFolder
         * ����˵�����ݹ�Delete�ļ���Ŀ¼���ļ�
         * ��    ����dir:�ļ���·��
         * ����ʾ�У�
         *           string dir = Server.MapPath("test/");  
         *           EC.FileObj.DeleteFolder(dir);       
        *****************************************/
    /// <summary>
    /// �ݹ�Delete�ļ���Ŀ¼���ļ�
    /// </summary>
    /// <param name="dir"></param>
    /// <returns></returns>
    public static void DeleteFolder(string dir)
    {
        if (Directory.Exists(dir)) //�����������ļ���Delete֮ 
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                    File.Delete(d); //ֱ��Delete���е��ļ� 
                else
                    DeleteFolder(d); //�ݹ�Delete���ļ��� 
            }
            Directory.Delete(dir); //Delete�ѿ��ļ��� 
        }

    }

    #endregion

    #region ��ָ���ļ����������������copy��Ŀ���ļ������� ��Ŀ���ļ���Ϊֻ�����Ծͻᱨ��
    /****************************************
         * ����Item Name��CopyDir
         * ����˵������ָ���ļ����������������copy��Ŀ���ļ������� ��Ŀ���ļ���Ϊֻ�����Ծͻᱨ��
         * ��    ����srcPath:ԭʼ·��,aimPath:Ŀ���ļ���
         * ����ʾ�У�
         *           string srcPath = Server.MapPath("test/");  
         *           string aimPath = Server.MapPath("test1/");
         *           EC.FileObj.CopyDir(srcPath,aimPath);   
        *****************************************/
    /// <summary>
    /// ָ���ļ����������������copy��Ŀ���ļ�������
    /// </summary>
    /// <param name="srcPath">ԭʼ·��</param>
    /// <param name="aimPath">Ŀ���ļ���</param>
    public static void CopyDir(string srcPath, string aimPath)
    {
        try
        {
            // ���Ŀ��Ŀ¼�Ƿ���Ŀ¼�ָ��ַ�����������������֮
            if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                aimPath += Path.DirectorySeparatorChar;
            // �ж�Ŀ��Ŀ¼�Ƿ����������������½�֮
            if (!Directory.Exists(aimPath))
                Directory.CreateDirectory(aimPath);
            // �õ�ԴĿ¼���ļ��б��������ǰ����ļ��Լ�Ŀ¼·����һ������
            //�����ָ��copyĿ���ļ�������ļ���������Ŀ¼��ʹ������ķ���
            //string[] fileList = Directory.GetFiles(srcPath);
            string[] fileList = Directory.GetFileSystemEntries(srcPath);
            //�������е��ļ���Ŀ¼
            foreach (string file in fileList)
            {
                //�ȵ���Ŀ¼��������������Ŀ¼�͵ݹ�Copy��Ŀ¼������ļ�

                if (Directory.Exists(file))
                    CopyDir(file, aimPath + Path.GetFileName(file));
                //����ֱ��Copy�ļ�
                else
                    File.Copy(file, aimPath + Path.GetFileName(file), true);
            }

        }
        catch (Exception ee)
        {
            throw new Exception(ee.ToString());
        }
    }


    #endregion

}
