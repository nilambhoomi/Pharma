<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" Inherits="ePharmaTrax.AddUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main" runat="server">

    <div class="row">
        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
            <div class="sparkline12-list">
                <div class="main-sparkline12-hd">
                    <h1>Users Details</h1>
                </div>
            </div>
            <div class="sparkline12-graph">
                <div class="basic-login-form-ad">

                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="all-form-element-inner">

                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <label class="login2 pull-right pull-right-pro">Login Id</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" runat="server" id="txtLoginId" class="form-control" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <label class="login2 pull-right pull-right-pro">Password</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <input type="password" runat="server" id="txtPassword" class="form-control" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <label class="login2 pull-right pull-right-pro">First Name</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" runat="server" id="txtFname" class="form-control" />
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <label class="login2 pull-right pull-right-pro">Last Name</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" runat="server" id="txtLname" class="form-control" />
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <label class="login2 pull-right pull-right-pro">Email</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <input type="email" runat="server" id="txtEmail" class="form-control" />
                                        </div>
                                    </div>
                                </div>

                               

                                <div class="form-group-inner">
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                                            <label class="login2 pull-right pull-right-pro">Phone</label>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" runat="server" id="txtPhone" class="form-control" />
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group-inner">
                                    <div class="login-btn-inner">
                                        <div class="row">
                                            <div class="col-lg-3"></div>
                                            <div class="col-lg-9">
                                                <div class="login-horizental cancel-wp pull-left form-bc-ele">
                                                    <button class="btn btn-white" runat="server" id="btnCancel" type="submit" onserverclick="btnCancel_ServerClick" >Cancel</button>
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
</asp:Content>
