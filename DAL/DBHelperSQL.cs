using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public abstract class DBHelperSQL
    {
        //数据库连接字符串(web.config来配置)
        //<add key="ConnectionString" value="server=127.0.0.1;database=DATABASE;uid=sa;pwd=" />		
        protected static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        private static SqlConnection con = new SqlConnection(connectionString);
        public DBHelperSQL()
        {
        }

        #region 公用方法
        /// <summary>
        /// 返回当前最大ID数+1
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        /// <summary>
        /// 返回当前最大ID
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetMaxID(string FieldName, string TableName, string current)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        connection.Dispose();
                        throw new Exception(E.Message);
                    }

                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }

            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    cmd.Dispose();
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(E.Message);
                }

            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段I am a为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    cmd.Dispose();
                    connection.Close();
                    throw new Exception(E.Message);
                }

            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        connection.Dispose();

                        throw new Exception(e.Message);
                    }

                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }


        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }


        }

        #endregion

        #region 存储过程Action

        /// <summary>
        /// 执行存储过程returnReader
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedureRV(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程返回dataset
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedureUp(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        /// <summary>
        /// 执行存储过程返回dataset
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

        #region 连接数据源con.open()

        /// <summary>
        /// 打开数据库连接.
        /// </summary>
        private static void Open()
        {
            // 打开数据库连接
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    ///打开数据库连接
                    con.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                    //SystemError.SystemLog(ex.Message);
                }
                finally
                {
                    ///关闭已经打开的数据库连接				
                }
            }
        }
        #endregion


        #region 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void Close()
        {
            ///判断连接是否已经创建
            if (con != null)
            {
                ///判断连接的状态是否打开
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 确认连接是否已经关闭
            if (con != null)
            {
                con.Dispose();
                con = null;
            }
        }
        #endregion


        #region 执行存储过程,存储过程Item Name,返回存储过程返回值(intI am a)
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的Item Name</param>
        /// <returns>返回存储过程返回值</returns>
        public static int RunProc(string procName)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                //SystemError.SystemLog(ex.Message);
            }
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        #endregion

        #region 执行存储过程,存储过程Item Name,存储过程所需要参数,返回存储过程返回值(intI am a)
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程Item Name</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回存储过程返回值</returns>
        public static int RunProc(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                //SystemError.SystemLog(ex.Message);
            }
            Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        #endregion

        #region 执行存储过程,存储过程Item Name,存储过程所需参数
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程Item Name</param>
        /// <param name="prams">存储过程所需参数</param>		
        public static void RunProcEdit(string procName, SqlParameter[] prams)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
                //SystemError.SystemLog(ex.Message);
            }
            Close();

        }
        #endregion

        #region 执行存储过程,存储过程Item Name,返回存储过程返回值(DataReaderI am a)
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的Item Name</param>
        /// <param name="dataReader">返回存储过程返回值</param>
        public static void RunProc(string procName, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, null);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 执行存储过程,存储过程的Item Name,存储过程所需参数,返回存储过程返回值(DataReaderI am a)
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的Item Name</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <param name="dataReader">存储过程所需参数</param>
        public static void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            SqlCommand cmd = CreateCommand(procName, prams);
            dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        #endregion

        #region 创建一个SqlCommand对象以此来执行存储过程
        /// <summary>
        /// 创建一个SqlCommand对象以此来执行存储过程
        /// </summary>
        /// <param name="procName">存储过程的Item Name</param>
        /// <param name="prams">存储过程所需参数</param>
        /// <returns>返回SqlCommand对象</returns>
        private static SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            // 确认打开连接
            Open();

            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            // 依次把参数传入存储过程
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            // 加入返回参数
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            ///返回创建的SqlCommand对象
            return cmd;
        }
        #endregion

        #region 生成存储过程参数
        /// <summary>
        /// 生成存储过程参数
        /// </summary>
        /// <param name="ParamName">存储过程Item Name</param>
        /// <param name="DbType">参数I am a</param>
        /// <param name="Size">参数大小</param>
        /// <param name="Direction">参数方向</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter CreateParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            ///当参数大小为0时，不使用该参数大小值
            if (Size > 0)
            {
                param = new SqlParameter(ParamName, DbType, Size);
            }
            else
            {
                ///当参数大小为0时，不使用该参数大小值
                param = new SqlParameter(ParamName, DbType);
            }

            ///创建输出I am a的参数
            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
            {
                param.Value = Value;
            }

            ///返回创建的参数
            return param;
        }
        #endregion

        #region 传入输入参数(CreateInParam)
        /// <summary>
        /// 传入输入参数
        /// </summary>
        /// <param name="ParamName">存储过程Item Name</param>
        /// <param name="DbType">参数I am a</param></param>
        /// <param name="Size">参数大小</param>
        /// <param name="Value">参数值</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter CreateInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }
        #endregion

        #region 传入返回值参数(CreateOutParam)
        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程Item Name</param>
        /// <param name="DbType">参数I am a</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter CreateOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }
        #endregion

        #region 传入返回值参数(CreateReturnParam)
        /// <summary>
        /// 传入返回值参数
        /// </summary>
        /// <param name="ParamName">存储过程Item Name</param>
        /// <param name="DbType">参数I am a</param>
        /// <param name="Size">参数大小</param>
        /// <returns>新的 parameter 对象</returns>
        public static SqlParameter CreateReturnParam(string ParamName, SqlDbType DbType, int Size)
        {
            return CreateParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
        }
        #endregion

        #region 执行一条查询语句,返回一个数据集DataSet
        /// <summary>
        /// 执行一条查询语句,
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>返回的是一个数据集DataSet</returns>
        /// 
        public static DataSet ReturnDataSet(string strSql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter(strSql, connection);
                sqlDA.Fill(dataSet, "objDataSet");
                connection.Close();

                return dataSet;
            }
        }
        #endregion

        #region 执行一条查询语句,返回的是DataReader
        /// <summary>
        /// 执行一条查询语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回的是DataReader</returns>
        /// 
        public static SqlDataReader ReturnDataReader(String strSql)
        {

            //objSqlConn.Open();
            if (con.State == ConnectionState.Closed)
                Open();
            SqlCommand objSqlCmd = new SqlCommand(strSql, con);
            SqlDataReader objDataReader = objSqlCmd.ExecuteReader();


            return objDataReader;
        }
        #endregion


        #region 执行sql语句,修改数据库
        /// <summary>
        /// 修改数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回真和假 true  false</returns>
        /// 
        public static bool EditDatabase(string strSql)
        {
            bool boolState = false;
            if (con.State == ConnectionState.Open)
            {
            }
            else
            {
                Open();
            }
            SqlTransaction objSqlTr = con.BeginTransaction();
            SqlCommand objSqlCmd = new SqlCommand(strSql, con, objSqlTr);
            SqlCommand d = new SqlCommand();
            try
            {
                objSqlCmd.ExecuteNonQuery();
                objSqlTr.Commit();
                boolState = true;
            }

            catch
            {
                objSqlTr.Rollback();
            }
            finally
            {
                objSqlCmd.Dispose();
                con.Close();
            }

            return boolState;
        }
        #endregion

        #region 返回一个整形的结果(单个值ExecuteSqlValuOfInt)
        /// <summary>
        /// 返回一个整形的结果(单个值)
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>返回的是一个整型的数值</returns>

        public static int ExecuteSqlValueOfInt(string strSql)
        {
            //objSqlConn.Open();
            Open();
            SqlCommand objSqlCmd = new SqlCommand(strSql, con);
            try
            {
                object r = objSqlCmd.ExecuteScalar();
                if (Object.Equals(r, null))
                {
                    throw new Exception("value unavailable");
                }
                else
                {
                    return (int)r;
                }
            }
            catch
            {
                return 0;

            }
            finally
            {
                objSqlCmd.Dispose();
                con.Close();
            }
        }
        #endregion

        #region 将DataReader 转为 DataTable
        /// <summary>
        /// 将DataReader 转为 DataTable
        /// </summary>
        /// <param name="DataReader">DataReader</param>
        public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();
            foreach (DataRow myRow in schemaTable.Rows)
            {
                DataColumn myDataColumn = new DataColumn();
                myDataColumn.DataType = myRow.GetType();
                myDataColumn.ColumnName = myRow[0].ToString();
                datatable.Columns.Add(myDataColumn);
            }

            while (dataReader.Read())
            {
                DataRow myDataRow = datatable.NewRow();
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    myDataRow[i] = dataReader[i].ToString();
                }
                datatable.Rows.Add(myDataRow);
                myDataRow = null;
            }
            schemaTable = null;
            dataReader.Close();
            return datatable;
        }

        #endregion


        public static void EditDatabase()
        {
            throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 执行多条SQL语句
        /// </summary>
        /// <param name="strSQLs"></param>
        /// <returns></returns>
        public static int ExecuteSqls(string[] strSQLs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand mycmd = new SqlCommand();
                int j = strSQLs.Length;
                SqlTransaction myTrans = connection.BeginTransaction();//新建一个事务
                try
                {
                    mycmd.Connection = connection;
                    mycmd.Transaction = myTrans;//指定Transaction属性为新建的myTrans
                    foreach (string str in strSQLs)
                    {
                        mycmd.CommandText = str;
                        mycmd.ExecuteNonQuery();//执行数据库的命令
                    }
                    myTrans.Commit();
                    return 1;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                    //证明失败了
                    //throw new Exception(e.Message);
                }
                finally
                {
                    mycmd.Dispose();
                    Close();
                }
            }
        }


        public static int pcusername(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            return cmdresult;
        }


    }
}
