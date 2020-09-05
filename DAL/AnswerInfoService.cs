using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:AnswerInfoService
	/// </summary>
	public partial class AnswerInfoService
	{
		public AnswerInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 采用回复信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateUse(int id)
        {
            string sql = "update AnswerInfo set status = 1 where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 根据医生Id采用记录Quantity
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int GetAnswerUserCountByAddUser(int userid)
        {
            string sql = "select count(id) from AnswerInfo where addUser = " + userid + " and status = 1";
            object obj = DBHelperSQL.GetSingle(sql);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 根据医生Id回答记录Quantity
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int GetAnswerCountByAddUser(int userid) 
        {
            string sql = "select count(id) from AnswerInfo where addUser = " + userid;
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        /// <summary>
        /// 根据问题查询回答问题的Quantity
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static int GetAnswerCount(int questionId) 
        {
            string sql = "select count(*) from AnswerInfo where questionId = " + questionId;
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
			strSql.Append("select count(1) from AnswerInfo");
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
		public static int Add(Model.AnswerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AnswerInfo(");
			strSql.Append("questionId,answerContent,answerDesc,remark,status,isGood,isBad,isTj,isHot,isNew,addTime,addUser,infoType)");
			strSql.Append(" values (");
			strSql.Append("@questionId,@answerContent,@answerDesc,@remark,@status,@isGood,@isBad,@isTj,@isHot,@isNew,@addTime,@addUser,@infoType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@questionId", SqlDbType.Int,4),
					new SqlParameter("@answerContent", SqlDbType.NText),
					new SqlParameter("@answerDesc", SqlDbType.VarChar,150),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@isGood", SqlDbType.Int,4),
					new SqlParameter("@isBad", SqlDbType.Int,4),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isNew", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4)};
			parameters[0].Value = model.questionId;
			parameters[1].Value = model.answerContent;
			parameters[2].Value = model.answerDesc;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
			parameters[5].Value = model.isGood;
			parameters[6].Value = model.isBad;
			parameters[7].Value = model.isTj;
			parameters[8].Value = model.isHot;
			parameters[9].Value = model.isNew;
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.AnswerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AnswerInfo set ");
			strSql.Append("questionId=@questionId,");
			strSql.Append("answerContent=@answerContent,");
			strSql.Append("answerDesc=@answerDesc,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");
			strSql.Append("isGood=@isGood,");
			strSql.Append("isBad=@isBad,");
			strSql.Append("isTj=@isTj,");
			strSql.Append("isHot=@isHot,");
			strSql.Append("isNew=@isNew,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("addUser=@addUser,");
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@questionId", SqlDbType.Int,4),
					new SqlParameter("@answerContent", SqlDbType.NText),
					new SqlParameter("@answerDesc", SqlDbType.VarChar,150),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@isGood", SqlDbType.Int,4),
					new SqlParameter("@isBad", SqlDbType.Int,4),
					new SqlParameter("@isTj", SqlDbType.Int,4),
					new SqlParameter("@isHot", SqlDbType.Int,4),
					new SqlParameter("@isNew", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.questionId;
			parameters[1].Value = model.answerContent;
			parameters[2].Value = model.answerDesc;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.status;
			parameters[5].Value = model.isGood;
			parameters[6].Value = model.isBad;
			parameters[7].Value = model.isTj;
			parameters[8].Value = model.isHot;
			parameters[9].Value = model.isNew;
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
		/// Delete一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AnswerInfo ");
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
			strSql.Append("delete from AnswerInfo ");
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
		public static Model.AnswerInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,questionId,answerContent,answerDesc,remark,status,isGood,isBad,isTj,isHot,isNew,addTime,addUser,infoType from AnswerInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.AnswerInfo model=new Model.AnswerInfo();
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
		public static Model.AnswerInfo DataRowToModel(DataRow row)
		{
			Model.AnswerInfo model=new Model.AnswerInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["questionId"]!=null && row["questionId"].ToString()!="")
				{
					model.questionId=int.Parse(row["questionId"].ToString());
				}
				if(row["answerContent"]!=null)
				{
					model.answerContent=row["answerContent"].ToString();
				}
				if(row["answerDesc"]!=null)
				{
					model.answerDesc=row["answerDesc"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["isGood"]!=null && row["isGood"].ToString()!="")
				{
					model.isGood=int.Parse(row["isGood"].ToString());
				}
				if(row["isBad"]!=null && row["isBad"].ToString()!="")
				{
					model.isBad=int.Parse(row["isBad"].ToString());
				}
				if(row["isTj"]!=null && row["isTj"].ToString()!="")
				{
					model.isTj=int.Parse(row["isTj"].ToString());
				}
				if(row["isHot"]!=null && row["isHot"].ToString()!="")
				{
					model.isHot=int.Parse(row["isHot"].ToString());
				}
				if(row["isNew"]!=null && row["isNew"].ToString()!="")
				{
					model.isNew=int.Parse(row["isNew"].ToString());
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
			strSql.Append("select id,questionId,answerContent,answerDesc,remark,status,isGood,isBad,isTj,isHot,isNew,addTime,addUser,infoType ");
			strSql.Append(" FROM AnswerInfo ");
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
			strSql.Append(" id,questionId,answerContent,answerDesc,remark,status,isGood,isBad,isTj,isHot,isNew,addTime,addUser,infoType ");
			strSql.Append(" FROM AnswerInfo ");
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
			strSql.Append("select count(1) FROM AnswerInfo ");
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
			strSql.Append(")AS Row, T.*  from AnswerInfo T ");
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
			parameters[0].Value = "AnswerInfo";
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

