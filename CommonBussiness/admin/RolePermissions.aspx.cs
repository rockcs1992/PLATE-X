using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using Model;
using DAL;

namespace CommonBussiness.admin
{
    public partial class rolePermissions : System.Web.UI.Page
    {
        #region###窗体加载事件
        int roleId = CRequest.GetInt("roleId",0);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.hidDepartId.Value = "";
                this.hidRoleId.Value = "";
                this.hidRowsCount.Value = "";
                if (Session["loginUser"] == null)
                {
                    Response.Redirect("/admin/login.aspx");
                    return;
                }
                if(roleId > 0)
                {
                    SysRole role = SysRoleService.GetSysRoleById(roleId);
                    if(role != null)
                    {
                        this.lblRoleName.Text = role.RoleName;
                        this.lblRoleDesc.Text = role.RoleDesc;
                        Department depart = DepartmentService.GetDepartmentByID(role.DepartmentId);
                        this.lblDepartment.Text = depart.Name;
                        this.hidDepartId.Value = role.DepartmentId.ToString();
                        this.hidRoleId.Value = role.Id.ToString();
                        
                        //加载权限树
                        LoadLevelTree(role.Id,role.DepartmentId);
                    }
                }
              
            }
        }
        #endregion
        private void LoadLevelTree(int roleId,int departId) 
        {
            DataSet ds = OALevelService.GetList("parentLevelNo = 0");      //顶级信息
            DataSet ds1 = new DataSet();    //存放一级菜单信息
            DataSet ds2 = new DataSet();   //存放二级菜单信息
           // StringBuilder sb = new StringBuilder();    //存储第三级复选框的id信息
            if(ds.Tables[0].Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                TreeNode tn = null;
                TreeNode tn1 = null;
                TreeNode tn2 = null;
                string levelNo0 = "";
                string levelNo1 = "";
                string levelNo2 = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ ) 
                {
                    tn = new TreeNode();
                    levelNo0 = ds.Tables[0].Rows[i]["levelNo"].ToString();
                    ds1 = OALevelService.GetList("parentLevelNo = '" + levelNo0 + "'");
                    if (SysPrivilegesService.Exists(roleId, departId, Convert.ToInt32(levelNo0)))
                    {
                        tn.Text = "<input type='checkbox' id='" + i + "' onclick='check(this," + ds1.Tables[0].Rows.Count + ")' value='" + ds.Tables[0].Rows[i]["levelNo"].ToString() + "' checked='checked' />" + ds.Tables[0].Rows[i]["levelName"].ToString();                    

                    }
                    else
                    {
                        tn.Text = "<input type='checkbox' id='" + i + "' onclick='check(this," + ds1.Tables[0].Rows.Count + ")' value='" + ds.Tables[0].Rows[i]["levelNo"].ToString() + "' />" + ds.Tables[0].Rows[i]["levelName"].ToString();                    

                    }
                    #region      一级菜单信息的加载        
                    
                    if(ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds1.Tables[0].Rows.Count;j++ )
                        {
                            tn1 = new TreeNode();
                            levelNo1 = ds1.Tables[0].Rows[j]["levelNo"].ToString();
                            ds2 = OALevelService.GetList("parentLevelNo = '" + levelNo1 + "'");
                            if (SysPrivilegesService.Exists(roleId, departId, Convert.ToInt32(levelNo1)))
                            {
                                tn1.Text = "<input type='checkbox' id='" + i + "_" + j + "' onclick='check2(this," + ds2.Tables[0].Rows.Count + ")' value='" + ds1.Tables[0].Rows[j]["levelNo"].ToString() + "' checked='checked' />" + ds1.Tables[0].Rows[j]["levelName"].ToString();

                            }
                            else
                            {
                                tn1.Text = "<input type='checkbox' id='" + i + "_" + j + "' onclick='check2(this," + ds2.Tables[0].Rows.Count + ")' value='" + ds1.Tables[0].Rows[j]["levelNo"].ToString() + "' />" + ds1.Tables[0].Rows[j]["levelName"].ToString();

                            }
                                                        
                            #region   二级菜单信息的加载
                            
                            //this.level2Count.Value = ds2.Tables[0].Rows.Count.ToString();        //二级菜单的子类数量
                            if(ds2.Tables[0].Rows.Count > 0)
                            {
                                for (int k = 0; k < ds2.Tables[0].Rows.Count;k++ )
                                {
                                    tn2 = new TreeNode();
                                    levelNo2 = ds2.Tables[0].Rows[k]["levelNo"].ToString();
                                    sb.Append((i + "_" + j + "_" + k).ToString() + ",");

                                    if (SysPrivilegesService.Exists(roleId, departId, Convert.ToInt32(levelNo2)))
                                    {
                                        tn2.Text = "<input type='checkbox' id='" + i + "_" + j + "_" + k + "' onclick='check3(this)' value='" + ds2.Tables[0].Rows[k]["levelNo"].ToString() + "' checked='checked' />" + ds2.Tables[0].Rows[k]["levelName"].ToString(); 

                                    }
                                    else
                                    {
                                        tn2.Text = "<input type='checkbox' id='" + i + "_" + j + "_" + k + "' onclick='check3(this)' value='" + ds2.Tables[0].Rows[k]["levelNo"].ToString() + "' />" + ds2.Tables[0].Rows[k]["levelName"].ToString(); 

                                    }
                                    
                                    tn1.ChildNodes.Add(tn2);
                                }
                            }
                            #endregion
                            tn.ChildNodes.Add(tn1);   //一级菜单追加到顶级菜单节点下。
                        }
                    }
                    #endregion
                    this.tvModel.Nodes.Add(tn);      //顶级菜单追加到权限树上
                }
                tvModel.CollapseAll();
                this.hidRowsCount.Value = sb.ToString().TrimEnd(',');
            }
            
        }   
        
    }
}