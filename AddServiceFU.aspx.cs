using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class AddServiceFU : System.Web.UI.Page
{
    private DBHelperClass db = new DBHelperClass();
    //public DBHelperClass1 db = new DBHelperClass1();

    private int recordperpage = 4;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            //txtInitDate.Value = System.DateTime.Now.ToString("MM/dd/yyyy");
            generateTable();

            ////DataTable dt = new DataTable();
            ////string query = "select max(PatientFU_ID) from tblFUServiceMaster where PatientService_ID = " + Convert.ToString(Request["ID"]);
            ////dt = db.selectDatatable(query);
            //if (dt != null)
            //{ ViewState["FUid"]  = Convert.ToInt32(dt.Rows[0][0]); }

            if (Request["FUid"] != null)
            {
                ViewState["FUid"] = Convert.ToInt32(Request["FUid"].ToString());
                ViewState["Id"] = Convert.ToInt32(Request["Id"].ToString());

                bindDataFU(ViewState["FUid"].ToString(), ViewState["Id"].ToString());
                btnPrintForm.Attributes.Add("style", "display:inline");
                btnPrintReport.Attributes.Add("style", "display:inline");
            }
            else if (Request["id"] != null)
            {
                ViewState["Id"] = Request["id"].ToString();
                DataTable dt = new DataTable();
                string query = "SELECT top 1 PatientFU_ID,PatientService_ID from tblFUServiceMaster where PatientService_ID = " + Convert.ToString(Request["ID"]) + " order by PatientFU_ID desc";
                dt = db.selectDatatable(query);
                if (dt.Rows.Count > 0)
                {
                    ViewState["FUid"] = Convert.ToInt32(dt.Rows[0][0]);
                    ViewState["Id"] = Convert.ToInt32(dt.Rows[0][1]);

                    bindDataFU(ViewState["FUid"].ToString(), ViewState["Id"].ToString());
                    btnPrintForm.Attributes.Add("style", "display:inline");
                    btnPrintReport.Attributes.Add("style", "display:inline");


                }
                else
                {
                    bindData(Request["id"].ToString());
                    ViewState["Id"] = Request["id"].ToString();
                    btnPrintForm.Attributes.Add("style", "display:inline");
                    btnPrintReport.Attributes.Add("style", "display:inline");
                }


            }

        }
    }
    public int executeSPint(string sp, SqlParameter[] param)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ePharmaTrax"].ConnectionString); ;
        int val = 0;
        try
        {
            SqlCommand cm = new SqlCommand(sp, cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cm.Parameters.AddRange(param.ToArray());
            cn.Open();
            val = Convert.ToInt32(cm.ExecuteScalar());
            cn.Close();
            return val;
        }
        catch (Exception e)
        {
            //  LogError(e);
        }

        return val;
    }
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        try
        {
            SqlParameter[] param = null;
            if (Request["FUid"] == null)
            {
                param = new SqlParameter[41];
            }
            else
            {
                param = new SqlParameter[42];
            }

            param[0] = new SqlParameter("@NameOfInsurance", txtNameOfInsurance.Value);
            param[1] = new SqlParameter("@NameClaimRePresntative", txtNameClaimRePresntative.Value);
            param[2] = new SqlParameter("@PolicyNo", txtPolicyNo.Value);
            param[3] = new SqlParameter("@PolicyHolder", txtPolicyHolder.Value);
            param[4] = new SqlParameter("@AcciedentDate", txtAcciedentDate.Value == "" ? null : txtAcciedentDate.Value);
            param[5] = new SqlParameter("@ClaimNo", txtClaimNo.Value);
            param[6] = new SqlParameter("@ProviderName", txtProviderName.Value);
            param[7] = new SqlParameter("@Sex", ddl_sex.SelectedItem.Text);
            param[8] = new SqlParameter("@PatientName", txtName.Value);
            param[9] = new SqlParameter("@Address", txtAddress.Value);
            param[10] = new SqlParameter("@AGE", txtDOB.Value == "" ? 0 : GetAge(Convert.ToDateTime(txtDOB.Value)));
            param[11] = new SqlParameter("@Occupation", txtOccupation.Value);
            param[12] = new SqlParameter("@Diagnosis", txtDiagnosis.Value);
            param[13] = new SqlParameter("@FirstSymptomsDate", txtFirstSymptomsDate.Value == "" ? null : txtFirstSymptomsDate.Value);
            param[14] = new SqlParameter("@FirstConsultDate", txtFirstConsultDate.Value == "" ? null : txtFirstConsultDate.Value);
            param[15] = new SqlParameter("@IsSimlilerCondition", chkIsSimlilerCondition.Checked);
            param[16] = new SqlParameter("@SimilerConditionDesc", txtSimilerConditionDesc.Value);
            param[17] = new SqlParameter("@IsAutomobileAccident", chkIsAutomobileAccident.Checked);
            param[18] = new SqlParameter("@AutomobileAccidentDesc", txtAutomobileAccidentDesc.Value);
            param[19] = new SqlParameter("@IsDueToInjury", chkchkIsDueToInjury.Value);
            param[20] = new SqlParameter("@PermanentDisablityStatus", ddlPermanentDisablityStatus.SelectedItem.Value);
            param[21] = new SqlParameter("@PermanentDisablityDesc", txtPermanentDisablityDesc.Value);
            param[22] = new SqlParameter("@EnabletoWorkFrom", txtEnabletoWorkFrom.Value == "" ? null : txtEnabletoWorkFrom.Value);
            param[23] = new SqlParameter("@EnabletoWorkThrough", txtEnabletoWorkThrough.Value == "" ? null : txtEnabletoWorkThrough.Value);
            param[24] = new SqlParameter("@ReturnWorkOn", txtReturnWorkOn.Value == "" ? null : txtReturnWorkOn.Value);
            param[25] = new SqlParameter("@IsReqRehab", chkIsReqRehab.Checked);
            param[26] = new SqlParameter("@ReqRehabDesc", txtReqRehabDesc.Value);

            if (Request["FUid"] == null)
            {
                param[27] = new SqlParameter("@CreatedBy", Session["uname"].ToString());
            }
            else
            {
                param[27] = new SqlParameter("@UpdatedBy", Session["uname"].ToString());
            }

            param[28] = new SqlParameter("@TreatingProviderName", txtTreatingProviderName.Value);
            param[29] = new SqlParameter("@Title", txtTitle.Value);
            param[30] = new SqlParameter("@LicenceForCeriNo", txtLicenceForCeriNo.Value);
            param[31] = new SqlParameter("@BusinessRelationShip", ddlBusinessRelationShip.SelectedItem.Text);
            param[32] = new SqlParameter("@BusinessRelationShipOtherDesc", txtBusinessRelationShipOtherDesc.Value);
            param[33] = new SqlParameter("@IsUndesrYourcCare", chkIsUndesrYourcCare.Checked);
            param[34] = new SqlParameter("@EstimateDuration", txtEstimateDuration.Value);
            param[35] = new SqlParameter("@Attachment", txtAttchment.Value);
            param[36] = new SqlParameter("@InitDate", txtInitDate.Value == "" ? null : txtInitDate.Value);
            param[37] = new SqlParameter("@DOB", txtDOB.Value);
            param[38] = new SqlParameter("@NameOfInsuranceDetails", hdNameOfInsurance.Value);
            param[39] = new SqlParameter("@NameClaimRePresntativeDetails", hdNameClaimRePresntative.Value);
            param[40] = new SqlParameter("@PatientService_ID", ViewState["Id"].ToString());

            string sp = "SP_FU_INSERT_SERVICE";

            if (Request["FUid"] != null)
            {
                param[41] = new SqlParameter("@PatientFU_ID", Request["FUid"].ToString());
                sp = "SP_FU_UPDATE_SERVICE";
            }

            int _result = db.executeSP(sp, param);

            if (_result > 0)
            {
                if (sp == "SP_FU_UPDATE_SERVICE")
                {
                    SaveReportRendred(Convert.ToInt32(ViewState["Id"]), Convert.ToInt32(ViewState["FUid"]));
                }
                else
                {
                    SaveReportRendred(Convert.ToInt32(ViewState["Id"]), _result);
                }
                
                if (Request["FUid"] == null)
                {
                    ViewState["FUId"] = _result;
                    btnPrintForm.Attributes.Add("style", "display:inline");
                    btnPrintReport.Attributes.Add("style", "display:inline");
                }
                string parameter = _result + "," + Convert.ToInt32(ViewState["Id"]);
                // Response.Redirect("ViewServices.aspx");
                Page.ClientScript.RegisterStartupScript(GetType(), "CallMyFunction", "serviceadded(" + parameter + ")", true);
            }

        }
        catch (Exception)
        {

        }
    }

    public void generateTable()
    {
        DataTable dt = new DataTable("Service");
        dt.Columns.Add("DateOfService", typeof(DateTime));
        dt.Columns.Add("PlaceOfService", typeof(string));
        dt.Columns.Add("TreatmentDesc", typeof(string));
        dt.Columns.Add("TreatmentCode", typeof(string));
        dt.Columns.Add("Charges", typeof(double));
        dt.Columns.Add("ServiceId", typeof(int));
		dt.Columns.Add("FUId", typeof(int));
		dt.Columns.Add("IEId", typeof(int));


        dt.WriteXml(Server.MapPath("Service.xml"));
        dt.WriteXmlSchema(Server.MapPath("Service.xls"));
        repReport.DataSource = dt;
        repReport.DataBind();
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.ReadXmlSchema(Server.MapPath("Service.xls"));
            dt.ReadXml(Server.MapPath("Service.xml"));
            DataRow rw = dt.NewRow();
            rw["DateOfService"] = txtDate.Value;
            rw["PlaceOfService"] = txtPlace.Value;
            rw["TreatmentDesc"] = txtDesc.Value;
            rw["TreatmentCode"] = txtCode.Value;
            rw["Charges"] = txtCharges.Value;
            rw["FUId"] = 0;
            rw["IEId"] = 0;
            


            dt.Rows.Add(rw);



            //if (Request["id"] == null)
            //    txtTotal.Text = dt.AsEnumerable().Sum(x => x.Field<double>("Charges")).ToString();
            //else
            //{

            //    txtTotal.Text = dt.AsEnumerable().Sum(x => x.Field<double>("Charges")).ToString();
            //}

            dt.WriteXml(Server.MapPath("Service.xml"));
            dt.WriteXmlSchema(Server.MapPath("Service.xls"));
            repReport.DataSource = dt;
            repReport.DataBind();

            txtTotal.Text = dt.Compute("Sum(Charges)", string.Empty).ToString();
            // txtDate.Value = string.Empty;
            // txtPlace.Value = string.Empty;
            txtDesc.Value = string.Empty;
            txtCode.Value = string.Empty;
            txtCharges.Value = string.Empty;
        }
        catch (Exception exep)
        {
            exep.ToString();
        }

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.ReadXmlSchema(Server.MapPath("Service.xls"));
            dt.ReadXml(Server.MapPath("Service.xml"));
            dt.Rows.RemoveAt(e.Item.ItemIndex);
            if (Request["id"] == null)
            {
                txtTotal.Text = dt.AsEnumerable().Sum(x => x.Field<double>("Charges")).ToString();
            }
            else
            {
                txtTotal.Text = dt.AsEnumerable().Sum(x => x.Field<decimal>("Charges")).ToString();
            }
            dt.WriteXml(Server.MapPath("Service.xml"));
            dt.WriteXmlSchema(Server.MapPath("Service.xls"));
            repReport.DataSource = dt;
            repReport.DataBind();
        }
        catch (Exception)
        {

        }


    }

    public void SaveReportRendred(int IE, int FUID)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.ReadXmlSchema(Server.MapPath("Service.xls"));
            dt.ReadXml(Server.MapPath("Service.xml"));

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@IEId", IE);
            param[1] = new SqlParameter("@FUId", FUID);

            db.executeSP("SP_DELETE_FUSERVICE_RENDERED", param);

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    param = new SqlParameter[7];

                    param[0] = new SqlParameter("@DateOfService", dt.Rows[i]["DateOfService"].ToString());
                    param[1] = new SqlParameter("@PlaceOfService", dt.Rows[i]["PlaceOfService"].ToString());
                    param[2] = new SqlParameter("@TreatmentDesc", dt.Rows[i]["TreatmentDesc"].ToString());
                    param[3] = new SqlParameter("@TreatmentCode", dt.Rows[i]["TreatmentCode"].ToString());
                    param[4] = new SqlParameter("@Charges", dt.Rows[i]["Charges"].ToString());
                    param[5] = new SqlParameter("@IE", IE);
                    param[6] = new SqlParameter("@FUId", FUID);

                    executeSPint("SP_INSERT_FUSERVICE_RENDERED", param);
                }
            }

        }
        catch (Exception)
        {

        }
    }

    public void bindData(string id)
    {
        try
        {
            string _query = " where Patient_Id=" + id;

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@cnd", _query);

            DataSet _dt = db.executeSelectSP("SP_SERVICE_DATA", param);

            if (_dt != null && _dt.Tables[0].Rows.Count > 0)
            {
                txtAcciedentDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["AcciedentDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["AcciedentDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtInitDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["InitDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["InitDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtAddress.Value = _dt.Tables[0].Rows[0]["Address"].ToString();
                txtDOB.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["DOB"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["DOB"].ToString()).ToString("MM/dd/yyyy") : "";
                txtAutomobileAccidentDesc.Value = _dt.Tables[0].Rows[0]["AutomobileAccidentDesc"].ToString();
                txtBusinessRelationShipOtherDesc.Value = _dt.Tables[0].Rows[0]["BusinessRelationShipOtherDesc"].ToString();

                txtClaimNo.Value = _dt.Tables[0].Rows[0]["ClaimNo"].ToString();

                txtDiagnosis.Value = _dt.Tables[0].Rows[0]["Diagnosis"].ToString();
                txtEnabletoWorkFrom.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["EnabletoWorkFrom"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["EnabletoWorkFrom"].ToString()).ToString("MM/dd/yyyy") : "";
                txtEnabletoWorkThrough.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["EnabletoWorkThrough"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["EnabletoWorkThrough"].ToString()).ToString("MM/dd/yyyy") : "";
                txtEstimateDuration.Value = _dt.Tables[0].Rows[0]["EstimateDuration"].ToString();
                txtFirstConsultDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["FirstConsultDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["FirstConsultDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtFirstSymptomsDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["FirstSymptomsDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["FirstSymptomsDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtLicenceForCeriNo.Value = _dt.Tables[0].Rows[0]["LicenceForCeriNo"].ToString();
                txtName.Value = _dt.Tables[0].Rows[0]["PatientName"].ToString();
                txtNameClaimRePresntative.Value = _dt.Tables[0].Rows[0]["NameClaimRePresntative"].ToString();
                txtNameOfInsurance.Value = _dt.Tables[0].Rows[0]["NameOfInsurance"].ToString();
                txtOccupation.Value = _dt.Tables[0].Rows[0]["Occupation"].ToString();
                txtPermanentDisablityDesc.Value = _dt.Tables[0].Rows[0]["PermanentDisablityDesc"].ToString();

                txtPolicyHolder.Value = _dt.Tables[0].Rows[0]["PolicyHolder"].ToString();
                txtPolicyNo.Value = _dt.Tables[0].Rows[0]["PolicyNo"].ToString();
                txtProviderName.Value = _dt.Tables[0].Rows[0]["ProviderName"].ToString();
                ddl_sex.SelectedItem.Text = _dt.Tables[0].Rows[0]["sex"].ToString();
                txtReqRehabDesc.Value = _dt.Tables[0].Rows[0]["ReqRehabDesc"].ToString();
                txtReturnWorkOn.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["ReturnWorkOn"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["ReturnWorkOn"].ToString()).ToString("MM/dd/yyyy") : ""; ;
                txtSimilerConditionDesc.Value = _dt.Tables[0].Rows[0]["SimilerConditionDesc"].ToString();
                txtTitle.Value = _dt.Tables[0].Rows[0]["Title"].ToString();
                txtTreatingProviderName.Value = _dt.Tables[0].Rows[0]["TreatingProviderName"].ToString();

                chkchkIsDueToInjury.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsDueToInjury"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsDueToInjury"].ToString()) : false;

                chkIsAutomobileAccident.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsAutomobileAccident"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsAutomobileAccident"].ToString()) : false;

                if (chkIsAutomobileAccident.Checked)
                {
                    divIsAutomobileAccident.Attributes.Add("style", "display:none");
                }

                chkIsReqRehab.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsReqRehab"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsReqRehab"].ToString()) : false;


                if (chkIsReqRehab.Checked)
                {
                    divReqRehabDesc.Attributes.Add("style", "display:block");
                }

                chkIsSimlilerCondition.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsSimlilerCondition"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsSimlilerCondition"].ToString()) : false;


                if (chkIsSimlilerCondition.Checked)
                {
                    divIsSimlilerCondition.Attributes.Add("style", "display:block");
                }

                chkIsUndesrYourcCare.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsUndesrYourcCare"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsUndesrYourcCare"].ToString()) : false;

                bindRenderedData(id);
            }
        }
        catch (Exception)
        {

        }
    }

    public void bindDataFU(string FUID, string id)
    {
        try
        {
            string _query = " where PatientFU_ID = " + FUID + " and PatientService_ID = " + id;

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@cnd", _query);

            DataSet _dt = db.executeSelectSP("SP_FUSERVICE_DATA", param);

            if (_dt != null && _dt.Tables[0].Rows.Count > 0)
            {
                txtAcciedentDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["AcciedentDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["AcciedentDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtInitDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["InitDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["InitDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtAddress.Value = _dt.Tables[0].Rows[0]["Address"].ToString();
                txtDOB.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["DOB"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["DOB"].ToString()).ToString("MM/dd/yyyy") : "";
                txtAutomobileAccidentDesc.Value = _dt.Tables[0].Rows[0]["AutomobileAccidentDesc"].ToString();
                txtBusinessRelationShipOtherDesc.Value = _dt.Tables[0].Rows[0]["BusinessRelationShipOtherDesc"].ToString();

                txtClaimNo.Value = _dt.Tables[0].Rows[0]["ClaimNo"].ToString();

                txtDiagnosis.Value = _dt.Tables[0].Rows[0]["Diagnosis"].ToString();
                txtEnabletoWorkFrom.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["EnabletoWorkFrom"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["EnabletoWorkFrom"].ToString()).ToString("MM/dd/yyyy") : "";
                txtEnabletoWorkThrough.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["EnabletoWorkThrough"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["EnabletoWorkThrough"].ToString()).ToString("MM/dd/yyyy") : "";
                txtEstimateDuration.Value = _dt.Tables[0].Rows[0]["EstimateDuration"].ToString();
                txtFirstConsultDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["FirstConsultDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["FirstConsultDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtFirstSymptomsDate.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["FirstSymptomsDate"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["FirstSymptomsDate"].ToString()).ToString("MM/dd/yyyy") : "";
                txtLicenceForCeriNo.Value = _dt.Tables[0].Rows[0]["LicenceForCeriNo"].ToString();
                txtName.Value = _dt.Tables[0].Rows[0]["PatientName"].ToString();
                txtNameClaimRePresntative.Value = _dt.Tables[0].Rows[0]["NameClaimRePresntative"].ToString();
                txtNameOfInsurance.Value = _dt.Tables[0].Rows[0]["NameOfInsurance"].ToString();
                txtOccupation.Value = _dt.Tables[0].Rows[0]["Occupation"].ToString();
                txtPermanentDisablityDesc.Value = _dt.Tables[0].Rows[0]["PermanentDisablityDesc"].ToString();

                txtPolicyHolder.Value = _dt.Tables[0].Rows[0]["PolicyHolder"].ToString();
                txtPolicyNo.Value = _dt.Tables[0].Rows[0]["PolicyNo"].ToString();
                txtProviderName.Value = _dt.Tables[0].Rows[0]["ProviderName"].ToString();
                ddl_sex.SelectedItem.Text = _dt.Tables[0].Rows[0]["sex"].ToString();
                txtReqRehabDesc.Value = _dt.Tables[0].Rows[0]["ReqRehabDesc"].ToString();
                txtReturnWorkOn.Value = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["ReturnWorkOn"].ToString()) ? Convert.ToDateTime(_dt.Tables[0].Rows[0]["ReturnWorkOn"].ToString()).ToString("MM/dd/yyyy") : ""; ;
                txtSimilerConditionDesc.Value = _dt.Tables[0].Rows[0]["SimilerConditionDesc"].ToString();
                txtTitle.Value = _dt.Tables[0].Rows[0]["Title"].ToString();
                txtTreatingProviderName.Value = _dt.Tables[0].Rows[0]["TreatingProviderName"].ToString();

                chkchkIsDueToInjury.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsDueToInjury"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsDueToInjury"].ToString()) : false;

                chkIsAutomobileAccident.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsAutomobileAccident"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsAutomobileAccident"].ToString()) : false;

                if (chkIsAutomobileAccident.Checked)
                {
                    divIsAutomobileAccident.Attributes.Add("style", "display:none");
                }

                chkIsReqRehab.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsReqRehab"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsReqRehab"].ToString()) : false;


                if (chkIsReqRehab.Checked)
                {
                    divReqRehabDesc.Attributes.Add("style", "display:block");
                }

                chkIsSimlilerCondition.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsSimlilerCondition"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsSimlilerCondition"].ToString()) : false;


                if (chkIsSimlilerCondition.Checked)
                {
                    divIsSimlilerCondition.Attributes.Add("style", "display:block");
                }

                chkIsUndesrYourcCare.Checked = !string.IsNullOrEmpty(_dt.Tables[0].Rows[0]["IsUndesrYourcCare"].ToString()) ? Convert.ToBoolean(_dt.Tables[0].Rows[0]["IsUndesrYourcCare"].ToString()) : false;

                bindRenderedDataFU(id, FUID);
            }
        }
        catch (Exception)
        {

        }
    }

    public void bindRenderedDataFU(string id, string FUid)
    {
        try
        {
            string _query = " where FUId = " + FUid + " and IEId = " + id;

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@cnd", _query);

            DataSet _dt = db.executeSelectSP("SP_FUSERVICERENDERED_DATA", param, "Service");


            if (_dt != null && _dt.Tables[0].Rows.Count > 0)
            {
                _dt.Tables[0].WriteXml(Server.MapPath("Service.xml"));
                _dt.Tables[0].WriteXmlSchema(Server.MapPath("Service.xls"));

                txtTotal.Text = _dt.Tables[0].AsEnumerable().Sum(x => x.Field<decimal>("Charges")).ToString();

                repReport.DataSource = _dt;
                repReport.DataBind();
            }
            else
            {
                txtTotal.Text = "0.00";
            }

        }
        catch (Exception)
        {

        }
    }

    public void bindRenderedData(string id)
    {
        try
        {
            string _query = " where ServiceId=" + id;

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@cnd", _query);

            DataSet _dt = db.executeSelectSP("SP_SERVICERENDERED_DATA", param, "Service");



            if (_dt != null && _dt.Tables[0].Rows.Count > 0)
            {
                _dt.Tables[0].WriteXml(Server.MapPath("Service.xml"));
                _dt.Tables[0].WriteXmlSchema(Server.MapPath("Service.xls"));

                txtTotal.Text = _dt.Tables[0].AsEnumerable().Sum(x => x.Field<decimal>("Charges")).ToString();

                repReport.DataSource = _dt;
                repReport.DataBind();
            }
            else
            {
                txtTotal.Text = "0.00";
            }

        }
        catch (Exception)
        {

        }
    }
    [WebMethod]
    public static string[] getInsComp(string prefix)
    {
        DBHelperClass db = new DBHelperClass();
        List<string> inscmp = new List<string>();

        if (prefix.IndexOf("'") > 0)
        {
            prefix = prefix.Replace("'", "''");
        }

        DataSet ds = db.selectData("select Id,Name,Address,Phone,PinCode from tblInsuranceComp where Name like '%" + prefix + "%'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            string cmpname = "";
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                cmpname = ds.Tables[0].Rows[i]["Name"].ToString() + "^" + ds.Tables[0].Rows[i]["Address"].ToString();

                inscmp.Add(string.Format("{0}", cmpname));
            }
        }

        return inscmp.ToArray();
    }

    [WebMethod]
    public static string[] getMedication(string prefix)
    {
        DBHelperClass db = new DBHelperClass();
        List<string> inscmp = new List<string>();

        if (prefix.IndexOf("'") > 0)
        {
            prefix = prefix.Replace("'", "''");
        }

        DataSet ds = db.selectData("select Medication,MedCode,Fees from tblMedication where Medication like '%" + prefix + "%'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            string cmpname = "";
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                cmpname = ds.Tables[0].Rows[i]["Medication"].ToString() + "^" + ds.Tables[0].Rows[i]["MedCode"].ToString() + "^" + ds.Tables[0].Rows[i]["Fees"].ToString();
                inscmp.Add(string.Format("{0}", cmpname));
            }
        }

        return inscmp.ToArray();
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

    protected void btnCancel_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("ViewServices.aspx");
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

                DataTable dt = db.selectDatatable("select * from View_FU_ServiceMaster where PatientFU_ID=" + id.ToString());
                DataTable dt2 = db.selectDatatable("select * from View_FU_ServiceRendered where FUId=" + id.ToString());
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



        }

        pdfStamper.Close();
        pdfReader.Close();


    }

    protected void DownloadFile(string filePath)
    {

        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }

    protected void btnPrintReport_ServerClick(object sender, EventArgs e)
    {
        PrintRequest(ViewState["FUid"].ToString(), "r");
    }

    protected void btnPrintForm_ServerClick(object sender, EventArgs e)
    {
        PrintRequest(ViewState["FUid"].ToString(), "f");
    }
}