<%@ Page Title="Reservations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservations.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.User.Reservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ml-2"><%: Title %></h2>

    <div class="row">
        <div class="col-md-12">
            <section id="loginForm">
                <div>
                    <asp:ListView ID="ReservationList"
                        DataKeyNames="ID"
                        runat="server"
                        DataSourceID="ReservationDataSource">
                        <LayoutTemplate>
                            <table id="dataTable" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th><asp:LinkButton ID="SortByRoomNumber" runat="server" Text="Room Number" CommandArgument="RoomNumber" CommandName="Sort" /></th>
                                        <th><asp:LinkButton ID="SortByUserUsername" runat="server" Text="Username" CommandArgument="UserUsername" CommandName="Sort" /></th>
                                        <th><asp:LinkButton ID="SortByClients" runat="server" Text="Clients" CommandArgument="Clients" CommandName="Sort" /></th>
                                        <th><asp:LinkButton ID="SortByArrivalDate" runat="server" Text="ArrivalDate" CommandArgument="ArrivalDate" CommandName="Sort" /></th>
                                        <th><asp:LinkButton ID="SortByDeparatureDate" runat="server" Text="DeparatureDate" CommandArgument="DeparatureDate" CommandName="Sort" /></th>
                                        <th>Has Breakfast</th>
                                        <th>Is AllInclusive</th>
                                        <th><asp:LinkButton ID="SortByPrice" runat="server" Text="Price" CommandArgument="Price" CommandName="Sort" /></th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server" />
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>RoomNumber</th>
                                        <th>Username</th>
                                        <th>Clients</th>
                                        <th>ArrivalDate</th>
                                        <th>DeparatureDate</th>
                                        <th>Has Breakfast</th>
                                        <th>Is AllInclusive</th>
                                        <th>Price</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="RoomNumber" runat="server" Text='<%# Eval("RoomNumber")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="UserUsername" runat="server" Text='<%# Eval("UserUsername")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Clients" runat="server" Text='<%# Eval("Clients")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="ArrivalDate" runat="server" Text='<%# Eval("ArrivalDate")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="DeparatureDate" runat="server" Text='<%# Eval("DeparatureDate")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="HasBreakfastCheckBox" runat="server" Enabled="false" Checked='<%# Eval("HasBreakfast").ToString() == "1"%>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="IsAllInclusive" runat="server" Enabled="false" Checked='<%# Eval("IsAllInclusive").ToString() == "1"%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Price" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                </td>
                                <td>
                                    <a class="btn btn-info" href="../User/Reservations/EditReservation/<%# Eval("ID") %>">Edit</a>
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
                    <asp:DataPager ID="ReservationDataPager" class="btn-group pager-buttons" runat="server" PageSize="1" PagedControlID="ReservationList">
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
                    <a class="btn btn-success pull-right" href="../User/Reservations/AddReservation">Add Reservation</a>
                </div>
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false"></asp:PlaceHolder>
                </div>
                <asp:ObjectDataSource ID="ReservationDataSource" runat="server" SelectMethod="GetReservations" SortParameterName="ColumnName" TypeName="HotelManagerReservationsPt3.Models.ListReservation"></asp:ObjectDataSource>
            </section>
        </div>
    </div>
</asp:Content>
