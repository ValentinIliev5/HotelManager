<%@ Page Title="Room" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRoom.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.Admin.AddRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>Add a room</h2>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Capacity" CssClass="col-md-2 control-label">Capacity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Capacity" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Capacity"
                    CssClass="text-danger" ErrorMessage="The Capacity field is required." Display="Dynamic" />
                <asp:RangeValidator
                    ControlToValidate="Capacity"
                    MinimumValue="1"
                    MaximumValue="3"
                    Type="Integer"
                    Text="Must be a number between 1 and 3"
                    runat="server"
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Type" CssClass="col-md-2 control-label">Type</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Type" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Type"
                    CssClass="text-danger" ErrorMessage="The Type field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AdultPrice" CssClass="col-md-2 control-label">Adult Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AdultPrice" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AdultPrice"
                    CssClass="text-danger" ErrorMessage="The Adult Price field is required." Display="Dynamic" />
                <asp:RangeValidator
                    ControlToValidate="AdultPrice"
                    MinimumValue="1"
                    MaximumValue="5000"
                    Type="Double"
                    Text="Must be a number"
                    runat="server"
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="KidPrice" CssClass="col-md-2 control-label">Kid Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="KidPrice" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="KidPrice"
                    CssClass="text-danger" ErrorMessage="The Kid Price field is required." Display="Dynamic" />
                <asp:RangeValidator
                    ControlToValidate="KidPrice"
                    MinimumValue="1"
                    MaximumValue="5000"
                    Type="Double"
                    Text="Must be a number"
                    runat="server"
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Number" CssClass="col-md-2 control-label">Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Number" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Number"
                    CssClass="text-danger" ErrorMessage="The Number field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="AddRoomButton" OnClick="AddRoomButton_Click" Text="Add Room" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
