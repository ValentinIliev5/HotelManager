<%@ Page Title="Rooms" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.Admin.Rooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ml-2"><%: Title %></h2>

    <div class="row">
        <div class="col-md-12">
            <section id="loginForm">
                <div>
                    <asp:ListView ID="RoomList"
                        DataKeyNames="ID"
                        runat="server"
                        DataSourceID="RoomDataSource">
                        <LayoutTemplate>
                            <table id="dataTable" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:LinkButton ID="SortByCapacity" runat="server" Text="Capacity" CommandArgument="Capacity" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByType" runat="server" Text="Type" CommandArgument="Type" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByAdultPrice" runat="server" Text="Adult Price" CommandArgument="AdultPrice" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByKidPrice" runat="server" Text="Kid Price" CommandArgument="KidPrice" CommandName="Sort" /></th>
                                        <th>
                                            <asp:LinkButton ID="SortByNumber" runat="server" Text="Number" CommandArgument="Number" CommandName="Sort" /></th>
                                        <th>Delete</th>
                                        <th>Edit</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr id="itemPlaceholder" runat="server" />
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>Capacity</th>
                                        <th>Type</th>
                                        <th>Adult Price</th>
                                        <th>Kid Price</th>
                                        <th>Number</th>
                                        <th>Delete</th>
                                        <th>Edit</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Capacity" runat="server" Text='<%# Eval("Capacity")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Type" runat="server" Text='<%# Eval("Type")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="AdultPrice" runat="server" Text='<%# Eval("AdultPrice")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="KidPrice" runat="server" Text='<%# Eval("KidPrice")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Number" runat="server" Text='<%# Eval("Number")%>'></asp:Label>
                                </td>
                                <td>
                                    <a class="btn btn-info" href="../Admin/Rooms/EditRoom/<%# Eval("ID") %>">Edit</a>
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
                    <asp:DataPager ID="RoomDataPager" class="btn-group pager-buttons" runat="server" PageSize="1" PagedControlID="RoomList">
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
                    <a class="btn btn-success pull-right" href="../Admin/Rooms/AddRoom">Add Room</a>
                </div>
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false"></asp:PlaceHolder>
                </div>
                <asp:ObjectDataSource ID="RoomDataSource" runat="server" SelectMethod="GetRooms" SortParameterName="ColumnName" TypeName="HotelManagerReservationsPt3.Models.ListRoom"></asp:ObjectDataSource>
            </section>
        </div>
    </div>

</asp:Content>
