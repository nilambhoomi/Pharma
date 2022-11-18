﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace ePharmaTrax
{
    public partial class ViewMedication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["sort"] = "asc";
                ViewState["pageIndex"] = 1;
                BindGrid("", 1);

                if (Request["id"] != null)
                {
                    deleteRecord(Request["id"].ToString());
                }
            }
        }

        protected void lnkPage_Click(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            ViewState["pageIndex"] = pageIndex;
            BindGrid("", pageIndex);
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Value))
            {

                string query = " where REPLACE(REPLACE(Medication, CHAR(13), ''), CHAR(10), '') like '%" + txtSearch.Value + "%' or MedCode like '%" + txtSearch.Value + "%' ";

                BindGrid(query, 1);

                ViewState["cnd"] = query;
            }
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("AddMedication.aspx");
        }

        protected void BindGrid(string query, int pageindex, int pagesize = 25, string columnname = "Id", string sortorder = "desc")
        {
            DataSet lds = null;
            int totalrecords = 0;
            try
            {
                using (SqlConnection gConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ePharmaTrax"].ConnectionString))
                {
                    SqlCommand gComm = new SqlCommand("SP_MEDICATION_INDEX_DATA", gConn)
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

        protected void btnClear_ServerClick(object sender, EventArgs e)
        {
            txtSearch.Value = string.Empty;
            BindGrid("", 1);
        }

        public void deleteRecord(string id)
        {
            try
            {
                string _query = " delete from tblMedication where Id=" + id;
                int val = new DBHelperClass().executeQuery(_query);


                BindGrid("", 1);

            }
            catch (Exception)
            {

                throw;
            }
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

        protected void btnExcel_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DBHelperClass db = new DBHelperClass();
                string query = "select Medication,MedCode,Fees from tblMedication";

                if (ViewState["cnd"] != null)
                {
                    query = query + " " + ViewState["cnd"].ToString();
                }

                DataTable dt = db.selectDatatable(query);
                string attachment = "attachment; filename=Medication.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    string val = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        val = Regex.Replace(dr[i].ToString(), @"\r\n?|\n", "");
                        Response.Write(tab + val);
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            catch (Exception)
            {
            }
        }

        [WebMethod]
        public static string[] getMedicationName(string prefix)
        {
            DBHelperClass db = new DBHelperClass();
            List<string> inscmp = new List<string>();

            if (prefix.IndexOf("'") > 0)
            {
                prefix = prefix.Replace("'", "''");
            }

            DataSet ds = db.selectData("select Medication from tblMedication where REPLACE(REPLACE(Medication, CHAR(13), ''), CHAR(10), '') like '%" + prefix + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string cmpname = "";
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    cmpname = ds.Tables[0].Rows[i]["Medication"].ToString();

                    inscmp.Add(string.Format("{0}", cmpname));
                }
            }

            return inscmp.ToArray();
        }
    }
}