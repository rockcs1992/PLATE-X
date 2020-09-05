using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ShoperInfoService
	/// </summary>
	public partial class ShoperInfoService
	{
		public ShoperInfoService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelperSQL.GetMaxID("id", "ShoperInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ShoperInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.ShoperInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ShoperInfo(");
			strSql.Append("shoperName,imgUrl,tel,mobile,price,pid,cid,regionId,address,remark,status,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@shoperName,@imgUrl,@tel,@mobile,@price,@pid,@cid,@regionId,@address,@remark,@status,@addTime,@addUser,@infoType)");
			SqlParameter[] parameters = {
					new SqlParameter("@shoperName", SqlDbType.VarChar,50),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.shoperName;
			parameters[1].Value = model.imgUrl;
			parameters[2].Value = model.tel;
			parameters[3].Value = model.mobile;
			parameters[4].Value = model.price;
			parameters[5].Value = model.pid;
			parameters[6].Value = model.cid;
			parameters[7].Value = model.regionId;
			parameters[8].Value = model.address;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.status;
			parameters[11].Value = model.addTime;
			parameters[12].Value = model.addUser;
			parameters[13].Value = model.infoType;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static int Update(Model.ShoperInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ShoperInfo set ");
			strSql.Append("shoperName=@shoperName,");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("tel=@tel,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("price=@price,");
			strSql.Append("pid=@pid,");
			strSql.Append("cid=@cid,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("address=@address,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@shoperName", SqlDbType.VarChar,50),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@price", SqlDbType.Money,8),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.shoperName;
			parameters[1].Value = model.imgUrl;
			parameters[2].Value = model.tel;
			parameters[3].Value = model.mobile;
			parameters[4].Value = model.price;
			parameters[5].Value = model.pid;
			parameters[6].Value = model.cid;
			parameters[7].Value = model.regionId;
			parameters[8].Value = model.address;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.status;
			parameters[11].Value = model.addTime;
			parameters[12].Value = model.addUser;
			parameters[13].Value = model.infoType;
			parameters[14].Value = model.id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ShoperInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
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
			strSql.Append("delete from ShoperInfo ");
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
		public static Model.ShoperInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,shoperName,imgUrl,tel,mobile,price,pid,cid,regionId,address,remark,status,addTime,addUser,infoType from ShoperInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			Model.ShoperInfo model=new Model.ShoperInfo();
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
		public static Model.ShoperInfo DataRowToModel(DataRow row)
		{
			Model.ShoperInfo model=new Model.ShoperInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["shoperName"]!=null)
				{
					model.shoperName=row["shoperName"].ToString();
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["mobile"]!=null)
				{
					model.mobile=row["mobile"].ToString();
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=double.Parse(row["price"].ToString());
				}
				if(row["pid"]!=null && row["pid"].ToString()!="")
				{
					model.pid=int.Parse(row["pid"].ToString());
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["regionId"]!=null && row["regionId"].ToString()!="")
				{
					model.regionId=int.Parse(row["regionId"].ToString());
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["addUser"]!=null && row["addUser"].ToString()!="")
				{
					model.addUser=int.Parse(row["addUser"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,shoperName,imgUrl,tel,mobile,price,pid,cid,regionId,address,remark,status,addTime,addUser,infoType ");
			strSql.Append(" FROM ShoperInfo ");
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
			strSql.Append(" id,shoperName,imgUrl,tel,mobile,price,pid,cid,regionId,address,remark,status,addTime,addUser,infoType ");
			strSql.Append(" FROM ShoperInfo ");
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
			strSql.Append("select count(1) FROM ShoperInfo ");
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
			strSql.Append(")AS Row, T.*  from ShoperInfo T ");
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
			parameters[0].Value = "ShoperInfo";
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

