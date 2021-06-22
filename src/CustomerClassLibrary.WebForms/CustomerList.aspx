<%@ Page Title="CustomersList" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="CustomerClassLibrary.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <a class="btn btn-primary" href="CustomerEdit">Add</a>
    <br />
    <br />
    <table class="table">
        <% foreach (var customer in listCustomers) { %>

            <tr>
                <td>
                    <%= customer.CustomerId %>
                </td>
                <td>
                    <%= customer.FirstName %>
                </td>
                <td>
                    <%= customer.LastName %>
                </td>
                <td>
                    <a href="AddressesList?page=1&customerId=<%= customer.CustomerId %>">Addresses</a>
                </td>
                <td>
                    <%= customer.Email %>
                </td>
                <td>
                    <%= customer.Money %>
                </td>
                <td>
                    <%= customer.PhoneNumber %>
                </td>
                <td>
                    <a>Notes</a>
                </td>
                <td>
                    <a href="CustomerEdit?customerId=<%= customer.CustomerId %>" class="btn btn-primary">Change</a>
                </td>
                <td>
                    <a href="CustomerList?customerId=<%= customer.CustomerId %>&page=<%= pageNum %>" class="btn btn-danger">Delete</a>
                </td>
            </tr>

        <% } %>
    </table>
    <div class="row">
        <div>
        <% if(pageNum != 1)
           {
                %><a class="btn btn-primary" href="CustomerList?page=<%= pageNum - 1 %>">Back</a><%
           }
        %>
            &nbsp&nbsp
        <% if((pageNum * 15) < customersCount)
           {
                %><a class="btn btn-primary" href="CustomerList?page=<%= pageNum + 1 %>">Next</a><%
           }
        %>
    </div>
    
</asp:Content>
