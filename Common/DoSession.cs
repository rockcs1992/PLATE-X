using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;


        /// SessionAction类
        /// <summary>
        /// SessionAction类
        /// </summary>
public class DoSession:System.Web.UI.Page

{
             
            /// 添加Session，调动有效期默认为60分钟
            /// <summary>
            /// 添加Session，调动有效期默认为60分钟
            /// </summary>
            /// <param name="strSessionName">Session对象Item Name</param>
            /// <param name="strValue">Session值</param>
            public static void Add(string strSessionName, string strValue)
            {
                HttpContext.Current.Session[strSessionName] = strValue;
                HttpContext.Current.Session.Timeout = 60;
            }
            /// 添加Session
            /// <summary>
            /// 添加Session
            /// </summary>
            /// <param name="strSessionName">Session对象Item Name</param>
            /// <param name="strValue">Session值</param>
            /// <param name="iExpires">调动有效期（分钟）</param>
            public static void Add(string strSessionName, string strValue, int iExpires)
            {
                HttpContext.Current.Session[strSessionName] = strValue;
                HttpContext.Current.Session.Timeout = iExpires;
            }

            /// 读取某个Session对象值
            /// <summary>
            /// 读取某个Session对象值
            /// </summary>
            /// <param name="strSessionName">Session对象Item Name</param>
            /// <returns>Session对象值</returns>
            public static string Get(string strSessionName)
            {
                if (HttpContext.Current.Session[strSessionName] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Session[strSessionName].ToString();
                }
            }

            /// Delete某个Session对象
            /// <summary>
            /// Delete某个Session对象
            /// </summary>
            /// <param name="strSessionName">Session对象Item Name</param>
            public static void Del(string strSessionName)
            {
                HttpContext.Current.Session[strSessionName] = null;
            }
            public static void DelALL()
            {
                HttpContext.Current.Session["UserType"] = null;
                HttpContext.Current.Session["UserID"] = null;
                HttpContext.Current.Session["UserName"] = null;
            }
        }

   