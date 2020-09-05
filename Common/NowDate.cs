using System;
using System.Collections.Generic;
using System.Text;


public class NowDate
{
    public static string ReturnWeek(string nowdate)
    {
        string week = "";
        switch (nowdate)
        {
            case "Friday":
                week = "星期五";
                break;
            case "Monday":
                week = "星期一";
                break;
            case "Saturday":
                week = "星期六";
                break;
            case "Sunday":
                week = "星期日";
                break;
            case "Thursday":
                week = "星期四";
                break;
            case "Tuesday":
                week = "星期二";
                break;
            case "Wednesday":
                week = "星期三";
                break;
        }
        return week;
    }
}

