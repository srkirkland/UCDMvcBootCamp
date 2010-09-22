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
    <br />
    <br />
    <input type="button" id="show-attendees" value="Show Attendees" />
    <p id="attendees"></p>


</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="AdditionalScripts" runat="server">

<% if (false) { %>
    <script src="../../Scripts/jquery-1.4.1-vsdoc.js" type="text/javascript"></script>
<% } %>

<script language="javascript" type="text/javascript">

    $(function () {
        $('#show-attendees').click(function () {

            var url = '<%= Url.Action("Show", "Attendee", new { confname = Model.Name }) %>';

            // Keep a reference to the show attendees button for later
            var button = $(this);

            var callback = function (data, textStatus) {

                // Place HTML returned from AJAX inside special p tag below
                $('#attendees').html(data);

                // Hide the show attendees button
                button.hide();
            };

            // Issue an AJAX GET, to return HTML (and not JSON)
            $.get(url, null, callback, 'html');
        });
    });

</script>

</asp:Content>