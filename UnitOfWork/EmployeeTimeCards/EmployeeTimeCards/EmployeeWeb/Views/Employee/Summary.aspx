<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<EmployeeWeb.Models.EmployeeSummaryViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Summary
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Summary</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <div class="display-label">TotalTimeCards</div>
        <div class="display-field"><%: Model.TotalTimeCards %></div>
        
    </fieldset>
    <p>        
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

