using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace ePharmaTrax
{
    public partial class ViewPrint : System.Web.UI.Page
    {
        private DBHelperClass db = new DBHelperClass();
        private int recordperpage = 5;

        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            ViewState["pageIndex"] = pageIndex;
            BindGrid("", pageIndex);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                BindGrid("", 1);

                ViewState["sort"] = "asc";
                ViewState["pageIndex"] = 1;

                if (Directory.Exists(HttpContext.Current.Server.MapPath("~/DownloadPdf")))
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath("~/DownloadPdf"), true);
                }

                if (Request["id"] != null)
                {
                    PrintRequest(Request["id"].ToString(), Request["type"].ToString());
                }
            }
        }

        protected void BindGrid(string query, int pageindex, int pagesize = 25, string columnname = "Patient_ID", string sortorder = "desc")
        {
            DataSet lds = null;
            int totalrecords = 0;
            try
            {
                using (SqlConnection gConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ePharmaTrax"].ConnectionString))
                {
                    SqlCommand gComm = new SqlCommand("SP_SERVICE_INDEX_DATA", gConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    gComm.Parameters.AddWithValue("@PageIndex", pageindex);
                    gComm.Parameters.AddWithValue("@cnd", query);

                    gComm.Parameters.AddWithValue("@ordercolumn", columnname);
                    gComm.Parameters.AddWithValue("@sortorder", sortorder);

                    gComm.Parameters.AddWithValue("@PageSize", pagesize);
                    gComm.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    gComm.Parameters["@RecordCount"].Direction = ParameterDirection.Output;



                    gConn.Open();
                    SqlDataAdapter lda = new SqlDataAdapter(gComm);
                    lds = new DataSet();
                    lda.Fill(lds);


                    totalrecords = Convert.ToInt32(gComm.Parameters["@RecordCount"].Value);


                    gConn.Close();


                    if (lds.Tables[0].Rows.Count > 0)
                    {
                        rpview.DataSource = lds;
                        rpview.DataBind();
                    }
                    else
                    {
                        rpview.DataSource = null;
                        rpview.DataBind();
                    }
                    PopulatePager(totalrecords, pageindex);
                }

            }
            catch (Exception)
            {

            }


        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            List<ListItem> pages = new List<ListItem>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            try
            {
                //Calculate the Start and End Index of pages to be displayed.
                double dblPageCount = (double)(recordCount / Convert.ToDecimal(10));
                int pageCount = (int)Math.Ceiling(dblPageCount);

                startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
                endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
                if (currentPage > pagerSpan % 2)
                {
                    if (currentPage == 2)
                    {
                        endIndex = 5;
                    }
                    else
                    {
                        endIndex = currentPage + 2;
                    }
                }
                else
                {
                    endIndex = (pagerSpan - currentPage) + 1;
                }

                if (endIndex - (pagerSpan - 1) > startIndex)
                {
                    startIndex = endIndex - (pagerSpan - 1);
                }

                if (endIndex > pageCount)
                {
                    endIndex = pageCount;
                    startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
                }

                //Add the First Page Button.
                if (currentPage > 1)
                {
                    pages.Add(new ListItem("First", "1"));
                }

                //Add the Previous Button.
                if (currentPage > 1)
                {
                    pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
                }

                for (int i = startIndex; i <= endIndex; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }

                //Add the Next Button.
                if (currentPage < pageCount)
                {
                    pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
                }

                //Add the Last Button.
                if (currentPage != pageCount)
                {
                    pages.Add(new ListItem("Last", pageCount.ToString()));
                }

                if (recordCount > 0)
                {


                    rptPager.DataSource = pages;
                    rptPager.DataBind();
                }
                else
                {


                    rptPager.DataSource = null;
                    rptPager.DataBind();
                }
            }
            catch (Exception)
            {
                //log.Error("Error Message: " + ex.Message.ToString(), ex);
            }
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string _cnd = " where 1=1 ";

                if (!string.IsNullOrEmpty(txtSearch.Value))
                {
                    _cnd = _cnd + " and PatientName like '%" + txtSearch.Value + "%' or Address like '%" + txtSearch.Value + "%' or Occupation like '%" + txtSearch.Value + "%' ";
                }

                BindGrid(_cnd, 1);
            }
            catch (Exception)
            {
            }
        }

        protected void btnClear_ServerClick(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Value = string.Empty;
                BindGrid("", 1);
            }
            catch (Exception)
            {
            }
        }

        private void PrintRequest(string id, string type)
        {
            try
            {
                string fileName = "", filePrefix = "";

                if (type == "r")
                {
                    fileName = "Service.pdf";
                    filePrefix = "Report";
                }
                else
                {
                    fileName = "Form2.pdf";
                    filePrefix = "Form_2";
                }

                if (File.Exists(Server.MapPath("MapPdf/" + fileName)))
                {

                    DataTable dt = db.selectDatatable("select * from view_ServiceMaster where Patient_Id=" + id.ToString());
                    DataTable dt2 = db.selectDatatable("select * from tblServiceRendered where ServiceId=" + id.ToString());
                    if (dt.Rows.Count > 0)
                    {

                        string target = ("DownloadPdf/" + dt.Rows[0]["PatientName"].ToString() + "_" + DateTime.Now.ToString("MMddyyyyHHmmss"));
                        Directory.CreateDirectory(Server.MapPath(target));
                        //for (int i = 0; i < dt2.Rows.Count; i += 2)
                        //{
                        Stamping(Server.MapPath("MapPdf/" + fileName), dt, dt2, 0, target, filePrefix);
                        // Stamping(Server.MapPath("MapPdf/Form2.pdf"), dt, dt2, 0, target, "Form_2");
                        //}



                        Page.ClientScript.RegisterStartupScript(GetType(), "CallMyFunction", "LoadData('" + target + "')", true);

                        //using (ZipFile zip = new ZipFile())
                        //{
                        //    zip.AddDirectory(Server.MapPath(target));

                        //    //zip.Save(Server.MapPath(target +".zip"));
                        //    Response.AppendHeader("content-disposition", "attachment; filename=" + target + ".zip");
                        //    zip.CompressionMethod = CompressionMethod.BZip2;
                        //    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                        //    //Save the zip content in output stream  
                        //    zip.Save(Response.OutputStream);
                        //}
                        //Directory.Delete(Server.MapPath(target), true);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void Stamping(string SourceFile, DataTable dt, DataTable dt2, int startfrom, string target, string fp = "")
        {

            PdfReader pdfReader = new PdfReader(SourceFile);
            AcroFields readPdfFields = pdfReader.AcroFields;
            string fileprefix = "1";
            try
            {
                fileprefix = dt.Rows[0]["PatientName"].ToString() + "_" + fp;
            }
            catch { }
            // HttpContext.Current.Response.Write(dt.Rows.Count);
            // HttpContext.Current.Response.Write(fileprefix);

            string doa = "";
            if (!string.IsNullOrEmpty(dt.Rows[0]["AcciedentDate"].ToString()))
            {
                doa = Convert.ToDateTime(dt.Rows[0]["AcciedentDate"].ToString()).ToString("MMddyyyy");

            }

            //PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(HttpContext.Current.Server.MapPath(target+"/"+ fileprefix + "_" + ((startfrom / recordperpage) + 1).ToString() + "_" + Path.GetFileName(SourceFile)) , FileMode.Create));
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(HttpContext.Current.Server.MapPath(target + "/" + fileprefix + "_" + ((startfrom / recordperpage) + 1).ToString() + "_" + doa + ".pdf"), FileMode.Create));
            // MemoryStream pdfOutput = new MemoryStream();
            // PdfStamper pdfStamper = new PdfStamper(pdfReader, pdfOutput);
            AcroFields pdfFormFields = pdfStamper.AcroFields;
            pdfStamper.FormFlattening = false;
            AcroFields ae = pdfReader.AcroFields;
            foreach (KeyValuePair<string, iTextSharp.text.pdf.AcroFields.Item> de in pdfReader.AcroFields.Fields)
            {
                string textvalue = pdfFormFields.GetField(de.Key.ToString());
                string[] textpair = textvalue.Split('|');
                if (textpair.Length > 1)
                {
                    try
                    {
                        //if (ae.GetFieldType(de.Key.ToString()) == AcroFields.FIELD_TYPE_CHECKBOX)
                        //{
                        //    if (dt.Rows[0][textpair[1]].ToString() == "True")
                        //        pdfFormFields.SetField(textpair[0], "yes");
                        //    else
                        //        pdfFormFields.SetField(textpair[0], "No");
                        //}
                        //else
                        //{
                        if (!textpair[0].StartsWith("15"))
                        {
                            if (dt.Rows[0][textpair[1]] is DateTime)
                            {
                                pdfFormFields.SetField(textpair[0], DateTime.Parse(dt.Rows[0][textpair[1]].ToString()).ToString("MM-dd-yyyy").Replace('-', '/'));
                            }
                            else
                            {
                                pdfFormFields.SetField(textpair[0], dt.Rows[0][textpair[1]].ToString());
                            }
                        }
                        else
                        {

                            for (int j = startfrom; j < startfrom + recordperpage; j++)
                            {
                                if (textpair[0].EndsWith((j - startfrom + 1).ToString()))
                                {
                                    if (dt2.Rows[j][textpair[1]] is DateTime)
                                    {
                                        pdfFormFields.SetField(textpair[0], DateTime.Parse(dt2.Rows[j][textpair[1]].ToString()).ToString("MM-dd-yyyy").Replace('-', '/'));
                                    }
                                    else
                                    {
                                        pdfFormFields.SetField(textpair[0], dt2.Rows[j][textpair[1]].ToString());
                                    }
                                }
                            }
                        }
                        //}
                    }
                    catch (Exception)
                    {
                        pdfFormFields.SetField(textpair[0], "");
                        //hidGenError.Value  += "\n " + ex.Message;
                    }
                }
                else
                {
                    pdfFormFields.SetField(textpair[0], "");
                }




                if (de.Key.StartsWith("15TotalCharges"))
                {
                    double sum = 0;
                    for (int j = startfrom; j < startfrom + recordperpage; j++)
                    {
                        try
                        {
                            sum += Convert.ToDouble(dt2.Rows[j]["Charges"].ToString());
                        }
                        catch (Exception) { }
                    }
                    pdfFormFields.SetField("15TotalCharges", sum.ToString("0.00"));
                }

                //if (de.Key.StartsWith("imgsign"))
                //{
                //    try
                //    {
                //        Stream inputImageStream = new FileStream(HttpContext.Current.Server.MapPath("Sign/" + ID + ".jpg"), FileMode.Open, FileAccess.Read, FileShare.Read);

                //        AcroFields.FieldPosition f = ae.GetFieldPositions(de.Key.ToString())[0];
                //        var pdfContentByte = pdfStamper.GetOverContent(f.page);
                //        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(inputImageStream);
                //        image.ScaleToFit(f.position.Width, f.position.Height + 10);

                //        image.SetAbsolutePosition(f.position.Left, f.position.Bottom);
                //        pdfContentByte.AddImage(image);

                //        pdfFormFields.SetFieldProperty(de.Key.ToString(), "flags", PdfFormField.FLAGS_NOVIEW, null);
                //    }
                //    catch (Exception ex) { }
                //}

            }

            pdfStamper.Close();
            pdfReader.Close();
            //try
            //{
            //    var response = HttpContext.Current.Response;
            //    response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileprefix + "_" + ((startfrom / 2) + 1).ToString() + "_" +  Path.GetFileName(SourceFile) + "\"");
            //    response.ContentType = "application/pdf";
            //    response.BinaryWrite(pdfOutput.ToArray());
            //    response.End();
            //}
            //catch (Exception ex)
            //{
            //    // Logger.Error(ex);
            //}

        }

        protected void DownloadFile(string filePath)
        {

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        [System.Web.Services.WebMethod]
        public static List<string> getDownloadFiles(string FolderName)
        {
            List<string> _str = new List<string>();


            string folderPath = HttpContext.Current.Server.MapPath("~/" + FolderName);


            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.GetFiles())
            {
                string contents = FolderName + "/" + file.Name;
                _str.Add(contents);
            }


            // _str.Add(@"F:\Elance\Arumg\ePharmaTrax\ePharmaTrax\123_1_Service.pdf");

            return _str;
        }

        [System.Web.Services.WebMethod]
        public static string removeDirectory(string FolderName)
        {
            Directory.Delete(HttpContext.Current.Server.MapPath(FolderName), true);

            return "";
        }

        protected void lnkSort_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton colname = sender as LinkButton;
                int pageIndex = Convert.ToInt16(ViewState["pageIndex"].ToString());
                if (ViewState["sort"].ToString() == "asc")
                {
                    ViewState["sort"] = "desc";
                }
                else
                {
                    ViewState["sort"] = "asc";
                }
                BindGrid("", pageIndex, 25, colname.CommandArgument, ViewState["sort"].ToString());
            }
            catch (Exception)
            {

            }
        }
    }
}