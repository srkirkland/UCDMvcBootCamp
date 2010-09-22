<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<UCDMvcBootCamp.Models.ConferenceListModel>>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Conferences</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h2>Showing Conferences</h2>
    <h3><%: Html.ActionLink("View list in xml", "Xml", "ConferenceXml") %></h3>

    <% using (Html.BeginForm("Index", "Conference", FormMethod.Get)) { %>
        Filter by Min Sessions: <%: Html.TextBox("minSessions") %>
        <input type="submit" value="Filter!" />
    <% } %>
    
    <br />

    <table>
        <thead>
            <tr>
                <td></td>
                <td>Name</td>
                <td>Attendee Count</td>
                <td>Session Count</td>
            </tr>
        </thead>
        <tbody>
            <% foreach (var conference in Model) { %>
                
                <tr>
                    <td>
                        <%: Html.ActionLink("Edit", "Edit", new { confname = conference.Name }) %> | 
                        <%: Html.ActionLink("Show", "Show", new { confname = conference.Name }) %>
                    </td>
                    <td><%: conference.Name %></td>
                    <td><%: conference.AttendeeCount %></td>
                    <td><%: conference.SessionCount %></td>
                </tr>        

            <% } %>
        </tbody>
    </table>

</asp:Content>
