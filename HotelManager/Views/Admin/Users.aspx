<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ml-2"><%: Title %></h2>

    <div class="row">
        <div class="col-md-12">
            <section id="loginForm">
                <div>
                    <asp:ListView ID="UserList"
                        DataKeyNames="UserID"
                        runat="server">
                        <LayoutTemplate>
                            <table id="dataTable" class="table table-striped table-bordered">
                                <thead>
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
                                    <a class="btn btn-link" href="Edit">Edit</a>
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
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false"></asp:PlaceHolder>
                </div>
            </section>
        </div>
    </div>

</asp:Content>
