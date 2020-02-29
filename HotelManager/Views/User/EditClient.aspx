<%@ Page Title="Edit Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditClient.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.User.EditClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>Edit a client</h2>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="MiddleName" CssClass="col-md-2 control-label">Middle Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="MiddleName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MiddleName"
                    CssClass="text-danger" ErrorMessage="The Middle Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="The Last Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Phone" CssClass="col-md-2 control-label">Phone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Phone" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone"
                    CssClass="text-danger" ErrorMessage="The phone field is required." />
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Phone" ID="PhoneRegEx" ValidationExpression="^[0-9]{10}$" runat="server" ErrorMessage="Must be 10 characters long." CssClass="text-danger"></asp:RegularExpressionValidator>

            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="IsAdult" CssClass="col-md-2 control-label">Adult</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="IsAdult" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="EditCurrentClient" runat="server" OnClick="EditCurrentClient_Click" Text="Edit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
