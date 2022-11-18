using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;

public partial class ImportPatients : System.Web.UI.Page
{
    StringBuilder sb = new StringBuilder();
    DBHelperClass db = new DBHelperClass();
    SqlConnection oSQLConn = new SqlConnection();
    SqlCommand oSQLCmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ImportFromExcel(object sender, EventArgs e)
    {
        // CHECK IF A FILE HAS BEEN SELECTED.
        if ((FileUpload.HasFile))
        {

            if (!Convert.IsDBNull(FileUpload.PostedFile) &
                FileUpload.PostedFile.ContentLength > 0)
            {

                //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload.SaveAs(Server.MapPath(".") + "\\Pat\\" + FileUpload.FileName);

                // SqlBulkCopy oSqlBulk = null;

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\Pat\\" + FileUpload.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB = new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(objBulkReader);
                    myExcelConn.Close();
                    // Read data from this file, when I'm done I don't need it any more
                    File.Delete(Server.MapPath(".") + "\\Pat\\" + FileUpload.FileName); // IOException: file is in use
                    
                    char[] charsToTrim = { ',', '.', ' ' };
                    foreach (DataRow row in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(row.ItemArray[0])))
                        {
                            SqlParameter[] param = null;
                            param = new SqlParameter[6];
                            param[0] = new SqlParameter("@NameOfInsurance", Convert.ToString(row.ItemArray[2]));
                            param[1] = new SqlParameter("@AcciedentDate", Convert.ToString(row.ItemArray[5]) == "" ? null : Convert.ToString(row.ItemArray[5]));
                            param[2] = new SqlParameter("@ClaimNo", Convert.ToString(row.ItemArray[3]));
                            param[3] = new SqlParameter("@PatientName", Convert.ToString(row.ItemArray[0]).TrimEnd(charsToTrim));
                            param[4] = new SqlParameter("@Address", Convert.ToString(row.ItemArray[1]));
                            param[5] = new SqlParameter("@CreatedBy", "Utility");

                            string sp = "SP_INSERT_SERVICE_utility";
                            int _result = db.executeSP(sp, param);
                        }


                        //if (dc.ColumnName.Equals("PatientIE"))
                        //{
                        //    ieID = Convert.ToString(row[dc]);
                        //}
                        //if (dc.ColumnName.Equals("PatientFU"))
                        //{
                        //    fuid = Convert.ToString(row[dc]);
                        //}
                        //if (dc.ColumnName.Equals("Drug"))
                        //{
                        //    med = Convert.ToString(row[dc]);
                        //}

                        //if (!string.IsNullOrEmpty(med) && !string.IsNullOrEmpty(ieID) && string.IsNullOrEmpty(fuid))
                        //{
                        //    SaveMediUI(ieID, med);
                        //}
                        //if (!string.IsNullOrEmpty(fuid) && !string.IsNullOrEmpty(med) && string.IsNullOrEmpty(ieID))
                        //{
                        //    SaveMediUIFU(fuid, med);
                        //}

                    }

                    lblConfirm.Text = "DATA IMPORTED SUCCESSFULLY.";
                    lblConfirm.Attributes.Add("style", "color:green");

                }
                catch (Exception ex)
                {

                    lblConfirm.Text = ex.Message;
                    lblConfirm.Attributes.Add("style", "color:red");

                }
                finally
                {
                    // CLEAR.
                    myExcelConn.Close();

                }
            }
        }
        else
        {
            lblConfirm.Text = "Please select file to Import.";
            lblConfirm.Attributes.Add("style", "color:red");
        }
    }
    public int GetAge(DateTime birthDate)
    {
        DateTime n = DateTime.Now; // To avoid a race condition around midnight
        int age = n.Year - birthDate.Year;

        if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
        {
            age--;
        }

        return age;
    }
}