<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="PS.WebForm.Autos.List"
    MasterPageFile="~/Site.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <asp:HiddenField ID="manufacturerIdHiddenField" runat="server" />

    <h1><asp:Label ID="manufacturerNameLabel" runat="server" /></h1>

    <asp:Repeater ID="autosRepeater" runat="server">
        <HeaderTemplate><ul></HeaderTemplate>

        <ItemTemplate>
            <li>
                <a href='Detail.aspx?id=<%# Eval("Id") %>'><%# Eval("Name") %> <%# Eval("Model") %> </a>
            </li>    
        </ItemTemplate>

        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>


    
</asp:Content>