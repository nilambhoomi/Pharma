using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePharmaTrax
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] != null)
                lbluname.InnerText = Session["uname"].ToString();
            else
                Response.Redirect("Login.aspx");
        }
    }
}