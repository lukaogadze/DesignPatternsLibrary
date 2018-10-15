<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<EmployeeDomain.Employee>" %>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Name</div>
        <div class="display-field"><%: Model.Name %></div>
        
        <div class="display-label">Hire Date</div>
        <div class="display-field"><%: Model.HireDate.ToShortDateString() %></div>

        <div class="display-label">Total Time Cards</div>
        <div class="display-field"><%: Model.TimeCards.Count() %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id  }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>


