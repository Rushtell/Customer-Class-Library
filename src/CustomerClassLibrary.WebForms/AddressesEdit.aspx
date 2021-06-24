<%@ Page Title="Addresses Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesEdit.aspx.cs" Inherits="CustomerClassLibrary.WebForms.AddressesEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%
        if(errorReq != null)
        {
            if (addressIdReq != null)
            {%>
                    <h3 class="text-danger">Error to change address, wrong data</h3>
                <%}
                    else
                    {%>
                    <h3 class="text-danger">Error to create address, wrong data</h3>
                <%}
                    }
    %>

    <div class="form-group">
        <asp:Label runat="server" Text="Address Line"></asp:Label>
        <asp:TextBox ID="addressLine" CssClass="form-control" runat="server"></asp:TextBox>
    </div>    
    
    <div class="form-group">
        <asp:Label runat="server" Text="Second Address Line"></asp:Label>
        <asp:TextBox ID="secondAddressLine" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Postal Code"></asp:Label>
        <asp:TextBox ID="postalCode" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Address Type"></asp:Label>
        <asp:TextBox ID="addressType" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="State"></asp:Label>
        <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="Country"></asp:Label>
        <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />

</asp:Content>
