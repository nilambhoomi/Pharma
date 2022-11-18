using System;
using System.Data;
using System.Data.SqlClient;


namespace ePharmaTrax
{
    public partial class AddMedication : System.Web.UI.Page
    {
        private DBHelperClass db = new DBHelperClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ViewMedication.aspx");
        }
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            try
            {

                SqlParameter[] param = null;
                string Sp = "";

                if (Request["Id"] == null)
                {
                    param = new SqlParameter[3];
                    Sp = "SP_INSERT_MEDICATION";
                }
                else
                {
                    param = new SqlParameter[4];
                    Sp = "SP_UPDATE_MEDICATION";
                }

                param[0] = new SqlParameter("@Medication", txtMedication.Value);
                param[1] = new SqlParameter("@MedCode", txt_MedCode.Value);
                param[2] = new SqlParameter("@Fee", txt_Fees.Value == "" ? "0" : txt_Fees.Value);


                if (Request["Id"] != null)
                {
                    param[3] = new SqlParameter("@Id", Request["Id"].ToString());
                }

                int _val = db.executeSP(Sp, param);

                if (_val > 0)
                {
                    Response.Redirect("ViewMedication.aspx");
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
                string query = "select * from tblMedication where Id=" + id;

                DataSet ds = db.selectData(query);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    txtMedication.Value = ds.Tables[0].Rows[0]["Medication"].ToString();
                    txt_MedCode.Value = ds.Tables[0].Rows[0]["MedCode"].ToString();
                    txt_Fees.Value = ds.Tables[0].Rows[0]["Fees"].ToString();

                }
            }
            catch (Exception)
            {
            }
        }
    }
}