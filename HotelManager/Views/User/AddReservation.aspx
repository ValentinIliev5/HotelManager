<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReservation.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.User.AddReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>Create new reservation</h2>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="RoomList" CssClass="col-md-2 control-label">Rooms</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="RoomList" CssClass="form-control" />
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ClientsList" CssClass="col-md-2 control-label">Clients</asp:Label>
            <div class="col-md-3">
                <asp:ListBox SelectionMode="Multiple" runat="server" ID="ClientsList" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ClientsList"
                    CssClass="text-danger" ErrorMessage="The Clients field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ArrivalDate" CssClass="col-md-2 control-label">Arrival Date</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="ArrivalDate" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="DeparatureDate" CssClass="col-md-2 control-label">Deparature Date</asp:Label>
            <div class="col-md-10">
                <asp:Calendar ID="DeparatureDate" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="HasBreakfast" CssClass="col-md-2 control-label">Breakfast</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="HasBreakfast" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="IsAllInclusive" CssClass="col-md-2 control-label">All Inclusive</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="IsAllInclusive" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="AddReservation_Click" Text="Add" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
