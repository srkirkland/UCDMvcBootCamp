<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<UCDMvcBootCamp.Core.Domain.Conference>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Editing Conference <%: Model.Name %></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h2>Editing Conference <%: Model.Name %></h2>

    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.HiddenFor(x=>x.Id) %>

        Conference Name: <%: Html.TextBoxFor(x=>x.Name) %>

        <br /><br />
        <table>
            <thead>
                <tr>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Email</td>
                </tr>
            </thead>
            <tbody>
                <% for (int i = 0; i < Model.Attendees.Count; i++) { %>
                    
                    <% var count = i; %>
                    <tr>
                        <td>
                            <%= Html.HiddenFor(m => m.Attendees[count].Id) %>
                            <%= Html.TextBoxFor(m => m.Attendees[count].FirstName)%>
                        </td>
                        <td><%= Html.TextBoxFor(m => m.Attendees[count].LastName)%></td>
                        <td><%= Html.TextBoxFor(m => m.Attendees[count].Email)%></td>
                    </tr>

                <% } %>
            </tbody>
        </table>

        <input type="submit" value="Edit!" />
    
    <% } %>

</asp:Content>
