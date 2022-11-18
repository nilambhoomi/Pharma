using System;
using System.Data.SqlClient;

namespace ePharmaTrax
{
    public partial class Register : System.Web.UI.Page
    {
        private DBHelperClass dB = new DBHelperClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSingup_ServerClick(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];

                param[0] = new SqlParameter("@LoginID", txtusername.Value);
                param[1] = new SqlParameter("@Password", txtPass.Value);
                param[2] = new SqlParameter("@FirstName", txtFname.Value);
                param[3] = new SqlParameter("@LastName", txtLname.Value);
                param[4] = new SqlParameter("@EmailId", txtEmail.Value);
                param[5] = new SqlParameter("@Ph_No", txtPhone.Value);

                int _val = dB.executeSP("SP_INSERT_USER", param);

                if (_val > 0)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}