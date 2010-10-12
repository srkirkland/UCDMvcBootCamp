<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<UCDMvcBootCamp.Models.VerificationModel>" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent">Verification</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th>Operation</th>
            <th>Expected #</th>
            <th>Actual #</th>
            <th>Verified</th>
        </tr>
        <tr>
            <td>Initial Conference Count</td>
            <td><%: Model.ExpectedInitialConferenceCount %></td>
            <td><%: Model.InitialConferenceCount %></td>
            <td><%: Model.VerifyInitialConferenceCount %></td>
        </tr>
        <tr>
            <td>Create new conference</td>
            <td><%: Model.ExpectedNewConferenceCount %></td>
            <td><%: Model.NewConferenceCount %></td>
            <td><%: Model.VerifyNewConferenceCount %></td>
        </tr>
        <tr>
            <td>Remove a conference</td>
            <td><%: Model.ExpectedRemovedConferenceCount %></td>
            <td><%: Model.RemovedConferenceCount %></td>
            <td><%: Model.VerifyRemovedConferenceCount %></td>
        </tr>
    </table>
    <br />
    <br />
    
    <h2><%: Model.Verify() ? "Verification Successfull!" : "Oh no, something went wrong" %></h2>
    <br />
    <br />
    <%: Html.ActionLink("Go Home", "Index") %>

</asp:Content>
