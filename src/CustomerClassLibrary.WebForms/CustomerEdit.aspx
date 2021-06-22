<%@ Page Title="CustomerEdit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <asp:Label runat="server" Text="First Name"></asp:Label>
        <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Phone Number"></asp:Label>
        <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Money"></asp:Label>
        <asp:TextBox ID="money" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />
</asp:Content>
