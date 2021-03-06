﻿<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="HotelManagerReservationsPt3.Views.Admin.EditUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Edit this user</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                    CssClass="text-danger" ErrorMessage="The username field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
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
            <asp:Label runat="server" AssociatedControlID="EGN" CssClass="col-md-2 control-label">EGN</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EGN" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="EGN"
                    CssClass="text-danger" ErrorMessage="The EGN field is required." Display="Dynamic" />
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="EGN" ID="EGNRegEx" ValidationExpression="^[0-9]{10}$" runat="server" ErrorMessage="Must be 10 characters long." CssClass="text-danger"></asp:RegularExpressionValidator>
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Phone" CssClass="col-md-2 control-label">Phone</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Phone" CssClass="form-control" MaxLength="10" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone"
                    CssClass="text-danger" ErrorMessage="The Phone field is required." Display="Dynamic" />
                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="Phone" ID="PhoneRegEx" ValidationExpression="^[0-9]{10}$" runat="server" ErrorMessage="Must be 10 characters long." CssClass="text-danger"></asp:RegularExpressionValidator>
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AdminCheckBox" CssClass="col-md-2 control-label">Admin</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox ID="AdminCheckBox" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="EditButton" OnClick="EditButton_Click" Text="Edit" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
