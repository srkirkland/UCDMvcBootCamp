<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<UCDMvcBootCamp.Models.AttendeeEditModel>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Register for <%: Model.ConferenceName %></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <h2>Register for <%: Model.ConferenceName %></h2>
    
    <%: Html.ValidationSummary() %>
    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>

        <%: Html.EditorForModel() %>

        <input type="submit" value="Register!" />

    <% } %>

</asp:Content>
