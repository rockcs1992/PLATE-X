using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.Text;
using System.IO;
using System.Data;

namespace CommonBussiness
{
    public partial class deleteOrder : System.Web.UI.Page
    {
        protected int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                OrderService.UpdateStatus(id, 150);
                Response.Redirect("/orders_0.html");
            }
        }

    }
}