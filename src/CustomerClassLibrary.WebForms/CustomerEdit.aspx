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


    <%if (customerIdReq == null)
      {
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


                    <div class="form-group">
                        <asp:Label runat="server" Text="Note Text"></asp:Label>
                        <asp:TextBox ID="noteText" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
            <%   
      } %>

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />
</asp:Content>
