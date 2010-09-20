<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<UCDMvcBootCamp.Core.Domain.Conference>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Editing Conference <%: Model.Name %></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <h2>Editing Conference <%: Model.Name %></h2>

    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
    
        Conference Name: <%: Html.TextBoxFor(x=>x.Name) %>

        <input type="submit" value="Edit!" />
    
    <% } %>

</asp:Content>
