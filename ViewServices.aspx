<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" CodeFile="ViewServices.aspx.cs" AutoEventWireup="true" Inherits="ViewServices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main" runat="server">
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .Grid, .ChildGrid {
            border: 1px solid #ccc;
        }

            .Grid td, .Grid th {
                border: 1px solid #ccc;
            }

            .Grid th {
                background-color: #B8DBFD;
                color: #333;
                font-weight: bold;
            }

            .ChildGrid td, .ChildGrid th {
                border: 1px solid #ccc;
            }

            .ChildGrid th {
                background-color: #ccc;
                color: #333;
                font-weight: bold;
            }
    </style>
    <div class="product-status mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="product-status-wrap">
                        <h4>Patient List</h4>


                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-8 col-xs-12">
                                <div class="form-group">
                                    <input name="txtNameOfInsurance" id="txtSearch" type="text" runat="server" class="form-control" placeholder="TYPE ENTERING">
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12">
                                <button type="submit" class="btn btn-primary waves-effect waves-light" runat="server" onserverclick="btnSearch_ServerClick" id="btnSearch">Search</button>
                                &nbsp;
                                  <button type="submit" class="btn btn-warning" runat="server" onserverclick="btnClear_ServerClick" id="btnClear">Clear</button>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12">
                                <button type="submit" class="btn btn-primary waves-effect waves-light" runat="server" onserverclick="btnAdd_ServerClick" id="btnAdd">Add Patient</button>
                            </div>
                        </div>
                        <div class="clearfix"></div>

                        <div class="asset-inner">

                            <asp:Repeater ID="rpview" runat="server" OnItemDataBound="rpview_ItemDataBound">
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <th scope="col">&nbsp;
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="lnkSort" CommandArgument="CreatedDate" OnClick="lnkSort_Click" Text="Date"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument="PatientName" OnClick="lnkSort_Click" Text="Name"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton2" CommandArgument="Address" OnClick="lnkSort_Click" Text="Address"></asp:LinkButton></th>
                                            <th>Action</th>

                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%--<img alt="" style="cursor: pointer" src="img/plus.png" />--%>
                                             <asp:Literal ID="plusimage" runat="server"></asp:Literal>
                                            <asp:Panel ID="pnlfudetails" runat="server" Style="display: none">
                                                <asp:Repeater ID="rptfudetails" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="ChildGrid" border="1">
                                                            <tr>
                                                                <th scope="col" style="width: 150px">CreatedDate
                                                                </th>
                                                                <th scope="col" style="width: 150px">PatientName
                                                                </th>
                                                                <th scope="col" style="width: 150px">Address
                                                                </th>
                                                                <th>Action</th>
                                                            </tr>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%# Eval("CreatedDate","{0:MM/dd/yyyy}") %></td>
                                                            <td><%# Eval("PatientName") %></td>
                                                            <td><%# Eval("Address") %></td>
                                                            <td>
                                                                <a data-toggle="tooltip" title="EditFU" href="<%# "AddServiceFU.aspx?FUid=" + Eval("PatientFU_ID").ToString()+"&Id=" + Eval("PatientService_ID").ToString()  %>" class="pd-setting-ed"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                                                &nbsp;&nbsp;
                                                                 &nbsp;&nbsp;
                                                               <a data-toggle="tooltip" title="Delete" onclick="return confirm('Are sure you want to delet ?')" href="<%# "ViewServices.aspx?FUid=" + Eval("PatientFU_ID").ToString() %>" class="pd-setting-ed"><i class="fa fa-trash-o" aria-hidden="true"></i></a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </asp:Panel>
                                            <asp:HiddenField ID="hfpatientId" runat="server" Value='<%# Eval("Patient_Id") %>' />
                                        </td>
                                        <td><%# Eval("CreatedDate","{0:MM/dd/yyyy}") %></td>
                                        <td><%# Eval("PatientName") %></td>
                                        <td><%# Eval("Address") %></td>
                                        <td>
                                            <a data-toggle="tooltip" title="AddFU" href="<%# "AddServiceFU.aspx?id=" + Eval("Patient_Id").ToString() %>" class="pd-setting-ed"><i class="fa fa-clipboard" aria-hidden="true"></i></a>
                                            &nbsp;&nbsp;
                                            <a data-toggle="tooltip" title="Edit" href="<%# "AddService.aspx?id=" + Eval("Patient_Id").ToString() %>" class="pd-setting-ed"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                            &nbsp;&nbsp;
                                             <a data-toggle="tooltip" title="Delete" onclick="return confirm('Are sure you want to delet ?')" href="<%# "ViewServices.aspx?id=" + Eval("Patient_Id").ToString() %>" class="pd-setting-ed"><i class="fa fa-trash-o" aria-hidden="true"></i></a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>


                        </div>
                        <div class="custom-pagination">

                            <ul class="pagination">
                                <asp:Repeater ID="rptPager" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "active" : "" %>'
                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>

                            <%--   <ul class="pagination">
                                <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                                <li class="page-item"><a class="page-link" href="#">1</a></li>
                                <li class="page-item"><a class="page-link" href="#">2</a></li>
                                <li class="page-item"><a class="page-link" href="#">3</a></li>
                                <li class="page-item"><a class="page-link" href="#">Next</a></li>
                            </ul>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>

        //$(function () {

        //    LoadData();

        //})



        function downloadAll(files, targetFolder) {
            if (files.length == 0) return;


            files.forEach(function (item) {

                var fname = item.split('/')[1];

                var theAnchor = $('<a />')
                    .attr('href', item)
                    //.attr('href', '123_03102021122319/123_1_Service.pdf')
                    //.attr('download', file[0])
                    .attr('download', fname)
                    // Firefox does not fires click if the link is outside
                    // the DOM
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
                url: '<%= ResolveUrl("ViewServices.aspx/getDownloadFiles")%>',
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
            var $j = jQuery.noConflict();
            $j("[id$=txtSearch]").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $j('[id$=txtSearch]').val() };
                    $j.ajax({
                        url: "ViewServices.aspx/getName",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($j.map(data.d, function (item) {
                                return {
                                    value: item

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

                    $j("[id$=txtSearch]").val(ui.item.value);

                },
                minLength: 2 //This is the Char length of inputTextBox  
            });
        })
    </script>
    <script type="text/javascript">
        //$("body").on("click", "[src*=plus]", function () {
        //    $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        //    $(this).attr("src", "images/minus.png");
        //});
        //$("body").on("click", "[src*=minus]", function () {
        //    $(this).attr("src", "images/plus.png");
        //    $(this).closest("tr").next().remove();
        //});
        $(document).ready(function () {
            $("body").on("click", "[src*=plus]", function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
                $(this).attr("src", "img/minus.png");
            });
            $("body").on("click", "[src*=minus]", function () {
                $(this).attr("src", "img/plus.png");
                $(this).closest("tr").next().remove();
            });
        });
    </script>
</asp:Content>
