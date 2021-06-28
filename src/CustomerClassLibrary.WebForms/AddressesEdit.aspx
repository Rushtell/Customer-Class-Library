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

    <asp:RegularExpressionValidator id="RegularExpressionValidatorAddressLine" 
                        ControlToValidate="addressLine"
                        ValidationExpression=".{1,100}"
                        Display="Static"
                        ErrorMessage="AddressLine is incorrect"
                        EnableClientScript="False" 
                        runat="server"/>

    <asp:RequiredFieldValidator id="RequiredFieldValidatorAddressLine"
                ControlToValidate="addressLine"
                Display="Static"
                ErrorMessage="AddressLine is incorrect"
                runat="server"/>
    
    <div class="form-group">
        <asp:Label runat="server" Text="Second Address Line"></asp:Label>
        <asp:TextBox ID="secondAddressLine" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:RegularExpressionValidator id="RegularExpressionValidatorSecondAddressLine" 
                        ControlToValidate="secondAddressLine"
                        ValidationExpression=".{1,100}"
                        Display="Static"
                        ErrorMessage="SecondAddressLine is incorrect"
                        EnableClientScript="False" 
                        runat="server"/>

    <asp:RequiredFieldValidator id="RequiredFieldValidatorSecondAddressLine"
                ControlToValidate="secondAddressLine"
                Display="Static"
                ErrorMessage="SecondAddressLine is incorrect"
                runat="server"/>

    <div class="form-group">
        <asp:Label runat="server" Text="Postal Code"></asp:Label>
        <asp:TextBox ID="postalCode" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:RegularExpressionValidator id="RegularExpressionValidatorPostalCode" 
                    ControlToValidate="postalCode"
                    ValidationExpression="\d{1,6}"
                    Display="Static"
                    ErrorMessage="PostalCode is incorrect"
                    EnableClientScript="False" 
                    runat="server"/>

    <asp:RequiredFieldValidator id="RequiredFieldValidatorPostalCode"
                ControlToValidate="postalCode"
                Display="Static"
                ErrorMessage="PostalCode is incorrect"
                runat="server"/>

    <div class="form-group">
        <asp:Label runat="server" Text="Address Type"></asp:Label>
        <select ID="addressType" class="form-control" runat="server">
            <option ID="op1">Billing</option>
            <option ID="op2">Shipping</option>
        </select>
    </div>

    <div class="form-group">
        <asp:Label runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:RegularExpressionValidator id="RegularExpressionValidatorCity" 
                ControlToValidate="city"
                ValidationExpression="[a-zA-Z]{1,50}"
                Display="Static"
                ErrorMessage="City is incorrect"
                EnableClientScript="False" 
                runat="server"/>

        <asp:RequiredFieldValidator id="RequiredFieldValidatorCity"
                ControlToValidate="city"
                Display="Static"
                ErrorMessage="City is incorrect"
                runat="server"/>

    <div class="form-group">
        <asp:Label runat="server" Text="State"></asp:Label>
        <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:RegularExpressionValidator id="RegularExpressionValidatorState" 
                ControlToValidate="state"
                ValidationExpression="[a-zA-Z]{1,20}"
                Display="Static"
                ErrorMessage="State is incorrect"
                EnableClientScript="False" 
                runat="server"/>

        <asp:RequiredFieldValidator id="RequiredFieldValidatorState"
                ControlToValidate="state"
                Display="Static"
                ErrorMessage="State is incorrect"
                runat="server"/>

    <div class="form-group">
        <asp:Label runat="server" Text="Country"></asp:Label>
        <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:RegularExpressionValidator id="RegularExpressionValidatorCountry" 
                ControlToValidate="country"
                ValidationExpression="[a-zA-Z]{1,50}"
                Display="Static"
                ErrorMessage="Country is incorrect"
                EnableClientScript="False" 
                runat="server"/>

    <asp:RequiredFieldValidator id="RequiredFieldValidatorCountry"
                ControlToValidate="country"
                Display="Static"
                ErrorMessage="Country is incorrect"
                runat="server"/> 

    <asp:Button runat="server" CssClass="btn btn-primary" 
                OnClick="OnSaveClick" 
                Text="Save" />

</asp:Content>
