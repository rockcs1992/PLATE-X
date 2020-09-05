using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 数据访问类:QuestionInfoService
	/// </summary>
	public partial class QuestionInfoService
	{
		public QuestionInfoService()
		{}
		#region  BasicMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.QuestionInfo GetImgTjModel(int num)
        {
            StringBuilder strSql = new StringBuilder();
            if (num == 1)
            {
                strSql.Append("select  top 1 * from QuestionInfo ");
                strSql.Append(" where status in(1,3) and otherTypeId = 1 and questionRemark <> '' order by id desc");
            }
            else if(num == 2)
            {
                strSql.Append("select  top 1 * from QuestionInfo ");
                strSql.Append(" where status in(1,3) and infoTypeId = 1 and questionRemark <> '' order by id desc");
            }
            else if (num == 3)
            {
                strSql.Append("select  top 1 * from QuestionInfo ");
                strSql.Append(" where status in(1,3) and remark = '1' and questionRemark <> '' order by id desc");
            }else if(num == 4)
            {
                strSql.Append("select  top 1 * from QuestionInfo ");
                strSql.Append(" where status in(1,3) and questionRemark <> '' order by id desc");
            }

            

            Model.QuestionInfo model = new Model.QuestionInfo();
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
        /// 加图推荐
        /// </summary>
        /// <param name="id"></param>
        /// <param name="spic"></param>
        /// <returns></returns>
        public static int UpdateAddImgTj(int id,string spic)
        {
            string sql = "update QuestionInfo set questionRemark = '" + spic + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新问题的回答Quantity
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public static int UpdateAnswerCount(int questionId) 
        {
            string sql = "update QuestionInfo set answerCount = answerCount + 1 where id = " + questionId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 推荐问题设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateTj(int id, int status)
        {
            string sql = "update QuestionInfo set remark = '" + status + "' where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 经典问题设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateOld(int id, int status)
        {
            string sql = "update QuestionInfo set otherTypeId = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 疑难问题设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateDiff(int id,int status) 
        {
            string sql = "update QuestionInfo set infoTypeId = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 科室下的未解决问题Quantity
        /// </summary>
        /// <param name="docDepartId"></param>
        /// <returns></returns>
        public static int GetCountByType(int docDepartId) 
        {
            string sql = "select count(id) from QuestionInfo where status in(1,3) and docDepartId in (select id from DocDepart where id = " + docDepartId + " or infoType = " + docDepartId + ")";
            object obj = DBHelperSQL.GetSingle(sql);
            if(obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }
        /// <summary>
        /// 更新审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int UpdateStatus(int id, int status)
        {
            string sql = "update QuestionInfo set status = " + status + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from QuestionInfo");
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
		public static int Add(Model.QuestionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into QuestionInfo(");
            strSql.Append("docDepartId,illTypeId,infoTypeId,otherTypeId,questionTitle,questionContent,questionDesc,questionRemark,remark,status,addTime,addUser,infoType,answerCount)");
			strSql.Append(" values (");
            strSql.Append("@docDepartId,@illTypeId,@infoTypeId,@otherTypeId,@questionTitle,@questionContent,@questionDesc,@questionRemark,@remark,@status,@addTime,@addUser,@infoType,@answerCount)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@docDepartId", SqlDbType.Int,4),
					new SqlParameter("@illTypeId", SqlDbType.Int,4),
					new SqlParameter("@infoTypeId", SqlDbType.Int,4),
					new SqlParameter("@otherTypeId", SqlDbType.Int,4),
					new SqlParameter("@questionTitle", SqlDbType.VarChar,1000),
					new SqlParameter("@questionContent", SqlDbType.NText),
					new SqlParameter("@questionDesc", SqlDbType.VarChar,150),
					new SqlParameter("@questionRemark", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@addUser", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),new SqlParameter("@answerCount",SqlDbType.Int,4)};
			parameters[0].Value = model.docDepartId;
			parameters[1].Value = model.illTypeId;
			parameters[2].Value = model.infoTypeId;
			parameters[3].Value = model.otherTypeId;
			parameters[4].Value = model.questionTitle;
			parameters[5].Value = model.questionContent;
			parameters[6].Value = model.questionDesc;
			parameters[7].Value = model.questionRemark;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.status;
			parameters[10].Value = model.addTime;
			parameters[11].Value = model.addUser;
			parameters[12].Value = model.infoType;
            parameters[13].Value = model.answerCount;
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
		public static bool Update(Model.QuestionInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update QuestionInfo set ");
			strSql.Append("docDepartId=@docDepartId,");
			strSql.Append("illTypeId=@illTypeId,");
			strSql.Append("infoTypeId=@infoTypeId,");
			strSql.Append("otherTypeId=@otherTypeId,");
			strSql.Append("questionTitle=@questionTitle,");
			strSql.Append("questionContent=@questionContent,");
			strSql.Append("questionDesc=@questionDesc,");
			strSql.Append("questionRemark=@questionRemark,");
			strSql.Append("remark=@remark,");
			strSql.Append("status=@status,");			
			strSql.Append("infoType=@infoType");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@docDepartId", SqlDbType.Int,4),
					new SqlParameter("@illTypeId", SqlDbType.Int,4),
					new SqlParameter("@infoTypeId", SqlDbType.Int,4),
					new SqlParameter("@otherTypeId", SqlDbType.Int,4),
					new SqlParameter("@questionTitle", SqlDbType.VarChar,1000),
					new SqlParameter("@questionContent", SqlDbType.NText),
					new SqlParameter("@questionDesc", SqlDbType.VarChar,150),
					new SqlParameter("@questionRemark", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@infoType", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.docDepartId;
			parameters[1].Value = model.illTypeId;
			parameters[2].Value = model.infoTypeId;
			parameters[3].Value = model.otherTypeId;
			parameters[4].Value = model.questionTitle;
			parameters[5].Value = model.questionContent;
			parameters[6].Value = model.questionDesc;
			parameters[7].Value = model.questionRemark;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.status;
			parameters[10].Value = model.infoType;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from QuestionInfo ");
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
			strSql.Append("delete from QuestionInfo ");
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
		public static Model.QuestionInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from QuestionInfo ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.QuestionInfo model=new Model.QuestionInfo();
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
		public static Model.QuestionInfo DataRowToModel(DataRow row)
		{
			Model.QuestionInfo model=new Model.QuestionInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["docDepartId"]!=null && row["docDepartId"].ToString()!="")
				{
					model.docDepartId=int.Parse(row["docDepartId"].ToString());
				}
				if(row["illTypeId"]!=null && row["illTypeId"].ToString()!="")
				{
					model.illTypeId=int.Parse(row["illTypeId"].ToString());
				}
				if(row["infoTypeId"]!=null && row["infoTypeId"].ToString()!="")
				{
					model.infoTypeId=int.Parse(row["infoTypeId"].ToString());
				}
				if(row["otherTypeId"]!=null && row["otherTypeId"].ToString()!="")
				{
					model.otherTypeId=int.Parse(row["otherTypeId"].ToString());
				}
				if(row["questionTitle"]!=null)
				{
					model.questionTitle=row["questionTitle"].ToString();
				}
				if(row["questionContent"]!=null)
				{
					model.questionContent=row["questionContent"].ToString();
				}
				if(row["questionDesc"]!=null)
				{
					model.questionDesc=row["questionDesc"].ToString();
				}
				if(row["questionRemark"]!=null)
				{
					model.questionRemark=row["questionRemark"].ToString();
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
                if (row["answerCount"] != null && row["answerCount"].ToString() != "")
				{
                    model.answerCount = int.Parse(row["answerCount"].ToString());
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
			strSql.Append("select * ");
			strSql.Append(" FROM QuestionInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" * ");
			strSql.Append(" FROM QuestionInfo ");
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
			strSql.Append("select count(1) FROM QuestionInfo ");
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
			strSql.Append(")AS Row, T.*  from QuestionInfo T ");
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
			parameters[0].Value = "QuestionInfo";
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

