using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace CommonBussiness.mobile
{
    public partial class doneOrder : System.Web.UI.Page
    {
        string action = CRequest.GetString("action");
        int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (action.Equals("recieve"))
                {
                    int rows = OrderService.UpdateStatus(id, 3);
                    if (rows > 0)
                    {
                        Response.Redirect("myOrder_3.html");
                    }
                }
                if(action.Equals("cancel"))
                {
                    int rows = OrderService.UpdateStatus(id, 100);
                    if(rows > 0)
                    {
                        Response.Redirect("myOrder_99.html");
                    }
                }

                if (action.Equals("delete"))
                {
                    int rows = OrderService.UpdateStatus(id, 150);
                    if (rows > 0)
                    {
                        Response.Redirect("myOrder_0.html");
                    }
                }

            }
        }
    }
}