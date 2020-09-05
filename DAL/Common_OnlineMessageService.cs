using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:Common_OnlineMessageService
	/// </summary>
	public partial class Common_OnlineMessageService
	{
		public Common_OnlineMessageService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Common_OnlineMessage");
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
		public static int Add(Model.Common_OnlineMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Common_OnlineMessage(");
			strSql.Append("typeId,objId,name,mobile,tel,qq,email,address,title,mesContent,imgURL,remark,ip,status,addTime,infoType)");
			strSql.Append(" values (");
			strSql.Append("@typeId,@objId,@name,@mobile,@tel,@qq,@email,@address,@title,@mesContent,@imgURL,@remark,@ip,@status,@addTime,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@objId", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,20),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),
					new SqlParameter("@qq", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,20),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@mesContent", SqlDbType.NText),
					new SqlParameter("@imgURL", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@ip", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.objId;
			parameters[2].Value = model.name;
			parameters[3].Value = model.mobile;
			parameters[4].Value = model.tel;
			parameters[5].Value = model.qq;
			parameters[6].Value = model.email;
			parameters[7].Value = model.address;
			parameters[8].Value = model.title;
			parameters[9].Value = model.mesContent;
			parameters[10].Value = model.imgURL;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.ip;
			parameters[13].Value = model.status;
			parameters[14].Value = model.addTime;
			parameters[15].Value = model.infoType;

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
		public bool Update(Model.Common_OnlineMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Common_OnlineMessage set ");
			strSql.Append("typeId=@typeId,");
			strSql.Append("objId=@objId,");
			strSql.Append("name=@name,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("tel=@tel,");
			strSql.Append("qq=@qq,");
			strSql.Append("email=@email,");
			strSql.Append("address=@address,");
			strSql.Append("title=@title,");
			strSql.Append("mesContent=@mesContent,");
			strSql.Append("imgURL=@imgURL,");
			strSql.Append("remark=@remark,");
			strSql.Append("ip=@ip,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@objId", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.VarChar,20),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@tel", SqlDbType.VarChar,20),
					new SqlParameter("@qq", SqlDbType.VarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,20),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@title", SqlDbType.VarChar,100),
					new SqlParameter("@mesContent", SqlDbType.NText),
					new SqlParameter("@imgURL", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,500),
					new SqlParameter("@ip", SqlDbType.VarChar,20),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.objId;
			parameters[2].Value = model.name;
			parameters[3].Value = model.mobile;
			parameters[4].Value = model.tel;
			parameters[5].Value = model.qq;
			parameters[6].Value = model.email;
			parameters[7].Value = model.address;
			parameters[8].Value = model.title;
			parameters[9].Value = model.mesContent;
			parameters[10].Value = model.imgURL;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.ip;
			parameters[13].Value = model.status;
			parameters[14].Value = model.addTime;
			parameters[15].Value = model.infoType;
			parameters[16].Value = model.id;

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
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Common_OnlineMessage ");
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
			strSql.Append("delete from Common_OnlineMessage ");
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
		public static Model.Common_OnlineMessage GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeId,objId,name,mobile,tel,qq,email,address,title,mesContent,imgURL,remark,ip,status,addTime,infoType from Common_OnlineMessage ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.Common_OnlineMessage model=new Model.Common_OnlineMessage();
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
		public static Model.Common_OnlineMessage DataRowToModel(DataRow row)
		{
			Model.Common_OnlineMessage model=new Model.Common_OnlineMessage();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["objId"]!=null && row["objId"].ToString()!="")
				{
					model.objId=int.Parse(row["objId"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["qq"]!=null)
				{
					model.qq=row["qq"].ToString();
				}
				if(row["email"]!=null)
				{
					model.email=row["email"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["mesContent"]!=null)
				{
					model.mesContent=row["mesContent"].ToString();
				}
				if(row["imgURL"]!=null)
				{
					model.imgURL=row["imgURL"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["ip"]!=null)
				{
					model.ip=row["ip"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
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
			strSql.Append("select id,typeId,objId,name,mobile,tel,qq,email,address,title,mesContent,imgURL,remark,ip,status,addTime,infoType ");
			strSql.Append(" FROM Common_OnlineMessage ");
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
			strSql.Append(" id,typeId,objId,name,mobile,tel,qq,email,address,title,mesContent,imgURL,remark,ip,status,addTime,infoType ");
			strSql.Append(" FROM Common_OnlineMessage ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Common_OnlineMessage ");
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
			strSql.Append(")AS Row, T.*  from Common_OnlineMessage T ");
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
			parameters[0].Value = "Common_OnlineMessage";
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

