using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Collections.Generic;

namespace DAL
{
	/// <summary>
	/// 数据访问类NewsService。
	/// </summary>
	public class NewsService
	{
		public NewsService()
		{}
		#region  成员方法

        /// <summary>
        /// 审核信息更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int UpdateCheckInfo(int id, int num)
        {
            string sql = "update News set areaId = " + num + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 专题页顶部推荐最新
        /// </summary>
        /// <returns></returns>
        public static News GetTopicTjNew()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from News ");
            strSql.Append(" where newsType in(select id from NewsType where parentId = 2) and is_tj = 1 and newImg <> '' and is_hot= 1 order by id desc");
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.pageName = ds.Tables[0].Rows[0]["pageName"].ToString();
                if (ds.Tables[0].Rows[0]["newsType"].ToString() != "")
                {
                    model.newsType = int.Parse(ds.Tables[0].Rows[0]["newsType"].ToString());
                }
                model.newImg = ds.Tables[0].Rows[0]["newImg"].ToString();
                model.newsContent = ds.Tables[0].Rows[0]["newsContent"].ToString();
                model.keyword = ds.Tables[0].Rows[0]["keyword"].ToString();
                model.newsDesc = ds.Tables[0].Rows[0]["newsDesc"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                if (ds.Tables[0].Rows[0]["is_tj"].ToString() != "")
                {
                    model.is_tj = Convert.ToInt32(ds.Tables[0].Rows[0]["is_tj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_hot"].ToString() != "")
                {
                    model.is_hot = Convert.ToInt32(ds.Tables[0].Rows[0]["is_hot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ordernum"].ToString() != "")
                {
                    model.ordernum = int.Parse(ds.Tables[0].Rows[0]["ordernum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_userid"].ToString() != "")
                {
                    model.add_userid = int.Parse(ds.Tables[0].Rows[0]["add_userid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["res_views"].ToString() != "")
                {
                    model.res_views = int.Parse(ds.Tables[0].Rows[0]["res_views"].ToString());
                }
                if (ds.Tables[0].Rows[0]["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
                }
                model.sid = ds.Tables[0].Rows[0]["sid"].ToString();
                if (ds.Tables[0].Rows[0]["releaseTime"].ToString() != "")
                {
                    model.releaseTime = DateTime.Parse(ds.Tables[0].Rows[0]["releaseTime"].ToString());
                }
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 首页带图
        /// </summary>
        /// <returns></returns>
        public static News GetModel_Index(int newsType) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from News ");
            strSql.Append(" where newsType = " + newsType + " and is_hot = 1 and is_tj = 1 order by id desc");
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.pageName = ds.Tables[0].Rows[0]["pageName"].ToString();
                if (ds.Tables[0].Rows[0]["newsType"].ToString() != "")
                {
                    model.newsType = int.Parse(ds.Tables[0].Rows[0]["newsType"].ToString());
                }
                model.newImg = ds.Tables[0].Rows[0]["newImg"].ToString();
                model.newsContent = ds.Tables[0].Rows[0]["newsContent"].ToString();
                model.keyword = ds.Tables[0].Rows[0]["keyword"].ToString();
                model.newsDesc = ds.Tables[0].Rows[0]["newsDesc"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                if (ds.Tables[0].Rows[0]["is_tj"].ToString() != "")
                {
                    model.is_tj = Convert.ToInt32(ds.Tables[0].Rows[0]["is_tj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_hot"].ToString() != "")
                {
                    model.is_hot = Convert.ToInt32(ds.Tables[0].Rows[0]["is_hot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ordernum"].ToString() != "")
                {
                    model.ordernum = int.Parse(ds.Tables[0].Rows[0]["ordernum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_userid"].ToString() != "")
                {
                    model.add_userid = int.Parse(ds.Tables[0].Rows[0]["add_userid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["res_views"].ToString() != "")
                {
                    model.res_views = int.Parse(ds.Tables[0].Rows[0]["res_views"].ToString());
                }
                if (ds.Tables[0].Rows[0]["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
                }
                model.sid = ds.Tables[0].Rows[0]["sid"].ToString();
                if (ds.Tables[0].Rows[0]["releaseTime"].ToString() != "")
                {
                    model.releaseTime = DateTime.Parse(ds.Tables[0].Rows[0]["releaseTime"].ToString());
                }
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        public static News GetModelTop()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from News ");
            strSql.Append(" where is_hot = 1 order by id desc");
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.pageName = ds.Tables[0].Rows[0]["pageName"].ToString();
                if (ds.Tables[0].Rows[0]["newsType"].ToString() != "")
                {
                    model.newsType = int.Parse(ds.Tables[0].Rows[0]["newsType"].ToString());
                }
                model.newImg = ds.Tables[0].Rows[0]["newImg"].ToString();
                model.newsContent = ds.Tables[0].Rows[0]["newsContent"].ToString();
                model.keyword = ds.Tables[0].Rows[0]["keyword"].ToString();
                model.newsDesc = ds.Tables[0].Rows[0]["newsDesc"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                if (ds.Tables[0].Rows[0]["is_tj"].ToString() != "")
                {
                    model.is_tj = Convert.ToInt32(ds.Tables[0].Rows[0]["is_tj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_hot"].ToString() != "")
                {
                    model.is_hot = Convert.ToInt32(ds.Tables[0].Rows[0]["is_hot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ordernum"].ToString() != "")
                {
                    model.ordernum = int.Parse(ds.Tables[0].Rows[0]["ordernum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_userid"].ToString() != "")
                {
                    model.add_userid = int.Parse(ds.Tables[0].Rows[0]["add_userid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["res_views"].ToString() != "")
                {
                    model.res_views = int.Parse(ds.Tables[0].Rows[0]["res_views"].ToString());
                }
                if (ds.Tables[0].Rows[0]["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
                }
                model.sid = ds.Tables[0].Rows[0]["sid"].ToString();
                if (ds.Tables[0].Rows[0]["releaseTime"].ToString() != "")
                {
                    model.releaseTime = DateTime.Parse(ds.Tables[0].Rows[0]["releaseTime"].ToString());
                }
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 资讯置顶
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int UpdateTop(int id, int num)
        {
            string sql = "update News set is_hot = " + num + " where id = " + id;         
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 推荐信息更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int UpdateTj(int id, int num)
        {
            string sql = "update News set is_tj = " + num + " where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 首页常见问答    得到一个对象实体
        /// </summary>
        public static Model.News GetModel(int id,int typeId)
        {
            string sql = "";
            if (typeId == 1)     //图片问答
            {
                if (id == 1)      //第一条
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 order by releaseTime desc";
                }
                else if (id == 2)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 and id not in (select top 1 id from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 order by releaseTime desc) order by releaseTime desc";
                }
                else if (id == 8)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 and id not in (select top 2 id from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 order by releaseTime desc) order by releaseTime desc";
                }
                else if (id == 9)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 and id not in (select top 2 id from news where newsType = 4 and newImg <> '' and is_tj = 1 and is_hot = 1 order by releaseTime desc) order by releaseTime desc";
                }
            }
            else
            { 
                if(id == 3)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg = '' order by id desc";
                }
                else if (id == 4)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg = '' and id not in (select top 1 id from news where newsType = 4 and newImg = '' order by id desc) order by id desc";
                }
                else if (id == 5)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg = '' and id not in (select top 2 id from news where newsType = 4 and newImg = '' order by id desc) order by id desc";
                }
                else if (id == 6)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg = '' and id not in (select top 3 id from news where newsType = 4 and newImg = '' order by id desc) order by id desc";
                }
                else if (id == 7)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg = '' and id not in (select top 4 id from news where newsType = 4 and newImg = '' order by id desc) order by id desc";
                }
                else if (id == 10)
                {
                    sql = "select top 1 id,title,linkurl,newImg,pageName from news where newsType = 4 and newImg = '' and id not in (select top 5 id from news where newsType = 4 and newImg = '' order by id desc) order by id desc";
                }
            }
            DataSet ds = DBHelperSQL.Query(sql);
            Model.News model = new Model.News();
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.pageName = ds.Tables[0].Rows[0]["pageName"].ToString();
                
                model.newImg = ds.Tables[0].Rows[0]["newImg"].ToString();
                
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得首页社保知识数据列表
        /// </summary>
        public static List<News> GetListItemWenDa()
        {
            List<News> list = new List<News>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 6 title,linkurl FROM News where newsType = 5 order by id desc ");
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                News model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new News();
                    model.title = ds.Tables[0].Rows[i]["title"].ToString();
                    model.linkurl = ds.Tables[0].Rows[i]["linkurl"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 专题对象列表
        /// </summary>
        /// <returns></returns>
        public static List<News> GetZhuanTiInfo() 
        {
            List<News> list = new List<News>();
            string sql = "select title,pageName,newImg,linkurl from News where (newsType = 3 or newsType in (select id from NewsType where parentId = 3)) and newImg <> '' order by id desc";
            DataSet ds = DBHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                News model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    model = new News();
                    model.title = ds.Tables[0].Rows[i]["title"].ToString();
                    model.newImg = ds.Tables[0].Rows[i]["newImg"].ToString();
                    model.linkurl = ds.Tables[0].Rows[i]["linkurl"].ToString();
                    model.pageName = ds.Tables[0].Rows[i]["pageName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 得到一个对象实体,资讯详细页下一篇
        /// </summary>
        public static Model.News GetNextModel(News item)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 title,linkurl from News ");
            strSql.Append(" where id>@id and newsType=@newsType order by id asc");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),new SqlParameter("@newsType", SqlDbType.Int,4)};      
            parameters[0].Value = item.id;
            parameters[1].Value = item.newsType;
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 得到一个对象实体,资讯详细页上一篇
        /// </summary>
        public static Model.News GetLastModel(News item)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 title,linkurl from News ");
            strSql.Append(" where id<@id and newsType=@newsType order by id desc");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),new SqlParameter("@newsType", SqlDbType.Int,4)};
            parameters[0].Value = item.id;
            parameters[1].Value = item.newsType;
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.title = ds.Tables[0].Rows[0]["title"].ToString();                
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 获得资讯列表页最新专题数据列表
        /// </summary>
        public static News GetNewZhuanTi()
        {        
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title,newImg,linkurl FROM News where (newsType = 3 or newsType in (select id from newsType where parentId = 3)) and newImg <> '' order by id desc ");
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                News model = new News();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.newImg = ds.Tables[0].Rows[0]["newImg"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                return model;
            }

            return null;
        }
        /// <summary>
        /// 获得资讯列表页热门数据列表
        /// </summary>
        public static List<News> GetHotListItem()
        {
            List<News> list = new List<News>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 10 title,linkurl FROM News where newsType <> 22 and ordernum = 1 order by id desc ");
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                News model = null;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model = new News();
                    model.title = ds.Tables[0].Rows[i]["title"].ToString();
                    model.linkurl = ds.Tables[0].Rows[i]["linkurl"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        /// <summary>
        /// 获得首页社保知识数据列表
        /// </summary>
        public static List<News> GetListItem()
        {
            List<News> list = new List<News>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 9 title,linkurl FROM News where newsType not in(10,4,22) order by id desc ");
           DataSet ds = DBHelperSQL.Query(strSql.ToString());
           if (ds.Tables[0].Rows.Count > 0)
           {
               News model = null;
               for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
               {
                   model = new News();
                   model.title = ds.Tables[0].Rows[i]["title"].ToString();
                   model.linkurl = ds.Tables[0].Rows[i]["linkurl"].ToString();
                   list.Add(model);
               }
           }
           return list;
        }

        /// <summary>
        /// 资讯热点设置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UpdateOrderNum(int id)
        {
            string sql = "update News set ordernum = 1 where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.News GetModel_ZhuanTi()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from News ");
            strSql.Append(" where newImg <> '' and newsType = 3 order by id desc");
            Model.News model = new Model.News();
            DataSet ds = DBHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.pageName = ds.Tables[0].Rows[0]["pageName"].ToString();
                if (ds.Tables[0].Rows[0]["newsType"].ToString() != "")
                {
                    model.newsType = int.Parse(ds.Tables[0].Rows[0]["newsType"].ToString());
                }
                model.newImg = ds.Tables[0].Rows[0]["newImg"].ToString();
                model.newsContent = ds.Tables[0].Rows[0]["newsContent"].ToString();
                model.keyword = ds.Tables[0].Rows[0]["keyword"].ToString();
                model.newsDesc = ds.Tables[0].Rows[0]["newsDesc"].ToString();
                model.linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
                if (ds.Tables[0].Rows[0]["is_tj"].ToString() != "")
                {
                    model.is_tj = Convert.ToInt32(ds.Tables[0].Rows[0]["is_tj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_hot"].ToString() != "")
                {
                    model.is_hot = Convert.ToInt32(ds.Tables[0].Rows[0]["is_hot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ordernum"].ToString() != "")
                {
                    model.ordernum = int.Parse(ds.Tables[0].Rows[0]["ordernum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addTime"].ToString() != "")
                {
                    model.addTime = DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_userid"].ToString() != "")
                {
                    model.add_userid = int.Parse(ds.Tables[0].Rows[0]["add_userid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["res_views"].ToString() != "")
                {
                    model.res_views = int.Parse(ds.Tables[0].Rows[0]["res_views"].ToString());
                }
                if (ds.Tables[0].Rows[0]["areaid"].ToString() != "")
                {
                    model.areaid = int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
                }
                model.sid = ds.Tables[0].Rows[0]["sid"].ToString();
                if (ds.Tables[0].Rows[0]["releaseTime"].ToString() != "")
                {
                    model.releaseTime = DateTime.Parse(ds.Tables[0].Rows[0]["releaseTime"].ToString());
                }
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
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
        public static DataSet GetHotList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select newsType,sid");
            strSql.Append(" FROM News where newsType <> 22");
            return DBHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 屏蔽一条数据
        /// </summary>
        public static int UpdateStop(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update News set orderNum = 5");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from News");
			strSql.Append(" where id=@id and newsType <> 22");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Model.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into News(");
			strSql.Append("title,pageName,newsType,newImg,newsContent,keyword,newsDesc,linkurl,is_tj,is_hot,ordernum,addTime,add_userid,res_views,areaid,sid,releaseTime,author)");
			strSql.Append(" values (");
			strSql.Append("@title,@pageName,@newsType,@newImg,@newsContent,@keyword,@newsDesc,@linkurl,@is_tj,@is_hot,@ordernum,@addTime,@add_userid,@res_views,@areaid,@sid,@releaseTime,@author)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@pageName", SqlDbType.NText),
					new SqlParameter("@newsType", SqlDbType.Int,4),
					new SqlParameter("@newImg", SqlDbType.VarChar,500),
					new SqlParameter("@newsContent", SqlDbType.NText),
					new SqlParameter("@keyword", SqlDbType.VarChar,250),
					new SqlParameter("@newsDesc", SqlDbType.NText),
					new SqlParameter("@linkurl", SqlDbType.VarChar,250),
					new SqlParameter("@is_tj", SqlDbType.Int,1),
					new SqlParameter("@is_hot", SqlDbType.Int,4),
					new SqlParameter("@ordernum", SqlDbType.Int,4),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@add_userid", SqlDbType.Int,4),
					new SqlParameter("@res_views", SqlDbType.Int,4),
					new SqlParameter("@areaid", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.VarChar,500),
					new SqlParameter("@releaseTime", SqlDbType.DateTime),
					new SqlParameter("@author", SqlDbType.VarChar,50)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.pageName;
			parameters[2].Value = model.newsType;
			parameters[3].Value = model.newImg;
			parameters[4].Value = model.newsContent;
			parameters[5].Value = model.keyword;
			parameters[6].Value = model.newsDesc;
			parameters[7].Value = model.linkurl;
			parameters[8].Value = model.is_tj;
			parameters[9].Value = model.is_hot;
			parameters[10].Value = model.ordernum;
			parameters[11].Value = model.addTime;
			parameters[12].Value = model.add_userid;
			parameters[13].Value = model.res_views;
			parameters[14].Value = model.areaid;
			parameters[15].Value = model.sid;
			parameters[16].Value = model.releaseTime;
			parameters[17].Value = model.author;

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
        public static int UpdateViews(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update News set ");
            strSql.Append("res_views=res_views + 1");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
					};
            parameters[0].Value = id;
            return DBHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static int Update(Model.News model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update News set ");
			strSql.Append("title=@title,");
			strSql.Append("newsType=@newsType,");
			strSql.Append("newImg=@newImg,");
			strSql.Append("newsContent=@newsContent,");

			strSql.Append("keyword=@keyword,");
			strSql.Append("newsDesc=@newsDesc,");            
            strSql.Append("pageName=@pageName,");
            strSql.Append("sid=@sid,author=@author");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@newsType", SqlDbType.Int,4),
					new SqlParameter("@newImg", SqlDbType.VarChar,500),
					new SqlParameter("@newsContent", SqlDbType.NText),

					new SqlParameter("@keyword", SqlDbType.VarChar,250),
					new SqlParameter("@newsDesc", SqlDbType.NText),
                    new SqlParameter("@pageName", SqlDbType.NText),
                    new SqlParameter("@sid", SqlDbType.VarChar,250),new SqlParameter("@author", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.title;
			parameters[2].Value = model.newsType;
			parameters[3].Value = model.newImg;
			parameters[4].Value = model.newsContent;

			parameters[5].Value = model.keyword;
			parameters[6].Value = model.newsDesc;
            parameters[7].Value = model.pageName;
            parameters[8].Value = model.sid;
            parameters[9].Value = model.author;
			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// Delete一条数据
		/// </summary>
		public static int Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from News ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DBHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Model.News GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,pageName,newsType,newImg,newsContent,keyword,newsDesc,linkurl,is_tj,is_hot,ordernum,addTime,add_userid,res_views,areaid,sid,releaseTime,author from News ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Model.News model=new Model.News();
			DataSet ds=DBHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.title=ds.Tables[0].Rows[0]["title"].ToString();
				model.pageName=ds.Tables[0].Rows[0]["pageName"].ToString();
				if(ds.Tables[0].Rows[0]["newsType"].ToString()!="")
				{
					model.newsType=int.Parse(ds.Tables[0].Rows[0]["newsType"].ToString());
				}
				model.newImg=ds.Tables[0].Rows[0]["newImg"].ToString();
				model.newsContent=ds.Tables[0].Rows[0]["newsContent"].ToString();
				model.keyword=ds.Tables[0].Rows[0]["keyword"].ToString();
				model.newsDesc=ds.Tables[0].Rows[0]["newsDesc"].ToString();
				model.linkurl=ds.Tables[0].Rows[0]["linkurl"].ToString();
				if(ds.Tables[0].Rows[0]["is_tj"].ToString()!="")
				{
                    model.is_tj = Convert.ToInt32(ds.Tables[0].Rows[0]["is_tj"].ToString());					
				}
				if(ds.Tables[0].Rows[0]["is_hot"].ToString()!="")
				{
                    model.is_hot = Convert.ToInt32(ds.Tables[0].Rows[0]["is_hot"].ToString());	
				}
				if(ds.Tables[0].Rows[0]["ordernum"].ToString()!="")
				{
					model.ordernum=int.Parse(ds.Tables[0].Rows[0]["ordernum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(ds.Tables[0].Rows[0]["addTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["add_userid"].ToString()!="")
				{
					model.add_userid=int.Parse(ds.Tables[0].Rows[0]["add_userid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["res_views"].ToString()!="")
				{
					model.res_views=int.Parse(ds.Tables[0].Rows[0]["res_views"].ToString());
				}
				if(ds.Tables[0].Rows[0]["areaid"].ToString()!="")
				{
					model.areaid=int.Parse(ds.Tables[0].Rows[0]["areaid"].ToString());
				}
				model.sid=ds.Tables[0].Rows[0]["sid"].ToString();
				if(ds.Tables[0].Rows[0]["releaseTime"].ToString()!="")
				{
					model.releaseTime=DateTime.Parse(ds.Tables[0].Rows[0]["releaseTime"].ToString());
				}
				model.author=ds.Tables[0].Rows[0]["author"].ToString();
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
        public static DataSet GetListResource(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,pageName,newsType,newImg,newsContent,keyword,newsDesc,linkurl,is_tj,is_hot,ordernum,addTime,add_userid,res_views,areaid,sid,releaseTime,author ");
            strSql.Append(" FROM News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and newsType <> 22 order by addTime desc");
            }
            return DBHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,pageName,newsType,newImg,newsContent,keyword,newsDesc,linkurl,is_tj,is_hot,ordernum,addTime,add_userid,res_views,areaid,sid,releaseTime,author ");
			strSql.Append(" FROM News ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere + " and newsType <> 22");
			}
			return DBHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static DataSet GetListASC(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,pageName,newsType,newImg,newsContent,keyword,newsDesc,linkurl,is_tj,is_hot,ordernum,addTime,add_userid,res_views,areaid,sid,releaseTime,author ");
            strSql.Append(" FROM News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " and newsType <> 22");
            }
            strSql.Append(" order by " + filedOrder + " asc,id asc");
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
			strSql.Append(" id,title,pageName,newsType,newImg,newsContent,keyword,newsDesc,linkurl,is_tj,is_hot,ordernum,addTime,add_userid,res_views,areaid,sid,releaseTime,author ");
			strSql.Append(" FROM News ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder + " desc");
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
			parameters[0].Value = "News";
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

