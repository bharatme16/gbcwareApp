<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="adjusterOverdueClaims.aspx.vb" Inherits="crossCountry_responsive.adjusterOverdueClaims" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel panel-default">

<div class="container">
<h4 class="lead"> <strong>Overdue Claims: </strong> <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label></h4>
</div>

<div class="panel-body">
<asp:GridView ID="gdFiles" runat="server" Width="100%" CssClass="table table-hover table-striped" GridLines="None"  
AllowPaging="true" pagesize="50" DataKeyNames="Claim ID" ShowHeaderWhenEmpty="true"  
AutoGenerateColumns="false" AllowSorting="true" OnSorting="sortRecords" EmptyDataText="There are no claims to display"> 
<Columns>

<asp:BoundField DataField="Claim ID" HeaderText="Claim ID" ReadOnly="True" SortExpression="Claim ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"/> 
<asp:hyperLinkField DataTextField="Claim #" HeaderText="Claim #" SortExpression="Claim #" DataNavigateUrlFields="Claim ID" DataNavigateUrlFormatString="/Admin/claimDetail.aspx?claimId={0}" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"  /> 
<asp:BoundField DataField="Insured Name" HeaderText="Insured" ReadOnly="True" SortExpression="Insured Name"/> 
<asp:BoundField DataField="Carrier" HeaderText="Carrier" ReadOnly="True" SortExpression="Carrier" HeaderStyle-CssClass="visible-lg visible-md visible-sm visible-xs" ItemStyle-CssClass="visible-lg visible-md visible-sm visible-xs"  /> 
<asp:BoundField DataField="Claim Contact" HeaderText="Claim Contact" ReadOnly="True" SortExpression="Claim Contact" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md" /> 
<asp:BoundField DataField="Loss Type" HeaderText="Loss Type" ReadOnly="True" SortExpression="Loss Type" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg"  /> 
 
<asp:BoundField DataField="Received Date" HeaderText="Received Date" ReadOnly="True" SortExpression="Received Date" HeaderStyle-CssClass="visible-md visible-lg visible-sm visible-xs" ItemStyle-CssClass="visible-md visible-lg visible-sm visible-xs"/> 
<asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" HeaderStyle-CssClass="visible-lg visible-md" ItemStyle-CssClass="visible-lg visible-md"/> 
       
</Columns>

</asp:GridView>


</div>

</div>

</asp:Content>
