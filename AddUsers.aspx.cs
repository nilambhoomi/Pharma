using System;
using System.Data;
using System.Data.SqlClient;

namespace ePharmaTrax
{
    public partial class AddUsers : System.Web.UI.Page
    {
        private DBHelperClass db = new DBHelperClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                    BindData(Request["id"].ToString());
            }

        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewUser.aspx");
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            SqlParameter[] param = null;
            string sp = "";

            if (Request["Id"] == null)
            {
                param = new SqlParameter[6];
                sp = "SP_INSERT_USER";
            }
            else
            {
                param = new SqlParameter[7];
                sp = "SP_UPDATE_USER";
            }

            param[0] = new SqlParameter("@LoginID", txtLoginId.Value);
            param[1] = new SqlParameter("@Password", txtPassword.Value);
            param[2] = new SqlParameter("@FirstName", txtFname.Value);
            param[3] = new SqlParameter("@LastName", txtLname.Value);
            param[4] = new SqlParameter("@EmailId", txtEmail.Value);
            param[5] = new SqlParameter("@Ph_No", txtPhone.Value);


            if (Request["Id"] != null)
            {
                param[6] = new SqlParameter("@User_Id", Request["Id"].ToString());
            }

            int _val = db.executeSP(sp, param);

            if (_val > 0)
            {
                Response.Redirect("ViewUser.aspx");
            }
        }

        private void BindData(string id)
        {
            string Query = "SELECT * from tblUserMaster WHERE User_Id =" + id;
            DataSet ds = db.selectData(Query);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

               
                txtFname.Value = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLname.Value = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtLoginId.Value = ds.Tables[0].Rows[0]["LoginID"].ToString();
                txtEmail.Value = ds.Tables[0].Rows[0]["EmailId"].ToString();
                txtPhone.Value = ds.Tables[0].Rows[0]["Ph_No"].ToString();
                txtPassword.Attributes.Add("value", ds.Tables[0].Rows[0]["Password"].ToString());

            }
        }

    }
}