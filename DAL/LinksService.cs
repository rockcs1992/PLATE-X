using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Collections.Generic;

namespace DAL
{
	/// <summary>
	/// 数据访问类LinksService。
	/// </summary>
	public class LinksService
	{
		public LinksService()
		{}
		#region  成员方法
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static List<Links> GetListItem(int num)
        {
            List<Links> list = new List<Links>();
            StringBuilder strSql = new StringBuilder();
            if (num == 1)
            {
                strSql.Append("select id,linkname,linkurl FROM Links where isTj = 1 order by id desc");    
            }
            else
            {
                strSql.Append("select id,linkname,linkurl FROM Links where isTj <> 1 order by id desc");    
            }
                  
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if(ds.Tables[0].Rows.Count > 0)
            {
                Links model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    model = new Links();
                    if (ds.Tables[0].Rows[i]["id"].ToString() != "")
                    {
                        model.id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    }                    
                    model.linkname = ds.Tables[0].Rows[i]["linkname"].ToString();                  
                    model.linkurl = ds.Tables[0].Rows[i]["linkurl"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Links");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.Links model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Links(");
			strSql.Append("linkname,linktitle,linkurl,addtime,isTj)");
			strSql.Append(" values (");
			strSql.Append("@linkname,@linktitle,@linkurl,@addtime,@isTj)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@linkname", SqlDbType.NVarChar,50),
					new SqlParameter("@linktitle", SqlDbType.VarChar,100),
					new SqlParameter("@linkurl", SqlDbType.NVarChar,500),
					new SqlParameter("@addtime", SqlDbType.DateTime),new SqlParameter("@isTj", SqlDbType.Int,4)};
			parameters[0].Value = model.linkname;
			parameters[1].Value = model.linktitle;
			parameters[2].Value = model.linkurl;
			parameters[3].Value = model.addtime;
            parameters[4].Value = model.istj;
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
		public static int Update(Model.Links model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Links set ");
			strSql.Append("linkname=@linkname,");
			strSql.Append("linktitle=@linktitle,");
			strSql.Append("linkurl=@linkurl,");
            strSql.Append("isTj=@isTj");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@linkname", SqlDbType.NVarChar,50),
					new SqlParameter("@linktitle", SqlDbType.VarChar,100),
					new SqlParameter("@linkurl", SqlDbType.NVarChar,500),
				new SqlParameter("@isTj",SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.linkname;
			parameters[2].Value = model.linktitle;
			parameters[3].Value = model.linkurl;			
            parameters[4].Value = model.istj;
			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Links ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.Links GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from Links ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.Links model=new Model.Links();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
                if (ds.Tables[0].Rows[0]["isTj"].ToString() != "")
                {
                    model.istj = int.Parse(ds.Tables[0].Rows[0]["isTj"].ToString());
                }
				model.linkname=ds.Tables[0].Rows[0]["linkname"].ToString();
				model.linktitle=ds.Tables[0].Rows[0]["linktitle"].ToString();
				model.linkurl=ds.Tables[0].Rows[0]["linkurl"].ToString();
				if(ds.Tables[0].Rows[0]["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(ds.Tables[0].Rows[0]["addtime"].ToString());
				}
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
			strSql.Append("select id,linkname,linktitle,linkurl,addtime,isTj ");
			strSql.Append(" FROM Links ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by id desc");
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
			strSql.Append(" id,linkname,linktitle,linkurl,addtime,isTj ");
			strSql.Append(" FROM Links ");
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
			parameters[0].Value = "Links";
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

