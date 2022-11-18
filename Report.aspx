<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="ePharmaTrax.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_main" runat="server">

    <div class="product-status mg-b-15">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="product-status-wrap">
                        <h4>Report</h4>


                        <div class="row">
                            <div class="col-lg-3 col-md-6 col-sm-8 col-xs-12">
                                <div class="form-group">
                                    <input name="txtSDate" id="txtSDate" type="date" runat="server" class="form-control" placeholder="FROM DATE">
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-8 col-xs-12">
                                <div class="form-group">
                                    <input name="txtEDate" id="txtEDate" type="date" runat="server" class="form-control" placeholder="TO DATE">
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-2 col-sm-4 col-xs-12">
                                <button type="submit" class="btn btn-primary waves-effect waves-light" runat="server" onserverclick="btnSearch_ServerClick" id="btnSearch">Search</button>
                                &nbsp;
                                  <button type="submit" class="btn btn-warning" runat="server" onserverclick="btnClear_ServerClick" id="btnClear">Clear</button>
                                &nbsp;
                                  <button type="submit" class="btn btn-info" runat="server" onserverclick="btnExcel_ServerClick"
                                      id="btnExcel">
                                      Export Excel</button>
                            </div>

                        </div>
                        <div class="clearfix"></div>

                        <div class="asset-inner">

                            <asp:Repeater ID="rpview" runat="server">
                                <HeaderTemplate>

                                    <table>
                                        <tr>


                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument="PatientName" OnClick="lnkSort_Click" Text="Name"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton2" CommandArgument="Address" OnClick="lnkSort_Click" Text="Address"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton3" CommandArgument="NameOfInsurance" OnClick="lnkSort_Click" Text="Insurance"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton4" CommandArgument="ClaimNo" OnClick="lnkSort_Click" Text="Claim#"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="LinkButton5" CommandArgument="AcciedentDate" OnClick="lnkSort_Click" Text="DOA"></asp:LinkButton></th>
                                            <th>
                                                <asp:LinkButton runat="server" ID="lnkSort" CommandArgument="InitDate" OnClick="lnkSort_Click" Text="Date"></asp:LinkButton></th>

                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>


                                        <td><%# Eval("PatientName") %></td>
                                        <td><%# Eval("Address") %></td>
                                        <td><%# Eval("NameOfInsurance") %></td>
                                        <td><%# Eval("ClaimNo") %></td>
                                        <td><%# Eval("AcciedentDate","{0:d}") %></td>
                                        <td><%# Eval("InitDate","{0:d}") %></td>

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

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
