<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ePharmaTrax.Dashboard" %>



<asp:Content ContentPlaceHolderID="cph_main" ID="cp_main" runat="server">

    <style>
        .row {
            margin: 0px;
        }

        .scale {
            transform: scale(1,1);
        }

        @media screen and (min-width: 480px) {
            .scale {
                transform: scale(1.10,1.10);
                margin-bottom: 30px;
            }

            .left {
                padding-left: 30px;
            }

            .right {
                padding-right: 30px;
            }
        }

        @media screen and (min-width: 720px) {
            .scale {
                transform: scale(1.50,1.50);
                margin-left: 120px;
                margin-right: 120px;
            }

            .left {
                padding-left: 100px;
            }

            .right {
                padding-right: 100px;
            }
        }
    </style>

    <div class="product-payment-inner-st">
        <center>
        <div class="row scale " style="margin-top: 50px;">
            <div class="col-md-6 col-xs-6 left">
                <a href="AddService.aspx"  style="text-decoration: none;">
                    <img src="img/add.png" width="80px" style="border: none" />
                    <h4 style="margin-top:10px">Add Patient</h4>
                </a>
            </div>

            <div class="col-md-6 col-xs-6 right">
                <a href="ViewServices.aspx" style="text-decoration: none;">
                    <img src="img/list2.png" width="80px" style="border: none" />
                    <h4 style="margin-top:10px">View Patient</h4>
                </a>
            </div>

            <div class="clearfix"></div>
            <br />

            <div class="col-md-6 col-xs-6 left">
                <a href="ViewPrint.aspx" style="text-decoration: none;">
                    <img src="img/pcc.png" width="80px" style="border: none" />
                    <h4 style="margin-top:10px">Print</h4>
                </a>
            </div>
           
             <div class="col-md-6 col-xs-6 right">
                <a href="#"  style="text-decoration: none;">
                    <img src="img/seetings.png" width="80px" style="border: none" />
                    <h4 style="margin-top:10px">Setting</h4>
                </a>
            </div>
        </div>
            </center>
    </div>

</asp:Content>
