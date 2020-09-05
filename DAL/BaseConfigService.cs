using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类BaseConfigService。
	/// </summary>
	public class BaseConfigService
	{
		public BaseConfigService()
		{}
		#region  成员方法
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SetValue_Name(int id, string value)
        {
            string sql = "update BaseConfig set proName = '" + value + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetById_Name(int id)
        {
            string sql = "select proName from BaseConfig where id = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 首页套餐I am a排名图片
        /// </summary>
        /// <param name="orderNum"></param>
        /// <returns></returns>
        public static string GetImg(int orderNum) 
        {
            string sql = "select remark from BaseConfig where parentId = " + orderNum;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != DBNull.Value && obj != null)
            {
                return obj.ToString();
            }
            return "in_pbg4.png";
        }

        /// <summary>
        /// 付费套餐排序更新
        /// </summary>
        /// <param name="payType"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static int UpdateOrder(string payType,string order,string url) 
        {
            string sql = "update BaseConfig set parentId = " + order + ",proValue = '" + url + "' where proType = " + payType;
            return DBHelperSQL.ExecuteSql(sql);
        }


        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SetValue(int id, string value)
        {
            string sql = "update BaseConfig set proValue = '" + value + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetById(int id)
        {
            string sql = "select proValue from BaseConfig where id = " + id;
            object obj = DBHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public static bool Exists(string parentId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseConfig");
            strSql.Append(" where parentId=@parentId ");
			SqlParameter[] parameters = {
					new SqlParameter("@parentId", SqlDbType.VarChar,50)};
            parameters[0].Value = parentId;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.BaseConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseConfig(");
			strSql.Append("proType,proName,proValue,parentId,status,remark)");
			strSql.Append(" values (");
			strSql.Append("@proType,@proName,@proValue,@parentId,@status,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@proType", SqlDbType.Int,4),
					new SqlParameter("@proName", SqlDbType.VarChar,50),
					new SqlParameter("@proValue", SqlDbType.NText),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
			parameters[0].Value = model.proType;
			parameters[1].Value = model.proName;
			parameters[2].Value = model.proValue;
			parameters[3].Value = model.parentId;
			parameters[4].Value = model.status;
			parameters[5].Value = model.remark;

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
		public void Update(Model.BaseConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseConfig set ");
			strSql.Append("proType=@proType,");
			strSql.Append("proName=@proName,");
			strSql.Append("proValue=@proValue,");
			strSql.Append("parentId=@parentId,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@proType", SqlDbType.Int,4),
					new SqlParameter("@proName", SqlDbType.VarChar,50),
					new SqlParameter("@proValue", SqlDbType.NText),
					new SqlParameter("@parentId", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.proType;
			parameters[2].Value = model.proName;
			parameters[3].Value = model.proValue;
			parameters[4].Value = model.parentId;
			parameters[5].Value = model.status;
			parameters[6].Value = model.remark;

			DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseConfig ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.BaseConfig GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,proType,proName,proValue,parentId,status,remark from BaseConfig ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.BaseConfig model=new Model.BaseConfig();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["proType"].ToString()!="")
				{
					model.proType=int.Parse(ds.Tables[0].Rows[0]["proType"].ToString());
				}
				model.proName=ds.Tables[0].Rows[0]["proName"].ToString();
				model.proValue=ds.Tables[0].Rows[0]["proValue"].ToString();
				if(ds.Tables[0].Rows[0]["parentId"].ToString()!="")
				{
					model.parentId=int.Parse(ds.Tables[0].Rows[0]["parentId"].ToString());
				}
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
			strSql.Append("select id,proType,proName,proValue,parentId,status,remark ");
			strSql.Append(" FROM BaseConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by parentId asc");
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
			strSql.Append(" id,proType,proName,proValue,parentId,status,remark ");
			strSql.Append(" FROM BaseConfig ");
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
			parameters[0].Value = "BaseConfig";
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

