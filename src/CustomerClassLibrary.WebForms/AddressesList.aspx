<%@ Page Title="Addresses List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressesList.aspx.cs" Inherits="CustomerClassLibrary.WebForms.AddressesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <a class="btn btn-primary" href="AddressesEdit?customerId=<%= customerId %>">Add</a>
    <br />
    <br />
    <table class="table">
        <% foreach (var address in listAddresses) { %>

            <tr>
                <td>
                    <%= address.AddressId %>
                </td>
                <td>
                    <%= address.AddressLine %>
                </td>
                <td>
                    <%= address.SecondAddressLine %>
                </td>
                <td>
                    <%= address.AddressType %>
                </td>
                <td>
                    <%= address.PostalCode %>
                </td>
                <td>
                    <%= address.City %>
                </td>
                <td>
                    <%= address.State %>
                </td>
                <td>
                    <%= address.Country %>
                </td>
                <td>
                    <a href="AddressesEdit?addressId=<%= address.AddressId %>&customerId=<%= customerId %>" class="btn btn-primary">Change</a>
                </td>
                <td>
                    <a href="AddressesList?page=<%= pageNum %>&customerId=<%= customerId %>&addressId=<%= address.AddressId %>" class="btn btn-danger">Delete</a>
                </td>
            </tr>

        <% } %>
    </table>
    <div>
        <% if(pageNum != 1)
           {
                %><a class="btn btn-primary" href="AddressesList?page=<%= pageNum - 1 %>&customerId=<%= customerId %>">Back</a><%
           }
        %>
            &nbsp&nbsp
        <% if((pageNum * 15) < addressesCount)
           {
                %><a class="btn btn-primary" href="AddressesList?page=<%= pageNum + 1 %>&customerId=<%= customerId %>">Next</a><%
           }
        %>
    </div>

</asp:Content>
