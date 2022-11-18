<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="ePharmaTrax.ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main" runat="server">
    <div class="product-status mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="product-status-wrap">
                        <h4>User List</h4>

                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-8 col-xs-12">
                                <div class="form-group">
                                    <input name="txtSearch" id="txtSearch" type="text" runat="server" class="form-control" placeholder="TYPE ENTERING">
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12">
                                <button type="submit" class="btn btn-primary waves-effect waves-light" runat="server" onserverclick="btnSearch_ServerClick" id="btnSearch">Search</button>
                                &nbsp;
                                  <button type="submit" class="btn btn-warning" runat="server" onserverclick="btnClear_ServerClick" id="btnClear">Clear</button>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-4 col-xs-12">
                                <button type="submit" class="btn btn-primary waves-effect waves-light" runat="server" onserverclick="btnAdd_ServerClick" id="btnAdd">Add new</button>
                            </div>
                        </div>

                        <div class="asset-inner">

                            <asp:Repeater ID="rpview" runat="server">
                                <HeaderTemplate>

                                    <table>
                                        <tr>
                                            <th>
                                                <asp:LinkButton runat="server" ID="lnkSort" CommandArgument="LoginID" OnClick="lnkSort_Click" Text="Login Id"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument="FirstName" OnClick="lnkSort_Click" Text="First Name"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton2" CommandArgument="LastName" OnClick="lnkSort_Click" Text="Last Name"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton3" CommandArgument="EmailId" OnClick="lnkSort_Click" Text="Email"></asp:LinkButton>
                                            </th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton4" CommandArgument="Ph_No" OnClick="lnkSort_Click" Text="Phone"></asp:LinkButton>
                                            </th>


                                            <th>Action</th>

                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("LoginID") %></td>
                                        <td><%# Eval("FirstName") %></td>
                                        <td><%# Eval("LastName") %></td>
                                        <td><%# Eval("EmailId") %></td>
                                        <td><%# Eval("Ph_No") %></td>

                                        <td>
                                            <a data-toggle="tooltip" title="Edit" href="<%# "AddUsers.aspx?id=" + Eval("user_Id").ToString() %>" class="pd-setting-ed"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>
                                            <a data-toggle="tooltip" title="Delete" onclick="return confirm('Are sure you want to delet ?')" href="<%# "ViewMedication.aspx?id=" + Eval("user_Id").ToString() %>" class="pd-setting-ed"><i class="fa fa-trash-o" aria-hidden="true"></i></a>
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
                                                OnClick="lnkPage_Click" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
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

    <script src="Js/jquery-1.8.0.js"></script>
    <script src="Js/jquery-ui.js"></script>

    <script>
        $(document).ready(function () {
             var $j = jQuery.noConflict();
            $j("[id$=txtSearch]").autocomplete({
                source: function (request, response) {
                    var param = { prefix: $j('[id$=txtSearch]').val() };
                    $j.ajax({
                        url: "ViewUser.aspx/getPatientName",
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

</asp:Content>
