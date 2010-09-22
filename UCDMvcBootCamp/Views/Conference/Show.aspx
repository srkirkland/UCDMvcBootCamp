<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<UCDMvcBootCamp.Models.ConferenceShowModel>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Showing <%: Model.Name %></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Showing Details for <%: Model.Name %></h2>

    <%: Html.ActionLink("To Register Click Here!", "Register") %>
    <br />
    <br />
    Sessions:
    <br />
    <br />
    <ul>
        <% foreach (var session in Model.Sessions) { %>
            <li><%: session.Title %> by <strong><%: session.SpeakerFirstName %> <%: session.SpeakerLastName %></strong></li>
        <% } %>
    </ul>


</asp:Content>
