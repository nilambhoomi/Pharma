using System;
using System.Data;
using System.Data.SqlClient;
namespace ePharmaTrax
{
    public partial class AddInsurance : System.Web.UI.Page
    {
        private DBHelperClass db = new DBHelperClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindData(Request["Id"].ToString());
            //}
        }
        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewInsurance.aspx");
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {

                SqlParameter[] param = null;
                string Sp = "";

                if (Request["Id"] == null)
                {
                    param = new SqlParameter[4];
                    Sp = "SP_INSERT_INSURANCECOMP";
                }
                else
                {
                    param = new SqlParameter[5];
                    Sp = "SP_UPDATE_INSURANCECOMP";
                }

                param[0] = new SqlParameter("@Name", txtName.Value);
                param[1] = new SqlParameter("@Address", txt_address.Value);
                param[2] = new SqlParameter("@Phone", txt_ph_no.Value);
                param[3] = new SqlParameter("@PinCode", txt_pin.Value);

                if (Request["Id"] != null)
                {
                    param[4] = new SqlParameter("@Id", Request["Id"].ToString());
                }

                int _val = db.executeSP(Sp, param);

                if (_val > 0)
                {
                    Response.Redirect("ViewInsurance.aspx");
                }
            }
            catch (Exception)
            {
            }

        }

        private void BindData(string id)
        {
            try
            {
                string query = "select * from tblInsuranceComp where Id=" + id;

                DataSet ds = db.selectData(query);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Value = ds.Tables[0].Rows[0]["Name"].ToString();
                    txt_address.Value = ds.Tables[0].Rows[0]["Address"].ToString();
                    txt_ph_no.Value = ds.Tables[0].Rows[0]["Phone"].ToString();
                    txt_pin.Value = ds.Tables[0].Rows[0]["PinCode"].ToString();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}