<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ePharmaTrax.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>PainTrax</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- favicon
		============================================ -->
    <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.ico" />
    <!-- Google Fonts
		============================================ -->
    <link href="https://fonts.googleapis.com/css?family=Play:400,700" rel="stylesheet" />
    <!-- Bootstrap CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <!-- Bootstrap CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
    <!-- owl.carousel CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/owl.carousel.css" />
    <link rel="stylesheet" href="assets/css/owl.theme.css" />
    <link rel="stylesheet" href="assets/css/owl.transitions.css" />
    <!-- animate CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/animate.css" />
    <!-- normalize CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/normalize.css" />
    <!-- main CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/main.css" />
    <!-- morrisjs CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/morrisjs/morris.css" />


    <!-- style CSS
		============================================ -->
    <link rel="stylesheet" href="assets/style.css">
    <!-- responsive CSS
		============================================ -->
    <link rel="stylesheet" href="assets/css/responsive.css" />
    <!-- modernizr JS
		============================================ -->
    <script src="assets/js/vendor/modernizr-2.8.3.min.js"></script>
</head>
<body>


    <div class="error-pagewrap">
        <div class="error-page-int">
            <div class="text-center m-b-md custom-login">
                <h3>ePharmaTrax</h3>

            </div>
            <div class="content-error">
                <div class="hpanel">
                    <div class="panel-body">
                        <form runat="server" id="loginForm">
                            <div class="form-group col-lg-12">
                                <label class="control-label" for="username">User Name</label>
                                <input type="text" placeholder="UserName" runat="server" title="Please enter you username" required="" value="" name="txtusername" id="txtusername" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="val_uname" ErrorMessage="Please Enter User Name" ControlToValidate="txtusername" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Your unique username to app</span>--%>
                            </div>
                            <div class="clearfix"></div>
                            <div class="form-group col-lg-6">
                                <label class="control-label" for="password">First Name</label>
                                <input type="text" title="Please enter your first name" placeholder="First Name" required="" value="" name="txtFname" runat="server" id="txtFname" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Enter FirstName" ControlToValidate="txtFname" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>
                            <div class="form-group col-lg-6">
                                <label class="control-label" for="password">Last Name</label>
                                <input type="text" title="Please enter your last name" placeholder="Last Name" value="" name="txtLname" runat="server" id="txtLname" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ErrorMessage="Enter LastName" ControlToValidate="txtLname" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>
                            <div class="form-group col-lg-6">
                                <label class="control-label" for="password">Password</label>
                                <input type="password" title="Please enter your password" placeholder="******" value="" name="txtPass" runat="server" id="txtPass" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ErrorMessage="Enter Password" ControlToValidate="txtPass" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>
                            <div class="form-group col-lg-6">
                                <label class="control-label" for="password">Confirm Password</label>
                                <input type="password" title="Please enter confirm password" placeholder="******" value="" name="txtCPass" runat="server" id="txtCPass" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ErrorMessage="Enter Cofirm Password" ControlToValidate="txtCPass" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>

                            <div class="form-group col-lg-6">
                                <label class="control-label" for="password">Email</label>
                                <input type="text" title="Please enter email" placeholder="example@example.com" value="" name="txtEmail" runat="server" id="txtEmail" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ErrorMessage="Enter Email" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>

                            <div class="form-group col-lg-6">
                                <label class="control-label" for="password">Phone</label>
                                <input type="text" title="Please enter email" placeholder="(123)-1234-12346" value="" name="txtPhone" runat="server" id="txtPhone" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ErrorMessage="Enter Email" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>

                            <button class="btn btn-success btn-block loginbtn" id="btnSingup" runat="server" onserverclick="btnSingup_ServerClick">
                                SignUp</button>

                            <a class="btn btn-default btn-block loginbtn" href="Login.aspx">Login</a>

                        </form>
                    </div>
                </div>
            </div>
            <div class="text-center login-footer">
                <p>Copyright © <%= System.DateTime.Now.Year.ToString() %>. All rights reserved. </p>
            </div>
        </div>
    </div>



</body>
</html>
