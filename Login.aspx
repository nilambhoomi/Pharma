<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ePharmaTrax.Login" %>

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
                            <div class="form-group">
                                <label class="control-label" for="username">Username</label>
                                <input type="text" placeholder="example@gmail.com" runat="server" title="Please enter username" required="" value="" name="txtusername" id="txtusername" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="val_uname" ErrorMessage="Please Enter User Name" ControlToValidate="txtusername" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Your unique username to app</span>--%>
                            </div>
                            <div class="form-group">
                                <label class="control-label" for="password">Password</label>
                                <input type="password" title="Please enter your password" placeholder="******" required="" value="" name="txtpassword" runat="server" id="txtpassword" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage="Please Enter Password" ControlToValidate="txtpassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>
                             <div class="form-group">
                                <label class="control-label" for="password">Client Id</label>
                                <input type="text" title="Please enter your client id" placeholder="Please enter client id" required="" value="" name="txtclientid" runat="server" id="txtclientid" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ErrorMessage="Please Enter Client Id" ControlToValidate="txtclientid" Display="Dynamic"></asp:RequiredFieldValidator>
                                <%--<span class="help-block small">Yur strong password</span>--%>
                            </div>
                            <div class="checkbox login-checkbox">
                                <label>
                                    <input type="checkbox" class="i-checks" />
                                    Remember me
                                </label>

                            </div>
                            <button class="btn btn-success btn-block loginbtn" id="btnLogin" runat="server" onserverclick="btnLogin_ServerClick">
                                Login</button>

                             <a class="btn btn-default btn-block loginbtn" href="Register.aspx" style='display:none'>Signup</a>

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
