<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditInsurance.aspx.cs" Inherits="ePharmaTrax.EditInsurance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main" runat="server">


    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="sparkline12-list">
                <div class="sparkline12-hd">
                    <div class="main-sparkline12-hd">
                        <h1>Insurance Details</h1>
                    </div>
                </div>
                <div class="sparkline12-graph">
                    <div class="basic-login-form-ad">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="all-form-element-inner">

                                    <div class="form-group-inner">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <label class="login2 pull-right pull-right-pro">Name</label>
                                            </div>
                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                 <textarea type="text" runat="server" id="txtName" class="form-control" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="form-group-inner">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <label class="login2 pull-right pull-right-pro">Address</label>
                                            </div>
                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                <textarea runat="server" id="txt_address" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group-inner">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <label class="login2 pull-right pull-right-pro">Pin Code</label>
                                            </div>
                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                <input type="text" runat="server" id="txt_pin" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group-inner">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12">
                                                <label class="login2 pull-right pull-right-pro">Phone No</label>
                                            </div>
                                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                                <input type="text" runat="server" id="txt_ph_no" class="form-control" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="form-group-inner">
                                        <div class="login-btn-inner">
                                            <div class="row">
                                                <div class="col-lg-3"></div>
                                                <div class="col-lg-9">
                                                    <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                        <button class="btn btn-white" runat="server" id="btnCancel" onserverclick="btnCancel_ServerClick" type="submit">Cancel</button>
                                                        <button class="btn btn-sm btn-primary login-submit-cs" runat="server" id="btnSave" onserverclick="btnSave_ServerClick" type="submit">Save Change</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
