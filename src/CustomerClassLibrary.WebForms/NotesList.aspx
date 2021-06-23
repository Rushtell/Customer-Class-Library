<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotesList.aspx.cs" Inherits="CustomerClassLibrary.WebForms.NotesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <a class="btn btn-primary" href="NotesEdit?customerId=<%= customerId %>">Add</a>
    <br />
    <br />
    <table class="table">
        <% foreach (var note in listNotes) { %>

            <tr>
                <td>
                    <%= note.NoteId %>
                </td>
                <td>
                    <%= note.Text %>
                </td>
                <td>
                    <a href="NotesEdit?noteId=<%= note.NoteId %>&customerId=<%= customerId %>" class="btn btn-primary">Change</a>
                </td>
                <td>
                    <a href="NotesList?page=<%= pageNum %>&customerId=<%= customerId %>&noteId=<%= note.NoteId %>" class="btn btn-danger">Delete</a>
                </td>
            </tr>

        <% } %>
    </table>
    <div>
        <% if(pageNum != 1)
           {
                %><a class="btn btn-primary" href="NotesList?page=<%= pageNum - 1 %>&customerId=<%= customerId %>">Back</a><%
           }
        %>
            &nbsp&nbsp
        <% if((pageNum * 15) < notesCount)
           {
                %><a class="btn btn-primary" href="NotesList?page=<%= pageNum + 1 %>&customerId=<%= customerId %>">Next</a><%
           }
        %>
    </div>

</asp:Content>
