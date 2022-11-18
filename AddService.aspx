﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" CodeFile="AddService.aspx.cs" AutoEventWireup="true" Inherits="AddService" %>


<%--<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">




    <div class="product-payment-inner-st">

        <div id="myTabContent" class="tab-content custom-product-edit">

            <fieldset>
                <legend>Patient Details</legend>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="review-content-section">
                            <div class="row">

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group">
                                        <p class="pstyle">Name</p>
                                        <input type="text" name="txtName" id="txtName" runat="server" class="form-control" placeholder="Name">
                                        <asp:RequiredFieldValidator runat="server" ID="req1" ErrorMessage="Please Enter Name" Display="Dynamic" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group">
                                        <p class="pstyle">Address</p>
                                        <input type="text" name="txtAddress" id="txtAddress" runat="server" class="form-control" placeholder="Address">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">Sex</p>
                                    <div class="form-group">
                                        <asp:DropDownList RepeatDirection="Horizontal" runat="server" ID="ddl_sex" CssClass="form-control" Style="width: 50%; display: inline !important">
                                           <asp:ListItem Value="Male" Text ="Male"></asp:ListItem>
                                            <asp:ListItem Value="Female" Text ="Female"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">DOB</p>
                                    <input type="text"  runat="server" id="txtDOB" style="width: 60%; display: inline;" class="form-control" placeholder="DOB" name="txtDOB">
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">
                                    <p class="pstyle">Occupation</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtOccupation" class="form-control" placeholder="OCCUPATION" name="txtOccupation">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">
                                    <p class="pstyle">Diagnosis</p>
                                    <div class="form-group">
                                        <textarea runat="server" id="txtDiagnosis" name="txtDiagnosis" style="height: 100px !important" class="form-control" placeholder="DIAGNOSIS AND CONCURRENT CONDITIONS"></textarea>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">SYMPTOMS FIRST APPEAR DATE</p>
                                    <div class="form-group">
                                        <input type="text"  runat="server" id="txtFirstSymptomsDate" class="form-control" placeholder="SYMPTOMS FIRST APPEAR" name="txtFirstSymptomsDate">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">FIRST CONSULT DATE</p>
                                    <div class="form-group">

                                        <input type="text"  runat="server" id="txtFirstConsultDate" class="form-control" placeholder="FIRST CONSULT YOU FOR THI CONDITION" name="txtFirstConsultDate">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">

                                    <div class="form-group">
                                        <input class="pull-left" id="chkIsSimlilerCondition" name="chkIsSimlilerCondition" runat="server" type="checkbox">&nbsp;HAS PATIENT EVER HAD SAME OR SIMILAR CONDITION? 
                                    </div>
                                    <div class="form-group" runat="server" style="display: none" id="divIsSimlilerCondition">
                                        <input type="text" runat="server" id="txtSimilerConditionDesc" class="form-control" placeholder="State when and describe" name="txtSimilerConditionDesc">
                                    </div>
                                </div>


                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">

                                    <div class="form-group">
                                        <input class="pull-left" id="chkIsAutomobileAccident" name="chkIsAutomobileAccident" runat="server" type="checkbox">&nbsp; IS CONDITION SOLELY A RESULT OF THIS AUTOMOBILE ACCIDENT? 
                                    </div>
                                    <div class="form-group" runat="server" id="divIsAutomobileAccident">
                                        <input type="text" runat="server" id="txtAutomobileAccidentDesc" class="form-control" placeholder="Explain" name="txtAutomobileAccidentDesc">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">
                                    <p></p>
                                    <div class="form-group">
                                        <input class="pull-left" id="chkchkIsDueToInjury" name="chkIsDueToInjury" runat="server" type="checkbox">&nbsp; IS CONDITION DUE TO INJURY ARISING OUT OF PATIENT’S EMPLOYMENT? 
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">

                                    <p class="pstyle">WILL INJURY RESULT IN SIGNIFICANT DISFIGUREMENT OR PERMANENT DISABILITY?</p>
                                    <div class="form-group">

                                        <asp:DropDownList RepeatDirection="Horizontal" runat="server" ID="ddlPermanentDisablityStatus" CssClass="form-control" Style="width: 30%; display: inline!important">
                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                            <asp:ListItem Value="Not Determinable at this time">Not Determinable at this time</asp:ListItem>
                                        </asp:DropDownList>

                                        <input type="text" runat="server" id="txtPermanentDisablityDesc" class="form-control" placeholder="Explain" style="width: 65%; display: inline!important" name="txtPermanentDisablityDesc">
                                    </div>
                                </div>



                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">PATIENT WAS DISABLED (UNABLE TO WORK) </p>
                                    <div class="form-group">

                                        <input type="text"  runat="server" style="width: 45%; display: initial !important" id="txtEnabletoWorkFrom" class="form-control" placeholder="FROM" name="txtEnabletoWorkFrom">
                                        <input type="text"  runat="server" style="width: 45%; display: initial; float: right !important" id="txtEnabletoWorkThrough" class="form-control" placeholder="THROUGH" name="EnabletoWorkThrough">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">
                                    <p class="pstyle">IF STILL DISABLED THE PATIENT SHOULD BE ABLE TO RETURN TO WORK ON:  </p>
                                    <div class="form-group">

                                        <input type="text"  runat="server" style="width: 45%; display: initial !important" id="txtReturnWorkOn" class="form-control" placeholder="RETURN ON" name="txtReturnWorkOn">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group">
                                        <input class="pull-left" id="chkIsReqRehab" name="chkIsReqRehab" runat="server" type="checkbox">&nbsp;WILL THE PATIENT REQUIRE REHABILITATION AND/OR OCCUPATIONAL THERAPY AS A RESULT OF THE
 INJURIES SUSTAINED IN THIS ACCIDENT? 
                                    </div>

                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group" runat="server" style="display: none" id="divReqRehabDesc">
                                        <input type="text" runat="server" id="txtReqRehabDesc" class="form-control" placeholder="DESCRIBE YOUR RECOMMENDATION" name="txtReqRehabDesc">
                                    </div>
                                </div>

                                <div class="clearfix"></div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">NAME AND ADDRESS OF INSURER OR SELF-INSURER</p>
                                    <div class="form-group">
                                        <textarea name="txtNameOfInsurance" id="txtNameOfInsurance" runat="server" class="form-control" placeholder="NAME AND ADDRESS OF INSURER OR SELF-INSURER"></textarea>
                                        <asp:HiddenField runat="server" ID="hdNameOfInsurance" />
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                    <p class="pstyle">CREATED DATE</p>
                                    <div class="form-group">
                                        <input name="txtInitDate" id="txtInitDate" runat="server" type="text" onfocus="(this.type='date')" class="form-control" placeholder="DATE">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">POLICY HOLDER</p>
                                    <div class="form-group">
                                        <input name="txtPolicyHolder" id="txtPolicyHolder" runat="server" type="text" class="form-control" placeholder="POLICY HOLDER">
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">ACCIDENT DATE</p>
                                    <input name="txtAcciedentDate" id="txtAcciedentDate" runat="server" type="text" class="form-control" placeholder="ACCIDENT DATE" />
                                </div>



                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">NAME AND ADDRESS OF INSURER’S CLAIMS REPRESENTATIVE</p>
                                    <div class="form-group">
                                        <textarea name="txtNameClaimRePresntative" id="txtNameClaimRePresntative" runat="server" class="form-control" placeholder="NAME AND ADDRESS OF INSURER’S CLAIMS REPRESENTATIVE"></textarea>
                                        <asp:HiddenField runat="server" ID="hdNameClaimRePresntative" />
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12" style="display: none">
                                    <p class="pstyle">NAME OF PROVIDER</p>
                                    <div class="form-group">
                                        <input name="txtProviderName" id="txtProviderName" runat="server" type="text" class="form-control" placeholder="NAME OF PROVIDER">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">POLICY NUMBER</p>
                                    <div class="form-group">
                                        <input name="txtPolicyNo" id="txtPolicyNo" runat="server" type="text" class="form-control" placeholder="POLICY NUMBER">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">CLAIM NO</p>
                                    <div class="form-group">
                                        <input name="txtClaimNo" id="txtClaimNo" runat="server" type="text" class="form-control" placeholder="CLAIM NO">
                                    </div>
                                </div>



                                <div class="clearfix"></div>



                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>Report of Service Rendered</legend>
                <div class="row">
                    <div class="product-status mg-b-15">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="product-status-wrap">

                                        <div class="asset-inner">

                                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <p>
                                                        <b>Place of Service including ZIP code:</b> S&M Pharmacy 68-50 Main Street, Flushing, NY 11367
                                                    </p>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <th>DATE OF SERVICE</th>
                                                            <th style="display: none">PLACE OF SERVICE
                                                                <br />
                                                                INCLUDING ZIP CODE</th>
                                                            <th>DESCRIPTION OF TREATMENT OR 
                                                                <br />
                                                                HEALTH SERVICE RENDERED </th>
                                                            <th>FEE SCHEDULE TREATMENT CODE </th>
                                                            <th>CHARGES</th>
                                                            <th>Setting</th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input type="date" runat="server" id="txtDate" class="form-control" />
                                                                <asp:RequiredFieldValidator runat="server" ID="reqdate" ValidationGroup="grp_list" ControlToValidate="txtDate" ErrorMessage="Please Enter Date" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="display: none">
                                                                <textarea runat="server" id="txtPlace" class="form-control">S&M Pharmacy
                                                                    68-50 Main Street
                                                                    Flushing, NY 11367
                                                                </textarea>
                                                            </td>
                                                            <td>
                                                                <textarea runat="server" id="txtDesc" class="form-control"></textarea>
                                                            </td>
                                                            <td>
                                                                <input type="text" runat="server" id="txtCode" class="form-control" />
                                                            </td>
                                                            <td>
                                                                <input type="text" runat="server" id="txtCharges" class="form-control" />
                                                            </td>
                                                            <td>
                                                                <%--  <button data-toggle="tooltip" title="Add New" runat="server" onserverclick="BtnAdd_Click" causesvalidation="false" class="pd-setting-ed"><i class="fa fa-plus-square" aria-hidden="true"></i></button>--%>
                                                                <asp:LinkButton ID="BtnAdd" runat="server" data-toggle="tooltip" ValidationGroup="grp_list" title="Add New" OnClick="BtnAdd_Click" CausesValidation="false" class="pd-setting-ed"><i class="fa fa-plus-square" aria-hidden="true"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <asp:Repeater ID="repReport" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td><%#Eval("DateOfService","{0:MM/dd/yyyy}") %></td>
                                                                    <td style="display: none"><%#Eval("PlaceOfService") %></td>
                                                                    <td><%#Eval("TreatmentDesc") %></td>
                                                                    <td><%#Eval("TreatmentCode") %></td>
                                                                    <td><%#Eval("Charges") %></td>
                                                                    <td>
                                                                        <asp:LinkButton ID="BtnDelete" runat="server" Text="Remove" CausesValidation="false"></asp:LinkButton>

                                                                        <%-- <asp:LinkButton ID="BtnAdd" runat="server" data-toggle="tooltip" title="Add New" OnClick="BtnAdd_Click" CausesValidation="false" class="pd-setting-ed"><i class="fa fa-plus-square" aria-hidden="true"></i></asp:LinkButton>--%>
                                                                        <%--  <button data-toggle="tooltip" title="Remove" class="pd-setting-ed"><i class="fa fa-trash" aria-hidden="true"></i></button>--%>

                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <tr>
                                                            <td></td>

                                                            <td></td>
                                                            <td></td>
                                                            <td style="float: right">
                                                                <b>Total :</b>
                                                                <asp:TextBox CssClass="form-control" ID="txtTotal" ReadOnly="true" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                    </table>

                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="clearfix"></div>

                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>Other Details</legend>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="review-content-section">
                            <div class="row">

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">TREATING PROVIDER’S NAME</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtTreatingProviderName" class="form-control" placeholder="TREATING PROVIDER’S NAME" name="txtTreatingProviderName">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">TITLE</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtTitle" class="form-control" placeholder="TITLE" name="txtTitle">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">LICENSE OR CERTIFICATION NUMBER</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtLicenceForCeriNo" class="form-control" placeholder="LICENSE OR CERTIFICATION NUMBER" name="txtLicenceForCeriNo">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">BUSINESS RELATIONSHIP CHECK APPLICABLE BOX</p>
                                    <div class="form-group">

                                        <asp:DropDownList RepeatDirection="Horizontal" runat="server" ID="ddlBusinessRelationShip" CssClass="form-control" Style="width: 60% !important">
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="EMPLOYEE">EMPLOYEE</asp:ListItem>
                                            <asp:ListItem Value="INDEPENDENT CONTRACTOR">INDEPENDENT CONTRACTOR</asp:ListItem>
                                            <asp:ListItem Value="OTHER">OTHER</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">BUSINESS RELATIONSHIP DESC</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtBusinessRelationShipOtherDesc" class="form-control" placeholder="BUSINESS RELATIONSHIP DESC" name="txtBusinessRelationShipOtherDesc">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">LIST THE OWNER AND PROFESSIONAL LICENSING CREDENTIALS OF ALL OWNERS</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtAttchment" class="form-control" placeholder="LIST THE OWNER AND PROFESSIONAL LICENSING CREDENTIALS OF ALL OWNERS" name="txtAttchment">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <p class="pstyle">ESTIMATED DURATION OF FUTURE TREATMENT</p>
                                    <div class="form-group">
                                        <input type="text" runat="server" id="txtEstimateDuration" class="form-control" placeholder="ESTIMATED DURATION OF FUTURE TREATMENT" name="txtEstimateDuration">
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                    <div class="form-group">
                                        <input class="pull-left" id="chkIsUndesrYourcCare" name="chkIsUndesrYourcCare" runat="server" type="checkbox">&nbsp; IS PATIENT STILL UNDER YOUR CARE FOR THIS CONDITION? 
                                    </div>
                                </div>





                            </div>

                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="" style="float: right">


                                        <button class="btn btn-primary waves-effect waves-light" runat="server" onserverclick="btnSave_ServerClick" id="btnSave">Save</button>
                                        &nbsp;
                                        <button class="btn btn-default waves-effect" runat="server" onserverclick="btnCancel_ServerClick" id="btnCancel" causesvalidation="false">Cancel</button>

                                        <button class="btn btn-warning waves-effect" runat="server" style="display: none" onserverclick="btnPrintReport_ServerClick" id="btnPrintReport" causesvalidation="false">Print Report</button>
                                        <button class="btn btn-info waves-effect" runat="server" style="display: none" onserverclick="btnPrintForm_ServerClick" id="btnPrintForm" causesvalidation="false">Print Form 2</button>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

        </div>
    </div>

    <script>

        //$(function () {

        //    LoadData();

        //})



        function downloadAll(files, targetFolder) {
            if (files.length == 0) return;


            files.forEach(function (item) {

                var fname = item.split('/')[2];

                var theAnchor = $('<a />')
                    .attr('href', item)

                    .attr('download', fname)

                    .appendTo('body');

                theAnchor[0].click();
                theAnchor.remove();
            });

            return false;
        }


        function LoadData(foldername) {



            var obj = {};
            obj.FolderName = foldername;

            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("AddService.aspx/getDownloadFiles")%>',
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {

                    downloadAll(r.d, foldername);
                }
            });
            return false;
        }


    </script>


    <script src="Js/jquery-1.8.0.js"></script>
    <script src="Js/jquery-ui.js"></script>

    <script>
        $(document).ready(function () {


            $("[id$=chkIsSimlilerCondition]").change(function () {

                if ($(this).is(":checked")) {
                    $("[id*=divIsSimlilerCondition]").show();
                }
                else {
                    $("[id*=divIsSimlilerCondition]").hide();
                }
            })

            $("[id$=chkIsAutomobileAccident]").change(function () {

                if ($(this).is(":checked")) {
                    $("[id*=divIsAutomobileAccident]").hide();
                }
                else {
                    $("[id*=divIsAutomobileAccident]").show();
                }
            })

            $("[id$=chkIsReqRehab]").change(function () {

                if ($(this).is(":checked")) {
                    $("[id*=divReqRehabDesc]").show();
                }
                else {
                    $("[id*=divReqRehabDesc]").hide();
                }
            })

            $('#btnNext_tab1').click(function (e) {

                $('#myTabedu1 a[href="#tab2"]').tab('show');



            })

            $('#btnNext_tab2').click(function (e) {

                $('#myTabedu1 a[href="#tab3"]').tab('show');
            })

            $('#btnPrev_tab2').click(function (e) {

                $('#myTabedu1 a[href="#tab1"]').tab('show');
            })

            $('#btnNext_tab3').click(function (e) {

                $('#myTabedu1 a[href="#tab4"]').tab('show');
            })

            $('#btnPrev_tab3').click(function (e) {

                $('#myTabedu1 a[href="#tab2"]').tab('show');
            })
            $('#btnPrev_tab4').click(function (e) {

                $('#myTabedu1 a[href="#tab3"]').tab('show');
            })


            var $j = jQuery.noConflict();
            $j("[id$=txtNameOfInsurance]").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $j('[id$=txtNameOfInsurance]').val() };
                    $j.ajax({
                        url: "AddService.aspx/getInsComp",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($j.map(data.d, function (item) {
                                return {
                                    value: item.replace('^', ' '),
                                    details: item.replace('^', '\n')
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)

                            // console.log("Ajax Error!");  
                        }
                    });
                },
                select: function (event, ui) {

                    debugger;

                    $j("[id$=hdNameOfInsurance]").val(ui.item.details);

                },
                minLength: 2 //This is the Char length of inputTextBox  
            });

            $j("[id$=txtNameClaimRePresntative]").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $j('[id$=txtNameClaimRePresntative]').val() };
                    $j.ajax({
                        url: "AddService.aspx/getInsComp",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($j.map(data.d, function (item) {
                                return {
                                    value: item.replace('^', ' '),
                                    details: item.replace('^', '\n')
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)
                            // console.log("Ajax Error!");  
                        }
                    });
                },
                select: function (event, ui) {

                    debugger;

                    $j("[id$=txtNameClaimRePresntative]").val(ui.item.details);

                },
                minLength: 2 //This is the Char length of inputTextBox  
            });



            $j("[id$=txtDesc]").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $j('[id$=txtDesc]').val() };
                    $j.ajax({
                        url: "AddService.aspx/getMedication",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },

                        success: function (data) {
                            response($j.map(data.d, function (item) {
                                return {
                                    value: item.split('^')[0],
                                    code: item.split('^')[1],
                                    fee: item.split('^')[2]

                                }
                            }))
                        },

                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)
                            // console.log("Ajax Error!");  
                        }
                    });
                },
                select: function (event, ui) {

                    debugger;
                    $("[id$=txtCode]").val(ui.item.code);
                    $("[id$=txtCharges]").val(ui.item.fee);
                },
                minLength: 2 //This is the Char length of inputTextBox  
            });

        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();

        var $j = jQuery.noConflict();

        prm.add_endRequest(function () {


            $j("[id$=txtDesc]").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $j('[id$=txtDesc]').val() };
                    $j.ajax({
                        url: "AddService.aspx/getMedication",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },

                        success: function (data) {
                            response($j.map(data.d, function (item) {
                                return {
                                    value: item.split('^')[0],
                                    code: item.split('^')[1],
                                    fee: item.split('^')[2]

                                }
                            }))
                        },

                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)
                            // console.log("Ajax Error!");  
                        }
                    });
                },
                select: function (event, ui) {

                    debugger;
                    $("[id$=txtCode]").val(ui.item.code);
                    $("[id$=txtCharges]").val(ui.item.fee);
                },
                minLength: 2 //This is the Char length of inputTextBox  
            });
        });

    </script>
</asp:Content>
