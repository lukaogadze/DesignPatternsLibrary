<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="PS.WebForm._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <h1><%: ViewModel.Title %></h1>
    <asp:HiddenField ID="sortedHiddenField" runat="server" />
    
    
    <asp:Repeater ID="manufacturersRepeater" runat="server">
    
    <HeaderTemplate>
        <table>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="nameSort" runat="server" Text="Name" OnClick="Sort_Click" />
            </td>
        </tr>
    </HeaderTemplate>
    
    <ItemTemplate>
        <tr>
            <td> 
            <a href='<%# "~/Autos/List.aspx?m=" + Eval("Id") %>' runat="server">view autos</a></td>
            <td><%# Eval("Name") %></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate> </table> </FooterTemplate>
    </asp:Repeater>
</asp:Content>
