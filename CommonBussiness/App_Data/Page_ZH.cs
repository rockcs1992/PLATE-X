using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DAL;

namespace CommonBussiness
{
    public class Page_ZH
    {
        public Page_ZH()
        { }
        public void InitBindDataUp(Control c, Wuqi.Webdiyer.AspNetPager aspnet, string tbname, string tbcolumn, string sqlwhere)
        {
            aspnet.RecordCount = GetRows(tbname, sqlwhere);
            if (aspnet.RecordCount > 0)
            {
                string contype = c.GetType().ToString();

                DataSet ds = GetListUp(aspnet.PageSize, aspnet.CurrentPageIndex, sqlwhere, tbname, tbcolumn);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (contype.IndexOf("GridView") != -1)
                    {
                        GridView gv = (GridView)c;
                        gv.DataSource = ds;
                        gv.DataBind();
                    }
                    else if (contype.IndexOf("Repeater") != -1)
                    {
                        Repeater rep = (Repeater)c;
                        rep.DataSource = ds;
                        rep.DataBind();
                    }
                    else if (contype.IndexOf("DataList") != -1)
                    {
                        DataList dl = (DataList)c;
                        dl.DataSource = ds;
                        dl.DataBind();
                    }
                }

                c.Visible = true;
            }
            else
            {
                string contype = c.GetType().ToString();
                if (contype.IndexOf("GridView") != -1)
                {
                    GridView gv = (GridView)c;
                    gv.DataSource = null;
                    gv.DataBind();
                }
                else if (contype.IndexOf("Repeater") != -1)
                {
                    Repeater rep = (Repeater)c;
                    rep.DataSource = null;
                    rep.DataBind();
                }
                else if (contype.IndexOf("DataList") != -1)
                {
                    DataList dl = (DataList)c;
                    dl.DataSource = null;
                    dl.DataBind();
                }
                c.Visible = false;
            }

        }

        public void InitBindData(Control c, Wuqi.Webdiyer.AspNetPager aspnet, string tbname, string tbcolumn, string sqlwhere)
        {
            aspnet.RecordCount = GetRows(tbname, sqlwhere);
            if (aspnet.RecordCount > 0)
            {
                string contype = c.GetType().ToString();

                DataSet ds = GetList(aspnet.PageSize, aspnet.CurrentPageIndex, sqlwhere, tbname, tbcolumn);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (contype.IndexOf("GridView") != -1)
                    {
                        GridView gv = (GridView)c;
                        gv.DataSource = ds;
                        gv.DataBind();
                    }
                    else if (contype.IndexOf("Repeater") != -1)
                    {
                        Repeater rep = (Repeater)c;
                        rep.DataSource = ds;
                        rep.DataBind();
                    }
                    else if (contype.IndexOf("DataList") != -1)
                    {
                        DataList dl = (DataList)c;
                        dl.DataSource = ds;
                        dl.DataBind();
                    }
                }
                
                c.Visible = true;
            }
            else
            {
                string contype = c.GetType().ToString();
                if (contype.IndexOf("GridView") != -1)
                {
                    GridView gv = (GridView)c;
                    gv.DataSource = null;
                    gv.DataBind();
                }
                else if (contype.IndexOf("Repeater") != -1)
                {
                    Repeater rep = (Repeater)c;
                    rep.DataSource = null;
                    rep.DataBind();
                }
                else if (contype.IndexOf("DataList") != -1)
                {
                    DataList dl = (DataList)c;
                    dl.DataSource = null;
                    dl.DataBind();
                }
                c.Visible = false;
            }

        }

        /// <summary>
        /// 获取行数
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        private int GetRows(string tablename, string strwhere)
        {
            string strSql = "select count(1) from " + tablename + " where " + strwhere + "";
            return int.Parse(DBHelperSQL.GetSingle(strSql).ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string tablename, string keyname)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = tablename;
            parameters[1].Value = keyname;
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 1;
            parameters[6].Value = strWhere;
            DataSet ds = DBHelperSQL.RunProcedure("sp_GetRecordByPage", parameters, "ds");
            int num = ds.Tables[0].Rows.Count;
            return ds;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetListUp(int PageSize, int PageIndex, string strWhere, string tablename, string keyname)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = tablename;
            parameters[1].Value = keyname;
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            DataSet ds = DBHelperSQL.RunProcedureUp("sp_GetRecordByPage", parameters, "ds");
            int num = ds.Tables[0].Rows.Count;
            return ds;
        }


    }
}
