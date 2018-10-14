<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<EmployeeDomain.Employee>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <% using (Html.BeginForm("Index", "Employee", FormMethod.Get)) { %>
        <input type="text" name="q" /> <input type="submit" value="Search" />
    <% }%>

    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                Name
            </th>
            <th>
                HireDate
            </th>
            <th>
                Total Time Cards
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%: Html.ActionLink("Details", "Details", new { id = item.Id })%> |               
            </td>
            <td>
                <%: item.Id %>
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.HireDate.ToShortDateString() %>
            </td>
            <td>
                <%: item.TimeCards.Count %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

