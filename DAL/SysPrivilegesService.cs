using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
namespace DAL
{
	/// <summary>
	/// 数据访问类SysPrivilegesService。
	/// </summary>
	public class SysPrivilegesService
	{
		public SysPrivilegesService()
		{}
		#region  成员方法
        /// <summary>
        /// 获取子权限信息总Quantity
        /// </summary>
        /// <param name="levelNo"></param>
        /// <returns></returns>
        public static int GetSonCount(int roleId, int departId)
        {
            string sql = "select count(levelNo) from SysPrivileges where roleId = " + roleId + " and departmentId = " + departId + " and parentLevelNo <> 0";
            object obj = DBHelperSQL.GetSingle(sql);
            return Convert.ToInt32(obj);
        }


        /// <summary>
        /// 获取子权限信息
        /// </summary>
        /// <param name="levelNo"></param>
        /// <returns></returns>
        public static DataSet GetSonInfo(int roleId,int departId,int levelNo) 
        {
            string sql = "select levelNo from SysPrivileges where roleId = " + roleId + " and departmentId = " + departId + " and parentLevelNo = " + levelNo;
            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// 根据角色id和部门id以及起始LevelNo获取左侧权限信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static DataSet GetLeftInfo(int roleId, int departId,int startLevelNo,int endLevelNo)
        {
            string sql = "select * from SysPrivileges where roleId = " + roleId + " and departmentId = " + departId + " and levelNo between " + startLevelNo + " and " + endLevelNo;
            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// 根据角色id和部门id获取权限信息（头部的）
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="departId"></param>
        /// <returns></returns>
        public static DataSet GetLevelInfo(int roleId,int departId)
        {
            string sql = "select * from SysPrivileges where roleId = " + roleId + " and departmentId = " + departId + " and levelNo < 90 order by levelNo asc";
            return DBHelperSQL.Query(sql);
        }

        /// <summary>
        /// 根据角色id,部门id,权限编号判断是否有次权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="departId"></param>
        /// <param name="levelNo"></param>
        /// <returns></returns>
        public static bool Exists(int roleId,int departId,int levelNo)
        {
            string sql = "select id from SysPrivileges where roleId = " + roleId + " and departmentId = " + departId + " and levelNo = " + levelNo;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null && obj.ToString() != "")
            {
                return true;
            }
            return false;
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SysPrivileges");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(SysPrivileges model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SysPrivileges(");
			strSql.Append("roleId,departmentId,levelNo,parentLevelNo)");
			strSql.Append(" values (");
			strSql.Append("@roleId,@departmentId,@levelNo,@parentLevelNo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@departmentId", SqlDbType.Int,4),
					new SqlParameter("@levelNo", SqlDbType.Int,4),
					new SqlParameter("@parentLevelNo", SqlDbType.Int,4)};
			parameters[0].Value = model.roleId;
			parameters[1].Value = model.departmentId;
			parameters[2].Value = model.levelNo;
			parameters[3].Value = model.parentLevelNo;

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
		public void Update(SysPrivileges model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SysPrivileges set ");
			strSql.Append("roleId=@roleId,");
			strSql.Append("departmentId=@departmentId,");
			strSql.Append("levelNo=@levelNo,");
			strSql.Append("parentLevelNo=@parentLevelNo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@roleId", SqlDbType.Int,4),
					new SqlParameter("@departmentId", SqlDbType.Int,4),
					new SqlParameter("@levelNo", SqlDbType.Int,4),
					new SqlParameter("@parentLevelNo", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.roleId;
			parameters[2].Value = model.departmentId;
			parameters[3].Value = model.levelNo;
			parameters[4].Value = model.parentLevelNo;

			DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SysPrivileges ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SysPrivileges GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,roleId,departmentId,levelNo,parentLevelNo from SysPrivileges ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			SysPrivileges model=new SysPrivileges();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["roleId"].ToString()!="")
				{
					model.roleId=int.Parse(ds.Tables[0].Rows[0]["roleId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["departmentId"].ToString()!="")
				{
					model.departmentId=int.Parse(ds.Tables[0].Rows[0]["departmentId"].ToString());
				}
				model.levelNo=int.Parse(ds.Tables[0].Rows[0]["levelNo"].ToString());
				model.parentLevelNo=int.Parse(ds.Tables[0].Rows[0]["parentLevelNo"].ToString());
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
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,roleId,departmentId,levelNo,parentLevelNo ");
			strSql.Append(" FROM SysPrivileges ");
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
			strSql.Append(" id,roleId,departmentId,levelNo,parentLevelNo ");
			strSql.Append(" FROM SysPrivileges ");
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
			parameters[0].Value = "SysPrivileges";
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

