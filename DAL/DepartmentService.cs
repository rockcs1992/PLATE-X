using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class DepartmentService
    {
        #region###查询所有部门
        public static DataSet GetDepartmentInfo() 
        {
            string sql = "select * from Department";
            return DBHelperSQL.Query(sql);
        }
        public static List<Department> GetDepartmentAll()
        {
            List<Department> list = new List<Department>();
            Department d = null;
            string sql = "select * from Department ORDER BY name,created";
            DataTable dt = DBHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                d = new Department();
                d.Id = Convert.ToInt32(dr["id"]);
                d.Name = Convert.ToString(dr["name"]);
                d.Remarks = Convert.ToString(dr["remarks"]);
                d.Created = Convert.ToDateTime(dr["created"]);
                d.Status = Convert.ToInt32(dr["status"]);
                list.Add(d);
            }
            return list;
        
            
        }

        #endregion


        #region###根据ID查询部门
        public static Department GetDepartmentByID(int id) 
        {
            Department d = null;
            string sql = "select * from Department where id =" + id;
            DataTable dt = DBHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                d = new Department();
                d.Id = Convert.ToInt32(dr["id"]);
                d.Name = Convert.ToString(dr["name"]);
                d.Remarks = Convert.ToString(dr["remarks"]);
                d.Created = Convert.ToDateTime(dr["created"]);
                d.Status = Convert.ToInt32(dr["status"]);
            }
            return d;   
        }


        #endregion


        #region###添加新的部门
        public static bool AddDepartment(Department d)
        {
            string sql = "insert into Department(name,remarks,created,status) values(@name,@remarks,@created,@status)";
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("name", d.Name));

            par.Add(new SqlParameter("remarks", d.Remarks));
            par.Add(new SqlParameter("created", d.Created));
            par.Add(new SqlParameter("status", d.Status));
            int res = DBHelperSQL.ExecuteSql(sql, par.ToArray());
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion


        #region###修改
        public static bool ModifyDepartment(Department d) {
            string sql = "Update Department set name=@name,remarks=@remarks,created=@created,status=@status where id=" + d.Id;

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("name", d.Name));

            par.Add(new SqlParameter("remarks", d.Remarks));
            par.Add(new SqlParameter("created", d.Created));
            par.Add(new SqlParameter("status", d.Status));
            int res = DBHelperSQL.ExecuteSql(sql, par.ToArray());
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion


        #region###Delete
        public static int DeleteDepartmentByID(int id)
        {
            string sql = "Delete from Department where id = " + id;
            return DBHelperSQL.ExecuteSql(sql);
        }

        #endregion
    }
}
