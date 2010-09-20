<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<UCDMvcBootCamp.Models.ConferenceListModel>>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Conferences</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h2>Showing Conferences</h2>

    <table>
        <thead>
            <tr>
                <td>Name</td>
                <td>Attendee Count</td>
                <td>Session Count</td>
            </tr>
        </thead>
        <tbody>
            <% foreach (var conference in Model) { %>
                
                <tr>
                    <td><%: conference.Name %></td>
                    <td><%: conference.AttendeeCount %></td>
                    <td><%: conference.SessionCount %></td>
                </tr>        

            <% } %>
        </tbody>
    </table>

</asp:Content>
