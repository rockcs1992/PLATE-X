using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class SysRoleService
    {
        #region###查询所有的系统角色
        /// <summary>
        /// 更新角色的是否可以更新订单的付款状态权限。
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="pay"></param>
        /// <returns></returns>
        public static int UpdatePay(int roleId,int pay)
        {
            string sql = "update SysRole set isPayOrder = " + pay + " where id = " + roleId;
            return DBHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SysRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id desc");
            return DBHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 查询所有的系统角色
        /// </summary>
        /// <returns></returns>
        public static List<SysRole> GetAllSysRole()
        {
            List<SysRole> list = new List<SysRole>();
            string sql = "SELECT * FROM [dbo].[SysRole] where id <> 1 order by creatingTime desc";
            DataTable dt = DBHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                SysRole sr = new SysRole();
                sr.Id = Convert.ToInt32(dr["id"]);
                sr.RoleName = dr["RoleName"].ToString();
                sr.RoleDesc = dr["RoleDesc"].ToString();
                sr.CreatingTime = Convert.ToDateTime(dr["creatingTime"]);
                sr.DepartmentId = Convert.ToInt32(dr["departmentId"]);
                sr.Status = Convert.ToInt32(dr["Status"]);
                sr.IsPayOrder = Convert.ToInt32(dr["isPayOrder"]);
                list.Add(sr);
            }
            return list;
        }
        #endregion

        #region###添加系统角色
        /// <summary>
        /// 添加系统角色
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static int AddSysRole(SysRole sr)
        {
            string sql = "INSERT INTO [dbo].[SysRole]([roleName],[roleDesc],[creatingTime],[departmentId],[status])VALUES(@roleName,@roleDesc,@creatingTime,@departmentId,@status)";
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@roleName",sr.RoleName),
                new SqlParameter("@roleDesc",sr.RoleDesc),
                new SqlParameter("@creatingTime",sr.CreatingTime),
                new SqlParameter("@departmentId",sr.DepartmentId),
                new SqlParameter("@status",sr.Status)             
                };
            return DBHelperSQL.ExecuteSql(sql, parms);
        }
        #endregion

        #region###修改系统角色
        /// <summary>
        /// 修改系统角色
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static int ModifySysRole(SysRole sr)
        {
            string sql = "UPDATE [dbo].[SysRole]SET [roleName] = @roleName,[roleDesc] = @roleDesc,[creatingTime] = @creatingTime,[departmentId] = @departmentId,[status] = @status WHERE id = @id";
            SqlParameter[] parms = new SqlParameter[] {
                new SqlParameter("@id",sr.Id),
                new SqlParameter("@roleName",sr.RoleName),
                new SqlParameter("@roleDesc",sr.RoleDesc),
                new SqlParameter("@creatingTime",sr.CreatingTime),
                new SqlParameter("@departmentId",sr.DepartmentId),
                new SqlParameter("@status",sr.Status)
                };
            return DBHelperSQL.ExecuteSql(sql, parms);
        }
        #endregion

        #region###根据角色idDelete系统角色
        /// <summary>
        /// 根据角色idDelete系统角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteSysRoleById(int id)
        {
            string sql = "DELETE FROM [dbo].[SysRole] WHERE id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }
        #endregion

        #region###根据角色id查询一条角色信息
        /// <summary>
        /// 根据角色id查询一条角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SysRole GetSysRoleById(int id)
        {
            SysRole sr = null;
            string sql = "SELECT * FROM [dbo].[SysRole] where id = " + id;
            DataTable dt = DBHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                sr = new SysRole();
                sr.Id = Convert.ToInt32(dr["id"]);
                sr.RoleName = dr["RoleName"].ToString();
                sr.RoleDesc = dr["RoleDesc"].ToString();
                sr.CreatingTime = Convert.ToDateTime(dr["creatingTime"]);
                sr.DepartmentId = Convert.ToInt32(dr["departmentId"]);
                sr.Status = Convert.ToInt32(dr["Status"]);
                sr.IsPayOrder = Convert.ToInt32(dr["isPayOrder"]);
            }
            return sr;
        }
        #endregion
    }
}
