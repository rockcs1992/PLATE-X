using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ContractInfoService
	/// </summary>
	public partial class ContractInfoService
	{
		public ContractInfoService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ContractInfo");
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
		public static int Add(Model.ContractInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ContractInfo(");
			strSql.Append("contractNumber,userId,contractType,typeId,timeFrom,timeEnd,storeMoney,status,remark,addTime,otherTime,infoType)");
			strSql.Append(" values (");
			strSql.Append("@contractNumber,@userId,@contractType,@typeId,@timeFrom,@timeEnd,@storeMoney,@status,@remark,@addTime,@otherTime,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@contractNumber", SqlDbType.VarChar,50),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@contractType", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@storeMoney", SqlDbType.Money,8),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@otherTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.contractNumber;
			parameters[1].Value = model.userId;
			parameters[2].Value = model.contractType;
			parameters[3].Value = model.typeId;
			parameters[4].Value = model.timeFrom;
			parameters[5].Value = model.timeEnd;
			parameters[6].Value = model.storeMoney;
			parameters[7].Value = model.status;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.addTime;
			parameters[10].Value = model.otherTime;
			parameters[11].Value = model.infoType;

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
		public bool Update(Model.ContractInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ContractInfo set ");
			strSql.Append("contractNumber=@contractNumber,");
			strSql.Append("userId=@userId,");
			strSql.Append("contractType=@contractType,");
			strSql.Append("typeId=@typeId,");
			strSql.Append("timeFrom=@timeFrom,");
			strSql.Append("timeEnd=@timeEnd,");
			strSql.Append("storeMoney=@storeMoney,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("otherTime=@otherTime,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@contractNumber", SqlDbType.VarChar,50),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@contractType", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@timeFrom", SqlDbType.DateTime),
					new SqlParameter("@timeEnd", SqlDbType.DateTime),
					new SqlParameter("@storeMoney", SqlDbType.Money,8),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,1500),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@otherTime", SqlDbType.DateTime),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.contractNumber;
			parameters[1].Value = model.userId;
			parameters[2].Value = model.contractType;
			parameters[3].Value = model.typeId;
			parameters[4].Value = model.timeFrom;
			parameters[5].Value = model.timeEnd;
			parameters[6].Value = model.storeMoney;
			parameters[7].Value = model.status;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.addTime;
			parameters[10].Value = model.otherTime;
			parameters[11].Value = model.infoType;
			parameters[12].Value = model.id;

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
			strSql.Append("delete from ContractInfo ");
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
			strSql.Append("delete from ContractInfo ");
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
		public static Model.ContractInfo GetModel(int id,int type)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,contractNumber,userId,contractType,typeId,timeFrom,timeEnd,storeMoney,status,remark,addTime,otherTime,infoType from ContractInfo ");
            strSql.Append(" where userId=@userId and typeId = " + type + " order by id desc");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.ContractInfo model=new Model.ContractInfo();
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
		public static Model.ContractInfo DataRowToModel(DataRow row)
		{
			Model.ContractInfo model=new Model.ContractInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["contractNumber"]!=null)
				{
					model.contractNumber=row["contractNumber"].ToString();
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId=int.Parse(row["userId"].ToString());
				}
				if(row["contractType"]!=null && row["contractType"].ToString()!="")
				{
					model.contractType=int.Parse(row["contractType"].ToString());
				}
				if(row["typeId"]!=null && row["typeId"].ToString()!="")
				{
					model.typeId=int.Parse(row["typeId"].ToString());
				}
				if(row["timeFrom"]!=null && row["timeFrom"].ToString()!="")
				{
					model.timeFrom=DateTime.Parse(row["timeFrom"].ToString());
				}
				if(row["timeEnd"]!=null && row["timeEnd"].ToString()!="")
				{
					model.timeEnd=DateTime.Parse(row["timeEnd"].ToString());
				}
				if(row["storeMoney"]!=null && row["storeMoney"].ToString()!="")
				{
					model.storeMoney=double.Parse(row["storeMoney"].ToString());
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
				if(row["otherTime"]!=null && row["otherTime"].ToString()!="")
				{
					model.otherTime=DateTime.Parse(row["otherTime"].ToString());
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
			strSql.Append("select id,contractNumber,userId,contractType,typeId,timeFrom,timeEnd,storeMoney,status,remark,addTime,otherTime,infoType ");
			strSql.Append(" FROM ContractInfo ");
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
			strSql.Append(" id,contractNumber,userId,contractType,typeId,timeFrom,timeEnd,storeMoney,status,remark,addTime,otherTime,infoType ");
			strSql.Append(" FROM ContractInfo ");
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
			strSql.Append("select count(1) FROM ContractInfo ");
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
			strSql.Append(")AS Row, T.*  from ContractInfo T ");
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
			parameters[0].Value = "ContractInfo";
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

