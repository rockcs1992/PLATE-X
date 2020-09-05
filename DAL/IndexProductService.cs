using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// ���ݷ�����:IndexProductService
	/// </summary>
	public partial class IndexProductService
	{
		public IndexProductService()
		{}
		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from IndexProduct");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
        public static int Add(Model.IndexProduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IndexProduct(");
			strSql.Append("typeId,typeName,proName,proDesc,proPrice,priceStr,unitDesc,imgUrl,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@typeId,@typeName,@proName,@proDesc,@proPrice,@priceStr,@unitDesc,@imgUrl,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@proName", SqlDbType.VarChar,150),
					new SqlParameter("@proDesc", SqlDbType.VarChar,150),
					new SqlParameter("@proPrice", SqlDbType.Money,8),
					new SqlParameter("@priceStr", SqlDbType.VarChar,50),
					new SqlParameter("@unitDesc", SqlDbType.VarChar,50),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.proName;
			parameters[3].Value = model.proDesc;
			parameters[4].Value = model.proPrice;
			parameters[5].Value = model.priceStr;
			parameters[6].Value = model.unitDesc;
			parameters[7].Value = model.imgUrl;
			parameters[8].Value = model.status;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.addTime;
			parameters[11].Value = model.addUser;
			parameters[12].Value = model.infoType;

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
		/// ����һ������
		/// </summary>
        public static bool Update(Model.IndexProduct model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IndexProduct set ");
			strSql.Append("typeId=@typeId,");
			strSql.Append("typeName=@typeName,");
			strSql.Append("proName=@proName,");
			strSql.Append("proDesc=@proDesc,");
			strSql.Append("proPrice=@proPrice,");
			strSql.Append("priceStr=@priceStr,");
			strSql.Append("unitDesc=@unitDesc,");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@proName", SqlDbType.VarChar,150),
					new SqlParameter("@proDesc", SqlDbType.VarChar,150),
					new SqlParameter("@proPrice", SqlDbType.Money,8),
					new SqlParameter("@priceStr", SqlDbType.VarChar,50),
					new SqlParameter("@unitDesc", SqlDbType.VarChar,50),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typeId;
			parameters[1].Value = model.typeName;
			parameters[2].Value = model.proName;
			parameters[3].Value = model.proDesc;
			parameters[4].Value = model.proPrice;
			parameters[5].Value = model.priceStr;
			parameters[6].Value = model.unitDesc;
			parameters[7].Value = model.imgUrl;
			parameters[8].Value = model.status;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.addTime;
			parameters[11].Value = model.addUser;
			parameters[12].Value = model.infoType;
			parameters[13].Value = model.id;

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
		/// Deleteһ������
		/// </summary>
        public static bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IndexProduct ");
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
		/// ����Delete����
		/// </summary>
        public static bool DeleteList(string idlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from IndexProduct ");
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
		/// �õ�һ������ʵ��
		/// </summary>
        public static Model.IndexProduct GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeId,typeName,proName,proDesc,proPrice,priceStr,unitDesc,imgUrl,status,remark,addTime,addUser,infoType from IndexProduct ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.IndexProduct model=new Model.IndexProduct();
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
		/// �õ�һ������ʵ��
		/// </summary>
        public static Model.IndexProduct DataRowToModel(DataRow row)
		{
			Model.IndexProduct model=new Model.IndexProduct();
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
				if(row["typeName"]!=null)
				{
					model.typeName=row["typeName"].ToString();
				}
				if(row["proName"]!=null)
				{
					model.proName=row["proName"].ToString();
				}
				if(row["proDesc"]!=null)
				{
					model.proDesc=row["proDesc"].ToString();
				}
				if(row["proPrice"]!=null && row["proPrice"].ToString()!="")
				{
					model.proPrice=double.Parse(row["proPrice"].ToString());
				}
				if(row["priceStr"]!=null)
				{
					model.priceStr=row["priceStr"].ToString();
				}
				if(row["unitDesc"]!=null)
				{
					model.unitDesc=row["unitDesc"].ToString();
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
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
		/// ��������б�
		/// </summary>
        public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,typeId,typeName,proName,proDesc,proPrice,priceStr,unitDesc,imgUrl,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM IndexProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
        public static DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,typeId,typeName,proName,proDesc,proPrice,priceStr,unitDesc,imgUrl,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM IndexProduct ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ��ȡ��¼����
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM IndexProduct ");
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
		/// ��ҳ��ȡ�����б�
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
			strSql.Append(")AS Row, T.*  from IndexProduct T ");
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
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "IndexProduct";
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

