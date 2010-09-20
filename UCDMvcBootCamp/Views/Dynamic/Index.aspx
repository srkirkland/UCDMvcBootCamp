<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Dynamic Page</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h3>You sent in <%: ViewData["text"] ?? "No text" %>
    </h3>

    <% using (Html.BeginForm("GoTo", "Dynamic")) { %>
        <%: Html.AntiForgeryToken() %>

        <%: Html.TextBox("gotoUrl") %>
        
        <input type="submit" name="submit" value="Go!" />

    <% } %>

</asp:Content> 
