using System;
using System.Data;

namespace ePharmaTrax
{
    public partial class Login : System.Web.UI.Page
    {
        private DBHelperClass db = new DBHelperClass();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _query = "select * from tblUserMaster where LoginID='" + txtusername.Value + "' and ClientId='" + txtclientid.Value + "'";

                DataSet _ds = db.selectData(_query);
                 if (_ds != null && _ds.Tables[0].Rows.Count > 0)
                {
                    if (_ds.Tables[0].Rows[0]["Password"].ToString() == txtpassword.Value)
                    {
                        Session["uname"] = _ds.Tables[0].Rows[0]["LoginID"].ToString();
                        Session["uid"] = _ds.Tables[0].Rows[0]["User_ID"].ToString();
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}