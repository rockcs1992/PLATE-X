using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类OALevelService。
	/// </summary>
	public class OALevelService
	{
		public OALevelService()
		{}
		#region  成员方法
        /// <summary>
        /// 查询一级权限的最大权限ID
        /// </summary>
        /// <returns></returns>
        public static int GetMaxLevelNo(int parentLevelNo) 
        {
            string sql = "select top 1 levelNo from OALevel where parentLevelNo = " + parentLevelNo + " order by id desc";
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj) + 1;
            }
            return Convert.ToInt32(parentLevelNo.ToString() + "01");
        }

        /// <summary>
        /// 根据条件获取对象列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<OALevel> GetListModel(string strWhere)
        {
            List<OALevel> list = null;
            OALevel model = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,levelName,levelNO,isParent,parentLevelNo,url,status,remark ");
            strSql.Append(" FROM OALevel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id desc");
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if(ds.Tables[0].Rows.Count > 0)
            {
                list = new List<OALevel>();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    model = new OALevel();
                    if (dr["id"].ToString() != "")
                    {
                        model.id = int.Parse(dr["id"].ToString());
                    }
                    model.levelName = dr["levelName"].ToString();
                    model.levelNO = int.Parse(dr["levelNO"].ToString());
                    if (dr["isParent"].ToString() != "")
                    {
                        model.isParent = int.Parse(dr["isParent"].ToString());
                    }
                    model.parentLevelNo = int.Parse(dr["parentLevelNo"].ToString());
                    model.url = dr["url"].ToString();
                    if (dr["status"].ToString() != "")
                    {
                        model.status = int.Parse(dr["status"].ToString());
                    }
                    model.remark = dr["remark"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static OALevel GetModelByLevelNo(int levelNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,levelName,levelNO,isParent,parentLevelNo,url,status,remark from OALevel ");
            strSql.Append(" where levelNO=@levelNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@levelNO", SqlDbType.Int,4)};
            parameters[0].Value = levelNo;

            OALevel model = new OALevel();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.levelName = ds.Tables[0].Rows[0]["levelName"].ToString();
                model.levelNO = int.Parse(ds.Tables[0].Rows[0]["levelNO"].ToString());
                if (ds.Tables[0].Rows[0]["isParent"].ToString() != "")
                {
                    model.isParent = int.Parse(ds.Tables[0].Rows[0]["isParent"].ToString());
                }
                model.parentLevelNo = int.Parse(ds.Tables[0].Rows[0]["parentLevelNo"].ToString());
                model.url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据levelNo获取父类levelNo
        /// </summary>
        /// <param name="levelNo"></param>
        /// <returns></returns>
        public static int GetparentLevelNoByLevelNo(int levelNo)
        {
            string sql = "select parentLevelNo from OALevel where levelNo = " + levelNo;
            object obj = DBHelperSQL.GetSingle(sql);
            if (obj != null && obj.ToString() != "")
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OALevel");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(OALevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OALevel(");
			strSql.Append("levelName,levelNO,isParent,parentLevelNo,url,status,remark)");
			strSql.Append(" values (");
			strSql.Append("@levelName,@levelNO,@isParent,@parentLevelNo,@url,@status,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@levelName", SqlDbType.VarChar,150),
					new SqlParameter("@levelNO", SqlDbType.Int,4),
					new SqlParameter("@isParent", SqlDbType.Int,4),
					new SqlParameter("@parentLevelNo", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.levelName;
			parameters[1].Value = model.levelNO;
			parameters[2].Value = model.isParent;
			parameters[3].Value = model.parentLevelNo;
			parameters[4].Value = model.url;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;

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
        public static int Update(int id, string levelName,string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OALevel set ");
            strSql.Append("levelName=@levelName,url=@url");            
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@levelName", SqlDbType.VarChar,150),new SqlParameter("@url", SqlDbType.VarChar,150)
					};
            parameters[0].Value = id;
            parameters[1].Value = levelName;
            parameters[2].Value = url;
            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static int Update(OALevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OALevel set ");
			strSql.Append("levelName=@levelName,");
			strSql.Append("levelNO=@levelNO,");
			strSql.Append("isParent=@isParent,");
			strSql.Append("parentLevelNo=@parentLevelNo,");
			strSql.Append("url=@url,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@levelName", SqlDbType.VarChar,150),
					new SqlParameter("@levelNO", SqlDbType.Int,4),
					new SqlParameter("@isParent", SqlDbType.Int,4),
					new SqlParameter("@parentLevelNo", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.levelName;
			parameters[2].Value = model.levelNO;
			parameters[3].Value = model.isParent;
			parameters[4].Value = model.parentLevelNo;
			parameters[5].Value = model.url;
			parameters[6].Value = model.status;
			parameters[7].Value = model.remark;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OALevel ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static OALevel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,levelName,levelNO,isParent,parentLevelNo,url,status,remark from OALevel ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			OALevel model=new OALevel();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.levelName=ds.Tables[0].Rows[0]["levelName"].ToString();
				model.levelNO=int.Parse(ds.Tables[0].Rows[0]["levelNO"].ToString());
				if(ds.Tables[0].Rows[0]["isParent"].ToString()!="")
				{
					model.isParent=int.Parse(ds.Tables[0].Rows[0]["isParent"].ToString());
				}
				model.parentLevelNo=int.Parse(ds.Tables[0].Rows[0]["parentLevelNo"].ToString());
				model.url=ds.Tables[0].Rows[0]["url"].ToString();
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
			strSql.Append("select id,levelName,levelNO,isParent,parentLevelNo,url,status,remark ");
			strSql.Append(" FROM OALevel ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by id asc");
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
			strSql.Append(" id,levelName,levelNO,isParent,parentLevelNo,url,status,remark ");
			strSql.Append(" FROM OALevel ");
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
			parameters[0].Value = "OALevel";
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

