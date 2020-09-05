using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:UserAddressService
	/// </summary>
	public partial class UserAddressService
	{
		public UserAddressService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="infoType"></param>
        /// <returns></returns>
        public static int SetDefault(int id,int infoType) 
        {
            string sql = "update UserAddress set infoType = " + infoType + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int UpdateInfoType(object userId,object num) 
        {
            string sql = "update UserAddress set infoType = " + num + " where addUser = " + userId;
            return DBHelperSQL.ExecuteSql(sql);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserAddress");
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
        public static int Add(Model.UserAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserAddress(");
			strSql.Append("relName,mobile,tel,qq,weixin,zipcode,pid,cid,regionId,address,addressDetail,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@relName,@mobile,@tel,@qq,@weixin,@zipcode,@pid,@cid,@regionId,@address,@addressDetail,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@relName", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@qq", SqlDbType.VarChar,50),
					new SqlParameter("@weixin", SqlDbType.VarChar,50),
					new SqlParameter("@zipcode", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@addressDetail", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.relName;
			parameters[1].Value = model.mobile;
			parameters[2].Value = model.tel;
			parameters[3].Value = model.qq;
			parameters[4].Value = model.weixin;
			parameters[5].Value = model.zipcode;
			parameters[6].Value = model.pid;
			parameters[7].Value = model.cid;
			parameters[8].Value = model.regionId;
			parameters[9].Value = model.address;
			parameters[10].Value = model.addressDetail;
			parameters[11].Value = model.status;
			parameters[12].Value = model.remark;
			parameters[13].Value = model.addTime;
			parameters[14].Value = model.addUser;
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
        public static bool Update(Model.UserAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserAddress set ");
			strSql.Append("relName=@relName,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("tel=@tel,");
			strSql.Append("qq=@qq,");
			strSql.Append("weixin=@weixin,");
			strSql.Append("zipcode=@zipcode,");
			strSql.Append("pid=@pid,");
			strSql.Append("cid=@cid,");
			strSql.Append("regionId=@regionId,");
			strSql.Append("address=@address,");
			strSql.Append("addressDetail=@addressDetail,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@relName", SqlDbType.VarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,50),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@qq", SqlDbType.VarChar,50),
					new SqlParameter("@weixin", SqlDbType.VarChar,50),
					new SqlParameter("@zipcode", SqlDbType.VarChar,50),
					new SqlParameter("@pid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@regionId", SqlDbType.Int,4),
					new SqlParameter("@address", SqlDbType.VarChar,150),
					new SqlParameter("@addressDetail", SqlDbType.VarChar,150),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.relName;
			parameters[1].Value = model.mobile;
			parameters[2].Value = model.tel;
			parameters[3].Value = model.qq;
			parameters[4].Value = model.weixin;
			parameters[5].Value = model.zipcode;
			parameters[6].Value = model.pid;
			parameters[7].Value = model.cid;
			parameters[8].Value = model.regionId;
			parameters[9].Value = model.address;
			parameters[10].Value = model.addressDetail;
			parameters[11].Value = model.status;
			parameters[12].Value = model.remark;
			parameters[13].Value = model.addTime;
			parameters[14].Value = model.addUser;
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
			strSql.Append("delete from UserAddress ");
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
        public static bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserAddress ");
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
        public static Model.UserAddress GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,relName,mobile,tel,qq,weixin,zipcode,pid,cid,regionId,address,addressDetail,status,remark,addTime,addUser,infoType from UserAddress ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.UserAddress model=new Model.UserAddress();
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
        public static Model.UserAddress DataRowToModel(DataRow row)
		{
			Model.UserAddress model=new Model.UserAddress();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["relName"]!=null)
				{
					model.relName=row["relName"].ToString();
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
				if(row["weixin"]!=null)
				{
					model.weixin=row["weixin"].ToString();
				}
				if(row["zipcode"]!=null)
				{
					model.zipcode=row["zipcode"].ToString();
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
				if(row["addressDetail"]!=null)
				{
					model.addressDetail=row["addressDetail"].ToString();
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
        public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,relName,mobile,tel,qq,weixin,zipcode,pid,cid,regionId,address,addressDetail,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserAddress ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by infoType desc");
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,relName,mobile,tel,qq,weixin,zipcode,pid,cid,regionId,address,addressDetail,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM UserAddress ");
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
			strSql.Append("select count(1) FROM UserAddress ");
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
			strSql.Append(")AS Row, T.*  from UserAddress T ");
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
			parameters[0].Value = "UserAddress";
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

