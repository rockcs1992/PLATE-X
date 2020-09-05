using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserImgInfoService
	/// </summary>
	public partial class UserImgInfoService
	{
		public UserImgInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 更新描述信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateImgDesc(UserImgInfo item) 
        {
            string sql = "update UserImgInfo set imgDesc = '" + item.imgDesc + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserImgInfo GetModel(string strsql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userId,userType,imgUrl,imgTitle,imgLink,imgDesc,status,remark,addTime,infoType from UserImgInfo ");
            strSql.Append(" where 1=1");
            if(strsql != "")
            {
                strSql.Append(" and " + strsql);
            }

            Model.UserImgInfo model = new Model.UserImgInfo();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新介绍信息
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int UpdateIntroduction(Model.UserImgInfo item) 
        {
            string sql = "update UserImgInfo set imgDesc = '" + item.imgDesc + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新图片信息
        /// </summary>
        /// <returns></returns>
        public static int UpdateImg(Model.UserImgInfo item) 
        {
            string sql = "update UserImgInfo set imgUrl = '" + item.imgUrl + "' where id = " + item.id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.UserImgInfo GetModel(Model.UserImgInfo item)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,userId,userType,imgUrl,imgTitle,imgLink,imgDesc,status,remark,addTime,infoType from UserImgInfo ");
            strSql.Append(" where userId=@userId and userType=@userType and infoType=@infoType");
            SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),new SqlParameter("@userType", SqlDbType.Int,4),new SqlParameter("@infoType", SqlDbType.Int,4)
			};
            parameters[0].Value = item.userId;
            parameters[1].Value = item.userType;
            parameters[2].Value = item.infoType;

            Model.UserImgInfo model = new Model.UserImgInfo();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 用户Upload图片Quantity
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetImgCount(int userId) 
        {
            string sql = "select count(*) from UserImgInfo where userId = " + userId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserImgInfo");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.UserImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserImgInfo(");
			strSql.Append("userId,userType,imgUrl,imgTitle,imgLink,imgDesc,status,remark,addTime,infoType)");
			strSql.Append(" values (");
			strSql.Append("@userId,@userType,@imgUrl,@imgTitle,@imgLink,@imgDesc,@status,@remark,@addTime,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@userType", SqlDbType.Int,4),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@imgTitle", SqlDbType.VarChar,150),
					new SqlParameter("@imgLink", SqlDbType.VarChar,50),
					new SqlParameter("@imgDesc", SqlDbType.VarChar,2500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.userType;
			parameters[2].Value = model.imgUrl;
			parameters[3].Value = model.imgTitle;
			parameters[4].Value = model.imgLink;
			parameters[5].Value = model.imgDesc;
			parameters[6].Value = model.status;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.addTime;
			parameters[9].Value = model.infoType;

			object obj = DBHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.UserImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserImgInfo set ");
			strSql.Append("userId=@userId,");
			strSql.Append("userType=@userType,");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("imgTitle=@imgTitle,");
			strSql.Append("imgLink=@imgLink,");
			strSql.Append("imgDesc=@imgDesc,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@userType", SqlDbType.Int,4),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@imgTitle", SqlDbType.VarChar,150),
					new SqlParameter("@imgLink", SqlDbType.VarChar,50),
					new SqlParameter("@imgDesc", SqlDbType.VarChar,2500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.userType;
			parameters[2].Value = model.imgUrl;
			parameters[3].Value = model.imgTitle;
			parameters[4].Value = model.imgLink;
			parameters[5].Value = model.imgDesc;
			parameters[6].Value = model.status;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.addTime;
			parameters[9].Value = model.infoType;
			parameters[10].Value = model.id;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserImgInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量Delete数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserImgInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DBHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.UserImgInfo GetModel(int id)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,userId,userType,imgUrl,imgTitle,imgLink,imgDesc,status,remark,addTime,infoType from UserImgInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserImgInfo model=new Model.UserImgInfo();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.UserImgInfo DataRowToModel(DataRow row)
		{
			Model.UserImgInfo model=new Model.UserImgInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
				}
				if(row["userType"]!=null && row["userType"].ToString()!="")
				{
					model.userType=int.Parse(row["userType"].ToString());
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
				}
				if(row["imgTitle"]!=null)
				{
					model.imgTitle=row["imgTitle"].ToString();
				}
				if(row["imgLink"]!=null)
				{
					model.imgLink=row["imgLink"].ToString();
				}
				if(row["imgDesc"]!=null)
				{
					model.imgDesc=row["imgDesc"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["infoType"]!=null && row["infoType"].ToString()!="")
				{
					model.infoType=int.Parse(row["infoType"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,userId,userType,imgUrl,imgTitle,imgLink,imgDesc,status,remark,addTime,infoType ");
			strSql.Append(" FROM UserImgInfo ");
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
			strSql.Append(" id,userId,userType,imgUrl,imgTitle,imgLink,imgDesc,status,remark,addTime,infoType ");
			strSql.Append(" FROM UserImgInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder + " desc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM UserImgInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from UserImgInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "UserImgInfo";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

