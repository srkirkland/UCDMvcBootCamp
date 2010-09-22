<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.List<UCDMvcBootCamp.Models.AttendeeListModel>>" %>

<table>
    <thead>
        <tr>
            <td>First Name</td>
            <td>Last Name</td>
            <td>Email</td>
        </tr>
    </thead>
    <tbody>
        <% foreach (var attendee in Model) { %>
    
            <tr>
                <td><%: attendee.FirstName %></td>
                <td><%: attendee.LastName %></td>
                <td><%: attendee.Email %></td>
            </tr>

        <% } %>
    </tbody>
</table>
