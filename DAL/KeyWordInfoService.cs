using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类KeyWordInfoService。
	/// </summary>
	public class KeyWordInfoService
	{
		public KeyWordInfoService()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public static bool Exists(string pageNameValue)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from KeyWordInfo");
            strSql.Append(" where pageNameValue=@pageNameValue ");
			SqlParameter[] parameters = {
					new SqlParameter("@pageNameValue", SqlDbType.VarChar,54)};
            parameters[0].Value = pageNameValue;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.KeyWordInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into KeyWordInfo(");
			strSql.Append("pageName,title,keyword,description,pageNameValue)");
			strSql.Append(" values (");
			strSql.Append("@pageName,@title,@keyword,@description,@pageNameValue)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pageName", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@keyword", SqlDbType.VarChar,150),
					new SqlParameter("@description", SqlDbType.VarChar,350),
					new SqlParameter("@pageNameValue", SqlDbType.VarChar,50)};
			parameters[0].Value = model.pageName;
			parameters[1].Value = model.title;
			parameters[2].Value = model.keyword;
			parameters[3].Value = model.description;
			parameters[4].Value = model.pageNameValue;

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
		public static int Update(Model.KeyWordInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update KeyWordInfo set ");
			strSql.Append("pageName=@pageName,");
			strSql.Append("title=@title,");
			strSql.Append("keyword=@keyword,");
			strSql.Append("description=@description,");
			strSql.Append("pageNameValue=@pageNameValue");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@pageName", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@keyword", SqlDbType.VarChar,150),
					new SqlParameter("@description", SqlDbType.VarChar,350),
					new SqlParameter("@pageNameValue", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.pageName;
			parameters[2].Value = model.title;
			parameters[3].Value = model.keyword;
			parameters[4].Value = model.description;
			parameters[5].Value = model.pageNameValue;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from KeyWordInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.KeyWordInfo GetModel(string pageURl)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,pageName,title,keyword,description,pageNameValue from KeyWordInfo ");
            strSql.Append(" where pageNameValue=@pageURl ");
            SqlParameter[] parameters = {
					new SqlParameter("@pageURl", SqlDbType.VarChar,54)};
            parameters[0].Value = pageURl;

            Model.KeyWordInfo model = new Model.KeyWordInfo();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.pageName = ds.Tables[0].Rows[0]["pageName"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.keyword = ds.Tables[0].Rows[0]["keyword"].ToString();
                model.description = ds.Tables[0].Rows[0]["description"].ToString();
                model.pageNameValue = ds.Tables[0].Rows[0]["pageNameValue"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.KeyWordInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pageName,title,keyword,description,pageNameValue from KeyWordInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.KeyWordInfo model=new Model.KeyWordInfo();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.pageName=ds.Tables[0].Rows[0]["pageName"].ToString();
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.keyword=ds.Tables[0].Rows[0]["keyword"].ToString();
				model.description=ds.Tables[0].Rows[0]["description"].ToString();
				model.pageNameValue=ds.Tables[0].Rows[0]["pageNameValue"].ToString();
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pageName,title,keyword,description,pageNameValue ");
			strSql.Append(" FROM KeyWordInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,pageName,title,keyword,description,pageNameValue ");
			strSql.Append(" FROM KeyWordInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "KeyWordInfo";
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

