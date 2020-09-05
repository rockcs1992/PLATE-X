using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// ��Ϣ״̬
/// </summary>
public class InfoState
{
    /// <summary>
    /// ����������Ʒ״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string IndexProductState(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<img src='../imgs/hot.gif'/>";

        }
        else if (bs == 0)
        {
            str_name = "<img src='../imgs/new.gif'/>";

        }
        return str_name;
    }

    /// <summary>
    /// �������״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnAuditingState(string bs)
    {
        string str_name = "";
        if (bs == "1")
        {
            str_name = "<img src='../imgs/ok.gif'/>";

        }
        else if (bs == "0")
        {
            str_name = "<img src='../imgs/false.gif'/>";

        }
        return str_name;
    }
    /// <summary>
    /// �����Ƽ�״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnIndexState(string bs)
    {
        string str_name = "";
        if (bs == "1")
        {
            str_name = "<img src='../imgs/card2.gif' />";

        }
        else if (bs == "0")
        {
            str_name = "<img src='../imgs/loadingx.gif' />";

        }
        return str_name;
    }

    /// <summary>
    /// �����ʺſ���״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnIsPass(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<img src='../imgs/unlock.gif'/>";

        }
        else if (bs == 0)
        {
            str_name = "<img src='../imgs/lock.gif'/>";

        }
        return str_name;
    }

    /// <summary>
    /// ���ػ�Ա״̬ͼƬ
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnUserTypeState(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>�շ�</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>���</span>";

        }
        return str_name;
    }

    /// <summary>
    /// ������Ʒ���¼�״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnProductShowState(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>�ϼ�</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>�¼�</span>";

        }
        return str_name;
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnPay(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>�Ѹ���</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>δ����</span>";

        }
        return str_name;
    }

    /// <summary>
    /// �����Ƿ�ȡ��״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnCancel(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>��ȡ��</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>δȡ��</span>";

        }
        return str_name;
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnSend(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>�ѷ���</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>δ����</span>";

        }
        return str_name;
    }

    /// <summary>
    /// �������״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnOrderComplete(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>Order Delivered</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>δ���</span>";

        }
        return str_name;
    }

    /// <summary>
    /// �鿴״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnIsLook(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>�Ѳ鿴</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>δ�鿴</span>";

        }
        return str_name;
    }

    /// <summary>
    /// ��ʾ״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnIsShow(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>��ʾ</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>����ʾ</span>";

        }
        return str_name;
    }

    /// <summary>
    /// ���״̬
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string wordIsAuditing(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>���</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>�����</span>";

        }
        return str_name;
    }

    /// <summary>
    /// ����������
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string newstype(string bs)
    {
        string str_name = "";
        if (bs == "1")
        {
            str_name = "��Ҵ���";

        }
        if (bs == "2")
        {
            str_name = "�����";

        }
        return str_name;
    }


    /// <summary>
    /// �鿴����I am a
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string pctype(string bs)
    {
        string str_name = "";
        if (bs == "1")
        {
            str_name = "���ܷ��";

        }
        if (bs == "2")
        {
            str_name = "�������";

        }
        if (bs == "3")
        {
            str_name = "�������";

        }
        if (bs == "4")
        {
            str_name = "����֮��";

        }
        return str_name;
    }



}
