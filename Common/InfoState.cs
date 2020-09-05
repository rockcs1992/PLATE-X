using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 信息状态
/// </summary>
public class InfoState
{
    /// <summary>
    /// 最新最热商品状态
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
    /// 返回审核状态
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
    /// 返回推荐状态
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
    /// 返回帐号可用状态
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
    /// 返回会员状态图片
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnUserTypeState(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>收费</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>免费</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 返回商品上下架状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnProductShowState(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>上架</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>下架</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 付款状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnPay(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>已付款</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>未付款</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 订单是否取消状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnCancel(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>已取消</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>未取消</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 发货状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnSend(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>已发货</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>未发货</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 订单完成状态
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
            str_name = "<span style='color:#3352CC'>未完成</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 查看状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnIsLook(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>已查看</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>未查看</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 显示状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string ReturnIsShow(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>显示</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>不显示</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 审核状态
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string wordIsAuditing(int bs)
    {
        string str_name = "";
        if (bs == 1)
        {
            str_name = "<span style='color:red'>审核</span>";

        }
        else if (bs == 0)
        {
            str_name = "<span style='color:#3352CC'>不审核</span>";

        }
        return str_name;
    }

    /// <summary>
    /// 店家新闻类别
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string newstype(string bs)
    {
        string str_name = "";
        if (bs == "1")
        {
            str_name = "店家大事";

        }
        if (bs == "2")
        {
            str_name = "促销活动";

        }
        return str_name;
    }


    /// <summary>
    /// 查看人物I am a
    /// </summary>
    /// <param name="bs"></param>
    /// <returns></returns>
    public static string pctype(string bs)
    {
        string str_name = "";
        if (bs == "1")
        {
            str_name = "老总风采";

        }
        if (bs == "2")
        {
            str_name = "管理层风采";

        }
        if (bs == "3")
        {
            str_name = "名厨风采";

        }
        if (bs == "4")
        {
            str_name = "服务之星";

        }
        return str_name;
    }



}
