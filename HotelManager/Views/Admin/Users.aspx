<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ml-2"><%: Title %></h2>

    <div class="row">
        <div class="col-md-12">
            <section id="loginForm">
                <div>
                    <asp:ListView ID="UserList"
                        DataKeyNames="UserID"
                        runat="server"
                        DataSourceID="UserDataSource">
                        <LayoutTemplate>
                            <table id="dataTable" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:LinkButton ID="SortByUsername" runat="server" Text="Username" CommandArgument="Username" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByEmail" runat="server" Text="Email" CommandArgument="Email" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByFullName" runat="server" Text="Full Name" CommandArgument="FullName" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByEGN" runat="server" Text="EGN" CommandArgument="EGN" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByPhone" runat="server" Text="Phone" CommandArgument="Phone" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByPhoneHiredDate" runat="server" Text="Hired Date" CommandArgument="HiredDate" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByPhoneFiredDate" runat="server" Text="Fired Date" CommandArgument="FiredDate" CommandName="Sort" /></th>
                                        <th>Fire</th>
                                        <th>Edit</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server" />
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Username</th>
                                        <th>Email</th>
                                        <th>Full Name</th>
                                        <th>EGN</th>
                                        <th>Phone</th>
                                        <th>Hired Date</th>
                                        <th>Fired Date</th>
                                        <th>Fire</th>
                                        <th>Edit</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Username" runat="server" Text='<%# Eval("Username")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Email" runat="server" Text='<%# Eval("Email")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="EGN" runat="server" Text='<%# Eval("EGN")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Phone" runat="server" Text='<%# Eval("Phone")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="HiredDate" runat="server" Text='<%# Eval("HiredDate")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="FiredDate" runat="server" Text='<%# Eval("FiredDate")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Fire" ID="FireCommandAction" CommandArgument='<%# Eval("UserID") %>' OnCommand="FireCommandAction_Command" CssClass="btn btn-danger" runat="server" Enabled='<%# Eval("IsActive").ToString() == "1"%>'></asp:Button>
                                </td>
                                <td>
                                    <a class="btn btn-link" href="/Admin/Users/EditUser/<%# Eval("UserID") %>">Edit</a>
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
                    <asp:DataPager ID="UserDataPager" class="btn-group pager-buttons" runat="server" PageSize="1" PagedControlID="UserList">
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
                </div>
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false"></asp:PlaceHolder>
                </div>
                <asp:ObjectDataSource ID="UserDataSource" runat="server" SelectMethod="GetUsers" SortParameterName="ColumnName" TypeName="HotelManagerReservationsPt3.Models.ListUser"></asp:ObjectDataSource>
            </section>
        </div>
    </div>

</asp:Content>
