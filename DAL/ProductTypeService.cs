using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ProductTypeService
	/// </summary>
	public partial class ProductTypeService
	{
		public ProductTypeService()
		{}
		#region  BasicMethod
        public static string GetName(object productTypeId) 
        {
            string sql = "select typeName from ProductType where id = " + productTypeId;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        /// <summary>
        /// Delete一条数据
        /// </summary>
        public static bool DeleteTypeImg(int id,int num)
        {

            StringBuilder strSql = new StringBuilder();
            if(num == 1)
            {
                strSql.Append("update ProductType set imgurl = ''");
            }
            if (num == 2)
            {
                strSql.Append("update ProductType set diaryImg = ''");
            }
            if (num == 3)
            {
                strSql.Append("update ProductType set remark = ''");
            }
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductType");
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
        public static int Add(Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductType(");
			strSql.Append("typeName,parentId,oneId,oneName,twoId,twoName,threeId,threeName,fourId,fourName,imgUrl,diaryImg,typeContent,typeDesc,status,remark,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@typeName,@parentId,@oneId,@oneName,@twoId,@twoName,@threeId,@threeName,@fourId,@fourName,@imgUrl,@diaryImg,@typeContent,@typeDesc,@status,@remark,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@oneId", SqlDbType.Int,4),
					new SqlParameter("@oneName", SqlDbType.VarChar,150),
					new SqlParameter("@twoId", SqlDbType.Int,4),
					new SqlParameter("@twoName", SqlDbType.VarChar,150),
					new SqlParameter("@threeId", SqlDbType.Int,4),
					new SqlParameter("@threeName", SqlDbType.VarChar,150),
					new SqlParameter("@fourId", SqlDbType.Int,4),
					new SqlParameter("@fourName", SqlDbType.VarChar,150),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@diaryImg", SqlDbType.VarChar,150),
					new SqlParameter("@typeContent", SqlDbType.NText),
					new SqlParameter("@typeDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.typeName;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.oneId;
			parameters[3].Value = model.oneName;
			parameters[4].Value = model.twoId;
			parameters[5].Value = model.twoName;
			parameters[6].Value = model.threeId;
			parameters[7].Value = model.threeName;
			parameters[8].Value = model.fourId;
			parameters[9].Value = model.fourName;
			parameters[10].Value = model.imgUrl;
			parameters[11].Value = model.diaryImg;
			parameters[12].Value = model.typeContent;
			parameters[13].Value = model.typeDesc;
			parameters[14].Value = model.status;
			parameters[15].Value = model.remark;
			parameters[16].Value = model.addTime;
			parameters[17].Value = model.addUser;
			parameters[18].Value = model.infoType;

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
        public static bool Update(Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductType set ");
			strSql.Append("typeName=@typeName,");
			strSql.Append("parentId=@parentId,");
			strSql.Append("oneId=@oneId,");
			strSql.Append("oneName=@oneName,");
			strSql.Append("twoId=@twoId,");
			strSql.Append("twoName=@twoName,");
			strSql.Append("threeId=@threeId,");
			strSql.Append("threeName=@threeName,");
			strSql.Append("fourId=@fourId,");
			strSql.Append("fourName=@fourName,");
			strSql.Append("imgUrl=@imgUrl,");
			strSql.Append("diaryImg=@diaryImg,");
			strSql.Append("typeContent=@typeContent,");
			strSql.Append("typeDesc=@typeDesc,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@typeName", SqlDbType.VarChar,150),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@oneId", SqlDbType.Int,4),
					new SqlParameter("@oneName", SqlDbType.VarChar,150),
					new SqlParameter("@twoId", SqlDbType.Int,4),
					new SqlParameter("@twoName", SqlDbType.VarChar,150),
					new SqlParameter("@threeId", SqlDbType.Int,4),
					new SqlParameter("@threeName", SqlDbType.VarChar,150),
					new SqlParameter("@fourId", SqlDbType.Int,4),
					new SqlParameter("@fourName", SqlDbType.VarChar,150),
					new SqlParameter("@imgUrl", SqlDbType.VarChar,150),
					new SqlParameter("@diaryImg", SqlDbType.VarChar,150),
					new SqlParameter("@typeContent", SqlDbType.NText),
					new SqlParameter("@typeDesc", SqlDbType.VarChar,1500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,150),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.typeName;
			parameters[1].Value = model.parentId;
			parameters[2].Value = model.oneId;
			parameters[3].Value = model.oneName;
			parameters[4].Value = model.twoId;
			parameters[5].Value = model.twoName;
			parameters[6].Value = model.threeId;
			parameters[7].Value = model.threeName;
			parameters[8].Value = model.fourId;
			parameters[9].Value = model.fourName;
			parameters[10].Value = model.imgUrl;
			parameters[11].Value = model.diaryImg;
			parameters[12].Value = model.typeContent;
			parameters[13].Value = model.typeDesc;
			parameters[14].Value = model.status;
			parameters[15].Value = model.remark;
			parameters[16].Value = model.addTime;
			parameters[17].Value = model.addUser;
			parameters[18].Value = model.infoType;
			parameters[19].Value = model.id;

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
			strSql.Append("delete from ProductType ");
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
			strSql.Append("delete from ProductType ");
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
        public static Model.ProductType GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,typeName,parentId,oneId,oneName,twoId,twoName,threeId,threeName,fourId,fourName,imgUrl,diaryImg,typeContent,typeDesc,status,remark,addTime,addUser,infoType from ProductType ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.ProductType model=new Model.ProductType();
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
        public static Model.ProductType DataRowToModel(DataRow row)
		{
			Model.ProductType model=new Model.ProductType();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["typeName"]!=null)
				{
					model.typeName=row["typeName"].ToString();
				}
				if(row["parentId"]!=null && row["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(row["parentId"].ToString());
				}
				if(row["oneId"]!=null && row["oneId"].ToString()!="")
				{
					model.oneId=int.Parse(row["oneId"].ToString());
				}
				if(row["oneName"]!=null)
				{
					model.oneName=row["oneName"].ToString();
				}
				if(row["twoId"]!=null && row["twoId"].ToString()!="")
				{
					model.twoId=int.Parse(row["twoId"].ToString());
				}
				if(row["twoName"]!=null)
				{
					model.twoName=row["twoName"].ToString();
				}
				if(row["threeId"]!=null && row["threeId"].ToString()!="")
				{
					model.threeId=int.Parse(row["threeId"].ToString());
				}
				if(row["threeName"]!=null)
				{
					model.threeName=row["threeName"].ToString();
				}
				if(row["fourId"]!=null && row["fourId"].ToString()!="")
				{
					model.fourId=int.Parse(row["fourId"].ToString());
				}
				if(row["fourName"]!=null)
				{
					model.fourName=row["fourName"].ToString();
				}
				if(row["imgUrl"]!=null)
				{
					model.imgUrl=row["imgUrl"].ToString();
				}
				if(row["diaryImg"]!=null)
				{
					model.diaryImg=row["diaryImg"].ToString();
				}
				if(row["typeContent"]!=null)
				{
					model.typeContent=row["typeContent"].ToString();
				}
				if(row["typeDesc"]!=null)
				{
					model.typeDesc=row["typeDesc"].ToString();
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
			strSql.Append("select id,typeName,parentId,oneId,oneName,twoId,twoName,threeId,threeName,fourId,fourName,imgUrl,diaryImg,typeContent,typeDesc,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" id,typeName,parentId,oneId,oneName,twoId,twoName,threeId,threeName,fourId,fourName,imgUrl,diaryImg,typeContent,typeDesc,status,remark,addTime,addUser,infoType ");
			strSql.Append(" FROM ProductType ");
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
			strSql.Append("select count(1) FROM ProductType ");
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
			strSql.Append(")AS Row, T.*  from ProductType T ");
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
			parameters[0].Value = "ProductType";
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

