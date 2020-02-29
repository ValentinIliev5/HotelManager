<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.Admin.Clients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ml-2"><%: Title %></h2>

    <div class="row">
        <div class="col-md-12">
            <section id="loginForm">
                <div>
                    <asp:ListView ID="ClientList"
                        DataKeyNames="ID"
                        runat="server"
                        DataSourceID="ClientDataSource">
                        <LayoutTemplate>
                            <table id="dataTable" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:LinkButton ID="SortByFullName" runat="server" Text="Full Name" CommandArgument="FullName" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByPhone" runat="server" Text="Phone" CommandArgument="Phone" CommandName="Sort" /></th>
                                        <th>Adult</th>
                                        <th>Delete</th>
                                        <th>Edit</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server" />
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Full Name</th>
                                        <th>Phone</th>
                                        <th>Adult</th>
                                        <th>Delete</th>
                                        <th>Edit</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Phone" runat="server" Text='<%# Eval("Phone")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="AdultCheckBox" runat="server"  Enabled="false" Checked='<%# Eval("IsAdult").ToString() == "1"%>' />
                                </td>
                                <td>
                                    <a class="btn btn-info" href="#<%# Eval("ID") %>">Edit</a>
                                </td>
                                <td>
                                    <asp:Button Text="Delete" ID="DeleteCommandAction" CommandArgument='<%# Eval("ID") %>' OnCommand="DeleteCommandAction_Command" CssClass="btn btn-danger" runat="server"></asp:Button>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td>No data was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <EmptyItemTemplate>
                            <td />
                        </EmptyItemTemplate>
                    </asp:ListView>
                </div>
                <div class="form-inline">
                    <asp:DataPager ID="ClientDataPager" class="btn-group pager-buttons" runat="server" PageSize="1" PagedControlID="ClientList">
                        <Fields>
                            <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" RenderNonBreakingSpacesBetweenControls="false" />
                            <asp:NumericPagerField ButtonType="Button" RenderNonBreakingSpacesBetweenControls="false" NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                            <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" RenderNonBreakingSpacesBetweenControls="false" />
                        </Fields>
                    </asp:DataPager>
                    <asp:DropDownList ID="PageDropDown" CssClass="form-control " Width="60px" OnSelectedIndexChanged="PageDropDown_SelectedIndexChanged" AutoPostBack="true" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                    </asp:DropDownList>
                    <a class="btn btn-success pull-right" href="Clients/AddClient">Add Client</a>
                </div>
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false"></asp:PlaceHolder>
                </div>
                <asp:ObjectDataSource ID="ClientDataSource" runat="server" SelectMethod="GetClients" SortParameterName="ColumnName" TypeName="HotelManagerReservationsPt3.Models.ListClient"></asp:ObjectDataSource>
            </section>
        </div>
    </div>

</asp:Content>
