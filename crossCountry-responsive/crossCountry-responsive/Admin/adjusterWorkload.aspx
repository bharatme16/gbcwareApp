<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="adjusterWorkload.aspx.vb" Inherits="crossCountry_responsive.adjusterWorkload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

<asp:GridView ID="gridAdjusterWorkload" runat="server" Width="100%" CssClass="table table-hover table-striped" 
    GridLines="None" AllowSorting="True" OnSorting="sortRecords" AutoGenerateColumns="False" 
ShowHeaderWhenEmpty="True" >
<Columns>
<asp:BoundField DataField="ID" HeaderText="User Id" SortExpression="ID"/>
<asp:BoundField DataField="adjuster" HeaderText="Adjuster" SortExpression="adjuster" />
<asp:BoundField DataField="assigned_claims" HeaderText="# of open Assigned Claims" SortExpression="assigned_claims"/>
<asp:BoundField DataField="overdue_claims" HeaderText="# of open Overdue Claims" SortExpression="overdue_claims" />
<asp:BoundField DataField="average_days" HeaderText="Average days open" SortExpression="average_days" />
</Columns>

</asp:GridView>

    </div>
</asp:Content>
