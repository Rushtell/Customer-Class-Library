<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotesEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.NotesEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label runat="server" Text="Note Text"></asp:Label>
        <asp:TextBox ID="noteText" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />

</asp:Content>
