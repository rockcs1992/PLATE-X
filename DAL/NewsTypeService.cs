using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类NewsTypeService。
	/// </summary>
	public class NewsTypeService
	{
		public NewsTypeService()
		{}
		#region  成员方法
        /// <summary>
        /// 获得首页社保知识数据列表
        /// </summary>
        public static List<NewsType> GetListItem(int parentId)
        {
            List<NewsType> list = new List<NewsType>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM NewsType where parentId = " + parentId + " order by id desc ");
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                NewsType model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new NewsType();
                    if (ds.Tables[0].Rows[i]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    }
                    model.name = ds.Tables[0].Rows[i]["name"].ToString();
                    if (ds.Tables[0].Rows[i]["parentId"].ToString() != "")
                    {
                        model.parentId = int.Parse(ds.Tables[0].Rows[i]["parentId"].ToString());
                    }
                    model.typedesc = ds.Tables[0].Rows[i]["typeDesc"].ToString();
                    model.pagename = ds.Tables[0].Rows[i]["pagename"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(Model.NewsType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewsType");
			strSql.Append(" where name=@name and parentId = " + model.parentId);
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,54)};
			parameters[0].Value = model.name;
			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.NewsType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into NewsType(");
            strSql.Append("name,parentId,status,remark,typedesc,pagename)");
			strSql.Append(" values (");
            strSql.Append("@name,@parentId,@status,@remark,@typedesc,@pagename)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
                    new SqlParameter("@typedesc", SqlDbType.NText),new SqlParameter("@pagename",SqlDbType.VarChar,1000)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.status;
			parameters[3].Value = model.remark;
            parameters[4].Value = model.typedesc;
            parameters[5].Value = model.pagename;
			object obj = DBHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static int UpdateModel(NewsType item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NewsType set ");
            strSql.Append("name=@name,remark=@remark,typedesc=@typedesc,pagename=@pagename,parentId=" + item.parentId + ",status = " + item.status);
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50),new SqlParameter("@remark", SqlDbType.VarChar,150),new SqlParameter("@typedesc", SqlDbType.NText),new SqlParameter("@pagename",SqlDbType.VarChar,1000)};
            parameters[0].Value = item.id;
            parameters[1].Value = item.name;
            parameters[2].Value = item.remark;
            parameters[3].Value = item.typedesc;
            parameters[4].Value = item.pagename;

            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static int Update(int id,string name,int status)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update NewsType set ");
			strSql.Append("name=@name,status = " + status);
			strSql.Append(" where id=@id "); 
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,50)};
			parameters[0].Value = id;
			parameters[1].Value = name;
			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from NewsType ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.NewsType GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from NewsType ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.NewsType model=new Model.NewsType();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				if(ds.Tables[0].Rows[0]["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
                model.typedesc = ds.Tables[0].Rows[0]["typeDesc"].ToString();
                model.pagename = ds.Tables[0].Rows[0]["pagename"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM NewsType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by status asc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public static DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM NewsType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder + " desc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
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
			parameters[0].Value = "NewsType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

